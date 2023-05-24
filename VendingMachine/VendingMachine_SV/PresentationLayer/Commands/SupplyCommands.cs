using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.UseCases;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class SupplyCommands : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "supply";
        public string Description => "Supply vending machine.";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SupplyCommands(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<SupplyUseCase>().Execute();
        }
    }
}
