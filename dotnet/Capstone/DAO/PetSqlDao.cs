using Capstone.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace Capstone.DAO
{
    public class PetSqlDao : IPetDao
    {
        private readonly string connectionString;
        private readonly IAddressDao createAddress;
        private readonly ITagDao createTag;
        private readonly IEnvironDao createEnvironment;
        private readonly IAttributesDao createAttribute;

        public PetSqlDao(string dbConnectionString, IAddressDao createAddress, ITagDao createTag,
            IEnvironDao createEnvironment, IAttributesDao createAttribute)
        {
            connectionString = dbConnectionString;
            this.createAddress = createAddress;
            this.createTag = createTag;
            this.createEnvironment = createEnvironment;
            this.createAttribute = createAttribute;
        }

        public Pet CreatePet(Pet pet, Attributes attributes, Environ environment, Tag tags,
            CreateAddress address)
        {
            Address newAddress = createAddress.CreateAddress(address);
            Tag newTag = createTag.CreateTag(tags);
            Environ newEnviron = createEnvironment.CreateEnvironment(environment);
            Attributes newAttributes = createAttribute.CreateAttribute(attributes);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();



                    SqlCommand cmd = new SqlCommand("INSERT INTO pets (type, species, color, age, name, description " +
                        "VALUES (@type, @species, @color, @age, @name, @description)", conn);
                    cmd.Parameters.AddWithValue("@type", pet.Type);
                    cmd.Parameters.AddWithValue("@species", pet.Species);
                    cmd.Parameters.AddWithValue("@color", pet.Color);
                    cmd.Parameters.AddWithValue("@age", pet.Age);
                    cmd.Parameters.AddWithValue("@name", pet.Name);
                    cmd.Parameters.AddWithValue("@description", pet.Description);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return pet;
        }

        public List<Pet> ListPets(int petId)
        {
            List<Pet> output = new List<Pet>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM pets WHERE pet_id = @pet_id", conn);
                    sqlCommand.Parameters.AddWithValue("@pet_id", petId);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet temp = GetPetFromReader(reader);
                        output.Add(temp);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public Pet GetPet(int petId)
        {
            Pet output = new Pet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pets WHERE pet_id = @pet_id", conn);
                    cmd.Parameters.AddWithValue("@pet_id", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = GetPetFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public Pet GetPetByAttributes(Attributes attributes)
        {
            Pet output = new Pet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT pet_id, type, species, color, age, " +
                        "pets.attribute_id, environment_id, tag_id, name, description, user_id, " +
                        "photo_id, is_adopted, adopter_id, address_id FROM pets JOIN attributes " +
                        "ON pets.attribute_id = attributes.attribute_id " +
                        "WHERE spayed_neutered = @spayed_neutered AND " +
                        "house_trained = @house_trained AND declawed = @declawed AND " +
                        "special_needs = @special_needs AND shots_current = @shots_current;", conn);

                    cmd.Parameters.AddWithValue("@spayed_neutered", attributes.IsSpayedNeutered);
                    cmd.Parameters.AddWithValue("@house_trained", attributes.IsHouseTrained);
                    cmd.Parameters.AddWithValue("@declawed", attributes.IsDeclawed);
                    cmd.Parameters.AddWithValue("@special_needs", attributes.IsSpecialNeeds);
                    cmd.Parameters.AddWithValue("@shots_current", attributes.IsShotsCurrent);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = GetPetFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public List<Pet> ListPetsByZip(Address zipAddress)
        {
            List<Pet> output = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM pets JOIN addresses on " +
                        "address_id = pet.address_id where zip = @zip", conn);
                    sqlCommand.Parameters.AddWithValue("@zip", zipAddress);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Pet temp = GetPetFromReader(reader);
                        output.Add(temp);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }
        public Pet GetPetByEnvironments(Environ environment)
        {
            Pet output = new Pet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM environments " +
                        "WHERE children = @children and dogs = @dogs and cats = @cats " +
                        "and other_animals = @other_animals and indoor_only = @indoor_only", conn);



                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = GetPetFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public Pet GetPetByTags(Tag tags)
        {
            Pet output = new Pet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tags WHERE playful = @playful and " +
                        "needs_exercise = @needs_exercise and cute = @cute and affectionate = @affectionate " +
                        "and large = @large and intelligent = @intelligent and happy = @happy and " +
                        "short_haired = @short_haired and shedder = @shedder and shy = @shy and " +
                        "faithful = @faithful and leash_trained = @leash_trained and " +
                        "hypoallergenic = @hypoallergenic", conn);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = GetPetFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public List<Pet> ListPetsByAdopter(int adopterId)
        {
            List<Pet> output = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("Select * FROM pets WHERE adopter_id = @adopter_id", conn);
                    sqlCommand.Parameters.AddWithValue("@adopter_id", adopterId);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet temp = GetPetFromReader(reader);
                        output.Add(temp);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public Pet UpdatePet(Pet updatedPet, Attributes updatedAttributes, Environ updatedEnvironment, Tag updatedTags, Address updatedAddress)
        {
            Address newAddress = createAddress.UpdateAddress(updatedAddress);
            Tag newTag = createTag.UpdateTag(updatedTags);
            Environ newEnviron = createEnvironment.UpdateEnvironment(updatedEnvironment);
            Attributes newAttributes = createAttribute.UpdateAttribute(updatedAttributes);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE pets SET type = @type, species = @species, " +
                        "color = @color, age = @age, name = @name, description = @description, " +
                        "pet_id = @pet_id", conn);
                    cmd.Parameters.AddWithValue("@pet_id", updatedPet.PetId);
                    cmd.Parameters.AddWithValue("@type", updatedPet.Type);
                    cmd.Parameters.AddWithValue("@species", updatedPet.Species);
                    cmd.Parameters.AddWithValue("@color", updatedPet.Color);
                    cmd.Parameters.AddWithValue("@age", updatedPet.Age);
                    cmd.Parameters.AddWithValue("@name", updatedPet.Name);
                    cmd.Parameters.AddWithValue("@description", updatedPet.Description);

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

            return updatedPet;
        }

        private Pet GetPetFromReader(SqlDataReader reader)
        {
            Pet p = new Pet();
            p.PetId = Convert.ToInt32(reader["petId"]);
            p.Type = Convert.ToString(reader["type"]);
            p.Species = Convert.ToString(reader["species"]);
            p.Color = Convert.ToString(reader["color"]);
            p.Age = Convert.ToInt32(reader["age"]);
            p.Name = Convert.ToString(reader["name"]);
            p.Description = Convert.ToString(reader["description"]);
            p.UserId = Convert.ToInt32(reader["user_id"]);
            p.PhotoId = Convert.ToInt32(reader["photo_id"]);
            p.AdopterId = Convert.ToInt32(reader["adopter_id"]);
            p.IsAdopted = Convert.ToBoolean(reader["is_adopted"]);

            Attributes tempAt = new Attributes();
            tempAt.AttributeId = Convert.ToInt32(reader["attribute_id"]);
            tempAt.IsSpayedNeutered = Convert.ToBoolean(reader["spayed_neutered"]);
            tempAt.IsHouseTrained = Convert.ToBoolean(reader["house_trained"]);
            tempAt.IsDeclawed = Convert.ToBoolean(reader["declawed"]);
            tempAt.IsSpecialNeeds = Convert.ToBoolean(reader["special_needs"]);
            tempAt.IsShotsCurrent = Convert.ToBoolean(reader["shots_current"]);
            p.Attributes = tempAt;

            Environ tempE = new Environ();
            tempE.EnvironmentId = Convert.ToInt32(reader["environment_id"]);
            tempE.IsChildSafe = Convert.ToBoolean(reader["children"]);
            tempE.IsDogSafe = Convert.ToBoolean(reader["dogs"]);
            tempE.IsCatSafe = Convert.ToBoolean(reader["cats"]);
            tempE.IsOtherAnimalSafe = Convert.ToBoolean(reader["other_animals"]);
            tempE.IsIndoorOnly = Convert.ToBoolean(reader["indoor_only"]);
            p.Environment = tempE;

            Tag tempTag = new Tag();
            tempTag.TagId = Convert.ToInt32(reader["tag_id"]);
            tempTag.IsPlayful = Convert.ToBoolean(reader["playful"]);
            tempTag.IsNeedsExercise = Convert.ToBoolean(reader["needs_exercise"]);
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

            Address tempAd = new Address();
            tempAd.AddressId = Convert.ToInt32(reader["address_id"]);
            tempAd.Street = Convert.ToString(reader["street"]);
            tempAd.City = Convert.ToString(reader["city"]);
            tempAd.State = Convert.ToString(reader["state_abr"]);
            tempAd.Zip = Convert.ToString(reader["zip"]);
            p.Address = tempAd;

            return p;
        }
    }
}
