using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using Proyecto_TFG.Views;
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
                        deleted(user.name);
                        usersViewModel.UserList = DataSetHandler.GetPerson();
                        usersViewModel.CurrentUser = new PersonModel();
                        break;
                    }
                }
            }
            else
            {
                gerror();
            }
        }

        private void deleted(string name)
        {
            bool? Result = new MessageBoxCustom("The user " + name + " has been deleted", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error deleting the user, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public UsersViewModel usersViewModel { get; set; }
        public DeleteUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
