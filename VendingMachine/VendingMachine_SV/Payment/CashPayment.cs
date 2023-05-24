using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;
using VendingMachine_SV.PresentationLayer;

namespace VendingMachine_SV.Payment
{
    internal class CashPayment : IPaymentMethod
    {
        private readonly CashPaymentTerminal cashPayment;
       
        public int Id=>1;
        public string Name=>"Cash";

        public CashPayment(CashPaymentTerminal cashPaymentTerminal)
        {
            this.cashPayment = cashPaymentTerminal ?? throw new ArgumentNullException(nameof(cashPaymentTerminal));
        }

        public void Run(decimal price)
        {
            CashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();
           decimal cashIn=cashPaymentTerminal.AskForMoney(price);

            if (cashIn > price)
            {
               decimal changeReturned = cashIn - price;
               cashPaymentTerminal.GiveBackChange(changeReturned);
            }
            else if (cashIn < price)
            {
                cashPaymentTerminal.AskForMoney(price - cashIn);
            }
        }
    }
}
