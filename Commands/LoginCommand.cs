using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
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
        
        public void Execute(object parameter)
        {
        
            ObservableCollection<PersonModel> personsList = DataSetHandler.GetPerson();

            PasswordBox pw = (PasswordBox)parameter;

            string passw = pw.Password;

            //Para un futuro, tengo que crear un nombre de usuario, modificable, de esta forma si dos usuarios se llaman igual no se colapsará.
            if(passw == "" || passw is null)
            {
                MessageBox.Show("Password is needed.");
            }
            else if(loginViewModel.username is null || loginViewModel.Equals(""))
            {
                MessageBox.Show("Username is needed.");
            }
            else {
                bool passok = false;
                foreach (PersonModel p in personsList)
                {
                    if (p.name == loginViewModel.username && p.password == passw)
                    {
                        MessageBox.Show("Welcome " + p.name + "!!");
                        loginViewModel.UpdateViewCommand.Execute("home");
                        passok = true;
                        break;
                    }
                    else
                    {
                        passok = false;
                    }
                }

                if(passok != true)
                {
                    MessageBox.Show("Please, check your user or password.");
                }
            }

        }
        public LoginViewModel loginViewModel { get; set; }
        public LoginCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }




    }
}
