using Nagarro.VendingMachine;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;
using VendingMachine_SV.Payment;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IProductRepository productRepository;
        private readonly IBuyView buyView;
        private readonly List<IPaymentMethod> paymentAlgorithms;
        private readonly IPaymentUseCase paymentUseCase;

        public string Name => "buy";

        public string Description => "Buy the product you want.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IProductRepository productRepository, IBuyView buyView, IAuthenticationService authenticationService, List<IPaymentMethod> paymentAlgorithms,IPaymentUseCase paymentUseCase)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.paymentAlgorithms = (new List<IPaymentMethod>(paymentAlgorithms)) ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
            this.paymentUseCase= paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public void Execute()
        {
            int columnId = buyView.RequestProduct();

            Product requestedProduct = productRepository.GetByColumn(columnId);


            if (requestedProduct == null)
                throw new InvalidColumnException(columnId);
            if (requestedProduct.Quantity <= 0)
                throw new InvalidStockException(requestedProduct.Name);

            PaymentUseCase paymentUseCase = new PaymentUseCase(buyView,paymentAlgorithms,authenticationService);
            paymentUseCase.Execute(requestedProduct.Price);


            buyView.DispenseProduct(requestedProduct.Name);
            requestedProduct.Quantity -= 1;
        }
    }
}
