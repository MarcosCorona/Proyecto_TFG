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
{   //este comando servirá para crear un cliente
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
                //si la lista clientes no es nula procederá a validar cada campo 
                if(clientsViewModel.ClientsList != null)
                {
                    foreach (ClientModel c in clientsViewModel.ClientsList)
                    {
                       
                        if (client.Name is null || client.Name.Equals(""))
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
                            //si todos los campos son correctos se llama al metodo para crear cliente
                            DataSetHandler.insertClient(client.ClientId, client.Name, client.Telephone, client.Email, client.NIF);
                            //devolvemos de nuevo la lista de los clientes
                            clientsViewModel.ClientsList = DataSetHandler.GetClients();
                            //el cliente actual pasa a ser uno nuevo
                            clientsViewModel.CurrentClient = new ClientModel();
                            //mensaje de cliente creado.
                            created(client.Name);
                            break;
                        }
                    }

                }
                else
                {
                    //si la lista es nula creará el primer cliente 
            
                    if (client.Name is null || client.Name.Equals(""))
                    {
                        name();
                    }
                    else if (client.Telephone is null || client.Telephone.Equals(""))
                    {
                        telephone();
                    }
                    else if (client.Email is null || client.Email.Equals(""))
                    {
                        email();
                    }
                    else if (client.NIF is null || client.NIF.Equals("") || client.NIF.Length > 10)
                    {
                        nif();
                    }
                    else
                    {
                        //inserta el cliente
                        DataSetHandler.insertClient(client.ClientId, client.Name, client.Telephone, client.Email, client.NIF);
                        clientsViewModel.ClientsList = DataSetHandler.GetClients();
                        clientsViewModel.CurrentClient = new ClientModel();
                        created(client.Name);
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
            bool? Result = new MessageBoxCustom("Error creating the client, please try again.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }

        public ClientsViewModel clientsViewModel { get; set; }
        public CreateClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
