using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using Proyecto_TFG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Proyecto_TFG.Commands
{
    class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public PersonModel person { get; set; }

        public void Execute(object parameter)
        {
        
            ObservableCollection<PersonModel> personsList = DataSetHandler.GetPerson();

            PasswordBox pw = (PasswordBox)parameter;

            string passw = pw.Password;

            
            if(passw == "" || passw is null)
            {
                passneeded();
            }
            else if(loginViewModel.username is null || loginViewModel.Equals(""))
            {
                userneeded();
            }
            else {
                bool passok = false;
                foreach (PersonModel p in personsList)
                {
                    if (p.username == loginViewModel.username && p.password == passw)
                    {
                        BTLOGT(p.name);
                        loginViewModel.UpdateViewCommand.Execute("home");
                        passok = true;
                        DataSetHandler.setUser(p);
                        break;
                    }
                    else
                    {
                        passok = false;
                    }
                }

                if(passok != true)
                {
                    BTUSERF();
                }
            }

        }
        private void BTLOGT(string name)
        {
            bool? Result = new MessageBoxCustom("Welcome " + name + " !!", MessageType.Success, MessageButtons.Ok).ShowDialog();
        }
        private void BTUSERF()
        {
            bool? Result = new MessageBoxCustom("Please, check your username or password.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void userneeded()
        {
            bool? Result = new MessageBoxCustom("Username is needed.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void passneeded()
        {
            bool? Result = new MessageBoxCustom("Password is needed.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }


        public LoginViewModel loginViewModel { get; set; }
        public LoginCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }




    }
}
