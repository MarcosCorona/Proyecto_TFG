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

        public InboundViewModel inboundViewModel { get; set; }
        public DeleteInboundCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
