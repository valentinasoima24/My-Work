using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Exceptions;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.Models;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.UseCases
{
    internal class SupplyUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ISupplyView supplyView;
        private readonly IAuthenticationService authenticationService;

        public string Name => "supply";
        public string Description => "Supply products";
        public bool CanExecute => this.authenticationService.IsUserAuthenticated;

        public SupplyUseCase(IProductRepository productRepository, ISupplyView supplyView,IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.supplyView = supplyView ?? throw new ArgumentNullException(nameof(supplyView));
        }

        public void Execute()
        {
            int columnId = this.supplyView.RequestProductId();
            _ = columnId <= 0 ? throw new InvalidPropertyValueException(Convert.ToString(columnId),nameof(columnId)) : columnId;

            string name=this.supplyView.RequestProductName();
            _ = string.IsNullOrWhiteSpace(name) ? throw new InvalidPropertyValueException(name, nameof(name)) : name;

            decimal price = this.supplyView.RequestProductPrice();
            _ = price <=0 ?throw new InvalidPropertyValueException(Convert.ToString(price), nameof(price)) : price;


            int quantity = this.supplyView.RequestProductQuantity();
            _ = quantity <= 0 ? throw new InvalidPropertyValueException(Convert.ToString(quantity), nameof(quantity)) : quantity;

            Product product = new Product()
            {
                ColumnId = columnId,
                Name = name,   
                Price = price,
                Quantity=quantity

            };


            _ = productRepository.AddProduct(product) ?? throw new ArgumentNullException(product.Name);
        }

    }
}
