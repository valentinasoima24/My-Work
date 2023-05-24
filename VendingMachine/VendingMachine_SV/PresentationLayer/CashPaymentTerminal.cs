using iQuest.VendingMachine.PresentationLayer;
using VendingMachine_SV.Exceptions;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase,ICashPayment
    {
        const string currency = "lei";
        decimal cashIn = 0;

        public decimal AskForMoney(decimal priceOfProduct)
        {
            string askForMoneyMessage = $"Please add {priceOfProduct} {currency}. Press enter to cancel.";
            DisplayLine(askForMoneyMessage, ConsoleColor.Green);

            string banknotesIn = Console.ReadLine();

            decimal.TryParse(banknotesIn, out cashIn);

            if ((decimal.TryParse(banknotesIn, out cashIn)==null))
            {
                throw new ParseException(banknotesIn);
            }

            return cashIn;

        }

        public void GiveBackChange(decimal change)
        {
            string askForMoneyMessage = $"Your change is {change} {currency}. ";
            Display(askForMoneyMessage, ConsoleColor.Green);
        }
    }
}
