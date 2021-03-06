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

            int age = (DateTime.Today.Year - user.birthday.Year);
            bool findOk = true; 

            if (user != null)
            {
                foreach (PersonModel u in usersViewModel.UserList)
                {
                    if (u.dni.Equals(user.dni))
                    {
                        findOk = true;
                        dniSearched();
                    }
                    else
                    {
                        findOk = false;
                    }
                   
                }
                if (findOk == false)
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
                    else if (user.birthday > DateTime.Today || user.birthday.Equals(""))
                    {
                        birthday();
                    }
                    else if (age < 18)
                    {
                        birthday2();
                    }
                    else if (age > 70)
                    {
                        birthday3();
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
                        usern();
                    }
                    else
                    {

                        DataSetHandler.insertUser(user.dni, user.name, user.lastname, user.email, user.password, user.birthday, user.job, user.address, user.city, user.username);
                        usersViewModel.UserList = DataSetHandler.GetPerson();
                        usersViewModel.CurrentUser = new PersonModel();
                        created(user.name);
                    }
                }
               
            }
            else
            {
                gerror();
            }
        }
        private void dni()
        {
            bool? Result = new MessageBoxCustom("Please, check the user dni.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void dniSearched()
        {
            bool? Result = new MessageBoxCustom("The user already exists.", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
        private void birthday2()
        {
            bool? Result = new MessageBoxCustom("The user age can't be lower than 18.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void birthday3()
        {
            bool? Result = new MessageBoxCustom("The user age can't be greater than 70.", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
        private void usern()
        {
            bool? Result = new MessageBoxCustom("Please, check the user username", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }


        private void created(string name)
        {
            bool? Result = new MessageBoxCustom("The user " + name + " has been created.", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void gerror()
        {
            bool? Result = new MessageBoxCustom("Error creating the user, please try again.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        public UsersViewModel usersViewModel { get; set; }
        public CreateUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
