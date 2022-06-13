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
    class ModifyClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //metodo para modificar clientes, lo hara en caso de que exista un cliente con el mismo id del cliente a modificar.

            ClientModel client = clientsViewModel.CurrentClient;

            if (client != null && client.ClientId >0 && client.Name != "" && client.Telephone != "" && client.Email != "" && client.NIF != "")
            {
                foreach (ClientModel c in clientsViewModel.ClientsList)
                {
                    if (c.ClientId.Equals(client.ClientId))
                    {
                        DataSetHandler.modifyClient(client.ClientId, client.Name, client.Telephone, client.Email, client.NIF);
                        modified(client.Name);   
                        clientsViewModel.ClientsList = DataSetHandler.GetClients();
                        clientsViewModel.CurrentClient = new ClientModel();
                        break;
                    }
                }
            }
            else
            {
                error();
            }
        }
        //messagebox para los casos de si se ha modificado o no.
        private void modified(string name)
        {
            bool? Result = new MessageBoxCustom("The client " + name + " has been modified.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("The client has not been modified, check the values.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public ClientsViewModel clientsViewModel { get; set; }
        public ModifyClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
