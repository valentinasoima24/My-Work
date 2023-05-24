using System.Collections.Generic;
using Nagarro.VendingMachine;
using VendingMachine_SV.Models;

namespace VendingMachine_SV.Interfaces
{
    internal interface IProductRepository
    {
        public List<Product> GetAll();

        public Product GetByColumn(int columnId);

        public Product AddProduct(Product product);

        public Product UpdateProduct(Product product);
    }
}
