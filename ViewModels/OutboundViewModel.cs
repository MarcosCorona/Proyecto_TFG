using Proyecto_TFG.Commands;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class OutboundViewModel:ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }

        public LoadProductsCommand loadProductsCommand { get; set; }

        public AddtochartCommand addtochartCommand { set; get; }

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

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));
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

        private ObservableCollection<ProductModel> charList;
        public ObservableCollection<ProductModel> CharList
        {
            set
            {
                charList = value;
                OnPropertyChanged(nameof(CharList));
            }
            get
            {
                return charList;
            }
        }
        public OutboundViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            loadProductsCommand = new LoadProductsCommand(this);
            addtochartCommand = new AddtochartCommand(this);
            updateViewCommandv2 = updateViewCommand;
        }
    }
}
