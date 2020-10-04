using MvvmCross;
using SampleApp.Core.Models;
using SampleApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ISqliteDataService _sqliteDataService;
        public UserService()
        {
            _sqliteDataService = Mvx.IoCProvider.Resolve<ISqliteDataService>();
        }

        public List<UserModel> GetAllUsers()
        {
            return _sqliteDataService.ReadList<UserModel>();
        }

        public UserModel GetUser(string userName)
        {
            return _sqliteDataService.ReadFirst<UserModel>(x => x.UserName == userName);
        }

        public void InsertUser(UserModel userModel)
        {
            _sqliteDataService.Insert(userModel, typeof(UserModel));
        }
    }
}
