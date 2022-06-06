﻿using Proyecto_TFG.Handlers;
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

        private void modified(string name)
        {
            bool? Result = new MessageBoxCustom("The supplier " + name + " has been modified.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("The supplier has not been modified, check the values.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public SupplierViewModel supplierViewModel { get; set; }
        public ModifySupplierCommand(SupplierViewModel supplierViewModel)
        {
            this.supplierViewModel = supplierViewModel;
        }
    }
}
