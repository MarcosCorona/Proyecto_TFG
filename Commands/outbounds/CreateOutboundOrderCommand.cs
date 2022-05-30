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

namespace Proyecto_TFG.Commands
{
    class CreateOutboundOrderCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClientModel c = outboundViewModel.Client;

            double total = 0;
            foreach (ProductModel p in outboundViewModel.CharList)
            {
                total = p.Total + total;
            }

            

            DateTime date = DateTime.Today;

            if (c is null)
            {
                MessageBox.Show("Select a client.");
            }      
            else if (total <= 0)
            {
                MessageBox.Show("Total is 0, please, select a product.");
            }
            else
            {
                bool okInsertar = DataSetHandler.insertOutbound(c.ClientId, date, total);
                if (okInsertar)
                {
                   foreach (ProductModel p in outboundViewModel.CharList)
                   {
                            DataSetHandler.insertDetail(p.ItemId, p.Description, p.Quantity, p.Price);
                   }
                    MessageBox.Show("Outbound order has been created.");
                    outboundViewModel.OutboundList = DataSetHandler.GetOutbounds();
                }
                else
                {
                    MessageBox.Show("There is a problem creating the order, please check again.");
                }
            }
        }
        public OutboundViewModel outboundViewModel { get; set; }
        public CreateOutboundOrderCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
