using System.Collections.Generic;
using Nagarro.VendingMachine;
using VendingMachine_SV.Models;

namespace VendingMachine_SV.Interfaces
{
    internal interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);
    }
}
