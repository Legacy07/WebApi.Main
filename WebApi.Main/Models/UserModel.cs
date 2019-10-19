namespace WebApi.Main.Models
{
    using System;

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserModel(Guid id, string username, string password, string email)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}