using Proyecto_TFG.Handlers;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.outbounds
{
    class LoadOutboundsCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            outboundViewModel.OutboundList = DataSetHandler.GetOutbounds();
        }

        public OutboundViewModel outboundViewModel { get; set; }
        public LoadOutboundsCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
