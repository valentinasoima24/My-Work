using System;
using VendingMachine_SV.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class LoginView : DisplayBase, ILoginView
    {
        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}