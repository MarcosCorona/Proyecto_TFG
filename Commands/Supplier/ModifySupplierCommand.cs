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

namespace Proyecto_TFG.Commands.Supplier
{
    class ModifySupplierCommand : ICommand
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
                foreach (SupplierModel s in supplierViewModel.SupplierList)
                {
                    if (s.SupplierId.Equals(supplier.SupplierId))
                    {
                        DataSetHandler.modifySupplier(supplier.SupplierId, supplier.Name, supplier.Telephone, supplier.Email, supplier.NIF);
                        MessageBox.Show("The supplier " + supplier.Name + " has been modified.");
                        supplierViewModel.SupplierList = DataSetHandler.GetSuppliers();
                        supplierViewModel.CurrentSupplier = new SupplierModel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error modifying the product, please try again.");
            }
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public ModifySupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
