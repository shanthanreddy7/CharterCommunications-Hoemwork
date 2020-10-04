using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using SampleApp.Core.Models;
using SampleApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SampleApp.Core.ViewModels
{
    public class AddUserViewModel : BaseViewModel
    {
        private readonly IUserService userService;
        public AddUserViewModel()
        {
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

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value)
                    return;

                firstName = value;
                RaisePropertyChanged(nameof(firstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value)
                    return;

                lastName = value;
                RaisePropertyChanged(nameof(lastName));
            }
        }

        private string mobileNumber;
        public string MobileNumber
        {
            get => mobileNumber;
            set
            {
                if (mobileNumber == value)
                    return;

                mobileNumber = value;
                RaisePropertyChanged(nameof(mobileNumber));
            }
        }

        public IMvxCommand AddUserClick => new MvxCommand(AddUserClickCommand);

        private async void AddUserClickCommand()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(MobileNumber))
            {
                Regex rgx = new Regex(@"(.+)\1");
                if (!rgx.IsMatch(Password) && Password.Length >= 5 && Password.Length <= 12)
                {
                    UserModel userModel = new UserModel()
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        UserName = this.UserName,
                        MobileNumber = this.MobileNumber,
                        Password = this.Password
                    };

                    userService.InsertUser(userModel);
                    await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Close(this);
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("Password strength is not good. Please choose another password.");
                }
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Please enter values in all the fields.");
            }
        }
    }
}
