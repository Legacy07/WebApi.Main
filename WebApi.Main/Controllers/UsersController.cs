using LocalCommuter.WebAPI.Models;
using LocalCommuter.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet]
        [Route("api/[controller]/users/{username}/{password}")]
        public UserModel Get(string userName, string password)
        {
            var user = this.UserRepository.GetUser(userName, password);
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]UserModel userModel)
        {
            this.UserRepository.SaveUser(userModel);
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
