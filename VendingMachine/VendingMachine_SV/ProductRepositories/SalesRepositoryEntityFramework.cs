using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.DataAccess
{
    internal class SalesRepositoryEntityFramework : ISaleRepository
    {
        private readonly VendingMachineContext databaseContext;

        public SalesRepositoryEntityFramework(VendingMachineContext database)
        {
            this.databaseContext = database ?? throw new ArgumentNullException(nameof(database));
        }

        public void Add(Sale sale)
        {
            databaseContext.Add(new Sale
            {
                Date = sale.Date,
                ProductName = sale.ProductName,
                Price = sale.Price,
                PaymentType = sale.PaymentType
            });
        }

        public IEnumerable<Sale> Get(TimeInterval timeInterval)
        {
            List<Sale> sales = databaseContext.Sales
                .Where(sale => sale.Date >= timeInterval.StartTime && sale.Date <= timeInterval.EndTime)
                .OrderBy(p => p.Id).ToList();

            return sales;
        }

        public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval timeInterval)
        {
            var productSales = databaseContext
                .Sales.Where(sale => sale.Date >= timeInterval.StartTime && sale.Date <= timeInterval.EndTime)
                .GroupBy(sale => sale.ProductName);

            return (IEnumerable<ProductSale>)productSales;
        }
    }
}
