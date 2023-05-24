using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SV.Interfaces
{
    internal interface IMainView
    {
        public void DisplayApplicationHeader();

        public ICommands ChooseCommand(IEnumerable<ICommands> commands);
    }
}
