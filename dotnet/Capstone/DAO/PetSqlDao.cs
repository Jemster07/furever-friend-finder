using Capstone.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Capstone.DAO
{
    public class PetSqlDao //: IPetDao
    {
        private string connectionString;

        //public Pet CreateNewPet(Pet newPet, Attribute attributes, Environ environment, Tag tags, Address address)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand atcmd = new SqlCommand("INSERT INTO Attributes (spayed_neutered, house_trained, declawed, special_needs, shots_current " +
        //                "VALUES (@spayed_Neutered, @house_trained, @declawed, @special_needs, @shots_current)", conn);

        //            atcmd.Parameters.AddWithValue("@spayed_neutered", attributes.IsSpayedNeutered);
        //            atcmd.Parameters.AddWithValue("@house_trained", attributes.IsHouseTrained);
        //            atcmd.Parameters.AddWithValue("@declawed", attributes.IsDeclawed);
        //            atcmd.Parameters.AddWithValue("@special_needs", attributes.IsSpecialNeeds);
        //            atcmd.Parameters.AddWithValue("@shots_current", attributes.IsShotsCurrent);
        //            atcmd.ExecuteNonQuery();
        //            Attribute.AttributeId = Convert.ToInt32(atcmd.ExecuteScalar());

        //            SqlCommand envcmd = new SqlCommand("INSERT INTO Environments (dogs, cats");

        //            SqlCommand cmd = new SqlCommand("INSERT INTO Pets (type, species, color, age, name, description " +
        //                "VALUES (@type, @species, @color, @age, @name, @description)", conn);
        //            cmd.Parameters.AddWithValue("@type", newPet.Type);
        //            cmd.Parameters.AddWithValue("@species", newPet.Species);
        //            cmd.Parameters.AddWithValue("@color", newPet.Color);
        //            cmd.Parameters.AddWithValue("@age", newPet.Age);
        //            cmd.Parameters.AddWithValue("@name", newPet.Name);
        //            cmd.Parameters.AddWithValue("@description", newPet.Description);
        //            cmd.ExecuteNonQuery();
        //        }
        //        return newPet;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        public List<Pet> GetListOfPets(int petId)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPet(int petId)
        {
            Pet output = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * where pet_id = @pet_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@pet_id", petId);
                    if (reader.Read())
                    {
                        output = GetPetFromReader(reader);
                    }
                }
            }
            catch
            {
                throw;
            }
            return output;
        }

        //public Pet GetPetByAttribute(Attribute attributes)
        //{
        //    throw new System.NotImplementedException();
        //}

        public Pet GetPetByEnvironment(Environ environment)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPetByTags(Tag tags)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetPetsByAdopter(int adopterId)
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePetById(Pet updatedPet)
        {
            throw new System.NotImplementedException();
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

            //Attribute tempAt = new Attribute();

            //tempAt.AttributeId = Convert.ToInt32(reader["attribute_id"]);
            //tempAt.IsSpayedNeutered = Convert.ToBoolean(reader["spayed_neutered"]);
            //tempAt.IsHouseTrained = Convert.ToBoolean(reader["house_trained"]);
            //tempAt.IsDeclawed = Convert.ToBoolean(reader["declawed"]);
            //tempAt.IsSpecialNeeds = Convert.ToBoolean(reader["special_needs"]);
            //tempAt.IsShotsCurrent = Convert.ToBoolean(reader["shots_current"]);
            //p.Attributes = tempAt;

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
            p.Address= tempAd;

            return p;
        }
    }
}
