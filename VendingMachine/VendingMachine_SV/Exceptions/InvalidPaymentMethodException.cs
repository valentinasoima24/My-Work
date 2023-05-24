using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.ProductSpecifications
{
    internal class InvalidPaymentMethodException :Exception
    {
        private const string Message = "The ID: {0} of payment methods is invalid.";

        public InvalidPaymentMethodException(decimal paymentId)
            : base(String.Format(Message, paymentId))
        {
        }
    }
}
