using Proyecto_TFG.Handlers;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands
{
    class LoadProductsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("outbound"))
            {
                outboundViewModel.ProductsList = DataSetHandler.GetProducts();
            }
           
        }
        public OutboundViewModel outboundViewModel { get; set; }
        public LoadProductsCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
