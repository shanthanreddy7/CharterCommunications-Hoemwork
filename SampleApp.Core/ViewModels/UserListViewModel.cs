using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
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
    }
}
