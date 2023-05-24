using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.ProductSpecifications
{
    internal class InvalidCardNumberException :Exception
    {
        private const string Message = "Invalid card number: {0}";

        public InvalidCardNumberException(string cardNumber)
            : base(string.Format(Message, cardNumber))
        {
        }
    }
}
