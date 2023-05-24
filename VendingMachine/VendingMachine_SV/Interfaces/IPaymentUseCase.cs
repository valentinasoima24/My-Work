using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    internal interface IPaymentUseCase
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute(decimal price);
    }
}
