using System.Xml.Serialization;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.Reports
{
    internal class XmlReportSerializer : IReportSerializer
    {
        public void Serialize<T>(IEnumerable<T> serializableObject, string reportType)
        {
            string dateAndTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string path = File.ReadLines("reports_settings.txt").First();
            string fileNameInArchive = String.Format("{0}_{1}.xml", reportType, dateAndTime);
            string zipFile = String.Format("{0}{1}_{2}.zip", path, reportType, dateAndTime);

            using MemoryStream memoryStream = new MemoryStream();

            ZippedReportFileStream zippedReportFileStream = new ZippedReportFileStream(memoryStream);
            using StreamWriter streamWriter = zippedReportFileStream.CreateEntry(fileNameInArchive);

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(streamWriter, serializableObject.ToList());

            zippedReportFileStream.Zip(zipFile);
        }
    }
}
