using Capstone.Models;
using System.Data.SqlClient;
using System;

namespace Capstone.DAO
{
    public class AttributesSqlDao:IAttributesDao
    {
        private readonly string connectionString;

        public AttributesSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Attributes CreateAttribute(NewAttributes newAttribute)
        {
            int attributeId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO attributes (spayed_neutered, house_trained, declawed, " +
                        "special_needs, shots_current) OUTPUT INSERTED.attribute_id VALUES (@spayed_neutered, " +
                        "@house_trained, @declawed, @special_needs, @shots_current)", conn);
                    cmd.Parameters.AddWithValue("@spayed_neutered", newAttribute.IsSpayedNeutered);
                    cmd.Parameters.AddWithValue("@house_trained", newAttribute.IsHouseTrained);
                    cmd.Parameters.AddWithValue("@declawed", newAttribute.IsDeclawed);
                    cmd.Parameters.AddWithValue("@special_needs", newAttribute.IsSpecialNeeds);
                    cmd.Parameters.AddWithValue("@shots_current", newAttribute.IsShotsCurrent);
                    attributeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetAttribute(attributeId);
        }

        public Attributes GetAttribute(int attribute_id)
        {
            Attributes output = new Attributes();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from attributes where attribute_id = @attribute_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@attribute_id", attribute_id);
                    if (reader.Read())
                    {
                        output = GetAttributesFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public Attributes UpdateAttribute(Attributes updatedAttributes)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update attributes set spayed_neutered = @spayed_neutered, " +
                        "house_trained = @house_trained, declawed = @declawed, special_needs = @special_needs, " +
                        "shots_current = @shots_current where attribute_id = @attribute_id", conn);
                    cmd.Parameters.AddWithValue("@attribute_id", updatedAttributes.AttributeId);
                    cmd.Parameters.AddWithValue("@spayed_neutered", updatedAttributes.IsSpayedNeutered);
                    cmd.Parameters.AddWithValue("@house_trained", updatedAttributes.IsHouseTrained);
                    cmd.Parameters.AddWithValue("@declawed", updatedAttributes.IsDeclawed);
                    cmd.Parameters.AddWithValue("@special_needs", updatedAttributes.IsSpecialNeeds);
                    cmd.Parameters.AddWithValue("@shots_current", updatedAttributes.IsShotsCurrent);
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

            return updatedAttributes;
        }

        private Attributes GetAttributesFromReader(SqlDataReader reader)
        {
            Attributes att = new Attributes();
            att.AttributeId = Convert.ToInt32(reader["attribute_id"]);
            att.IsSpayedNeutered = Convert.ToBoolean(reader["spayed_neutered"]);
            att.IsHouseTrained = Convert.ToBoolean(reader["house_trained"]);
            att.IsDeclawed = Convert.ToBoolean(reader["declawed"]);
            att.IsSpecialNeeds = Convert.ToBoolean(reader["special_needs"]);
            att.IsShotsCurrent = Convert.ToBoolean(reader["shots_current"]);

            return att;
        }
    }
}
