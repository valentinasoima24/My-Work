using Nagarro.VendingMachine;
using System;
using System.Collections.Generic;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CommandSelectorControl : DisplayBase
    {

        public IEnumerable<ICommands> Commands { get; set; }

        public ICommands Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (ICommands command in Commands)
                DisplayUseCase(command);
        }

        private static void DisplayUseCase(ICommands command)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(command.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + command.Description);
        }

        private ICommands SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                ICommands selectedUseCase = FindCommand(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private ICommands FindCommand(string rawValue)
        {
            ICommands selectedCommand = null;

            foreach (ICommands x in Commands)
            {
                if (x.Name == rawValue)
                {
                    selectedCommand = x;
                    break;
                }
            }

            return selectedCommand;
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}