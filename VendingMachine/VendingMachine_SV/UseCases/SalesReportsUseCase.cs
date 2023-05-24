
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Reports.ReportsModel;
using log4net;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    internal class SalesReportsUseCase : IUseCase
    {
        private readonly IReportSerializer reportsSerializer;
        private readonly IReportView reportView;
        private readonly ISaleRepository saleRepository;
        private readonly ILog logger;
        public SalesReportsUseCase(IReportSerializer reportsSerializer, IReportView reportView, ISaleRepository saleRepository, ILog logger)
        {
            this.reportsSerializer = reportsSerializer ?? throw new ArgumentNullException(nameof(reportsSerializer));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            const string typeOfReport = "Sales_Report";

            logger.Info("Starting: Asking for start and end date.");
            TimeInterval timeInterval = reportView.AskForStartAndEndDate();
            logger.Info("Finished: Asking for start and end date.");

            logger.Info("Starting: Getting the sale repository.");
            IEnumerable<Sale> sales = saleRepository.Get(timeInterval);
            logger.Info("Finished: Getting the sale repository.");

            List<SalesReportModel> validSales = sales
                .Select(x => new SalesReportModel()
                {
                    Date = x.Date,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    PaymentType = x.PaymentType
                })
                .ToList();

            logger.Info("Starting: Serializing the sales.");
            reportsSerializer.Serialize(validSales, typeOfReport);
            logger.Info("Finished: Serializing the sales.");
        }
    }
}
