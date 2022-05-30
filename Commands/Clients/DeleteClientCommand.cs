using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Clients
{
    class DeleteClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClientModel client = clientsViewModel.CurrentClient;
            if (client != null)
            {
                foreach (ClientModel c in clientsViewModel.ClientsList)
                {
                    if (c.ClientId.Equals(client.ClientId))
                    {
                        DataSetHandler.deleteClient(client.ClientId);
                        MessageBox.Show("The client " + client.Name + " has been deleted.");
                        clientsViewModel.ClientsList = DataSetHandler.GetClients();
                        clientsViewModel.CurrentClient = new ClientModel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error deleting the client, please try again.");
            }
        }

        public ClientsViewModel clientsViewModel { get; set; }
        public DeleteClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
