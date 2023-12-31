﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;
using System.Security.Policy;

namespace Capstone.DAO
{
    public class TagSqlDao : ITagDao
    {
        private readonly string connectionString;

        public TagSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Tag CreateTag(NewTag newTag)
        {
            int tagId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Tags (playful, needs_exercise, cute, affectionate, large, " +
                        "intelligent, happy, short_haired, shedder, shy, faithful, leash_trained, hypoallergenic) OUTPUT INSERTED.tag_id " +
                        "VALUES (@playful, @needs_exercise, @cute, @affectionate, @large, @intelligent, @happy, " +
                        "@short_haired, @shedder, @shy, @faithful, @leash_trained, @hypoallergenic)", conn);
                    cmd.Parameters.AddWithValue("@playful", newTag.IsPlayful);
                    cmd.Parameters.AddWithValue("@needs_exercise", newTag.NeedsExercise);
                    cmd.Parameters.AddWithValue("@cute", newTag.IsCute);
                    cmd.Parameters.AddWithValue("@affectionate", newTag.IsAffectionate);
                    cmd.Parameters.AddWithValue("@large", newTag.IsLarge);
                    cmd.Parameters.AddWithValue("@intelligent", newTag.IsIntelligent);
                    cmd.Parameters.AddWithValue("@short_haired", newTag.IsShortHaired);
                    cmd.Parameters.AddWithValue("@shedder", newTag.IsShedder);
                    cmd.Parameters.AddWithValue("@shy", newTag.IsShy);
                    cmd.Parameters.AddWithValue("@faithful", newTag.IsFaithful);
                    cmd.Parameters.AddWithValue("@leash_trained", newTag.IsLeashTrained);
                    cmd.Parameters.AddWithValue("@Hypoallergenic", newTag.IsHypoallergenic);
                    tagId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return GetTag(tagId);
        }

        public Tag GetTag(int tagId)
        {
            Tag output = new Tag();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from tags where tag_id = @tag_id", conn);
                    cmd.Parameters.AddWithValue("@tag_id", tagId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = GetTagsFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public Tag UpdateTag(Tag updatedTags)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Update tags set playful = @playful, needs_exercise = @needs_exercise, " +
                        "cute = @cute, affectionate = @affectionate, large = @large, intelligent = @intelligent, " +
                        "short_haired = @short_haired, shedder = @shedder, shy = @shy, faithful = @faithful, " +
                        "leash_trained = @leash_trained, hypoallergenic = @hypoallergenic where tag_id = @tag_id", conn);
                    cmd.Parameters.AddWithValue("@tag_Id", updatedTags.TagId);                   
                    cmd.Parameters.AddWithValue("@playful", updatedTags.IsPlayful);
                    cmd.Parameters.AddWithValue("@needs_exercise", updatedTags.NeedsExercise);
                    cmd.Parameters.AddWithValue("@cute", updatedTags.IsCute);
                    cmd.Parameters.AddWithValue("@affectionate", updatedTags.IsAffectionate);
                    cmd.Parameters.AddWithValue("@large", updatedTags.IsLarge);
                    cmd.Parameters.AddWithValue("@intelligent", updatedTags.IsIntelligent);
                    cmd.Parameters.AddWithValue("@short_haired", updatedTags.IsShortHaired);
                    cmd.Parameters.AddWithValue("@shedder", updatedTags.IsShedder);
                    cmd.Parameters.AddWithValue("@shy", updatedTags.IsShy);
                    cmd.Parameters.AddWithValue("@faithful", updatedTags.IsFaithful);
                    cmd.Parameters.AddWithValue("@leash_trained", updatedTags.IsLeashTrained);
                    cmd.Parameters.AddWithValue("@Hypoallergenic", updatedTags.IsHypoallergenic);

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

            return updatedTags;
        }

        private Tag GetTagsFromReader(SqlDataReader reader)
        {
            Tag u = new Tag();
            u.TagId = Convert.ToInt32(reader["tag_Id"]);
            u.IsPlayful = Convert.ToBoolean(reader["playful"]);
            u.NeedsExercise = Convert.ToBoolean(reader["needs_exercise"]);
            u.IsCute = Convert.ToBoolean(reader["cute"]);
            u.IsAffectionate = Convert.ToBoolean(reader["affectionate"]);
            u.IsLarge = Convert.ToBoolean(reader["large"]);
            u.IsIntelligent = Convert.ToBoolean(reader["intelligent"]);
            u.IsHappy = Convert.ToBoolean(reader["happy"]);
            u.IsShortHaired = Convert.ToBoolean(reader["short_haired"]);
            u.IsShedder = Convert.ToBoolean(reader["shedder"]);
            u.IsShy = Convert.ToBoolean(reader["shy"]);
            u.IsFaithful = Convert.ToBoolean(reader["faithful"]);
            u.IsLeashTrained = Convert.ToBoolean(reader["leash_trained"]);
            u.IsHypoallergenic = Convert.ToBoolean(reader["hypoallergenic"]);
            
            return u;
        }
    }
}