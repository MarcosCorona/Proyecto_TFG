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

             foreach (PersonModel p in personsList)
             {
               if (p.name == loginViewModel.username && p.password == parameter.ToString())
               {
                    loginViewModel.UpdateViewCommand.Execute("home");
                }
                else
                {
                    loginViewModel.UpdateViewCommand.Execute("home");
                    MessageBox.Show("Login incorrecto, por favor vuelva a intentarlo.");
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
