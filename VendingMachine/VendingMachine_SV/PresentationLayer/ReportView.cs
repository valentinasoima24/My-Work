using iQuest.VendingMachine.Interfaces;
using VendingMachine_SV.ProductSpecifications;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ReportView : DisplayBase, IReportView
    {
        public TimeInterval AskForStartAndEndDate()
        {
            int startDateYear = GetDateFromUser("start date year");
            int startDateMonth = GetDateFromUser("start date month");
            int startDateDay = GetDateFromUser("start date day");
            DateTime startDate = new DateTime(startDateYear, startDateMonth, startDateDay);

            int endDateYear = GetDateFromUser("end date year");
            int endDateMonth = GetDateFromUser("end date month");
            int endDateDay = GetDateFromUser("end date day");
            DateTime endDate = new DateTime(endDateYear, endDateMonth, endDateDay);

            return new TimeInterval(startDate, endDate);
        }

        private int GetDateFromUser(string typeOfDate)
        {
            Console.WriteLine();
            Display($"Type the {typeOfDate}: ", ConsoleColor.Cyan);
            var date = Console.ReadLine();

            if (string.IsNullOrEmpty(date))
            {
                throw new CancelException();
            }
            return Convert.ToInt32(date);
        }
    }
}
