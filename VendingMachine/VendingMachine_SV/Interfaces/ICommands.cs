using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    internal interface ICommands
    {
        public string Name { get; }

        public string Description { get; }

        public bool CanExecute { get; }

        public void Execute();
    }
}
