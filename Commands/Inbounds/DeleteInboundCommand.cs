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

namespace Proyecto_TFG.Commands.Inbounds
{
    class DeleteInboundCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InboundModel order = (InboundModel)parameter;
            if (order != null)
            {
                foreach (InboundModel o in inboundViewModel.InboundList)
                {
                    if (o.OrderId == order.OrderId)
                    {
                        ObservableCollection<InboundDetailModel> detailList = new ObservableCollection<InboundDetailModel>();
                        detailList = DataSetHandler.getInboundDetails();
                        foreach (InboundDetailModel detail in detailList)
                        {
                            DataSetHandler.removeInboundDetail((int)order.OrderId);
                        }
                        DataSetHandler.removeInbound((int)order.OrderId);
                        inboundViewModel.InboundList = DataSetHandler.GetInbounds();
                        MessageBox.Show("Order deleted.");
                    }
                }
            }
        }
        public InboundViewModel inboundViewModel { get; set; }
        public DeleteInboundCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
