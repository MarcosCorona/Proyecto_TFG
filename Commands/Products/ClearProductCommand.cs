using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Products
{
    class ClearProductCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           inventoryViewModel.CurrentProduct = new ProductModel();
        }

        public InventoryViewModel inventoryViewModel { get; set; }

        public ClearProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
