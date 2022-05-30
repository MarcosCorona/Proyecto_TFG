using Proyecto_TFG.Handlers;
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
    class LoadClientsListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString().Equals("outbound")){

                outboundViewModel.ClientsList = DataSetHandler.GetClients();
                if (outboundViewModel.ClientsList is null)
                {
                    MessageBox.Show("There are no clients to show.");
                }
            }
            else if (parameter.ToString().Equals("clients"))
            {
                clientsViewModel.ClientsList = DataSetHandler.GetClients();
                if (clientsViewModel.ClientsList is null)
                {
                    MessageBox.Show("There are no clients to show.");
                }
            }
           
        }

        public OutboundViewModel outboundViewModel { get; set; }
        public LoadClientsListCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
        public ClientsViewModel clientsViewModel { get; set; }
        public LoadClientsListCommand(ClientsViewModel clientsViewModel)
        {
            this.clientsViewModel = clientsViewModel;
        }

    }
}
