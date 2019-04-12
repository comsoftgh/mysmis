﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class TutorAcademics
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Institution { get; set; }
        public string AcademicLevel { get; set; }
        public string Qualification { get; set; }
        public DateTime DateAttended { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Comment { get; set; }
        public string Documment { get; set; }
        public string DocummentFname { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public TutorAcademics(){}
    }

    public class TutorAcademicsService
    {
        public bool AddTutorAcademics(TutorAcademics ad, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `tutoracademics`(`userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified`) VALUES (@userId,@institution,@academicLevel,@qualification,@dateAttended,@dateCompleted,@aComment,@document,@dateCreated,@lastModified)";

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", ad.UserId);
                cmd.Parameters.AddWithValue("@institution", ad.Institution);
                cmd.Parameters.AddWithValue("@academicLevel", ad.AcademicLevel);
                cmd.Parameters.AddWithValue("@qualification", ad.Qualification);
                cmd.Parameters.AddWithValue("@dateAttended", ad.DateAttended);
                cmd.Parameters.AddWithValue("@dateCompleted", ad.DateCompleted);
                cmd.Parameters.AddWithValue("@aComment", ad.Comment);
                cmd.Parameters.AddWithValue("@document", ad.Documment);
                cmd.Parameters.AddWithValue("@dateCreated", ad.DateCreated);
                cmd.Parameters.AddWithValue("@lastModified", ad.LastModified);
                int afecRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("ADDING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (afecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADDING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADDING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }



            return retVal;
        }

        public List<TutorAcademics> GetAllTutorAcademics(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            List<TutorAcademics> adList = new List<TutorAcademics>();
            TutorAcademics ad;

            string query = "SELECT `id`, `userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified` FROM `tutoracademics`";

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING ALL EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        ad = new TutorAcademics();
                        ad.Id = dr.GetInt32(0);
                        ad.UserId = dr.GetString(1);
                        ad.Institution = dr.GetString(2);
                        ad.AcademicLevel = dr.GetString(3);
                        ad.Qualification = dr.GetString(4);
                        ad.DateAttended = dr.GetDateTime(5);
                        ad.DateCompleted = dr.GetDateTime(6);
                        ad.Comment = dr.GetString(7);
                        if (dr.GetString(8) != "No Document") { ad.Documment = dr.GetString(8).Substring(0, dr.GetString(4).Length) + "." + (dr.GetString(8).Substring(dr.GetString(8).Length - 4)).TrimStart('.'); } else { ad.Documment = dr.GetString(8); }
                        ad.DocummentFname = dr.GetString(8);
                        ad.DateCreated = dr.GetDateTime(9);
                        ad.LastModified = dr.GetDateTime(10);
                        adList.Add(ad);
                    }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return adList;


        }

        public List<TutorAcademics> GetAllTutorAcademics(string studUserId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            List<TutorAcademics> adList = new List<TutorAcademics>();
            TutorAcademics ad;

            string query = "SELECT `id`, `userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified` FROM `tutoracademics` WHERE userId = @userId";

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        ad = new TutorAcademics();
                        ad.Id = dr.GetInt32(0);
                        ad.UserId = dr.GetString(1);
                        ad.Institution = dr.GetString(2);
                        ad.AcademicLevel = dr.GetString(3);
                        ad.Qualification = dr.GetString(4);
                        ad.DateAttended = dr.GetDateTime(5);
                        ad.DateCompleted = dr.GetDateTime(6);
                        ad.Comment = dr.GetString(7);
                        if (dr.GetString(8) != "No Document") { ad.Documment = dr.GetString(8).Substring(0, dr.GetString(4).Length) +"."+ (dr.GetString(8).Substring(dr.GetString(8).Length - 4)).TrimStart('.'); } else { ad.Documment = dr.GetString(8); }
                        ad.DocummentFname = dr.GetString(8);
                        ad.DateCreated = dr.GetDateTime(9);
                        ad.LastModified = dr.GetDateTime(10);

                        adList.Add(ad);
                    }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS ", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS ", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return adList;


        }

        public List<TutorAcademics> GetTutorAcademics(string studUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            List<TutorAcademics> adList = new List<TutorAcademics>();
            TutorAcademics ad;

            string query = "SELECT `id`, `userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified` FROM `tutoracademics` WHERE userId = @userId";

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("GETTING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        ad = new TutorAcademics();
                        ad.Id = dr.GetInt32(0);
                        ad.UserId = dr.GetString(1);
                        ad.Institution = dr.GetString(2);
                        ad.AcademicLevel = dr.GetString(3);
                        ad.Qualification = dr.GetString(4);
                        ad.DateAttended = dr.GetDateTime(5);
                        ad.DateCompleted = dr.GetDateTime(6);
                        ad.Comment = dr.GetString(7);
                        if (dr.GetString(8) != "No Document") { ad.Documment = dr.GetString(8).Substring(0, dr.GetString(4).Length) + "." + (dr.GetString(8).Substring(dr.GetString(8).Length - 4)).TrimStart('.'); } else { ad.Documment = dr.GetString(8); }
                        ad.DocummentFname = dr.GetString(8);
                        ad.DateCreated = dr.GetDateTime(9);
                        ad.LastModified = dr.GetDateTime(10);

                        adList.Add(ad);
                    }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS ", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS ", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return adList;


        }

        public TutorAcademics GetTutorAcademicsById(int id, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            TutorAcademics ad = new TutorAcademics();

            string query = string.Format("SELECT `id`, `userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified` FROM `tutoracademics` WHERE id='{0}'", id);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING ALL EDUCATIONAL RECORDS BY ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        ad = new TutorAcademics();
                        ad.Id = dr.GetInt32(0);
                        ad.UserId = dr.GetString(1);
                        ad.Institution = dr.GetString(2);
                        ad.AcademicLevel = dr.GetString(3);
                        ad.Qualification = dr.GetString(4);
                        ad.DateAttended = dr.GetDateTime(5);
                        ad.DateCompleted = dr.GetDateTime(6);
                        ad.Comment = dr.GetString(7);
                        if (dr.GetString(8) != "No Document") { ad.Documment = dr.GetString(8).Substring(0, dr.GetString(4).Length) + "." + (dr.GetString(8).Substring(dr.GetString(8).Length - 4)).TrimStart('.'); } else { ad.Documment = dr.GetString(8); }
                        ad.DocummentFname = dr.GetString(8);
                        ad.DateCreated = dr.GetDateTime(9);
                        ad.LastModified = dr.GetDateTime(10);
                    }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL EDUCATIONAL RECORDS BY ID", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL EDUCATIONAL RECORDS BY ID", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return ad;


        }

        public List<TutorAcademics> GetAllTutorAcademicsByQualification(string qualification, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            List<TutorAcademics> adList = new List<TutorAcademics>();
            TutorAcademics ad;

            string query = string.Format("SELECT `id`, `userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified` FROM `tutoracademics` WHERE qualification='{0}'", qualification);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING EDUCATIONAL RECORDS BY QUALIFICATION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        ad = new TutorAcademics();
                        ad.Id = dr.GetInt32(0);
                        ad.UserId = dr.GetString(1);
                        ad.Institution = dr.GetString(2);
                        ad.AcademicLevel = dr.GetString(3);
                        ad.Qualification = dr.GetString(4);
                        ad.DateAttended = dr.GetDateTime(5);
                        ad.DateCompleted = dr.GetDateTime(6);
                        ad.Comment = dr.GetString(7);
                        if (dr.GetString(8) != "No Document") { ad.Documment = dr.GetString(8).Substring(0, dr.GetString(4).Length) + "." + (dr.GetString(8).Substring(dr.GetString(8).Length - 4)).TrimStart('.'); } else { ad.Documment = dr.GetString(8); }
                        ad.DocummentFname = dr.GetString(8);
                        ad.DateCreated = dr.GetDateTime(9);
                        ad.LastModified = dr.GetDateTime(10);

                        adList.Add(ad);
                    }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS BY QUALIFICATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS BY QUALIFICATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return adList;


        }

        public List<TutorAcademics> GetAllTutorAcademicsByInstitution(string institution, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            List<TutorAcademics> adList = new List<TutorAcademics>();
            TutorAcademics ad;

            string query = string.Format("SELECT `id`, `userId`, `institution`, `academicLevel`, `qualification`, `dateAttended`, `dateCompleted`, `aComment`, `document`, `dateCreated`, `lastModified` FROM `tutoracademics` WHERE institution='{0}'", institution);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING EDUCATIONAL RECORDS BY INSTITUTION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        ad = new TutorAcademics();
                        ad.Id = dr.GetInt32(0);
                        ad.UserId = dr.GetString(1);
                        ad.Institution = dr.GetString(2);
                        ad.AcademicLevel = dr.GetString(3);
                        ad.Qualification = dr.GetString(4);
                        ad.DateAttended = dr.GetDateTime(5);
                        ad.DateCompleted = dr.GetDateTime(6);
                        ad.Comment = dr.GetString(7);
                        if (dr.GetString(8) != "No Document") { ad.Documment = dr.GetString(8).Substring(0, dr.GetString(4).Length) + "." + (dr.GetString(8).Substring(dr.GetString(8).Length - 4)).TrimStart('.'); } else { ad.Documment = dr.GetString(8); }
                        ad.DocummentFname = dr.GetString(8);
                        ad.DateCreated = dr.GetDateTime(9);
                        ad.LastModified = dr.GetDateTime(10);

                        adList.Add(ad);
                    }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS BY INSTITUTION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING EDUCATIONAL RECORDS BY INSTITUTION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return adList;


        }

        public bool DeleteTutorAcademics(int id, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("DELETE FROM tutoracademics WHERE id='{0}'", id);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                int affecRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("DELETING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR DELETING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR DELETING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }

        public bool UpdateTutorAcademics(TutorAcademics ad, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;

            string query = string.Format("UPDATE tutoracademics  SET  userId='{1}',institution='{2}',academicLevel='{3}',  qualification='{4}', dateAttended='{5}',dateCompleted='{6}',aComment='{7}',document='{8}',lastModified='{9}'" +
                 "WHERE (id='{0}')",
               ad.Id, ad.UserId, ad.Institution.Replace("'", "''"), ad.AcademicLevel.Replace("'", "''"), ad.Qualification.Replace("'", "''"), ad.DateAttended.ToString("yyyy-MM-dd"), ad.DateCompleted.ToString("yyyy-MM-dd"),
               ad.Comment.Replace("'", "''"), ad.Documment.Replace("'", "''"), ad.LastModified.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                int affecRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("UPDATING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING EDUCATIONAL RECORDS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }
    }
}