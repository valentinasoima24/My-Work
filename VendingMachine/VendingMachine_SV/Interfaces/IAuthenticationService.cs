namespace VendingMachine_SV.Interfaces
{
    internal interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get; set; }

        public void Login(string password);
        public void Logout();
    }
}
