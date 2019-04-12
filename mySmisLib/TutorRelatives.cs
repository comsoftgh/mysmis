using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class TutorRelatives
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RelType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string PostAddress { get; set; }
        public string NextOfKin { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        public string xFullName { get; set; }
        public TutorRelatives(){}
    }

    public class TutorRelativesService
    {
        public bool AddTutorRelatives(TutorRelatives rel, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `tutorrelatives`(`userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `dateCreated`, `lastModified`) VALUES (@userId,@relType,@firstName,@lastName,@otherName,@mobile,@tel,@email,@postAddress,@nextOfKin,@dateCreated,@lastModified)";


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", rel.UserId);
                cmd.Parameters.AddWithValue("@relType", rel.RelType);
                cmd.Parameters.AddWithValue("@firstName", rel.FirstName);
                cmd.Parameters.AddWithValue("@lastName", rel.LastName);
                cmd.Parameters.AddWithValue("@otherName", rel.OtherName);
                cmd.Parameters.AddWithValue("@mobile", rel.Mobile);
                cmd.Parameters.AddWithValue("@tel", rel.Tel);
                cmd.Parameters.AddWithValue("@email", rel.Email);
                cmd.Parameters.AddWithValue("@postAddress", rel.PostAddress);
                cmd.Parameters.AddWithValue("@nextOfKin", rel.NextOfKin);
                cmd.Parameters.AddWithValue("@dateCreated", rel.DateCreated);
                cmd.Parameters.AddWithValue("@lastModified", rel.LastModified);
                int afRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (afRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }

        public List<TutorRelatives> GetAllTutorRelatives(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `tutorrelatives`";


            List<TutorRelatives> relList = new List<TutorRelatives>();
            TutorRelatives rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);

                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new TutorRelatives();

                        rel.Id = dr.GetInt32(0);
                        rel.UserId = dr.GetString(1);
                        rel.RelType = dr.GetString(2);
                        rel.FirstName = dr.GetString(3);
                        rel.LastName = dr.GetString(4);
                        rel.OtherName = dr.GetString(5);
                        rel.Mobile = dr.GetString(6);
                        rel.Tel = dr.GetString(7);
                        rel.Email = dr.GetString(8);
                        rel.PostAddress = dr.GetString(9);
                        rel.NextOfKin = dr.GetString(10);
                        rel.Active = dr.GetInt32(11);
                        rel.DateCreated = dr.GetDateTime(12);
                        rel.LastModified = dr.GetDateTime(13);
                        rel.xFullName = dr.GetString(3) + " " + dr.GetString(5) + " " + dr.GetString(4);

                        relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }

        public List<TutorRelatives> GetTutorRelatives(string studUserId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `tutorrelatives` WHERE userId=@userId";

            List<TutorRelatives> relList = new List<TutorRelatives>();
            TutorRelatives rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new TutorRelatives();

                        rel.Id = dr.GetInt32(0);
                        rel.UserId = dr.GetString(1);
                        rel.RelType = dr.GetString(2);
                        rel.FirstName = dr.GetString(3);
                        rel.LastName = dr.GetString(4);
                        rel.OtherName = dr.GetString(5);
                        rel.Mobile = dr.GetString(6);
                        rel.Tel = dr.GetString(7);
                        rel.Email = dr.GetString(8);
                        rel.PostAddress = dr.GetString(9);
                        rel.NextOfKin = dr.GetString(10);
                        rel.Active = dr.GetInt32(11);
                        rel.DateCreated = dr.GetDateTime(12);
                        rel.LastModified = dr.GetDateTime(13);
                        rel.xFullName = dr.GetString(3) + " " + dr.GetString(5) + " " + dr.GetString(4);


                        relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }

        public List<TutorRelatives> GetTutorRelatives(string studUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `tutorrelatives` WHERE userId=@userId";

            List<TutorRelatives> relList = new List<TutorRelatives>();
            TutorRelatives rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("LOADING RELATIVES BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new TutorRelatives();

                        rel.Id = dr.GetInt32(0);
                        rel.UserId = dr.GetString(1);
                        rel.RelType = dr.GetString(2);
                        rel.FirstName = dr.GetString(3);
                        rel.LastName = dr.GetString(4);
                        rel.OtherName = dr.GetString(5);
                        rel.Mobile = dr.GetString(6);
                        rel.Tel = dr.GetString(7);
                        rel.Email = dr.GetString(8);
                        rel.PostAddress = dr.GetString(9);
                        rel.NextOfKin = dr.GetString(10);
                        rel.Active = dr.GetInt32(11);
                        rel.DateCreated = dr.GetDateTime(12);
                        rel.LastModified = dr.GetDateTime(13);
                        rel.xFullName = dr.GetString(3) + " " + dr.GetString(5) + " " + dr.GetString(4);


                        relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }

        public TutorRelatives GetTutorRelativesById(int id, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `tutorrelatives` WHERE id=@id";

            //TutorRelatives relList = new TutorRelatives();
            TutorRelatives rel = new TutorRelatives();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new TutorRelatives();

                        rel.Id = dr.GetInt32(0);
                        rel.UserId = dr.GetString(1);
                        rel.RelType = dr.GetString(2);
                        rel.FirstName = dr.GetString(3);
                        rel.LastName = dr.GetString(4);
                        rel.OtherName = dr.GetString(5);
                        rel.Mobile = dr.GetString(6);
                        rel.Tel = dr.GetString(7);
                        rel.Email = dr.GetString(8);
                        rel.PostAddress = dr.GetString(9);
                        rel.NextOfKin = dr.GetString(10);
                        rel.Active = dr.GetInt32(11);
                        rel.DateCreated = dr.GetDateTime(12);
                        rel.LastModified = dr.GetDateTime(13);
                        rel.xFullName = dr.GetString(3) + " " + dr.GetString(5) + " " + dr.GetString(4);


                        //relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY MEMBER ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return rel;

        }
        public List<TutorRelatives> GetAllTutorRelativesByType(string type, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `tutorrelatives` WHERE relType=@relType";

            List<TutorRelatives> relList = new List<TutorRelatives>();
            TutorRelatives rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@relType", type);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES BY TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new TutorRelatives();

                        rel.Id = dr.GetInt32(0);
                        rel.UserId = dr.GetString(1);
                        rel.RelType = dr.GetString(2);
                        rel.FirstName = dr.GetString(3);
                        rel.LastName = dr.GetString(4);
                        rel.OtherName = dr.GetString(5);
                        rel.Mobile = dr.GetString(6);
                        rel.Tel = dr.GetString(7);
                        rel.Email = dr.GetString(8);
                        rel.PostAddress = dr.GetString(9);
                        rel.NextOfKin = dr.GetString(10);
                        rel.Active = dr.GetInt32(11);
                        rel.DateCreated = dr.GetDateTime(12);
                        rel.LastModified = dr.GetDateTime(13);
                        rel.xFullName = dr.GetString(3) + " " + dr.GetString(5) + " " + dr.GetString(4);

                        relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }

        public Boolean TutorRelatives(string studUserId, string relType, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT id FROM tutorrelatives WHERE userId=@userId AND relType=@relType";


            Boolean returnVal = false;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                cmd.Parameters.AddWithValue("@relType", relType);

                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("LOADING RELATIVES BY TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    returnVal = true;
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR CHECK RELATIVE EXISTS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR CHECK RELATIVE EXISTS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return returnVal;

        }

        public bool DeleteTutorRelatives(int id, string userId)
        {

            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("DELETE FROM tutorrelatives WHERE id='{0}'", id);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                int afecRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("DELETING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (afecRow > 0)
                { retVal = true; }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR DELETING RELATIVE ", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            { con.Close(); }
            return retVal;

        }

        public bool UpdateTutorRelatives(TutorRelatives rel, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;


            string query = "UPDATE `tutorrelatives` SET `userId`=@userId,`relType`=@relType,`firstName`=@firstName,`lastName`=@lastName,`otherName`=@otherName,`mobile`=@mobile,`tel`=@tel,`email`=@email,`postAddress`=@postAddress,`nextOfKin`=@nextOfKin,`lastModified`=@lastModified WHERE id=@id";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", rel.UserId);
                cmd.Parameters.AddWithValue("@relType", rel.RelType);
                cmd.Parameters.AddWithValue("@firstName", rel.FirstName);
                cmd.Parameters.AddWithValue("@lastName", rel.LastName);
                cmd.Parameters.AddWithValue("@otherName", rel.OtherName);
                cmd.Parameters.AddWithValue("@mobile", rel.Mobile);
                cmd.Parameters.AddWithValue("@tel", rel.Tel);
                cmd.Parameters.AddWithValue("@email", rel.Email);
                cmd.Parameters.AddWithValue("@postAddress", rel.PostAddress);
                cmd.Parameters.AddWithValue("@nextOfKin", rel.NextOfKin);
                cmd.Parameters.AddWithValue("@lastModified", rel.LastModified);
                cmd.Parameters.AddWithValue("@id", rel.Id);
                int affecRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("UPDATING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING RELATIVE ", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            { con.Close(); }
            return retVal;
        }

    }
}
