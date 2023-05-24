using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    public interface IPaymentMethod
    {
        public int Id { get; }

        public string Name { get; }

        public void Run(decimal price);
    }
}
