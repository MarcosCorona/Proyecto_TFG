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

namespace Proyecto_TFG.Commands.outbounds
{
    class DeleteOutboundCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //metodo para borrar un albaran.
            OutboundModel order = (OutboundModel)parameter;
            if (order != null)
            {
                //por cada albaran de salida
                foreach (OutboundModel o in outboundViewModel.OutboundList)
                {
                    //si coincide con el id del solicitado para borrar
                    if (o.OrderId == order.OrderId)
                    {
                        ObservableCollection<OutboundDetailModel> detailList = new ObservableCollection<OutboundDetailModel>();
                        detailList = DataSetHandler.getDetails();
                        //se borra el detalle
                        foreach (OutboundDetailModel detail in detailList)
                        {
                            DataSetHandler.removeDetail((int)order.OrderId);
                        }
                        //se borra el albaran
                        DataSetHandler.removeOutbound((int)order.OrderId);
                        outboundViewModel.OutboundList = DataSetHandler.GetOutbounds();
                        success();
                    }
                  
                }
            }
            else
            {
                gerror();
            }
        }

        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error deleting the order, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void success()
        {
            bool? Result = new MessageBoxCustom("Order deleted.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }

        public OutboundViewModel outboundViewModel { get; set; }
        public DeleteOutboundCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
