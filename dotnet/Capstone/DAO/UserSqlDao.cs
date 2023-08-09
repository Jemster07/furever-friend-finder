using System;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;

        public UserSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt," +
                        " user_role, app_status, is_not_active, address_id, email, is_adopter" +
                        " FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }

        public User AddUser(RegisterUser registerUser)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(registerUser.Password);

            string userStreet = registerUser.Address.Street;
            string userCity = registerUser.Address.City;
            string userState = registerUser.Address.State;
            string userZip = registerUser.Address.Zip;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand addressCMD = new SqlCommand("INSERT INTO addresses (street, city, state_abr," +
                        " zip) OUTPUT INSERTED.address_id VALUES (@street, @city, @state_abr, @zip);", conn);
                    addressCMD.Parameters.AddWithValue("@street", userStreet);
                    addressCMD.Parameters.AddWithValue("@city", userCity);
                    addressCMD.Parameters.AddWithValue("@state_abr", userState);
                    addressCMD.Parameters.AddWithValue("@zip", userZip);
                    int newAddressID = Convert.ToInt32(addressCMD.ExecuteScalar());

                    SqlCommand userCMD = new SqlCommand("INSERT INTO users (username, password_hash, salt," +
                        " user_role, address_id, email) VALUES (@username, @password_hash, @salt, @user_role," +
                        " @address_id, @email)", conn);
                    userCMD.Parameters.AddWithValue("@username", registerUser.Username);
                    userCMD.Parameters.AddWithValue("@password_hash", hash.Password);
                    userCMD.Parameters.AddWithValue("@salt", hash.Salt);
                    userCMD.Parameters.AddWithValue("@user_role", registerUser.Role);
                    userCMD.Parameters.AddWithValue("@address_id", newAddressID);
                    userCMD.Parameters.AddWithValue("@email", registerUser.Email);
                    userCMD.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(registerUser.Username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User();

            u.UserId = Convert.ToInt32(reader["user_id"]);
            u.Username = Convert.ToString(reader["username"]);
            u.PasswordHash = Convert.ToString(reader["password_hash"]);
            u.Salt = Convert.ToString(reader["salt"]);
            u.Role = Convert.ToString(reader["user_role"]);

            Address tempA = new Address();
            tempA.AddressId = Convert.ToInt32(reader["address_id"]);
            tempA.Street = Convert.ToString(reader["street"]);
            tempA.City = Convert.ToString(reader["city"]);
            tempA.State = Convert.ToString(reader["state_abr"]);
            tempA.Zip = Convert.ToString(reader["zip"]);
            u.Address = tempA;

            u.ApplicationStatus = Convert.ToString(reader["app_status"]);
            u.IsActive = Convert.ToBoolean(reader["is_not_active"]);
            u.Email = Convert.ToString(reader["email"]);
            u.IsAdopter = Convert.ToBoolean(reader["is_adopter"]);

            return u;
        }
    }
}
