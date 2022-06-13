using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using Proyecto_TFG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Inbounds
{
    class CreateInboundOrderCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //metodo para crear un albaran de entrada.
            //atributos
            SupplierModel s = inboundViewModel.Supplier;

            double total = 0;

            //por cada producto calculamos el total del albaran
            foreach (ProductModel p in inboundViewModel.CharList)
            {
                total = p.Total + total;
            }
            //establecemos la fecha de creacion
            DateTime date = DateTime.Today;

            //se validan las casillas de proveedor y total
            if (s is null)
            {
                sclient();
            }
            else if (total <= 0)
            {
                charlist();
            }
            else
            {
                //si todo es correcto se inserta el albaran
                bool okInsertar = DataSetHandler.insertInbound(s.SupplierId, date, total);
                if (okInsertar)
                {
                    //por cada producto que existe en la lista del carrito se guardará un detalle asociado a ese albarán.
                    foreach (ProductModel p in inboundViewModel.CharList)
                    {
                        DataSetHandler.insertInboundDetail(p.ItemId, p.Description, p.Quantity, p.Price);
                    }
                    //dejamos la lista vacía
                    inboundViewModel.CharList = new ObservableCollection<ProductModel>();
                    //mensaje de creacion
                    ocreated();
                    //cargamos los albaranes
                    inboundViewModel.InboundList = DataSetHandler.GetInbounds();
                }
                else
                {
                    error();
                }
            }
        }

        private void sclient()
        {
            bool? Result = new MessageBoxCustom("Select a client.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void charlist()
        {
            bool? Result = new MessageBoxCustom("Your product list is empty.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void ocreated()
        {
            bool? Result = new MessageBoxCustom("Inbound order has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("There is a problem creating the order, please check again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public InboundViewModel inboundViewModel { get; set; }
        public CreateInboundOrderCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
