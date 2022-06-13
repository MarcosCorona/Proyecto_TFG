using Proyecto_TFG.Commands;
using Proyecto_TFG.Commands.Users;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class UsersViewModel:ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }
        public LoadUsersCommand loadUsersCommand { get; set; }
        public LoadUserCommand loadUserCommand { get; set; }
        public CreateUserCommand createUserCommand { set; get; }
        public ClearUserCommand clearUserCommand { get; set; }
        public DeleteUserCommand deleteUserCommand { set; get; }
        public ModifyUserCommand modifyUserCommand { set; get; }
        public SearchUserCommand searchUserCommand { set; get; }


        private PersonModel currentUser { get; set; }
        public PersonModel CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        private PersonModel selectedUser { get; set; }
        public PersonModel SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private PersonModel user;
        public PersonModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        private ObservableCollection<PersonModel> userList;
        public ObservableCollection<PersonModel> UserList
        {
            set
            {
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
            get
            {
                return userList;
            }
        }
        private ObservableCollection<String> jobList;
        public ObservableCollection<String> JobList
        {
            set
            {
                jobList = value;
                OnPropertyChanged(nameof(JobList));
            }
            get
            {
                return jobList;
            }
        }
        public string job { set; get; } 

        public int searchedId { get; set; }

        
        public UsersViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            updateViewCommandv2 = updateViewCommand;
            loadUserCommand = new LoadUserCommand(this);
            loadUsersCommand = new LoadUsersCommand(this);
            createUserCommand = new CreateUserCommand(this);
            clearUserCommand = new ClearUserCommand(this);
            deleteUserCommand = new DeleteUserCommand(this);
            modifyUserCommand = new ModifyUserCommand(this);
            searchUserCommand = new SearchUserCommand(this);
            JobList = new ObservableCollection<string>();
            JobList.Add("RRHH");
            JobList.Add("Administrative");
            JobList.Add("Stock");
            JobList.Add("Boss");
            CurrentUser = new PersonModel();
        }
    }
}
