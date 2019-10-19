namespace LocalCommuter.WebAPI.Repositories
{
    using Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebApi.Main.Models;

    public class UsersRepository : IUsersRepository
    {
        public UserDetails GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage SaveUser(UserModel user)
        {
            try
            {
                using (MainDataBaseEntities dbEntities = new MainDataBaseEntities())
                {
                    //add to database
                    dbEntities.Users.Add(user);
                    dbEntities.SaveChanges();

                    //get the response code of 201 for successful post and return the newly added loan
                    var message = Request.CreateResponse(HttpStatusCode.Created, user);
                    message.Headers.Location = new Uri(Request.RequestUri + user.Username.ToString());

                    return message;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}