using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated { get;  set; }

        public void Login(string password)
        {
            if (password == "x")
            {
                IsUserAuthenticated = true;
            }
            else
                throw new InvalidPasswordException();
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}