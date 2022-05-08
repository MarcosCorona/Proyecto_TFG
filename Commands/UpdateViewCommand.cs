using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_TFG.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                string viewName = (string)parameter;

                if (viewName.Equals("home"))
                {
                    mainViewModel.SelectedViewModel = new HomeViewModel();
                }
                else if (viewName.Equals("resumen"))
                {
                    mainViewModel.SelectedViewModel = new ResumenViewModel();
                }
            }
        }

        public MainViewModel mainViewModel { get; set; }
        public HomeViewModel homeViewModel { get; set; }



        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            mainViewModel.SelectedViewModel = new LoginViewModel(this);
        }


    }
}
