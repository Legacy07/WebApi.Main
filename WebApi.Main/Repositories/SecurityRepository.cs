namespace LocalCommuter.WebAPI.Repositories
{
    using AutoMapper;
    using Security;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApi.Main.Models;

    public class SecurityRepository : ISecurityRepository
    {
        public UserDetails GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string SaveUser(UserModel user)
        {
            UsersRepository usersRepository = new UsersRepository();

            UserModel userModel = user;
            var savedUser = usersRepository.SaveUser(userModel);

            return savedUser;
        }
    }
}