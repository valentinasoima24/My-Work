using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.UseCases;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LookCommands : ICommands
    {
        private readonly IUseCaseFactory useCaseFactory;
        public string Name => "look";

        public string Description => "Display available products.";

        public bool CanExecute => true;

        public LookCommands(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<LookUseCase>().Execute();
        }
    }
}
