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
            string query = "INSERT INTO Users(Id, Username, Password, Email, DateJoined) VALUES ('" + userModel.Id + "' , '" + userModel.Username + "', '" + userModel.Password + "',  '" + userModel.Email + "',  '" + userModel.DateJoined + "')";
            SqlCommand command = new SqlCommand(query, connection);

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
            SqlConnection connection = GetConnection();
            string query = "Select * From Users Where Username = @username AND Password = @password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                ////command.ExecuteNonQuery();
                var user = new UserDetails();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.Id = new Guid(reader.GetString(reader.GetOrdinal("Id")));
                            user.Username = reader.GetString(reader.GetOrdinal("Username"));
                            user.Email = reader.GetString(reader.GetOrdinal("Email"));
                            user.DateJoined = DateTime.Parse(reader.GetString(reader.GetOrdinal("DateJoined")));
                        }
                    }
                }

                return user;
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
    }
}
