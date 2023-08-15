using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
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

        public Photo GetPhotoFromDB(int photoId)
        {
            Photo requestedPhoto = new Photo();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT photo_id, photo_url, pet_id, is_not_active FROM photos " +
                        "WHERE photo_id = @photo_id AND is_not_active = 0;", conn);
                    cmd.Parameters.AddWithValue("@photo_id", photoId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        requestedPhoto.PhotoId = Convert.ToInt32(reader["photo_id"]);
                        requestedPhoto.PhotoUrl = Convert.ToString(reader["photo_url"]);
                        requestedPhoto.PetId = Convert.ToInt32(reader["pet_id"]);
                        requestedPhoto.IsInactive = Convert.ToBoolean(reader["is_not_active"]);
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
            List<Photo> photoList = new List<Photo>();
            string sql = "SELECT photo_id, photo_url, pet_id FROM photos " +
                "WHERE pet_id = @pet_id AND is_not_active = 0;";
            
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

        public Photo AddPhotoToDB(NewPhoto newPhoto)
        {
            int photoId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO photos (photo_url, pet_id, is_not_active) " +
                        "OUTPUT INSERTED.photo_id VALUES (@photo_url, @pet_id, @is_not_active);", conn);
                    cmd.Parameters.AddWithValue("@photo_url", newPhoto.PhotoUrl);
                    cmd.Parameters.AddWithValue("@pet_id", newPhoto.PetId);
                    cmd.Parameters.AddWithValue("@is_not_active", newPhoto.IsInactive);
                    photoId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return GetPhotoFromDB(photoId);
        }

        public int DeactivatePhoto(int photoId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE photos SET is_not_active = 1 " +
                        "WHERE photo_id = @photo_id;", conn);

                    cmd.Parameters.AddWithValue("@photo_id", photoId);

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

            return 0;
        }
    }
}
