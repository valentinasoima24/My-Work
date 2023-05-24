using Autofac;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.Reports;
using iQuest.VendingMachine.UseCases;
using log4net;
using Nagarro.VendingMachine;
using Nagarro.VendingMachine.PresentationLayer;
using System.Configuration;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Payment;
using VendingMachine_SV.PresentationLayer;
using VendingMachine_SV.UseCases;

namespace VendingMachine_SV
{
    internal class ContainerConfig
    {
        public static IContainer Configure()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<Bootstrapper>().As<VendingMachine_SV.Bootstrapper>();
           
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>();
            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();

            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>().AsSelf();
            builder.RegisterType<LoginUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<LogoutUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<LookUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<BuyUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<SupplyUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<StockReportsUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<SalesReportsUseCase>().As<IUseCase>().AsSelf();
            builder.RegisterType<VolumeReportsUseCase>().As<IUseCase>().AsSelf();

            builder.RegisterType<BuyCommands>().As<ICommands>();
            builder.RegisterType<LoginCommands>().As<ICommands>();
            builder.RegisterType<LogoutCommands>().As<ICommands>();
            builder.RegisterType<LookCommands>().As<ICommands>();
            builder.RegisterType<SupplyCommands>().As<ICommands>();
            builder.RegisterType<StockReportsCommand>().As<ICommands>();
            builder.RegisterType<SalesReportsCommand>().As<ICommands>();
            builder.RegisterType<VolumeReportsCommand>().As<ICommands>();

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<SupplyView>().As<ISupplyView>();
            builder.RegisterType<ReportView>().As<IReportView>();


            string serializeType = ConfigurationManager.AppSettings["serializeType"];
            if (serializeType is "xml")
            {
                builder.RegisterType<XmlReportSerializer>().As<IReportSerializer>();
            }
            else if (serializeType is "json")
            {
                builder.RegisterType<JsonReportSerializer>().As<IReportSerializer>();
            }

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

             
            builder.RegisterType<CashPayment>().As<IPaymentMethod>();
            builder.RegisterType<CardPayment>().As<IPaymentMethod>();
            builder.RegisterType<CashPaymentTerminal>().As<CashPaymentTerminal>();
            builder.RegisterType<CardPaymentTerminal>().As<CardPaymentTerminal>();

            builder.RegisterType<ProductRepositoryFromSQLite>().As<IProductRepository>().SingleInstance();

            string logFile = $"vending-machine-{DateTime.Now:yyy-MM-dd-HH-mm-ss}.log";
            log4net.GlobalContext.Properties["LogName"] = logFile;
            string loggerName = "log4net";
            builder.Register(logger => LogManager.GetLogger(loggerName)).As<ILog>();

            return builder.Build();
        }

    }
}
