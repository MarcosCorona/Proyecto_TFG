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
    class SearchProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int searchedId = inventoryViewModel.searchedId;
            bool searchedok = false;
            if (searchedId != null)
            {
                foreach (ProductModel p in inventoryViewModel.ProductsList)
                {
                    if (p.ItemId.Equals(searchedId))
                    {
                        inventoryViewModel.CurrentProduct = p;
                        searchedok = true;
                        break;
                    }
                    else
                    {
                        searchedok = false;
                    }
                }
                if(searchedok == false)
                {
                    MessageBox.Show("The product doesn't exists");
                }
            }
            else
            {
                MessageBox.Show("Error searching the product, please try again.");
            }
        }
        public InventoryViewModel inventoryViewModel { get; set; }

        public SearchProductCommand(InventoryViewModel inventoryViewModel)
        {
            this.inventoryViewModel = inventoryViewModel;
        }
    }
}
