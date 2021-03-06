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
            char firstL = product.location.ElementAt(0);
            if (product.Name is null || product.Name.Equals(""))
            {
                name();

            }
            else if (product.Quantity <= 0 || product.Quantity.Equals(""))
            {
                quantity();
            }
            else if (product.Price <= 0 || product.Price.ToString().Equals(""))
            {
                price();
            }
            else if (product.Description is null || product.Description.Equals(""))
            {
                description();
            }
            else if (product.location is null || product.location.Equals(""))
            {
                glocation();
            }
            else
            {
                if (product.location.ElementAt(0).ToString().Contains('H'))
                {
                    foreach (ProductModel p in inventoryViewModel.ProductsList)
                    {
                        if (p.ItemId.Equals(product.ItemId))
                        {
                            DataSetHandler.modifyProduct(product.ItemId, product.Name, product.Quantity, product.Description, product.Price, product.location);
                            modified(product.Name);
                            inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                            inventoryViewModel.CurrentProduct = new ProductModel();
                            break;
                        }
                    }
                }else if (product.location.ElementAt(0).ToString().Contains('P'))
                {
                    foreach (ProductModel p in inventoryViewModel.ProductsList)
                    {
                        if (p.ItemId.Equals(product.ItemId))
                        {
                            DataSetHandler.modifyProduct(product.ItemId, product.Name, product.Quantity, product.Description, product.Price, product.location);
                            modified(product.Name);
                            inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                            inventoryViewModel.CurrentProduct = new ProductModel();
                            break;
                        }
                    }
                }
                else
                {
                    glocation2();
                }
                
            }
         
        }

        private void name()
        {
            bool? Result = new MessageBoxCustom("Please, check the product name", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void quantity()
        {
            bool? Result = new MessageBoxCustom("Please, check the product quantity", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void price()
        {
            bool? Result = new MessageBoxCustom("Please, check the product price", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
  
        private void description()
        {
            bool? Result = new MessageBoxCustom("Please, check the product description", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void created(string name)
        {
            bool? Result = new MessageBoxCustom("The product " + name + " has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error creating the product, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void glocation()
        {
            bool? Result = new MessageBoxCustom("Please, check the product location", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void glocation2()
        {
            bool? Result = new MessageBoxCustom("Location must start with H (Height) or P (Picking)", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void modified(string name)
        {
            bool? Result = new MessageBoxCustom("The product " + name + " \n has been modified.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
