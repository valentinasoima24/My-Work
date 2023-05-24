using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace iQuest.VendingMachine.DataAccess
{
    internal class SalesRepositoryFromSQLite : ISaleRepository
    {
        private readonly SQLiteConnection connection;

        public SalesRepositoryFromSQLite(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        public void Add(Sale sale)
        {
            using SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "insert into Sales values (@Date, @ProductName, @Price, @PaymentType)";
            command.Parameters.AddWithValue("@Date", sale.Date.Ticks);
            command.Parameters.AddWithValue("@ProductName", sale.ProductName);
            command.Parameters.AddWithValue("@Price", sale.Price);
            command.Parameters.AddWithValue("@PaymentType", sale.PaymentType);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Sale> Get(TimeInterval timeInterval)
        {
            using SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "select * from Sales where Date >= @StartTime and Date <= @EndTime";
            command.Parameters.AddWithValue("@StartTime", timeInterval.StartTime.Ticks);
            command.Parameters.AddWithValue("@EndTime", timeInterval.EndTime.Ticks);

            using SQLiteDataReader reader = command.ExecuteReader();
            List<Sale> sales = new List<Sale>();

            while (reader.Read())
            {
                Sale sale = new Sale
                {
                    Date = new DateTime((long)reader["Date"]),
                    ProductName = reader["ProductName"].ToString(),
                    Price = (decimal)Convert.ToDouble(reader["Price"]),
                    PaymentType = reader["PaymentType"].ToString()
                };
                sales.Add(sale);
            }

            return sales;
        }

        public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval timeInterval)
        {
            using SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "select ProductName, count(*) as Quantity from Sales " +
                                  "where Date >= @StartTime and Date <= @EndTime " +
                                  "group by ProductName " +
                                  "order by Date";

            command.Parameters.AddWithValue("@StartTime", timeInterval.StartTime.Ticks);
            command.Parameters.AddWithValue("@EndTime", timeInterval.EndTime.Ticks);

            using SQLiteDataReader reader = command.ExecuteReader();
            List<ProductSale> sales = new List<ProductSale>();

            while (reader.Read())
            {
                ProductSale productSale = new ProductSale
                {
                    TimeInterval = timeInterval,
                    ProductName = reader["ProductName"].ToString(),
                    Quantity = (int)(long)reader["Quantity"]
                };
                sales.Add(productSale);
            }

            return sales;
        }
    }
}
