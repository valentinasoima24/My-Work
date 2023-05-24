﻿using Nagarro.VendingMachine;
using VendingMachine_SV.Interfaces;

namespace VendingMachine_SV.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        public string Name => "logout";

        public string Description => "Restrict access to administration section.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}