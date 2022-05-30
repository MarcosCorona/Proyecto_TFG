using Proyecto_TFG.Handlers;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Inbounds
{
    class LoadInboundsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            inboundViewModel.InboundList = DataSetHandler.GetInbounds();
        }

        public InboundViewModel inboundViewModel { get; set; }
        public LoadInboundsCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    }
}
