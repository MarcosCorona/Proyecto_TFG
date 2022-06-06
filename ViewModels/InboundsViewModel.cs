using Proyecto_TFG.Commands;
using Proyecto_TFG.Commands.Clients;
using Proyecto_TFG.Commands.Inbounds;
using Proyecto_TFG.Commands.Supplier;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class InboundViewModel : ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }
        public LoadProductsCommand loadProductsCommand { get; set; }
        public LoadSuppliersListCommand loadSuppliersListCommand { get; set; }
        public LoadInboundsCommand loadInboundsCommand { get; set; }
        public DeleteInboundCommand deleteInboundCommand { get; set; }
        public CreateInboundOrderCommand createInboundCommand { get; set; }
        public AddtoInboundChartCommand addtochartCommand { set; get; }
        public GenerateInbPDFCommand generateInbPDFCommand { get; set; }
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
        private ObservableCollection<SupplierModel> supplierList;
        public ObservableCollection<SupplierModel> SupplierList
        {
            set
            {
                supplierList = value;
                OnPropertyChanged(nameof(SupplierList));
            }
            get
            {
                return supplierList;
            }
        }

        private ObservableCollection<InboundModel> inboundList;
        public ObservableCollection<InboundModel> InboundList
        {
            set
            {
                inboundList = value;
                OnPropertyChanged(nameof(InboundList));
            }
            get
            {
                return inboundList;
            }
        }
        private InboundModel inbound;
        public InboundModel Inbound
        {
            set
            {
                inbound = value;
                OnPropertyChanged(nameof(Inbound));
            }
            get
            {
                return inbound;
            }
        }
        private SupplierModel supplier;
        public SupplierModel Supplier
        {
            set
            {
                supplier = value;
                OnPropertyChanged(nameof(Supplier));
            }
            get
            {
                return supplier;
            }
        }


        public InboundViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            loadProductsCommand = new LoadProductsCommand(this);
            addtochartCommand = new AddtoInboundChartCommand(this);
            createInboundCommand = new CreateInboundOrderCommand(this);
            loadSuppliersListCommand = new LoadSuppliersListCommand(this);
            loadInboundsCommand = new LoadInboundsCommand(this);
            deleteInboundCommand = new DeleteInboundCommand(this);
            generateInbPDFCommand = new GenerateInbPDFCommand(this);
            updateViewCommandv2 = updateViewCommand;
            CharList = new ObservableCollection<ProductModel>();
        }
    }
}

