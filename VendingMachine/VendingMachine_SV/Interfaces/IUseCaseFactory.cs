using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    internal interface IUseCaseFactory
    {
        public T Create<T>() where T : IUseCase;
    }
}
