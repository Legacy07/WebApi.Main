using LocalCommuter.WebAPI.Models;
using System;

namespace LocalCommuter.WebAPI.Repositories
{
    public interface IUsersRepository
    {
        void SaveUser(UserModel userModel);

        UserModel GetUser(Guid id);
    }
}