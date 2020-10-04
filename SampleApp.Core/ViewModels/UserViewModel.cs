using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SampleApp.Core.Models;
using SampleApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleApp.Core.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly IUserService userService;
        public MvxObservableCollection<UserListViewModel> Users { get; set; }
        public UserViewModel()
        {
            userService = Mvx.IoCProvider.Resolve<IUserService>();
            Users = new MvxObservableCollection<UserListViewModel>();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            Users.Clear();
            var usersList = userService.GetAllUsers();
            foreach (var item in usersList)
            {
                UserListViewModel userListViewModel = new UserListViewModel()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    MobileNumber = item.MobileNumber,
                    Password = item.Password
                };
                Users.Add(userListViewModel);

            }
        }

        public IMvxCommand AddUserClick => new MvxCommand(AddUserClickCommand);

        private async void AddUserClickCommand()
        {
            await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate(new AddUserViewModel());
        }
    }
}
