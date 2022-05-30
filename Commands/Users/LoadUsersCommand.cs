using Proyecto_TFG.Handlers;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_TFG.Commands.Users
{
    class LoadUsersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            usersViewModel.UserList = DataSetHandler.GetPerson();
            if (usersViewModel.UserList is null)
            {
                MessageBox.Show("There are no users to show.");
            }
        }
        public UsersViewModel usersViewModel { get; set; }
        public LoadUsersCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
