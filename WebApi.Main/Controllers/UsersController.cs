using LocalCommuter.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Main.Models;

namespace LocalCommuter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersRepository UserRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            this.UserRepository = usersRepository;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "user1", "user2" };
        }

        // GET: api/Users/5
        [HttpGet]
        [Route("{username}")]
        public UserDetails Get(string username, string password)
        {
            var user = this.UserRepository.GetUser(username, password);
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserModel user)
        {
            user.Id = Guid.NewGuid();
            user.DateJoined = DateTime.UtcNow.Date;

            var savedUser = this.UserRepository.SaveUser(user);

            //get the response code of 201 for successful post and return the user
            var message  = new HttpResponseMessage();
            if(savedUser != null)
            {
                message = new HttpResponseMessage(HttpStatusCode.Created);
                message.Headers.Location = new Uri(Request.Path + user.Id.ToString());
            }
            else
            {
                message = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return message;
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
