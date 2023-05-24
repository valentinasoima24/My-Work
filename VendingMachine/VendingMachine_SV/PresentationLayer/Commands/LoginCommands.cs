using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.UseCases;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LoginCommands : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "login";

        public string Description => "Get access to administration section.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginCommands(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<LoginUseCase>().Execute();
        }
    }
}
