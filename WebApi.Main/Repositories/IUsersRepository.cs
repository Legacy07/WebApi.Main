using WebApi.Main.Models;

namespace LocalCommuter.WebAPI.Repositories
{
    public interface IUsersRepository
    {
        void SaveUser(UserModel userModel);

        UserDetails GetUser(string userName, string password);
    }
}