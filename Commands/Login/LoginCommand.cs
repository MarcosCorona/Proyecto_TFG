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
        
            //metodo que se ejecuta al logearse
            ObservableCollection<PersonModel> personsList = DataSetHandler.GetPerson();

            PasswordBox pw = (PasswordBox)parameter;

            string passw = pw.Password;

            //validación del usuario y de la contraseña
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
                //por cada persona/usuario que este registrado
                foreach (PersonModel p in personsList)
                {
                    //si el usuario y la contraseña coinciden.
                    if (p.username == loginViewModel.username && p.password == passw)
                    {
                        //se conectará a la applicación
                        BTLOGT(p.name);
                        loginViewModel.UpdateViewCommand.Execute("home");
                        passok = true;
                        //definimos el empleado conectado para poder usarlo en el codigo XAML, el que eligirá las limitaciones del usuario.
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
        //respuestas.
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
