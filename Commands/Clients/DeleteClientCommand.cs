using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using Proyecto_TFG.Views;
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
        //comando para borrar cliente

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
                    //si el id del cliente que se desea borrar coincide con alguno de la lista lo borra.
                    if (c.ClientId.Equals(client.ClientId))
                    {
                        DataSetHandler.deleteClient(client.ClientId);
                        deleted(client.Name);
                        clientsViewModel.ClientsList = DataSetHandler.GetClients();
                        clientsViewModel.CurrentClient = new ClientModel();
                        break;
                    }
                }
            }
            else
            {
               gerror();
            }
        }
        private void deleted(string name)
        {
            bool? Result = new MessageBoxCustom("The client "+ name + " has been deleted", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error deleting the client, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public ClientsViewModel clientsViewModel { get; set; }
        public DeleteClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
