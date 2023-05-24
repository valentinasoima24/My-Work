using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface ISaleRepository
    {
        void Add(Sale sale);

        IEnumerable<Sale> Get(TimeInterval timeInterval);

        IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval timeInterval);
    }
}
