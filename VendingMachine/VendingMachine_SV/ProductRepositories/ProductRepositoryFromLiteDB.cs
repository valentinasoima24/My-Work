using LiteDB;
using System.Configuration;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace iQuest.VendingMachine.DataAccess
{
    internal class ProductRepositoryFromLiteDB : IProductRepository
    {
        private readonly LiteDatabase connection;

        public ProductRepositoryFromLiteDB()
        {
            string connectionString = LoadConnectionString();
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

            connection = new LiteDatabase(connectionString);
            //connection.Open();
        }

        public List<Product> GetAll()
        {
            using (var database = new LiteDatabase(LoadConnectionString()))
            {
                List<Product> allProducts = (List<Product>)database.GetCollection<Product>("allProducts");

                return allProducts;
            }
        }


        public Product GetByColumn(int idOfSelectedProduct)
        {
            using (var database = new LiteDatabase(LoadConnectionString()))
            {
                List<Product> allProducts = (List<Product>)database.GetCollection<Product>("allProducts");

                Product product = allProducts.Find(x => x.ColumnId == idOfSelectedProduct);

                return product;
            }
        }

        public Product AddProduct(Product product)
        {
            using (var database = new LiteDatabase(LoadConnectionString()))
            {
                List<Product> allProducts = (List<Product>)database.GetCollection<Product>("allProducts");

                allProducts.Add(product);

                return allProducts[0];
            }
        }

        public Product UpdateProduct(Product product)
        {
            using (var database = new LiteDatabase(LoadConnectionString()))
            {
                var allProducts = database.GetCollection<Product>("allProducts");

                Product productToUpdate = (Product)allProducts.Find(x => x.ColumnId == product.ColumnId);

                allProducts.Update(productToUpdate);

                return productToUpdate;
            }
        }

        private string LoadConnectionString(string id = "LiteDB")
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
