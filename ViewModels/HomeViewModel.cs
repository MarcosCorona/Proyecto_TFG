using Proyecto_TFG.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.ViewModels
{
    class HomeViewModel:ViewModelBase
    {
        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }

        public ICommand UpdateViewCommandv2 { get; set; }



        public HomeViewModel()
        {
            UpdateViewCommandv2 = new UpdateViewCommandV2(this);

        }
    }
}
