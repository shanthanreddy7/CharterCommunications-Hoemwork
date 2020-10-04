using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SampleApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService userService;

        public LoginViewModel()
        {
            Mvx.IoCProvider.Resolve<ISqliteDataService>().CreateTables();
            this.userService = Mvx.IoCProvider.Resolve<IUserService>();
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                if (userName == value)
                    return;

                userName = value;
                RaisePropertyChanged(nameof(userName));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (password == value)
                    return;

                password = value;
                RaisePropertyChanged(nameof(password));
            }
        }

        public IMvxCommand LoginClick => new MvxCommand(LoginClickCommand);

        private async void LoginClickCommand()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                var user = userService.GetUser(UserName);
                if (user != null)
                {
                    if (user.Password.Equals(Password))
                    {
                        await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate(new UserViewModel());
                    }
                    else
                    {
                        await UserDialogs.Instance.AlertAsync("Username or Password is incorrect.");
                        UserName = string.Empty;
                        Password = string.Empty;
                    }
                }
                else
                {
                    var confirmation = await UserDialogs.Instance.ConfirmAsync("If you want to add new User Please Click Add or Cancel.", "User Doesn't Exist", "Add", "Cancel");
                    if (confirmation)
                    {
                        await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate(new AddUserViewModel());
                    }
                }
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Please enter username and password");
                UserName = string.Empty;
                Password = string.Empty;
            }
        }
    }
}
