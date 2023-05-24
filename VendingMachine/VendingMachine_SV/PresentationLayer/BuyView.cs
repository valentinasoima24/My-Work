using iQuest.VendingMachine.PresentationLayer;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Payment;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.PresentationLayer
{

    public class BuyView : DisplayBase, IBuyView
    {
        public int RequestProduct()
        {
            Display("Please introduce the column number for the product you want:", ConsoleColor.White);
            string requestedColumnId = Console.ReadLine();

            if (string.IsNullOrEmpty(requestedColumnId))
                throw new CancelException();


            if (int.Parse(requestedColumnId) != 0)
            {
                return int.Parse(requestedColumnId);
            }
            else
            {
                throw new CancelException();
            }
        }

        public void DispenseProduct(string productName)
        {
            Display("Enjoy your " + productName + ". :)", ConsoleColor.Green);
        }



        public int AskForPaymentMethod(List<IPaymentMethod> paymentMethods)
        {
            string idOfPaymentMethod;
            string Message = "Please select the ID of the payment method you want to choose. Press Enter to cancel. 1-cash 2 - card  Enter-cancel";
            DisplayLine(Message, ConsoleColor.Cyan);
            idOfPaymentMethod = Console.ReadLine();
            
            if (string.IsNullOrEmpty(idOfPaymentMethod))
            {
                throw new CancelException();
            }

            int resultIdOfPayment = Int32.Parse(idOfPaymentMethod);

            return resultIdOfPayment;
        }
    }
}
