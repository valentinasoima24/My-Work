using iQuest.VendingMachine.PresentationLayer;
using VendingMachine_SV.UseCases;
using Nagarro.VendingMachine;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Payment;
using VendingMachine_SV.PresentationLayer;
using Autofac;
using System.ComponentModel;
using System.Collections.Generic;
namespace VendingMachine_SV
{
    internal class Bootstrapper : IBootstrapper
    {
        public void Run()
        {
            Autofac.IContainer container = ContainerConfig.Configure();
            

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                IVendingMachineApplication vendingMachineApplication = scope.Resolve<IVendingMachineApplication>();
                vendingMachineApplication.Run();
            }
        }

        private static IVendingMachineApplication BuildApplication()
        {
            Autofac.IContainer container = ContainerConfig.Configure();
         

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                return scope.Resolve<IVendingMachineApplication>();
            }
        }
    }

}
