using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Supplier
{
    class LoadSupplierCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                SupplierModel supplier = (SupplierModel)parameter;

                supplierViewModel.CurrentSupplier = (SupplierModel)supplier.Clone();

                supplierViewModel.SelectedSupplier = (SupplierModel)supplier.Clone();
            }
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public LoadSupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
