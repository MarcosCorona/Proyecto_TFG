using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Clients
{
    class LoadClientCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                ClientModel client = (ClientModel)parameter;

                clientsViewModel.CurrentClient = (ClientModel)client.Clone();

                clientsViewModel.SelectedClient = (ClientModel)client.Clone();
            }
        }
        public ClientsViewModel clientsViewModel { get; set; }
        public LoadClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
