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
                if (user.name is null || user.name.Equals(""))
                {
                    name();
          
                }
                else if (user.lastname is null || user.lastname.Equals(""))
                {
                    lname();
               
                }
                else if (user.email is null || user.email.Equals(""))
                {
                    email();
           
                }
                else if (user.password is null || user.password.Equals(""))
                {
                    password();
              
                }
                else if (user.birthday < DateTime.Today || user.birthday.Equals(""))
                {
                    birthday();
                
                }
                else if (user.job is null || user.job.Equals(""))
                {
                    job();
                
                }
                else if (user.address is null || user.address.Equals(""))
                {
                    address();
                    
                }
                else if (user.city is null || user.city.Equals(""))
                {
                    city();
                   
                }
                else if (user.username is null || user.username.Equals(""))
                {
                    city();
                  
                }
                else
                {
                    foreach (PersonModel u in usersViewModel.UserList)
                    {
                        if (u.dni.Equals(user.dni))
                        {
                            DataSetHandler.modifyUser(user.dni, user.name, user.lastname, user.email, user.password, user.birthday, user.job, user.address, user.city, user.username);
                            modified(user.name);
                            usersViewModel.UserList = DataSetHandler.GetPerson();
                            usersViewModel.CurrentUser = new PersonModel();
                            break;
                        }
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
        private void name()
        {
            bool? Result = new MessageBoxCustom("Please, check the user name", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void lname()
        {
            bool? Result = new MessageBoxCustom("Please, check the user last name", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void password()
        {
            bool? Result = new MessageBoxCustom("Please, check the user password", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void email()
        {
            bool? Result = new MessageBoxCustom("Please, check the user email", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void birthday()
        {
            bool? Result = new MessageBoxCustom("Please, check the user birthday", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void job()
        {
            bool? Result = new MessageBoxCustom("Please, check the user job", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void address()
        {
            bool? Result = new MessageBoxCustom("Please, check the user address", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void city()
        {
            bool? Result = new MessageBoxCustom("Please, check the user city", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public UsersViewModel usersViewModel { get; set; }
        public ModifyUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
