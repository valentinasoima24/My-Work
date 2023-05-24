using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IReportView
    {
        TimeInterval AskForStartAndEndDate();
    }
}
