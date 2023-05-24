using System;

namespace VendingMachine_SV.ProductSpecifications
{
    internal class InvalidColumnException : Exception
    {
        private const string DefaultMessage = "Column {0} is an invalid column :(";

        public InvalidColumnException(int ColumnId)
            : base(String.Format(DefaultMessage,ColumnId))
        {
        }
    }
} 