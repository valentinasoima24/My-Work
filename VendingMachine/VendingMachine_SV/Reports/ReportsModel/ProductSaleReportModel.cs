namespace iQuest.VendingMachine.Reports.ReportsModel
{
    internal class ProductSaleReportModel
    {
        public TimeInterval TimeInterval { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
