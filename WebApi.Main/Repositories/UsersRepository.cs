using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocalCommuter.WebAPI.Models;

namespace LocalCommuter.WebAPI.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public UserModel GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}