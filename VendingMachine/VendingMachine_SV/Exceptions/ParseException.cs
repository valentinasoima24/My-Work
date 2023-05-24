using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Exceptions
{
    internal class ParseException : Exception
    {
        private const string Message = "There has been a problem with the payment. The sum of money you added, {0}, will be returned to you shortly. ";

        public ParseException(string moneyIn)
            : base(String.Format(Message, moneyIn))
        {
        }
    }
}
