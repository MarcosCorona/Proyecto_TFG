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
                        MessageBox.Show("The user " + user.name + " has been modified.");
                        usersViewModel.UserList = DataSetHandler.GetPerson();
                        usersViewModel.CurrentUser = new PersonModel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error modifying the user, please try again.");
            }
        }
        public UsersViewModel usersViewModel { get; set; }
        public ModifyUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
