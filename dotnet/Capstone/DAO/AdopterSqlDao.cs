using Capstone.Models;
using System.Data.SqlClient;
using System;

namespace Capstone.DAO
{
    public class AdopterSqlDao : IAdopterDao
    {
        private readonly string connectionString;

        public AdopterSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Adopter GetAdopter(int petId)
        {
            Adopter returnAdopter = new Adopter();

            string sql = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("", );
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnAdopter = Convert.ToInt32(reader[""]);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return returnAdopter;
        }

        public Adopter AssignAdopter(Pet adoptedPet, int adopterId)
        {
            string sql = "UPDATE pets SET is_adopted = 1 WHERE pet_id = @pet_id; " +
                "INSERT INTO user_adopter (pet_id, adopter_id) VALUES (@pet_id, @adopter_id);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@pet_id", adoptedPet.PetId);
                    userCMD.Parameters.AddWithValue("@adopter_id", adopterId);

                    int rowsReturned = userCMD.ExecuteNonQuery();

                    if (rowsReturned != 1)
                    {
                        throw new Exception("Error updating pet adopted status");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetAdopter(adoptedPet.PetId);
        }
    }
}
