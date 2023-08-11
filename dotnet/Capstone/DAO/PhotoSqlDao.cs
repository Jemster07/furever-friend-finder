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

        public Photo AddPhoto(NewPhoto newPhoto)
        {
            throw new NotImplementedException();
        }

        public Photo UpdatePhoto(Photo photoToUpdate)
        {
            throw new NotImplementedException();
        }

        public List<Photo> ListPhotosByPet(int petId)
        {
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
    }
}
