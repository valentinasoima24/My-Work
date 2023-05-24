using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Exceptions
{
    internal class InvalidPropertyValueException:Exception
    {
        private const string Message = "Invalid property value: {0}";

        public InvalidPropertyValueException(string value, string value2)
            : base(string.Format(Message, value,value2))
        {
        }
    }
}
