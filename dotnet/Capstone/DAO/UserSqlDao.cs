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
            User returnUser = new User();

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
            u.ApplicationStatus = Convert.ToString(reader["app_status"]);
            u.IsActive = Convert.ToBoolean(reader["is_not_active"]);
            u.Email = Convert.ToString(reader["email"]);

            return u;
        }
    }
}
