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
                    if (c.ClientId.Equals(client.ClientId) || client.NIF is null)
                    {
                        id();
                        break;
                    }else if(client.Name is null || client.Name.Equals(""))
                    {
                        name();
                        break;
                    }
                    else if (client.Telephone is null || client.Telephone.Equals(""))
                    {
                        telephone();
                        break;
                    }
                    else if (client.Email is null || client.Email.Equals(""))
                    {
                        email();
                        break;
                    }
                    else if (client.NIF is null || client.NIF.Equals("") || client.NIF.Length > 10)
                    {
                        nif();
                        break;
                    }
                    else
                    {
                      
                        DataSetHandler.insertClient(client.ClientId, client.Name, client.Telephone, client.Email, client.NIF);
                        clientsViewModel.ClientsList = DataSetHandler.GetClients();
                        clientsViewModel.CurrentClient = new ClientModel();
                        created(client.Name);
                        break;
                    }
                }
            }
            else
            {
                gerror();
            }
        }

        private void id()
        {
            bool? Result = new MessageBoxCustom("Please, check the client already exists", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void name()
        {
            bool? Result = new MessageBoxCustom("Please, check the client name", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void telephone()
        {
            bool? Result = new MessageBoxCustom("Please, check the client telephone", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void email()
        {
            bool? Result = new MessageBoxCustom("Please, check the client email", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void nif()
        {
            bool? Result = new MessageBoxCustom("Please, check the client nif", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void created(string name)
        {
            bool? Result = new MessageBoxCustom("The client " + name + " has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error creating the client, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public ClientsViewModel clientsViewModel { get; set; }
        public CreateClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
