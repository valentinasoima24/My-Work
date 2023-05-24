using Nagarro.VendingMachine;
using VendingMachine_SV;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;

namespace VendingMachine_SV.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
       // private readonly IProductRepository productRepositoryLiteDB;
        private readonly IShelfView shelfView;

        public string Name => "look";
        public string Description => "Display available products";
        public bool CanExecute => true;

        public LookUseCase(IProductRepository productRepository, IShelfView shelfView)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
           // List<Product> allProducts = productRepository.GetAll();
            List<Product> allProducts = productRepository.GetAll();

            List<Product> productsToDisplay = new List<Product>();

            foreach (Product product in allProducts)
            {
                if (product.Quantity > 0)
                    productsToDisplay.Add(product);
            }

            shelfView.DisplayProducts(productsToDisplay);
        }
    }
}
