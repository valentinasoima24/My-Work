using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.Reports
{
    internal class JsonReportSerializer : IReportSerializer
    {
        public void Serialize<T>(IEnumerable<T> serializableObject, string reportType)
        {
            string dateAndTime = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
            string path = File.ReadLines("reports_settings.txt").Last();
            string file = String.Format("{0}{1}_{2}.json", path, reportType, dateAndTime);

            using FileStream stream = new FileStream(file, FileMode.Create);
            using StreamWriter streamWritter = new StreamWriter(stream, Encoding.UTF8);

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            serializer.Serialize(streamWritter, serializableObject);
        }
    }
}
