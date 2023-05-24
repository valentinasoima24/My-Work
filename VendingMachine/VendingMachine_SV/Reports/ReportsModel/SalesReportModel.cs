using System;

namespace iQuest.VendingMachine.Reports.ReportsModel
{
    internal class SalesReportModel
    {
        public DateTime Date { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string PaymentType { get; set; }
    }
}
