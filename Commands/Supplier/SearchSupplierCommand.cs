using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
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
                    MessageBox.Show("The supplier doesn't exists");
                }
            }
            else
            {
                MessageBox.Show("Error searching the supplier, please try again.");
            }
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public SearchSupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
