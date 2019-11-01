using WebApi.Main.Models;

namespace LocalCommuter.WebAPI.Repositories
{
    public interface ISecurityRepository
    {
        string SaveUser(UserModel userModel);

        UserDetails GetUser(string userName, string password);
    }
}