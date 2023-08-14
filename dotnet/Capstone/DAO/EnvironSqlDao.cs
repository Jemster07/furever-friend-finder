using Capstone.Models;
using System.Data.SqlClient;
using System;

namespace Capstone.DAO
{
    public class EnvironSqlDao : IEnvironDao
    {
        private readonly string connectionString;

        public EnvironSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Environ CreateEnvironment(NewEnviron newEnvironment)
        {
            int environmentId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO environments (children, dogs, cats, other_animals, " +
                        "indoor_only) OUTPUT INSERTED.environment_id " +
                        "VALUES (@children, @dog, @cat, @other_animals, @indoor_only)", conn);
                    cmd.Parameters.AddWithValue("@children", newEnvironment.IsChildSafe);
                    cmd.Parameters.AddWithValue("@dog", newEnvironment.IsDogSafe);
                    cmd.Parameters.AddWithValue("@cat", newEnvironment.IsCatSafe);
                    cmd.Parameters.AddWithValue("@other_animals", newEnvironment.IsOtherAnimalSafe);
                    cmd.Parameters.AddWithValue("@indoor_only", newEnvironment.IsIndoorOnly);
                    environmentId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return GetEnvironment(environmentId);
        }

        public Environ GetEnvironment(int environmentId)
        {
            Environ output = new Environ();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from environments where environment_id = @environment_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@environment_id", environmentId);
                    if (reader.Read())
                    {
                        output = GetEnvironmentFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
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
                    SqlCommand cmd = new SqlCommand("Update environments set children = @children, dog = @dog, " +
                        "cat = @cat, other_animals = @other_animals, indoor_only = @indoor_only " +
                        "where environment_id = @environment_id", conn);
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
            catch (Exception e)
            {
                throw e;
            }

            return updatedEnvironment;
        }
        private Environ GetEnvironmentFromReader(SqlDataReader reader)
        {
            Environ u = new Environ();
            u.EnvironmentId = Convert.ToInt32(reader["environment_id"]);
            u.IsChildSafe = Convert.ToBoolean(reader["children"]);
            u.IsDogSafe = Convert.ToBoolean(reader["dogs"]);
            u.IsCatSafe = Convert.ToBoolean(reader["cats"]);
            u.IsOtherAnimalSafe = Convert.ToBoolean(reader["other_animals"]);
            u.IsIndoorOnly = Convert.ToBoolean(reader["indoor_only"]);

            return u;
        }
    }
}
