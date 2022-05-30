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
    class ClearClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            clientsViewModel.CurrentClient = new ClientModel();
        }

        public ClientsViewModel clientsViewModel { get; set; }
        public ClearClientCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }
    }
}
