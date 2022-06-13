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
           if (supplier.Name is null || supplier.Name.Equals(""))
            {
                name();
                
            }
            else if (supplier.Telephone is null || supplier.Telephone.Equals(""))
            {
                telephone();
               
            }
            else if (supplier.Email is null || supplier.Email.Equals(""))
            {
                email();
               
            }
            else if (supplier.NIF is null || supplier.NIF.Equals("") || supplier.NIF.Length < 10)
            {
                nif();
                
            }
            else
            {
                if (supplier != null)
                {
                    foreach (SupplierModel s in supplierViewModel.SupplierList)
                    {
                        if (s.SupplierId.Equals(supplier.SupplierId))
                        {
                            DataSetHandler.modifySupplier(supplier.SupplierId, supplier.Name, supplier.Telephone, supplier.Email, supplier.NIF);
                            modified(supplier.Name);
                            supplierViewModel.SupplierList = DataSetHandler.GetSuppliers();
                            supplierViewModel.CurrentSupplier = new SupplierModel();
                            break;
                        }
                    }
                }
                else
                {
                    error();
                }
            }
           
        }

        private void modified(string name)
        {
            bool? Result = new MessageBoxCustom("The supplier " + name + " has been modified.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("The supplier has not been modified, check the values.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void name()
        {
            bool? Result = new MessageBoxCustom("Please, check the supplier name", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void telephone()
        {
            bool? Result = new MessageBoxCustom("Please, check the supplier telephone", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void email()
        {
            bool? Result = new MessageBoxCustom("Please, check the supplier email", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void nif()
        {
            bool? Result = new MessageBoxCustom("Please, check the supplier nif", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public SupplierViewModel supplierViewModel { get; set; }
        public ModifySupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
