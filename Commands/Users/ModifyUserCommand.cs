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
    class ModifyUserCommand : ICommand
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
                        DataSetHandler.modifyUser(user.dni, user.name, user.lastname, user.email, user.password,user.birthday,user.job,user.address,user.city);
                        modified(user.name);
                        usersViewModel.UserList = DataSetHandler.GetPerson();
                        usersViewModel.CurrentUser = new PersonModel();
                        break;
                    }
                }
            }
            else
            {
                error();
            }
        }

        private void modified(string name)
        {
            bool? Result = new MessageBoxCustom("The user " + name + " has been modified.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void error()
        {
            bool? Result = new MessageBoxCustom("The supplier has not been user, check the values.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public UsersViewModel usersViewModel { get; set; }
        public ModifyUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
