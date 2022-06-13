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
    class DeleteProductCommand : ICommand
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
                        
                        DataSetHandler.deleteProduct(product.ItemId);
                        deleted(p.Name);
                        inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                        inventoryViewModel.CurrentProduct = new ProductModel();

                        break;
                    }
                }
            }
            else
            {
                gerror();
            }
        }

        private void deleted(string name)
        {
            bool? Result = new MessageBoxCustom("The product " + name + " has been deleted", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }

        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error deleting the product, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public InventoryViewModel inventoryViewModel { get; set; }

        public DeleteProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
