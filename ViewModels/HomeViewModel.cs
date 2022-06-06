using Proyecto_TFG.Commands;
using Proyecto_TFG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }

        public ICommand LoginCommand { get; set; }  

        public ICommand UpdateViewCommandV2 { get; set; }


        public LoginCommand loginCommand { get; set; }

        public UpdateViewCommand UpdateViewCommand { set; get; }
        public HomeViewModel(UpdateViewCommand updateViewCommand)
        {
            UpdateViewCommandV2 = new UpdateViewCommandV2(this);
            UpdateViewCommand = updateViewCommand;
        }
    }
}
