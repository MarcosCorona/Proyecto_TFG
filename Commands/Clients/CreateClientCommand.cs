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
    class CreateClientCommand : ICommand
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
                        MessageBox.Show("The client already exists.");
                        break;
                    }
                    else
                    {
                        DataSetHandler.insertClient(client.ClientId, client.Name, client.Telephone, client.Email, client.NIF);
                        clientsViewModel.ClientsList = DataSetHandler.GetClients();
                        clientsViewModel.CurrentClient = new ClientModel();
                        MessageBox.Show("`The client " + client.Name + " has been created.");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error creating the client, please try again.");
            }
        }

        public ClientsViewModel clientsViewModel { get; set; }
        public CreateClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
