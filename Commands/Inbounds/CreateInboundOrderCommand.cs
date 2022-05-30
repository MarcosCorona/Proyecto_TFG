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
            SupplierModel s = inboundViewModel.Supplier;

            double total = 0;
            foreach (ProductModel p in inboundViewModel.CharList)
            {
                total = p.Total + total;
            }

            DateTime date = DateTime.Today;

            if (s is null)
            {
                MessageBox.Show("Select a client.");
            }
            else if (total <= 0)
            {
                MessageBox.Show("Total is 0, please, select a product.");
            }
            else
            {
                bool okInsertar = DataSetHandler.insertInbound(s.SupplierId, date, total);
                if (okInsertar)
                {
                    foreach (ProductModel p in inboundViewModel.CharList)
                    {
                        DataSetHandler.insertDetail(p.ItemId, p.Description, p.Quantity, p.Price);
                    }
                    MessageBox.Show("Outbound order has been created.");
                    inboundViewModel.InboundList = DataSetHandler.GetInbounds();
                }
                else
                {
                    MessageBox.Show("There is a problem creating the order, please check again.");
                }
            }
        }
        public InboundViewModel inboundViewModel { get; set; }
        public CreateInboundOrderCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
