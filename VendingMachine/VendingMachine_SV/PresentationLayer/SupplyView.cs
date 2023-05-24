using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.PresentationLayer
{
    internal class SupplyView :DisplayBase, ISupplyView
    {
        public int RequestProductId()
        {
            Console.WriteLine();
            Display("Insert product Id:", ConsoleColor.Blue);

            string columnId=Console.ReadLine();

            if (string.IsNullOrEmpty(columnId))
            {
                throw new CancelException();
            }

            return Convert.ToInt32(columnId);
        }


        public string RequestProductName()
        {
            Console.WriteLine();
            Display("Insert product name:", ConsoleColor.Blue);

            string name= Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                throw new CancelException();
            }
            return name;
        }

        public decimal RequestProductPrice()
        {
            Console.WriteLine();
            Display("Insert product price:", ConsoleColor.Blue);

            string price = Console.ReadLine();

            if (string.IsNullOrEmpty(price))
            {
                throw new CancelException();
            }
            return Convert.ToDecimal(price);
        }

        public int RequestProductQuantity()
        {
            Console.WriteLine();
            Display("Insert product quantity:", ConsoleColor.Blue);

            string quantity = Console.ReadLine();

            if (string.IsNullOrEmpty(quantity))
            {
                throw new CancelException();
            }
            return Convert.ToInt32(quantity);
        }

    }
}
