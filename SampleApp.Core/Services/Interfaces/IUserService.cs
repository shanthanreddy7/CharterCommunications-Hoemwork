using SampleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        void InsertUser(UserModel userModel);

        UserModel GetUser(string userName);

        List<UserModel> GetAllUsers();
    }
}
