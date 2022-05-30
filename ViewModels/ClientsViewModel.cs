using Proyecto_TFG.Commands;
using Proyecto_TFG.Commands.Clients;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class ClientsViewModel: ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }
        public LoadClientsListCommand loadClientsCommand { get; set; }
        public LoadClientCommand loadClientCommand { get; set; }
        public CreateClientCommand createClientCommand { set; get; }
        public ClearClientCommand clearClientCommand { get; set; }
        public DeleteClientCommand deleteClientCommand { set; get; }
        public ModifyClientCommand modifyClientCommand { set; get; }
        public SearchClientCommand searchClientCommand { set; get; }


        private ClientModel currentClient { get; set; }
        public ClientModel CurrentClient
        {
            get { return currentClient; }
            set
            {
                currentClient = value;
                OnPropertyChanged(nameof(CurrentClient));
            }
        }
        private ClientModel selectedClient { get; set; }
        public ClientModel SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private ClientModel client;
        public ClientModel Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
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

        public int searchedId { get; set; }

        public ClientsViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            updateViewCommandv2 = updateViewCommand;
            loadClientsCommand = new LoadClientsListCommand(this);
            loadClientCommand = new LoadClientCommand(this);
            createClientCommand = new CreateClientCommand(this);
            clearClientCommand = new ClearClientCommand(this);
            deleteClientCommand = new DeleteClientCommand(this);
            modifyClientCommand = new ModifyClientCommand(this);
            searchClientCommand = new SearchClientCommand(this);
            CurrentClient = new ClientModel();
        }
    }
}
