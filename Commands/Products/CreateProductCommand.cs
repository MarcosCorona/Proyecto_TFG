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
    class CreateProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductModel product = inventoryViewModel.CurrentProduct;
            if(product != null)
            {
                foreach (ProductModel p in inventoryViewModel.ProductsList)
                {
                    if (p.ItemId.Equals(product.ItemId))
                    {
                        MessageBox.Show("The product already exists.");
                        break;
                    }
                    else
                    {
                        DataSetHandler.insertProduct(product.ItemId, product.Name, product.Quantity, product.Price, product.Description);
                        inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                        inventoryViewModel.CurrentProduct = new ProductModel();
                        MessageBox.Show("`The product " + product.Name +" has been created.");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error creating the product, please try again.");
            }
            
        }

        public InventoryViewModel inventoryViewModel { get; set; }

        public CreateProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
