using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine();

            bool hasProducts = HasProducts(products);

            if (hasProducts)
            {
                DisplayLine("The Shelf contains the following items:", ConsoleColor.White);

                foreach (Product product in products)
                    Console.WriteLine("{0} - {1} ({2} lei) - {3} pcs", product.ColumnId, product.Name, product.Price, product.Quantity);
            }
            else
            {
                DisplayLine("There are no products on the shelf.", ConsoleColor.Yellow);
            }
        }

        private static bool HasProducts(IEnumerable<Product> products)
        {
            if (products == null)
                return false;

            foreach (Product product in products)
                return true;

            return false;
        }
    }
}