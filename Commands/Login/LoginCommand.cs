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

        public HomeView view = new HomeView(); 
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
                        if(p.job == "RRHH")
                        {
                            view.outboundsbt.Visibility = Visibility.Collapsed;
                            view.inboundsbt.Visibility = Visibility.Collapsed;
                            view.inventorybt.Visibility = Visibility.Collapsed;
                            view.clientsbt.Visibility = Visibility.Collapsed;
                            view.suppliersbt.Visibility = Visibility.Collapsed;
                            view.employeesbt.Visibility = Visibility.Visible;
                        }else if (p.job.Equals("Administrative"))
                        {
                            view.outboundsbt.Visibility = Visibility.Visible;
                            view.inboundsbt.Visibility = Visibility.Visible;
                            view.inventorybt.Visibility = Visibility.Collapsed;
                            view.clientsbt.Visibility = Visibility.Visible;
                            view.suppliersbt.Visibility = Visibility.Visible;
                            view.employeesbt.Visibility = Visibility.Visible;
                        }else if (p.job.Equals("Stock"))
                        {
                            view.outboundsbt.Visibility = Visibility.Collapsed;
                            view.inboundsbt.Visibility = Visibility.Collapsed;
                            view.inventorybt.Visibility = Visibility.Visible;
                            view.clientsbt.Visibility = Visibility.Collapsed;
                            view.suppliersbt.Visibility = Visibility.Collapsed;
                            view.employeesbt.Visibility = Visibility.Collapsed;
                        }else if (p.job.Equals("Boss"))
                        {
                            view.outboundsbt.Visibility = Visibility.Visible;
                            view.inboundsbt.Visibility = Visibility.Visible;
                            view.inventorybt.Visibility = Visibility.Visible;
                            view.clientsbt.Visibility = Visibility.Visible;
                            view.suppliersbt.Visibility = Visibility.Visible;
                            view.employeesbt.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            view.outboundsbt.Visibility = Visibility.Collapsed;
                            view.inboundsbt.Visibility = Visibility.Collapsed;
                            view.inventorybt.Visibility = Visibility.Collapsed;
                            view.clientsbt.Visibility = Visibility.Collapsed;
                            view.suppliersbt.Visibility = Visibility.Collapsed;
                            view.employeesbt.Visibility = Visibility.Collapsed;
                        }
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
