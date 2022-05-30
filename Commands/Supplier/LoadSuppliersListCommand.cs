using Proyecto_TFG.Handlers;
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
    class LoadSuppliersListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString().Equals("inbounds"))
            {
                inboundViewModel.SupplierList = DataSetHandler.GetSuppliers();
                if (inboundViewModel.SupplierList is null)
                {
                    MessageBox.Show("There are no suppliers to show.");
                }
            }else if (parameter.ToString().Equals("suppliers"))
            {
                supplierViewModel.SupplierList = DataSetHandler.GetSuppliers();
                if (supplierViewModel.SupplierList is null)
                {
                    MessageBox.Show("There are no suppliers to show.");
                }
            }
            
        }

        public InboundViewModel inboundViewModel { get; set; }
        public LoadSuppliersListCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }

        public SupplierViewModel supplierViewModel { get; set; }
        public LoadSuppliersListCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }

    }
}
