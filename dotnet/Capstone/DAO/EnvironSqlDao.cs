using Capstone.Models;
using System.Data.SqlClient;
using System;

namespace Capstone.DAO
{
    public class EnvironSqlDao : IEnvironDao
    {
        private string connectionString;
        public Environ CreateEnvironment(Environ newEnvironment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Environments (children, dogs, cats, other_animals, indoor_only " +
                        "VALUES (@children, @dog, @cat, @other_animals, @indoor_only) where environmentId = @environmentId", conn);
                    cmd.Parameters.AddWithValue("@environmentId", newEnvironment.EnvironmentId);
                    cmd.Parameters.AddWithValue("@children", newEnvironment.IsChildSafe);
                    cmd.Parameters.AddWithValue("@dog", newEnvironment.IsDogSafe);
                    cmd.Parameters.AddWithValue("@cat", newEnvironment.IsCatSafe);
                    cmd.Parameters.AddWithValue("@other_animals", newEnvironment.IsOtherAnimalSafe);
                    cmd.Parameters.AddWithValue("@indoor_only", newEnvironment.IsIndoorOnly);
                    cmd.ExecuteNonQuery();
                }
                return newEnvironment;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Environ GetEnvironment(int environmentId)
        {
            Environ output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from environments where environment_Id = @environment_Id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@environment_Id", environmentId);
                    if (reader.Read())
                    {
                        output = GetEnvironmentFromReader(reader);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return output;

        }

        public Environ UpdateEnvironment(Environ updatedEnvironment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update environments (children, dog, cat, other_animals, indoor_only) " +
                        "VALUES (@children, @dog, @cat, @other_animals, @indoor_only)", conn);
                    cmd.Parameters.AddWithValue("@children", updatedEnvironment.IsChildSafe);
                    cmd.Parameters.AddWithValue("@dog", updatedEnvironment.IsDogSafe);
                    cmd.Parameters.AddWithValue("@cat", updatedEnvironment.IsCatSafe);
                    cmd.Parameters.AddWithValue("@other_animals", updatedEnvironment.IsOtherAnimalSafe);
                    cmd.Parameters.AddWithValue("@indoor_only", updatedEnvironment.IsIndoorOnly);
                    int rowsReturned = cmd.ExecuteNonQuery();
                    // One row should be affected
                    if (rowsReturned != 1)
                    {
                        throw new SystemException();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return updatedEnvironment;
        }
        private Environ GetEnvironmentFromReader(SqlDataReader reader)
        {
            Environ u = new Environ();
            u.EnvironmentId = Convert.ToInt32(reader["environmentId"]);
            u.IsChildSafe = Convert.ToBoolean(reader["children"]);
            u.IsDogSafe = Convert.ToBoolean(reader["dogs"]);
            u.IsCatSafe = Convert.ToBoolean(reader["cats"]);
            u.IsOtherAnimalSafe = Convert.ToBoolean(reader["other_animals"]);
            u.IsIndoorOnly = Convert.ToBoolean(reader["indoor_only"]);

            return u;
        }

    }
}
