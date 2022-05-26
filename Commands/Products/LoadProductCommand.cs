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
    class LoadProductCommand: ICommand
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
                ProductModel product = (ProductModel)parameter;

                inventoryViewModel.CurrentProduct = (ProductModel)product.Clone();

                inventoryViewModel.SelectedProduct = (ProductModel)product.Clone();

            }
        }

        public InventoryViewModel inventoryViewModel { get; set; }

        public LoadProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
