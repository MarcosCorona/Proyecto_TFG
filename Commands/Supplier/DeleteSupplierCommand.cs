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
                        deleted(supplier.Name);
                        supplierViewModel.SupplierList = DataSetHandler.GetSuppliers();
                        supplierViewModel.CurrentSupplier = new SupplierModel();
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
            bool? Result = new MessageBoxCustom("The supplier " + name + " has been deleted", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error deleting the supplier, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public DeleteSupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
