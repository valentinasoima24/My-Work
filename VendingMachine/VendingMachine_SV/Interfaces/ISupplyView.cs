using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    internal interface ISupplyView
    {
        public int RequestProductId();
        public string RequestProductName();
        public decimal RequestProductPrice();
        public int RequestProductQuantity();
    }
}
