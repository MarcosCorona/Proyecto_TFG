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
    class SearchClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //metodo para buscar un cliente.
            int searchedId = clientsViewModel.searchedId;
            bool searchedok = false;
            if (searchedId != null)
            {
                foreach (ClientModel c in clientsViewModel.ClientsList)
                {
                    if (c.ClientId.Equals(searchedId))
                    {
                        //en caso de que el cliente exista en la lista, el cliente actual de la vista pasará a ser el 
                        //que se ha encontrado.
                        clientsViewModel.CurrentClient = c;
                        searchedok = true;
                        break;
                    }
                    else
                    {
                        searchedok = false;
                    }
                }
                if (searchedok == false)
                {
                    //si no se encuentra, mensaje de que no existe.
                    dexists();
                }
            }
            else
            {
                error();
            }
        }
        //metodos para modificar los mensajes
        private void dexists()
        {
            bool? Result = new MessageBoxCustom("The client doesn't exists", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("Error searching the client, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public ClientsViewModel clientsViewModel { get; set; }
        public SearchClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
