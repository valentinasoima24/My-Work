using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.PresentationLayer;
using VendingMachine_SV.Payment;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase 
    {
        public string AskForCardNumber()
        {
            Display("Please write the card number: ", ConsoleColor.White);
            string cardNumber = Console.ReadLine();
            return cardNumber;
        }
    }
}
