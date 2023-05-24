using System;
using Autofac;
using iQuest.VendingMachine;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Payment;
using VendingMachine_SV.PresentationLayer;
using VendingMachine_SV.ProductSpecifications;
using VendingMachine_SV.UseCases;



namespace VendingMachine_SV
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var container = ContainerConfig.Configure();
                var bootstrapper = container.Resolve<Bootstrapper>();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
                Pause();
            }

        }

        private static void DisplayError(Exception ex)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}