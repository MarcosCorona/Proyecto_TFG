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
    class CreateSupplierCommand : ICommand
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
                   if (supplier.Name is null || supplier.Name.Equals(""))
                    {
                        name();
                        break;
                    }
                    else if (supplier.Telephone is null || supplier.Telephone.Equals(""))
                    {
                        telephone();
                        break;
                    }
                    else if (supplier.Email is null || supplier.Email.Equals(""))
                    {
                        email();
                        break;
                    }
                    else if (supplier.NIF is null || supplier.NIF.Equals("") || supplier.NIF.Length < 10)
                    {
                        nif();
                        break;
                    }
                    else
                    {
                        DataSetHandler.insertSupplier(supplier.SupplierId, supplier.Name, supplier.Telephone, supplier.Email, supplier.NIF);
                        supplierViewModel.SupplierList = DataSetHandler.GetSuppliers();
                        supplierViewModel.CurrentSupplier = new SupplierModel();
                        created(supplier.Name);
                        break;
                    }
                }
            }
            else
            {
                gerror();
            }
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

        private void created(string name)
        {
            bool? Result = new MessageBoxCustom("The supplier " + name + " has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error creating the supplier, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public SupplierViewModel supplierViewModel { get; set; }
        public CreateSupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
