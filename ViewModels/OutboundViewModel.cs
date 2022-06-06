using Proyecto_TFG.Commands;
using Proyecto_TFG.Commands.Clients;
using Proyecto_TFG.Commands.outbounds;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class OutboundViewModel : ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }
        public LoadProductsCommand loadProductsCommand { get; set; }
        public LoadClientsListCommand loadClientsListCommand { get; set; }
        public LoadOutboundsCommand loadOutboundsCommand { get; set; }
        public DeleteOutboundCommand deleteOutboundCommand { get; set; }
        public CreateOutboundOrderCommand createOutboundOrderCommand { get; set; }
        public AddtochartCommand addtochartCommand { set; get; }
        public RemoveSelectedProductOCommand removeSelectedProductOCommand{ get; set;}

        public GeneratePDFCommand generatePDFCommand { get; set; }

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
        private ObservableCollection<ClientModel> clientsList;
        public ObservableCollection<ClientModel> ClientsList
        {
            set
            {
                clientsList = value;
                OnPropertyChanged(nameof(ClientsList));
            }
            get
            {
                return clientsList;
            }
        }

        private ObservableCollection<OutboundModel> outboundList;
        public ObservableCollection<OutboundModel> OutboundList
        {
            set
            {
                outboundList = value;
                OnPropertyChanged(nameof(OutboundList));
            }
            get
            {
                return outboundList;
            }
        }
        private OutboundModel outbound;
        public OutboundModel Outbound
        {
            set
            {
                outbound = value;
                OnPropertyChanged(nameof(Outbound));
            }
            get
            {
                return outbound;
            }
        }
        private ClientModel client;
        public ClientModel Client
        {
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
            get
            {
                return client;
            }
        }


        public OutboundViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            loadProductsCommand = new LoadProductsCommand(this);
            addtochartCommand = new AddtochartCommand(this);
            createOutboundOrderCommand = new CreateOutboundOrderCommand(this);
            loadClientsListCommand = new LoadClientsListCommand(this);
            loadOutboundsCommand = new LoadOutboundsCommand(this);
            deleteOutboundCommand = new DeleteOutboundCommand(this);
            generatePDFCommand = new GeneratePDFCommand(this);
            removeSelectedProductOCommand = new RemoveSelectedProductOCommand(this);
            updateViewCommandv2 = updateViewCommand;
            CharList = new ObservableCollection<ProductModel>();
        }
    }
}
