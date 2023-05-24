using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class SalesReportsCommand : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "sales_report";

        public string Description => "Generate the sales reports.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SalesReportsCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<SalesReportsUseCase>().Execute();
        }
    }
}
