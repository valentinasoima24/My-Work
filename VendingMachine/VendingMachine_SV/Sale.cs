using System;

namespace iQuest.VendingMachine
{
    internal class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string PaymentType { get; set; }

        public Sale()
        {
        }

        public Sale(int id, DateTime date, string productName, decimal price, string paymentType)
        {
            Id = id;
            Date = date;
            ProductName = productName;
            Price = price;
            PaymentType = paymentType;
        }
    }
}
