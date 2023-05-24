using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class StockReportsCommand : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "stock_report";

        public string Description => "Generate the stock reports.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public StockReportsCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<StockReportsUseCase>().Execute();
        }
    }
}
