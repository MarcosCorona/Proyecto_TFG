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

namespace Proyecto_TFG.Commands.Inbounds
{
    class GenerateInbPDFCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InboundModel inbound = (InboundModel)parameter;
            if (inbound != null)
            {
                if (inbound.OrderId > 0)
                {
                    inboundViewModel.updateViewCommandv2.pDFViewModel.generateInbPDF(inbound.OrderId);

                    inboundViewModel.updateViewCommandv2.Execute("pdfInbound");
                }
            }
            else
            {
                gerror();
            }
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Select an order.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public InboundViewModel inboundViewModel { get; set; }
        public GenerateInbPDFCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
