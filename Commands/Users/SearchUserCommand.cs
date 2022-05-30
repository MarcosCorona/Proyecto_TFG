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
    class SearchUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int searchedDni = usersViewModel.searchedId;
            bool searchedok = false;
            if (searchedDni != null)
            {
                foreach (PersonModel u in usersViewModel.UserList)
                {
                    if (u.dni.Equals(searchedDni))
                    {
                        usersViewModel.CurrentUser = u;
                        searchedok = true;
                        break;
                    }
                    else
                    {
                        searchedok = false;
                    }
                }
                if (searchedok == false)
                {
                    MessageBox.Show("The user doesn't exists");
                }
            }
            else
            {
                MessageBox.Show("Error searching the user, please try again.");
            }
        }

        public UsersViewModel usersViewModel { get; set; }
        public SearchUserCommand(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
        }
    }
}
