using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace VendingMachine_SV.ProductSpecifications
{
    internal class ProductRepositoryFromSQLite : IProductRepository
    {
        private readonly SQLiteConnection connection;

        public ProductRepositoryFromSQLite()
        {
            string connectionString = LoadConnectionString();

            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

            connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        public List<Product> GetAll()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                List<Product> allProducts =
                    (List<Product>)connection.Query<Product>
                    ("SELECT * FROM Products", new DynamicParameters());

                return allProducts;
            }
        }


        public Product GetByColumn(int idOfSelectedProduct)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                List<Product> selectedProduct =
                    (List<Product>)connection.Query<Product>
                    ("SELECT * FROM Products WHERE ColumnId = " + idOfSelectedProduct, new DynamicParameters());

                return selectedProduct.FirstOrDefault();
            }
        }

        public Product AddProduct(Product product)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                List<Product> products = (List<Product>)connection.Query<Product>
                    ("INSERT INTO Products (ColumnId, Name, Price, Quantity) values ("
                    + product.ColumnId + ", \" " + product.Name + "\"" + "," +
                    product.Price + "," + product.Quantity + ")");

                return product;
            }
        }

        public Product UpdateProduct(Product product)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Query<Product>
                      ("UPDATE Products SET Quantity = " + product.Quantity +
                      " WHERE ColumnId = " + product.ColumnId, new DynamicParameters());

                return product;
            }
        }

        private string LoadConnectionString(string id = "DatabaseConnection")
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void CloseAndDispose()
        {
            connection?.Dispose();
            connection?.Close();
        }
    }
}
