using System;
using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;

namespace Nagarro.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IList<ICommands> commands;
        private readonly IMainView mainView;

        public VendingMachineApplication(IList<ICommands> commands, IMainView mainView)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }


        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<ICommands> availableUseCases = GetExecutableUseCases();

                ICommands command = mainView.ChooseCommand(availableUseCases);

                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex.Message);
                }
            }
        }

        private List<ICommands> GetExecutableUseCases()
        {
            List<ICommands> executableUseCases = new List<ICommands>();

            foreach (ICommands command in commands)
            {
                if (command.CanExecute)
                    executableUseCases.Add(command);
            }

            return executableUseCases;
        }
        private static void DisplayErrorMessage(string message)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine('\n' + message);
            Console.ForegroundColor = oldColor;
        }
    }
}