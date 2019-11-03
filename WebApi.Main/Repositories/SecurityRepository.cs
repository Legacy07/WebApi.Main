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

        // inject usersrepository through constructor
        public SecurityRepository()
        {
        }

        public UserDetails GetUser(string userName, string password)
        {
            UsersRepository usersRepository = new UsersRepository();

            var user = usersRepository.GetUser(userName, password);

            return user;
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