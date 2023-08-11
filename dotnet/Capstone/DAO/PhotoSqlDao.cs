using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PhotoSqlDao : IPhotoDao
    {
        private readonly string connectionString;

        public PhotoSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Photo GetPhoto(int photoId)
        {
            //Add is_not_active = 0 to WHERE condition

            Photo requestedPhoto = new Photo();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT photo_id, photo_url, pet_id " +
                        "FROM photos WHERE photo_id = @photo_id;", conn);
                    cmd.Parameters.AddWithValue("@photo_id", photoId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        requestedPhoto.PhotoId = Convert.ToInt32(reader["photo_id"]);
                        requestedPhoto.PhotoUrl = Convert.ToString(reader["photo_url"]);
                        requestedPhoto.PetId = Convert.ToInt32(reader["pet_id"]);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return requestedPhoto;
        }

        public List<Photo> ListPhotosByPet(int petId)
        {
            //Add is_not_active = 0 to WHERE condition
            
            List<Photo> photoList = new List<Photo>();
            string sql = "SELECT photo_id, photo_url, pet_id FROM photos WHERE pet_id = @pet_id;";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand(sql, conn);
                    sqlCommand.Parameters.AddWithValue("@pet_id", petId);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Photo requestedPhoto = new Photo();
                        requestedPhoto.PhotoId = Convert.ToInt32(reader["photo_id"]);
                        requestedPhoto.PhotoUrl = Convert.ToString(reader["photo_url"]);
                        requestedPhoto.PetId = Convert.ToInt32(reader["pet_id"]);

                        photoList.Add(requestedPhoto);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return photoList;
        }

        public Photo AddPhoto(NewPhoto newPhoto)
        {
            int photoId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO photos (photo_url, pet_id) " +
                        "OUTPUT INSERTED.photo_id VALUES (@photo_url, @pet_id);", conn);
                    cmd.Parameters.AddWithValue("@photo_url", newPhoto.PhotoUrl);
                    cmd.Parameters.AddWithValue("@pet_id", newPhoto.PetId);
                    photoId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return GetPhoto(photoId);
        }

        public Photo DeactivatePhoto(int photoId)
        {
            //Add is_not_active property to sql queries
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE photos SET photo_url = @photo_url, pet_id = @pet_id " +
                        "WHERE photo_id = @photo_id;", conn);

                    cmd.Parameters.AddWithValue("@photo_url", photoToUpdate.PhotoUrl);
                    cmd.Parameters.AddWithValue("@pet_id", photoToUpdate.PetId);
                    cmd.Parameters.AddWithValue("@photo_id", photoToUpdate.PhotoId);

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

            return photoToUpdate;
        }
    }
}
