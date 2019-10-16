using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocalCommuter.WebAPI.Models;

namespace LocalCommuter.WebAPI.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public UserModel GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}