using System;

namespace LocalCommuter.WebAPI.Models
{
    public class UserModel
    {
        Guid Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }

        public UserModel(Guid id, string username, string password, string email)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}