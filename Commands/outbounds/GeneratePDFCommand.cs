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

namespace Proyecto_TFG.Commands.outbounds
{
    class GeneratePDFCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OutboundModel outbound = (OutboundModel)parameter;
            if (outbound != null)
            {
                //metodo para generar pdf's
                if (outbound.OrderId > 0)
                {
                    //enviamos el id del inbound seleccionado para generar el pdf.
                    outboundViewModel.updateViewCommandv2.pDFViewModel.generatePDF(outbound.OrderId);

                    //cambiamos de vista a la que está diseñada para ver los pdf.
                    outboundViewModel.updateViewCommandv2.Execute("pdfOutbound");

                }
                else
                {
                    gerror();
                }
            }
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Select an order.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public OutboundViewModel outboundViewModel { get; set; }
        public GeneratePDFCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
