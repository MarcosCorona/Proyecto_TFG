using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
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
    class DeleteUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PersonModel user = usersViewModel.CurrentUser;
            if (user != null)
            {
                foreach (PersonModel u in usersViewModel.UserList)
                {
                    if (u.dni.Equals(user.dni))
                    {
                        DataSetHandler.deleteUser(user.dni);
                        MessageBox.Show("The user " + user.name + " has been deleted.");
                        usersViewModel.UserList = DataSetHandler.GetPerson();
                        usersViewModel.CurrentUser = new PersonModel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error deleting the client, please try again.");
            }
        }
        public UsersViewModel usersViewModel { get; set; }
        public DeleteUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
