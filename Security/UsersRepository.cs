namespace Security
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;
    using WebApi.Main.Models;

    public class UsersRepository
    {
        private static SqlConnection GetConnection()
        {
            string databasePath;
            databasePath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\xampp\htdocs\WebApi.Main\Security\UsersDb.mdf;Integrated Security=True;";
            return new SqlConnection(databasePath);
        }

        public string SaveUser(UserModel userModel)
        {
            SqlConnection connection = GetConnection();
            string myQuery = "INSERT INTO Users(Id, Username, Password, Email, DateJoined) VALUES ('" + userModel.Id + "' , '" + userModel.Username + "', '" + userModel.Password + "',  '" + userModel.Email + "',  '" + userModel.DateJoined + "')";
            SqlCommand command = new SqlCommand(myQuery, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                return userModel.Username;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);

                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public UserDetails GetUser(string userName, string password)
        {
            return new UserDetails();
        }
    }
}
