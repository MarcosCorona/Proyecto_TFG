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
    class CreateUserCommand : ICommand
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
                        MessageBox.Show("The user already exists.");
                        break;
                    }
                    else
                    {

                        DataSetHandler.insertUser(user.dni, user.name, user.lastname, user.email, user.password,user.birthday,user.job,user.address,user.city);
                        usersViewModel.UserList = DataSetHandler.GetPerson();
                        usersViewModel.CurrentUser = new PersonModel();
                        MessageBox.Show("`The user " + user.name + " has been created.");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error creating the user, please try again.");
            }
        }

        public UsersViewModel usersViewModel { get; set; }
        public CreateUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
