using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
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
                        DataSetHandler.modifyProduct(product.ItemId,product.Name,product.Quantity,product.Description,product.Price);
                        MessageBox.Show("The product " + product.Name + " has been modified.");
                        inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                        inventoryViewModel.CurrentProduct = new ProductModel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error modifying the product, please try again.");
            }
        }
        public InventoryViewModel inventoryViewModel { get; set; }

        public ModifyProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
