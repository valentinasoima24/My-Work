﻿using System;
using Nagarro.VendingMachine;
using VendingMachine_SV.Interfaces;

namespace VendingMachine_SV.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILoginView loginView;

        public string Name => "login";

        public string Description => "Get access to administration section.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginUseCase(IAuthenticationService authenticationService, ILoginView loginView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
        }

        public void Execute()
        {
            string password = loginView.AskForPassword();
            authenticationService.Login(password);
        }
    }
}