using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    internal interface ICashPayment
    {
        public decimal AskForMoney(decimal remainingPriceOfProduct);

        public void GiveBackChange(decimal change);
    }
}
