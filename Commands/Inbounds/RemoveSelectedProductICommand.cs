using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Inbounds
{
    class RemoveSelectedProductICommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {   
            //metodo para eliminar un producto de la lista del carrito.
            ProductModel product = (ProductModel)parameter;
            foreach (ProductModel p in inboundViewModel.CharList)
            {
                if (p.ItemId == product.ItemId)
                {
                    //si el id del producto es igual al solicitado, se borra.
                    inboundViewModel.CharList.Remove(p);
                    break;
                }
            }
        }

        public InboundViewModel inboundViewModel { get; set; }
        public RemoveSelectedProductICommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
