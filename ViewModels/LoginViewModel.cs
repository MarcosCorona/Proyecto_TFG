using Proyecto_TFG.Commands;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Controls;
using System.Windows.Input;

namespace Proyecto_TFG.ViewModels
{
    class LoginViewModel : ViewModelBase
    {

        public string username { get; set; }
        public PasswordBox password { get; set; }

        public UpdateViewCommand UpdateViewCommand { set; get; }

        public LoginCommand LoginCommand { set; get; }

        private PersonModel currentPerson {get;set;}
        public PersonModel CurrentPerson
        {
            get { return currentPerson; }
            set
            {
                currentPerson = value;
                OnPropertyChanged(nameof(CurrentPerson));
            }
        }
        public LoginViewModel(UpdateViewCommand updateViewCommand )
        {
            UpdateViewCommand = updateViewCommand;
            LoginCommand = new LoginCommand(this);
        }
    }

}
