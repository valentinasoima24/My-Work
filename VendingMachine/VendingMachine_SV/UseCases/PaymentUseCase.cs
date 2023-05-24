using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;
using VendingMachine_SV.Payment;
using VendingMachine_SV.PresentationLayer;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;
        private readonly List<IPaymentMethod> paymentAlgorithms;
        private readonly IAuthenticationService authenticationService;

        public string Name => "pay";
        public string Description => "Pay for the product.";
        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public PaymentUseCase(IBuyView buyView, List<IPaymentMethod> paymentAlgorithms, IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = (new List<IPaymentMethod>(paymentAlgorithms)) ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
        }



        public void Execute(decimal price)
        {
            List<IPaymentMethod> paymentMethods = new List<IPaymentMethod>();
            paymentMethods.Add(new PaymentMethod() { Id = 1, Name = "cash" });
            paymentMethods.Add(new PaymentMethod() { Id = 2, Name = "card" });

            int desiredPaymentMethod = buyView.AskForPaymentMethod(paymentMethods);
            IPaymentMethod resultData = paymentMethods.FirstOrDefault(x => x.Id == desiredPaymentMethod); 

            if (resultData == null)
            {
                throw new InvalidPaymentMethodException(desiredPaymentMethod);
            }
            else
            {
                paymentAlgorithms[paymentMethods.IndexOf(resultData)].Run(price);
            }
        }
    }
}
