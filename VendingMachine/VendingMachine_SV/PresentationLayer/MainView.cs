using Nagarro.VendingMachine;
using System.Collections.Generic;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class MainView : DisplayBase, IMainView
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public ICommands ChooseCommand(IEnumerable<ICommands> commands)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                Commands = commands
            };
            return commandSelectorControl.Display();
        }
    }
}