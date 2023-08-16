using Capstone.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Xml.Linq;

namespace Capstone.DAO
{
    public class PetSqlDao : IPetDao
    {
        private readonly string connectionString;

        public PetSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Pet GetPet(int petId)
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);
            List<Photo> petPhotos = photoDao.ListPhotosByPet(petId);

            Pet fetchedPet = new Pet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pets " +
                        "LEFT JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                        "LEFT JOIN environments ON pets.environment_id = environments.environment_id " +
                        "LEFT JOIN tags ON pets.tag_id = tags.tag_id " +
                        "LEFT JOIN addresses ON pets.address_id = addresses.address_id " +
                        "WHERE pet_id = @pet_id;", conn);

                    cmd.Parameters.AddWithValue("@pet_id", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        fetchedPet = GetPetFromReader(reader);

                        fetchedPet.Photos = petPhotos;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return fetchedPet;
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            string sql = "UPDATE pets SET type = @type, species = @species, color = @color, age = @age, " +
                "attribute_id = @attribute_id, environment_id = @environment_id, tag_id = @tag_id, " +
                "name = @name, description = @description, user_id = @user_id, " +
                "address_id = @address_id, is_adopted = @is_adopted WHERE pet_id = @pet_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@type", updatedPet.Type);
                    userCMD.Parameters.AddWithValue("@species", updatedPet.Species);
                    userCMD.Parameters.AddWithValue("@color", updatedPet.Color);
                    userCMD.Parameters.AddWithValue("@age", updatedPet.Age);
                    userCMD.Parameters.AddWithValue("@attribute_id", updatedPet.Attributes.AttributeId);
                    userCMD.Parameters.AddWithValue("@environment_id", updatedPet.Environments.EnvironmentId);
                    userCMD.Parameters.AddWithValue("@tag_id", updatedPet.Tags.TagId);
                    userCMD.Parameters.AddWithValue("@name", updatedPet.Name);
                    userCMD.Parameters.AddWithValue("@description", updatedPet.Description);
                    userCMD.Parameters.AddWithValue("@user_id", updatedPet.UserId);
                    userCMD.Parameters.AddWithValue("@address_id", updatedPet.Address.AddressId);
                    userCMD.Parameters.AddWithValue("@is_adopted", updatedPet.IsAdopted);

                    int rowsReturned = userCMD.ExecuteNonQuery();

                    if (rowsReturned != 1)
                    {
                        throw new Exception("Error updating pet information");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetPet(updatedPet.PetId);
        }

        public Pet CreatePet(RegisterPet pet)
        {
            int newPetId = 0;
            string sql = "INSERT INTO pets (type, species, color, age, " +
                "name, description, user_id) OUTPUT INSERTED.pet_id " +
                "VALUES (@type, @species, @color, @age, " +
                "@name, @description, @user_id);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@type", pet.Type);
                    userCMD.Parameters.AddWithValue("@species", pet.Species);
                    userCMD.Parameters.AddWithValue("@color", pet.Color);
                    userCMD.Parameters.AddWithValue("@age", pet.Age);
                    userCMD.Parameters.AddWithValue("@name", pet.Name);
                    userCMD.Parameters.AddWithValue("@description", pet.Description);
                    userCMD.Parameters.AddWithValue("@user_id", pet.UserId);
                    newPetId = Convert.ToInt32(userCMD.ExecuteScalar());

                    // insert the attributes
                    sql = "Insert into attributes (spayed_neutered,house_trained,declawed,special_needs,shots_current)" +
                        " output inserted.attribute_id " +
                        " values(@spay,@house,@declaw,@special,@shots)";
                    userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@spay", pet.Attributes.IsSpayedNeutered);
                    userCMD.Parameters.AddWithValue("@house", pet.Attributes.IsHouseTrained);
                    userCMD.Parameters.AddWithValue("@declaw", pet.Attributes.IsDeclawed);
                    userCMD.Parameters.AddWithValue("@special", pet.Attributes.IsSpecialNeeds);
                    userCMD.Parameters.AddWithValue("@shots", pet.Attributes.IsShotsCurrent);
                    // create new sql command with new sql
                    int attributeID = Convert.ToInt32(userCMD.ExecuteScalar());

                    // do that same as attributes with environment, address, and tags
                    // then update the pet
                    sql = "update pets set attribute_id = @attID where pet_id = @petID";
                    userCMD = new SqlCommand(sql, conn);
                    userCMD.Parameters.AddWithValue("@attID", attributeID);
                    userCMD.Parameters.AddWithValue("@petID", newPetId);
                    userCMD.ExecuteNonQuery();

                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return GetPet(newPetId);
        }

        public List<Pet> ListAvailablePets()
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);

            List<Pet> petList = new List<Pet>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pets " +
                        "JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                        "JOIN environments ON pets.environment_id = environments.environment_id " +
                        "JOIN tags ON pets.tag_id = tags.tag_id " +
                        "JOIN addresses ON pets.address_id = addresses.address_id " +
                        "WHERE is_adopted = 0;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet fetchedPet = GetPetFromReader(reader);

                        petList.Add(fetchedPet);
                    }
                }

                foreach (Pet item in petList)
                {
                    List<Photo> petPhotos = photoDao.ListPhotosByPet(item.PetId);

                    item.Photos = petPhotos;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return petList;
        }

        public List<Pet> ListPetsByZip(string zip)
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);

            List<Pet> petList = new List<Pet>();

            string sql = "SELECT * FROM pets JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                "JOIN environments ON pets.environment_id = environments.environment_id " +
                "JOIN tags ON pets.tag_id = tags.tag_id " +
                "JOIN addresses ON pets.address_id = addresses.address_id WHERE zip = @zip;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand(sql, conn);
                    sqlCommand.Parameters.AddWithValue("@zip", zip);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet fetchedPet = GetPetFromReader(reader);

                        petList.Add(fetchedPet);
                    }
                }

                foreach (Pet item in petList)
                {
                    List<Photo> petPhotos = photoDao.ListPhotosByPet(item.PetId);

                    item.Photos = petPhotos;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return petList;
        }

        public List<Pet> ListPetsByAttributes(Attributes attributes)
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);

            List<Pet> petList = new List<Pet>();

            string sql = "SELECT * FROM pets JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                "JOIN environments ON pets.environment_id = environments.environment_id " +
                "JOIN tags ON pets.tag_id = tags.tag_id JOIN addresses ON pets.address_id = addresses.address_id " +
                "WHERE spayed_neutered = @spayed_neutered AND house_trained = @house_trained AND " +
                "declawed = @declawed AND special_needs = @special_needs AND shots_current = @shots_current;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@spayed_neutered", attributes.IsSpayedNeutered);
                    cmd.Parameters.AddWithValue("@house_trained", attributes.IsHouseTrained);
                    cmd.Parameters.AddWithValue("@declawed", attributes.IsDeclawed);
                    cmd.Parameters.AddWithValue("@special_needs", attributes.IsSpecialNeeds);
                    cmd.Parameters.AddWithValue("@shots_current", attributes.IsShotsCurrent);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet fetchedPet = GetPetFromReader(reader);

                        petList.Add(fetchedPet);
                    }
                }

                foreach (Pet item in petList)
                {
                    List<Photo> petPhotos = photoDao.ListPhotosByPet(item.PetId);

                    item.Photos = petPhotos;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return petList;
        }

        public List<Pet> ListPetsByEnvironments(Environ environment)
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);

            List<Pet> petList = new List<Pet>();

            string sql = "SELECT * FROM pets JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                "JOIN environments ON pets.environment_id = environments.environment_id " +
                "JOIN tags ON pets.tag_id = tags.tag_id JOIN addresses ON pets.address_id = addresses.address_id " +
                "WHERE children = @children AND dogs = @dogs AND cats = @cats AND other_animals = @other_animals " +
                "AND indoor_only = @indoor_only;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@children", environment.IsChildSafe);
                    cmd.Parameters.AddWithValue("@dogs", environment.IsDogSafe);
                    cmd.Parameters.AddWithValue("@cats", environment.IsCatSafe);
                    cmd.Parameters.AddWithValue("@other_animals", environment.IsOtherAnimalSafe);
                    cmd.Parameters.AddWithValue("@indoor_only", environment.IsIndoorOnly);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet fetchedPet = GetPetFromReader(reader);
                        petList.Add(fetchedPet);
                    }
                }

                foreach (Pet item in petList)
                {
                    List<Photo> petPhotos = photoDao.ListPhotosByPet(item.PetId);

                    item.Photos = petPhotos;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return petList;
        }

        public List<Pet> ListPetsByTags(Tag tags)
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);

            List<Pet> petList = new List<Pet>();

            string sql = "SELECT * FROM pets JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                "JOIN environments ON pets.environment_id = environments.environment_id " +
                "JOIN tags ON pets.tag_id = tags.tag_id " +
                "JOIN addresses ON pets.address_id = addresses.address_id " +
                "WHERE playful = @playful AND needs_exercise = @needs_exercise AND cute = @cute " +
                "AND affectionate = @affectionate AND large = @large AND intelligent = @intelligent " +
                "AND happy = @happy AND short_haired = @short_haired AND shedder = @shedder AND shy = @shy " +
                "AND faithful = @faithful AND leash_trained = @leash_trained AND hypoallergenic = @hypoallergenic;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@playful", tags.IsPlayful);
                    cmd.Parameters.AddWithValue("@needs_exercise", tags.NeedsExercise);
                    cmd.Parameters.AddWithValue("@cute", tags.IsCute);
                    cmd.Parameters.AddWithValue("@affectionate", tags.IsAffectionate);
                    cmd.Parameters.AddWithValue("@large", tags.IsLarge);
                    cmd.Parameters.AddWithValue("@intelligent", tags.IsIntelligent);
                    cmd.Parameters.AddWithValue("@happy", tags.IsHappy);
                    cmd.Parameters.AddWithValue("@short_haired", tags.IsShortHaired);
                    cmd.Parameters.AddWithValue("@shedder", tags.IsShedder);
                    cmd.Parameters.AddWithValue("@shy", tags.IsShy);
                    cmd.Parameters.AddWithValue("@faithful", tags.IsFaithful);
                    cmd.Parameters.AddWithValue("@leash_trained", tags.IsLeashTrained);
                    cmd.Parameters.AddWithValue("@hypoallergenic", tags.IsHypoallergenic);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet fetchedPet = GetPetFromReader(reader);
                        petList.Add(fetchedPet);
                    }
                }

                foreach (Pet item in petList)
                {
                    List<Photo> petPhotos = photoDao.ListPhotosByPet(item.PetId);

                    item.Photos = petPhotos;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return petList;
        }

        public List<Pet> ListPets()
        {
            IPhotoDao photoDao = new PhotoSqlDao(connectionString);

            List<Pet> petList = new List<Pet>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pets " +
                        "JOIN attributes ON pets.attribute_id = attributes.attribute_id " +
                        "JOIN environments ON pets.environment_id = environments.environment_id " +
                        "JOIN tags ON pets.tag_id = tags.tag_id " +
                        "JOIN addresses ON pets.address_id = addresses.address_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet fetchedPet = GetPetFromReader(reader);

                        petList.Add(fetchedPet);
                    }
                }

                foreach (Pet item in petList)
                {
                    List<Photo> petPhotos = photoDao.ListPhotosByPet(item.PetId);

                    item.Photos = petPhotos;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return petList;
        }

        private Pet GetPetFromReader(SqlDataReader reader)
        {
            Pet p = new Pet();
            p.PetId = Convert.ToInt32(reader["pet_id"]);
            p.Type = Convert.ToString(reader["type"]);
            p.Species = Convert.ToString(reader["species"]);
            p.Color = Convert.ToString(reader["color"]);
            p.Age = Convert.ToString(reader["age"]);
            p.Name = Convert.ToString(reader["name"]);
            p.Description = Convert.ToString(reader["description"]);
            p.UserId = Convert.ToInt32(reader["user_id"]);
            p.IsAdopted = Convert.ToBoolean(reader["is_adopted"]);

            if (reader["attribute_id"] != DBNull.Value)
            {

                Attributes tempAt = new Attributes();
                tempAt.AttributeId = Convert.ToInt32(reader["attribute_id"]);
                tempAt.IsSpayedNeutered = Convert.ToBoolean(reader["spayed_neutered"]);
                tempAt.IsHouseTrained = Convert.ToBoolean(reader["house_trained"]);
                tempAt.IsDeclawed = Convert.ToBoolean(reader["declawed"]);
                tempAt.IsSpecialNeeds = Convert.ToBoolean(reader["special_needs"]);
                tempAt.IsShotsCurrent = Convert.ToBoolean(reader["shots_current"]);
                p.Attributes = tempAt;
            }

            if (reader["environment_id"] != DBNull.Value)
            {

                Environ tempE = new Environ();
                tempE.EnvironmentId = Convert.ToInt32(reader["environment_id"]);
                tempE.IsChildSafe = Convert.ToBoolean(reader["children"]);
                tempE.IsDogSafe = Convert.ToBoolean(reader["dogs"]);
                tempE.IsCatSafe = Convert.ToBoolean(reader["cats"]);
                tempE.IsOtherAnimalSafe = Convert.ToBoolean(reader["other_animals"]);
                tempE.IsIndoorOnly = Convert.ToBoolean(reader["indoor_only"]);
                p.Environments = tempE;
            }

            if (reader["tag_id"] != DBNull.Value)
            {

                Tag tempTag = new Tag();
                tempTag.TagId = Convert.ToInt32(reader["tag_id"]);
                tempTag.IsPlayful = Convert.ToBoolean(reader["playful"]);
                tempTag.NeedsExercise = Convert.ToBoolean(reader["needs_exercise"]);
                tempTag.IsCute = Convert.ToBoolean(reader["cute"]);
                tempTag.IsAffectionate = Convert.ToBoolean(reader["affectionate"]);
                tempTag.IsLarge = Convert.ToBoolean(reader["large"]);
                tempTag.IsIntelligent = Convert.ToBoolean(reader["intelligent"]);
                tempTag.IsHappy = Convert.ToBoolean(reader["happy"]);
                tempTag.IsShortHaired = Convert.ToBoolean(reader["short_haired"]);
                tempTag.IsShedder = Convert.ToBoolean(reader["shedder"]);
                tempTag.IsShy = Convert.ToBoolean(reader["shy"]);
                tempTag.IsFaithful = Convert.ToBoolean(reader["faithful"]);
                tempTag.IsLeashTrained = Convert.ToBoolean(reader["leash_trained"]);
                tempTag.IsHypoallergenic = Convert.ToBoolean(reader["hypoallergenic"]);
                p.Tags = tempTag;
            }

            if (reader["address_id"] != DBNull.Value)
            {

                Address tempAd = new Address();
                tempAd.AddressId = Convert.ToInt32(reader["address_id"]);
                tempAd.Street = Convert.ToString(reader["street"]);
                tempAd.City = Convert.ToString(reader["city"]);
                tempAd.State = Convert.ToString(reader["state_abr"]);
                tempAd.Zip = Convert.ToString(reader["zip"]);
                p.Address = tempAd;
            }
            return p;
        }
    }
}