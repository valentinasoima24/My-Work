using System;

namespace VendingMachine_SV.ProductSpecifications
{
    internal class CancelException : Exception
    {
        private const string DefaultMessage = "Please, try again if you want to buy a product.";

        public CancelException()
            : base(DefaultMessage)
        {
        }
    }
}