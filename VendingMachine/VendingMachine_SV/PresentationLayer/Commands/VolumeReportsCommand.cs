using iQuest.VendingMachine.UseCases;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class VolumeReportsCommand : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "volume_report";

        public string Description => "Generate the volume reports.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public VolumeReportsCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<VolumeReportsUseCase>().Execute();
        }
    }
}
