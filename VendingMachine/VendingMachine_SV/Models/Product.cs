using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;

namespace VendingMachine_SV.Models
{
    public class Product 
    {
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(int columnId, string name, decimal price, int quantity)
        {
            ColumnId = columnId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Product()
        {
            ColumnId = 0;
            Name = "";
            Price = 0;
            Quantity = 0;
        }

    }
}
