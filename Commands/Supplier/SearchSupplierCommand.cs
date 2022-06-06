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

namespace Proyecto_TFG.Commands.Supplier
{
    class SearchSupplierCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int searchedId = supplierViewModel.searchedId;
            bool searchedok = false;
            if (searchedId != null)
            {
                foreach (SupplierModel s in supplierViewModel.SupplierList)
                {
                    if (s.SupplierId.Equals(searchedId))
                    {
                        supplierViewModel.CurrentSupplier = s;
                        searchedok = true;
                        break;
                    }
                    else
                    {
                        searchedok = false;
                    }
                }
                if (searchedok == false)
                {
                    dexists();
                }
            }
            else
            {
                error();
            }
        }

        private void dexists()
        {
            bool? Result = new MessageBoxCustom("The supplier doesn't exists", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("Error searching the supplier, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public SearchSupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
