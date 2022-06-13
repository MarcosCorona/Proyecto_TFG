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

namespace Proyecto_TFG.Commands.Products
{
    class ModifyProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductModel product = inventoryViewModel.CurrentProduct;
            if (product != null)
            {
                foreach (ProductModel p in inventoryViewModel.ProductsList)
                {
                    if (p.ItemId.Equals(product.ItemId))
                    {
                        DataSetHandler.modifyProduct(product.ItemId,product.Name,product.Quantity,product.Description,product.Price,product.location);
                        modified(product.Name);
                        inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                        inventoryViewModel.CurrentProduct = new ProductModel();
                        break;
                    }
                }
            }
            else
            {
                error();
            }
        }

        private void modified(string name)
        {
            bool? Result = new MessageBoxCustom("The product " + name + " has been modified.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("The product has not been modified, check the values.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public InventoryViewModel inventoryViewModel { get; set; }

        public ModifyProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
