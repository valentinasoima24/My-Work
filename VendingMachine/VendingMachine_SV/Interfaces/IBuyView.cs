using VendingMachine_SV.Payment;

namespace VendingMachine_SV.Interfaces
{
    internal interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);

        public int AskForPaymentMethod(List<IPaymentMethod> paymentMethods);
    }
}
