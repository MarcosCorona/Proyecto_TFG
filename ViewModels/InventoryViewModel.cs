using Proyecto_TFG.Commands;
using Proyecto_TFG.Commands.Products;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class InventoryViewModel: ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }
        public LoadProductsCommand loadProductsCommand { get; set; }
        public LoadProductCommand loadProductCommand { get; set; }

        private ProductModel currentProduct { get; set; }
        public ProductModel CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                currentProduct = value;
                OnPropertyChanged(nameof(CurrentProduct));
            }
        }
        private ProductModel selectedProduct { get; set; }
        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private ProductModel product;
        public ProductModel Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        private ObservableCollection<ProductModel> productsList;
        public ObservableCollection<ProductModel> ProductsList
        {
            set
            {
                productsList = value;
                OnPropertyChanged(nameof(ProductsList));
            }
            get
            {
                return productsList;
            }
        }


        public InventoryViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            updateViewCommandv2 = updateViewCommand;
            loadProductsCommand = new LoadProductsCommand(this);
            loadProductCommand = new LoadProductCommand(this); 
        }
    }
}
