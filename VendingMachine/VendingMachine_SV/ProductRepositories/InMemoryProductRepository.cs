using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Interfaces;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace iQuest.VendingMachine.DataAccess
{
    internal class InMemoryProductRepository : IProductRepository
    {
        private static readonly ICollection<Product> Products = new List<Product>
        {
            new Product
            {
                ColumnId = 1,
                Name = "Chocolate",
                Price = 9,
                Quantity = 20
            },
            new Product
            {
                ColumnId = 2,
                Name = "Chips",
                Price = 5,
                Quantity = 7
            },
            new Product
            {
                ColumnId = 3,
                Name = "Still Water",
                Price = 2,
                Quantity = 10
            },
            new Product
            {
                ColumnId = 4,
                Name = "Water",
                Price = 1,
                Quantity = 10
            }
        };

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            foreach (Product product in Products)
                list.Add(product);

            return list;
        }

        public Product GetByColumn(int columnId)
        {
            Product product = Products.SingleOrDefault(x => x.ColumnId == columnId);

            return product;
        }

        public Product AddProduct(Product product)
        {
            Products.Add(product);

            return product;
        }

        public Product UpdateProduct(Product product)
        {
            return product;
        }
    }
}
