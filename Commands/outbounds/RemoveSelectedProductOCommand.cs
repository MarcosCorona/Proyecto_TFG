using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.outbounds
{
    class RemoveSelectedProductOCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           ProductModel product = (ProductModel)parameter;
           foreach(ProductModel p in outboundViewModel.CharList)
           {
             if(p.ItemId == product.ItemId)
                {
                    outboundViewModel.CharList.Remove(p);
                    break;
                }
           }
        }

        public OutboundViewModel outboundViewModel { get; set; }
        public RemoveSelectedProductOCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
