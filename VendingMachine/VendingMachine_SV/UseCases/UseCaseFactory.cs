using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;

namespace VendingMachine_SV.UseCases
{
    internal class UseCaseFactory : IUseCaseFactory
    {
        private readonly ILifetimeScope scope;

        public UseCaseFactory(ILifetimeScope scope)
        {
            this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }

        public T Create<T>() where T : IUseCase
        {
            return scope.Resolve<T>();
        }
    }
}
