using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.UseCases;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LogoutCommands : ICommands
    {
        private IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "logout";

        public string Description => "Restrict access to administration section.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutCommands(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<LogoutUseCase>().Execute();
        }
    }
}
