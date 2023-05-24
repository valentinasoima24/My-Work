using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Reports.ReportsModel;
using log4net;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    internal class VolumeReportsUseCase : IUseCase
    {
        private readonly IReportSerializer reportsSerializer;
        private readonly IReportView reportView;
        private readonly ISaleRepository saleRepository;
        private readonly ILog logger;

        public VolumeReportsUseCase(IReportSerializer reportsSerializer, IReportView reportView, ISaleRepository saleRepository, ILog logger)
        {
            this.reportsSerializer = reportsSerializer ?? throw new ArgumentNullException(nameof(reportsSerializer));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            const string typeOfReport = "Volume_Report";

            logger.Info("Starting: Asking for start and end date.");
            TimeInterval timeInterval = reportView.AskForStartAndEndDate();
            logger.Info("Finished: Asking for start and end date.");

            logger.Info("Starting: Getting the sale repository.");
            IEnumerable<ProductSale> volume = saleRepository.GetGroupedByProduct(timeInterval);
            logger.Info("Finished: Getting the sale repository.");

            List<ProductSaleReportModel> validVolume = volume
                .Select(x => new ProductSaleReportModel()
                {
                    TimeInterval = x.TimeInterval,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity
                })
                .ToList();

            logger.Info("Starting: Serializing the volume sales.");
            reportsSerializer.Serialize(volume, typeOfReport);
            logger.Info("Finished: Serializing the volume sales.");
        }
    }
}
