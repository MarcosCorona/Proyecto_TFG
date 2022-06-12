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
                    if (product.ItemId.Equals(product.ItemId) || product.ItemId.Equals(""))
                    {
                        id();
                        break;
                    }
                    else if (p.Name is null || p.Name.Equals(""))
                    {
                        name();
                        break;
                    }
                    else if (p.Quantity < 0 || p.Quantity.Equals(""))
                    {
                        quantity();
                        break;
                    }
                    else if (p.Price < 0 || p.Price.Equals(""))
                    {
                        price();
                        break;
                    }
                    else if (p.Description is null || p.Description.Equals(""))
                    {
                        description();
                        break;
                    }
                    else
                    {
                        DataSetHandler.insertProduct(product.ItemId, product.Name, product.Quantity, product.Price, product.Description,product.location);
                        inventoryViewModel.ProductsList = DataSetHandler.GetProducts();
                        inventoryViewModel.CurrentProduct = new ProductModel();
                        created(product.Name);
                        break;
                    }
                }
            }
            else
            {
                gerror();
            }
            
        }
        private void id()
        {
            bool? Result = new MessageBoxCustom("Please, check the product id", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void name()
        {
            bool? Result = new MessageBoxCustom("Please, check the product name", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void quantity()
        {
            bool? Result = new MessageBoxCustom("Please, check the product telephone", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void price()
        {
            bool? Result = new MessageBoxCustom("Please, check the product email", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void description()
        {
            bool? Result = new MessageBoxCustom("Please, check the product nif", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void created(string name)
        {
            bool? Result = new MessageBoxCustom("The product " + name + " has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error creating the product, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public InventoryViewModel inventoryViewModel { get; set; }

        public CreateProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
