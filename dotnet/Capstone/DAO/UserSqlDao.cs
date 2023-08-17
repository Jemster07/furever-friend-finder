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

        public User GetAdopter(int petId)
        {
            User adopter = new User();

            string sql = "SELECT user_id, username, password_hash, salt, user_role, app_status, is_not_active, " +
                "users.address_id, email, is_adopter, addresses.address_id, street, city, state_abr, zip FROM users " +
                "JOIN addresses ON users.address_id = addresses.address_id " +
                "JOIN user_adopter ON user_id = adopter_id " +
                "WHERE pet_id = @petId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@petId", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        adopter = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return GetUser(adopter.Username);
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
                        " user_role, address_id, email, is_not_active, app_status, is_adopter) VALUES (@username, @password_hash, @salt, @user_role," +
                        " @address_id, @email, @is_not_active, @app_status, @is_adopter)", conn);
                    userCMD.Parameters.AddWithValue("@username", registerUser.Username);
                    userCMD.Parameters.AddWithValue("@password_hash", hash.Password);
                    userCMD.Parameters.AddWithValue("@salt", hash.Salt);
                    userCMD.Parameters.AddWithValue("@user_role", registerUser.Role);
                    userCMD.Parameters.AddWithValue("@address_id", registeredAddress.AddressId);
                    userCMD.Parameters.AddWithValue("@email", registerUser.Email);
                    userCMD.Parameters.AddWithValue("@is_not_active", false);
                    userCMD.Parameters.AddWithValue("@app_status", "pending");
                    userCMD.Parameters.AddWithValue("is_adopter", false);
                    userCMD.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return GetUser(registerUser.Username);
        }

        public User ChangeAppStatus(User updatedUser)
        {
            string sql = "UPDATE users SET app_status = @newStatus where username = @userToUpdate;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@newStatus", updatedUser.ApplicationStatus);
                    cmd.Parameters.AddWithValue("@userToUpdate", updatedUser.Username);
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

            return GetUser(updatedUser.Username);
        }

        public Adopter RegisterAdopter(Adopter adopter)
        {
            string sql = "INSERT INTO user_adopter (pet_id, adopter_id) VALUES (@pet_id, @adopter_id);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@pet_id", adopter.PetId);
                    userCMD.Parameters.AddWithValue("@adopter_id", adopter.AdopterId);

                    int rowsReturned = userCMD.ExecuteNonQuery();

                    if (rowsReturned != 1)
                    {
                        throw new Exception("Error registering adopter");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return adopter;
        }

        public User UpdateAdopterStatus(string username)
        {
            string sql = "UPDATE users SET is_adopter = 1 WHERE username = @username;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@username", username);

                    int rowsReturned = userCMD.ExecuteNonQuery();

                    if (rowsReturned != 1)
                    {
                        throw new Exception("Error updating adopter status");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetUser(username);
        }

        public List<DisplayUser> ListActiveUsers()
        {
            List<DisplayUser> output = new List<DisplayUser>();

            string sql = "SELECT user_id, username, user_role, app_status, " +
                "is_not_active, users.address_id, email, is_adopter, addresses.address_id, " +
                "street, city, state_abr, zip FROM users JOIN addresses " +
                "ON users.address_id = addresses.address_id " +
                "WHERE (user_role = 'friend' OR user_role = 'admin') AND app_status = 'approved' " +
                "AND is_not_active = 0;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand(sql, conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        DisplayUser returnUser = GetDisplayUserFromReader(reader);
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

        public List<DisplayUser> ListPendingUsers()
        {
            List<DisplayUser> output = new List<DisplayUser>();

            string sql = "SELECT user_id, username, user_role, app_status, " +
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
                        DisplayUser returnUser = GetDisplayUserFromReader(reader);
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

        public List<DisplayUser> ListAllUsers()
        {
            List<DisplayUser> output = new List<DisplayUser>();

            string sql = "SELECT user_id, username, user_role, app_status, " +
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
                        DisplayUser returnUser = GetDisplayUserFromReader(reader);
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
            u.IsAdopter = Convert.ToBoolean(reader["is_adopter"]);

            Address a = new Address();
            a.AddressId = Convert.ToInt32(reader["address_id"]);
            a.Street = Convert.ToString(reader["street"]);
            a.City = Convert.ToString(reader["city"]);
            a.State = Convert.ToString(reader["state_abr"]);
            a.Zip = Convert.ToString(reader["zip"]);
            u.Address = a;

            return u;
        }

        private DisplayUser GetDisplayUserFromReader(SqlDataReader reader)
        {
            DisplayUser u = new DisplayUser();
            u.UserId = Convert.ToInt32(reader["user_id"]);
            u.Username = Convert.ToString(reader["username"]);
            u.Role = Convert.ToString(reader["user_role"]);
            u.ApplicationStatus = Convert.ToString(reader["app_status"]);
            u.IsInactive = Convert.ToBoolean(reader["is_not_active"]);
            u.Email = Convert.ToString(reader["email"]);
            u.IsAdopter = Convert.ToBoolean(reader["is_adopter"]);

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
