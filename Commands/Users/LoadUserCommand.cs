using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Users
{
    class LoadUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                PersonModel user = (PersonModel)parameter;

                usersViewModel.CurrentUser = (PersonModel)user.Clone();

                usersViewModel.SelectedUser = (PersonModel)user.Clone();
            }
        }
        public UsersViewModel usersViewModel { get; set; }
        public LoadUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
