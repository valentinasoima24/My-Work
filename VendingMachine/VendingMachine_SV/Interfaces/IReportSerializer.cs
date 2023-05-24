using System.Collections.Generic;

namespace VendingMachine_SV.Interfaces
{
    internal interface IReportSerializer
    {
        void Serialize<T>(IEnumerable<T> serializableObject, string reportType);
    }
}
