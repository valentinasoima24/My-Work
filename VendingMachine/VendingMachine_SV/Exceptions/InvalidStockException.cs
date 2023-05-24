using System;

namespace VendingMachine_SV.ProductSpecifications
{
    internal class InvalidStockException : Exception
    {
        private const string DefaultMessage = "Product {0} is out of stock :(";

        public InvalidStockException(string ProductName)
            : base(String.Format(DefaultMessage, ProductName))
        {
        }
    }
}