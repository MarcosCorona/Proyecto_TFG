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
                ssupplier();
            }      
            else if (total <= 0)
            {
                charlist();
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
                    ocreated();
                    outboundViewModel.OutboundList = DataSetHandler.GetOutbounds();
                }
                else
                {
                    error();
                }
            }
        }

        private void ssupplier()
        {
            bool? Result = new MessageBoxCustom("Select a supplier.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void charlist()
        {
            bool? Result = new MessageBoxCustom("Your product list is empty.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void ocreated()
        {
            bool? Result = new MessageBoxCustom("Outbound order has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("There is a problem creating the order, please check again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public OutboundViewModel outboundViewModel { get; set; }
        public CreateOutboundOrderCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
