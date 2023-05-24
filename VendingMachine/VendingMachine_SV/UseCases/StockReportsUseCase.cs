using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Reports.ReportsModel;
using log4net;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace iQuest.VendingMachine.UseCases
{
    internal class StockReportsUseCase : IUseCase
    {
        private readonly IReportSerializer reportsSerializer;
        private readonly IProductRepository productRepository;
        private readonly ILog logger;

        public StockReportsUseCase(IReportSerializer reportsSerializer, IProductRepository productRepository, ILog logger)
        {
            this.reportsSerializer = reportsSerializer ?? throw new ArgumentNullException(nameof(reportsSerializer));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            const string typeOfReport = "Stock_Report";

            logger.Info("Starting: Getting the products.");
            IEnumerable<Product> products = productRepository.GetAll();
            products = products.Where(product => product?.Quantity > 0);
            logger.Info("Finished: Getting the products.");

            List<ProductReportModel> validProducts = products
                .Select(x => new ProductReportModel() { Name = x.Name, Quantity = x.Quantity })
                .ToList();

            logger.Info("Starting: Serializing the products.");
            reportsSerializer.Serialize(validProducts, typeOfReport);
            logger.Info("Finished: Serializing the products.");
        }
    }
}
