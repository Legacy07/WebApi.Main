namespace LocalCommuter.WebAPI.Repositories
{
    using AutoMapper;
    using Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApi.Main.Models;

    public class UsersRepository : IUsersRepository
    {
        public UserDetails GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public UserModel SaveUser(UserModel user)
        {
            try
            {
                using (SecurityUsersDbEntities dbEntities = new SecurityUsersDbEntities())
                {
                    //var mappedUser = Mapper.Map<User>(user);

                    var mappedUser = new User
                    {
                        Id = user.Id.ToString(),
                        Username = user.Username,
                        Password = user.Password,
                        Email = user.Email,
                        DateJoined = user.DateJoined.Date.ToString()
                    };

                    dbEntities.Users.Add(mappedUser);
                    dbEntities.SaveChanges();

                    return user;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}