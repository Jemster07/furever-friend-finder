using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;
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
            User returnUser = new User();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, " +
                        "user_role, app_status, is_not_active, users.address_id, email, is_adopter, " +
                        "addresses.address_id, street, city, state_abr, zip FROM users JOIN addresses " +
                        "ON users.address_id = addresses.address_id WHERE username = @username;", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return returnUser;
        }

        public User AddUser(RegisterUser registerUser)
        {
            IAddressDao createAddress = new AddressSqlDao(connectionString);                  
            Address registeredAddress = createAddress.CreateAddress(registerUser.Address);

            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(registerUser.Password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand userCMD = new SqlCommand("INSERT INTO users (username, password_hash, salt," +
                        " user_role, address_id, email, is_not_active, app_status) VALUES (@username, @password_hash, @salt, @user_role," +
                        " @address_id, @email, @is_not_active, @app_status)", conn);
                    userCMD.Parameters.AddWithValue("@username", registerUser.Username);
                    userCMD.Parameters.AddWithValue("@password_hash", hash.Password);
                    userCMD.Parameters.AddWithValue("@salt", hash.Salt);
                    userCMD.Parameters.AddWithValue("@user_role", registerUser.Role);
                    userCMD.Parameters.AddWithValue("@address_id", registeredAddress.AddressId);
                    userCMD.Parameters.AddWithValue("@email", registerUser.Email);
                    userCMD.Parameters.AddWithValue("@is_not_active", false);
                    userCMD.Parameters.AddWithValue("@app_status", "pending");
                    userCMD.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return GetUser(registerUser.Username);
        }

        public User ChangeAppStatus(string userToUpdate, string newStatus)
        {
            string sql = "UPDATE users SET app_status = @newStatus where username = @userToUpdate;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@newStatus", newStatus);
                    cmd.Parameters.AddWithValue("@userToUpdate", userToUpdate);
                    int rowsReturned = cmd.ExecuteNonQuery();

                    if (rowsReturned != 1)
                    {
                        throw new Exception("Error updating application status");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetUser(userToUpdate);
        }

        public List<User> ListAllUsers()
        {
            List<User> output = new List<User>();
            string sql = "SELECT user_id, username, password_hash, salt, user_role, app_status, " +
                "is_not_active, users.address_id, email, is_adopter, addresses.address_id, " +
                "street, city, state_abr, zip FROM users JOIN addresses " +
                "ON users.address_id = addresses.address_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    SqlCommand sqlCommand = new SqlCommand(sql, conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        User returnUser = GetUserFromReader(reader);
                        output.Add(returnUser);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return output;
        }

        public List<User> ListPendingUsers()
        {
            List<User> output = new List<User>();
            string sql = "SELECT user_id, username, password_hash, salt, user_role, app_status, " +
                "is_not_active, users.address_id, email, is_adopter, addresses.address_id, street, " +
                "city, state_abr, zip FROM users JOIN addresses ON users.address_id = " +
                "addresses.address_id WHERE user_role = 'friend' AND app_status = 'pending';";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand(sql, conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        User returnUser = GetUserFromReader(reader);
                        output.Add(returnUser);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User();
            u.UserId = Convert.ToInt32(reader["user_id"]);
            u.Username = Convert.ToString(reader["username"]);
            u.PasswordHash = Convert.ToString(reader["password_hash"]);
            u.Salt = Convert.ToString(reader["salt"]);
            u.Role = Convert.ToString(reader["user_role"]);
            u.ApplicationStatus = Convert.ToString(reader["app_status"]);
            u.IsInactive = Convert.ToBoolean(reader["is_not_active"]);
            u.Email = Convert.ToString(reader["email"]);

            Address a = new Address();
            a.AddressId = Convert.ToInt32(reader["address_id"]);
            a.Street = Convert.ToString(reader["street"]);
            a.City = Convert.ToString(reader["city"]);
            a.State = Convert.ToString(reader["state_abr"]);
            a.Zip = Convert.ToString(reader["zip"]);
            u.Address = a;

            return u;
        }
    }
}
