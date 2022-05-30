using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
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
            OutboundModel order = (OutboundModel)parameter;
            if (order != null)
            {
                foreach (OutboundModel o in outboundViewModel.OutboundList)
                {
                    if(o.OrderId == order.OrderId)
                    {
                        ObservableCollection<OutboundDetailModel> detailList = new ObservableCollection<OutboundDetailModel>();
                        detailList = DataSetHandler.getDetails();
                        foreach(OutboundDetailModel detail in detailList)
                        {
                            DataSetHandler.removeDetail((int)order.OrderId);
                        }
                        DataSetHandler.removeOutbound((int)order.OrderId);
                        outboundViewModel.OutboundList = DataSetHandler.GetOutbounds();
                        MessageBox.Show("Order deleted.");
                    }
                }
            }

        }

        public OutboundViewModel outboundViewModel { get; set; }
        public DeleteOutboundCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
