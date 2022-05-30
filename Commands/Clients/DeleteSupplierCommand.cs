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

namespace Proyecto_TFG.Commands.Clients
{
    class DeleteSupplierCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SupplierModel supplier = supplierViewModel.CurrentSupplier;
            if (supplier != null)
            {
                foreach (SupplierModel c in supplierViewModel.SupplierList)
                {
                    if (c.SupplierId.Equals(supplier.SupplierId))
                    {
                        DataSetHandler.deleteSupplier(supplier.SupplierId);
                        MessageBox.Show("The supplier " + supplier.Name + " has been deleted.");
                        supplierViewModel.SupplierList = DataSetHandler.GetSuppliers();
                        supplierViewModel.CurrentSupplier = new SupplierModel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error deleting the supplier, please try again.");
            }
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public DeleteSupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
