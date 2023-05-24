using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;

namespace VendingMachine_SV.Payment
{
    internal class PaymentMethod : IPaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Run(decimal price) { }

    }
}
