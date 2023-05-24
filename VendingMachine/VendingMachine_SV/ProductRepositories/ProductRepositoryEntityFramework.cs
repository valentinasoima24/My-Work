using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace iQuest.VendingMachine.DataAccess
{
    internal class ProductRepositoryEntityFramework : IProductRepository
    {
        private readonly VendingMachineContext databaseContext;

        public ProductRepositoryEntityFramework(VendingMachineContext database)
        {
            this.databaseContext = database ?? throw new ArgumentNullException(nameof(database));
        }

        public Product AddProduct(Product product)
        {
            databaseContext.Add(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            });

            return product;
        }

        public List<Product> GetAll()
        {
            List<Product> products = databaseContext.Products
                .OrderBy(p => p.ColumnId).ToList();

            return products;
        }

        public Product GetByColumn(int idOfSelectedProduct)
        {
            Product product = databaseContext.Products
            .Where(p => p.ColumnId == idOfSelectedProduct)
            .First();

            return product;
        }

        public Product UpdateProduct(Product product)
        {
            databaseContext.Update(product);

            return product;
        }
    }
}
