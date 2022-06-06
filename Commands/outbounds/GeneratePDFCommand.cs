using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
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
                if (outbound.OrderId > 0)
                {
                    outboundViewModel.updateViewCommandv2.pDFViewModel.generatePDF(outbound.OrderId);

                    outboundViewModel.updateViewCommandv2.Execute("pdfOutbound");

                }
                else
                {
                    MessageBox.Show("Select an outbound.");
                }

            }
        }

        public OutboundViewModel outboundViewModel { get; set; }
        public GeneratePDFCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
