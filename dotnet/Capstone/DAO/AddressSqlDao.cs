using Capstone.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;

namespace Capstone.DAO
{
    public class AddressSqlDao : IAddressDao
    {
        private string connectionString;

        public Address GetAddress(int addressId)
        {
            Address address = null;
            string sql = "SELECT address_id, street, city, state_abr, zip FROM addresses " +
                "WHERE address_id = @address_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@address_id", addressId);

                    if (reader.Read())
                    {
                        address = GetAddressFromReader(reader);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return address;
        }

        public Address CreateAddress(Address newAddress)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO addresses (street, city, state_abr," +
                        " zip) OUTPUT INSERTED.address_id VALUES (@street, @city, @state_abr, @zip);", conn);
                    cmd.Parameters.AddWithValue("@street", newAddress.Street);
                    cmd.Parameters.AddWithValue("@city", newAddress.City);
                    cmd.Parameters.AddWithValue("@state_abr", newAddress.State);
                    cmd.Parameters.AddWithValue("@zip", newAddress.Zip);
                    cmd.ExecuteNonQuery();
                    newAddress.AddressId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return newAddress;
        }

        public Address UpdateAddress(Address updatedAddress)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE addresses (street, city, state_abr, zip)" +
                        " VALUES (@street, @city, @state_abr, @zip) WHERE address_id = @address_id;", conn);

                    cmd.Parameters.AddWithValue("@address_id", updatedAddress.AddressId);
                    cmd.Parameters.AddWithValue("@street", updatedAddress.Street);
                    cmd.Parameters.AddWithValue("@city", updatedAddress.City);
                    cmd.Parameters.AddWithValue("@state_abr", updatedAddress.State);
                    cmd.Parameters.AddWithValue("@zip", updatedAddress.Zip);

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
            return updatedAddress;
        }

        private Address GetAddressFromReader(SqlDataReader reader)
        {
            Address a = new Address();

            a.AddressId = Convert.ToInt32(reader["address_id"]);
            a.Street = Convert.ToString(reader["street"]);
            a.City = Convert.ToString(reader["city"]);
            a.State = Convert.ToString(reader["state_abr"]);
            a.Zip = Convert.ToInt32(reader["zip"]);

            return a;
        }
    }
}
