using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.Models
{
    public class UserModel
    {
        [PrimaryKey]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

    }
}
