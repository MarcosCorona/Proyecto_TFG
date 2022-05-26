using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands
{
    class UpdateViewCommandV2 : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                string viewName = (string)parameter;

                if (viewName.Equals("outbound"))
                {
                    homeViewModel.SelectedViewModel = new OutboundViewModel(this);
                }
                else if (viewName.Equals("inventory"))
                {
                    homeViewModel.SelectedViewModel = new InventoryViewModel(this);
                }
            }
        }

        public HomeViewModel homeViewModel { get; set; }

        public UpdateViewCommandV2(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
    }
}
