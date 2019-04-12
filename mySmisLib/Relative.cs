using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class Relative
    {

        public int Id { get; set; }
        public string RelaUserId { get; set; }
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
        public string xStudUserId { get; set; }

        public Relative() { }

    }
    public class RelativeService
    {
        public bool AddRelative(Relative rel, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `studentrelatives`(`userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `dateCreated`, `lastModified`) VALUES (@userId,@relType,@firstName,@lastName,@otherName,@mobile,@tel,@email,@postAddress,@nextOfKin,@dateCreated,@lastModified)";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", rel.RelaUserId);
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
        public bool AddRelation(Relative rel, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `studentrelations`(`studuserid`, `relauserid`, `dateCreated`, `lastModified`) VALUES (@studuserid,@relauserid,@dateCreated,@lastModified)";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studuserid", rel.xStudUserId);
                cmd.Parameters.AddWithValue("@relauserid", rel.RelaUserId);
                cmd.Parameters.AddWithValue("@dateCreated", rel.DateCreated);
                cmd.Parameters.AddWithValue("@lastModified", rel.LastModified);
                int afRow = cmd.ExecuteNonQuery();
                //new AuditLogService().AddAuditLog("ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (afRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }
        public bool AddRelationList(string rel, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("INSERT INTO `studentrelations`(`studuserid`, `relauserid`, `dateCreated`, `lastModified`) VALUES {0}",rel);
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                
                int afRow = cmd.ExecuteNonQuery();
                //new AuditLogService().AddAuditLog("ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (afRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR ADDING RELATIVE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }
        public List<Relative> GetAllRelatives(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `studentrelatives`";


            List<Relative> relList = new List<Relative>();
            Relative rel;

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
                        rel = new Relative();

                        rel.Id = dr.GetInt32(0);
                        rel.RelaUserId = dr.GetString(1);
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

        public List<Relative> GetRelatives(string studUserId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT studentrelations.id,studentrelations.studuserid,studentrelations.relauserid,studentrelations.dateCreated,studentrelations.lastModified,studentrelatives.relType,studentrelatives.firstName,studentrelatives.lastName,studentrelatives.otherName,studentrelatives.mobile,studentrelatives.tel,studentrelatives.email,studentrelatives.postAddress,studentrelatives.nextOfKin,studentrelatives.active FROM studentrelations INNER JOIN studentrelatives ON studentrelations.relauserid = studentrelatives.userId WHERE studentrelations.studuserid = @studuserid";

            List<Relative> relList = new List<Relative>();
            Relative rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studuserid", studUserId);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new Relative();

                        rel.Id = dr.GetInt32(0);
                        rel.xStudUserId = dr.GetString(1);
                        rel.RelaUserId = dr.GetString(2);
                        rel.DateCreated = dr.GetDateTime(3);
                        rel.LastModified = dr.GetDateTime(4);
                        rel.RelType = dr.GetString(5);
                        rel.FirstName = dr.GetString(6);
                        rel.LastName = dr.GetString(7);
                        rel.OtherName = dr.GetString(8);
                        rel.Mobile = dr.GetString(9);
                        rel.Tel = dr.GetString(10);
                        rel.Email = dr.GetString(11);
                        rel.PostAddress = dr.GetString(12);
                        rel.NextOfKin = dr.GetString(13);
                        rel.Active = dr.GetInt32(14);
                        rel.xFullName = dr.GetString(6) + " " + dr.GetString(7) + " " + dr.GetString(8);

                        relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }

        public List<Relative> GetRelatives(string studUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `studentrelatives` WHERE userId=@userId";

            List<Relative> relList = new List<Relative>();
            Relative rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("LOADING RELATIVES BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new Relative();

                        rel.Id = dr.GetInt32(0);
                        rel.RelaUserId = dr.GetString(1);
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
                //new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }

        public Relative GetRelativeById(int id, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `studentrelatives` WHERE id=@id";

            //Relative relList = new Relative();
            Relative rel = new Relative();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new Relative();

                        rel.Id = dr.GetInt32(0);
                        rel.RelaUserId = dr.GetString(1);
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
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return rel;

        }
        public List<Relative> GetAllRelativesByType(string type, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `userId`, `relType`, `firstName`, `lastName`, `otherName`, `mobile`, `tel`, `email`, `postAddress`, `nextOfKin`, `active`, `dateCreated`, `lastModified` FROM `studentrelatives` WHERE relType=@relType";

            List<Relative> relList = new List<Relative>();
            Relative rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@relType",type);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("LOADING RELATIVES BY TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new Relative();

                        rel.Id = dr.GetInt32(0);
                        rel.RelaUserId = dr.GetString(1);
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
        public Boolean RelativeExists(string studUserId, string relType, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT studentrelations.id FROM studentrelations INNER JOIN studentrelatives ON studentrelations.relauserid = studentrelatives.userId WHERE studentrelations.studuserid=@userId AND studentrelatives.relType=@relType";
                

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
        public Boolean NextofKinExists(string studUserId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT studentrelations.id FROM studentrelations INNER JOIN studentrelatives ON studentrelations.relauserid = studentrelatives.userId WHERE studentrelations.studuserid=@userId AND studentrelatives.nextOfKin='Yes'";


            Boolean returnVal = false;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                //cmd.Parameters.AddWithValue("@relType", relType);

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
        public bool DeleteRelative(int id, string userId)
        {

            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("DELETE FROM studentrelatives WHERE id='{0}'", id);

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
        public bool UpdateRelative(Relative rel, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;


            string query = "UPDATE `studentrelatives` SET `userId`=@userId,`relType`=@relType,`firstName`=@firstName,`lastName`=@lastName,`otherName`=@otherName,`mobile`=@mobile,`tel`=@tel,`email`=@email,`postAddress`=@postAddress,`nextOfKin`=@nextOfKin,`lastModified`=@lastModified WHERE id=@id";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", rel.RelaUserId);
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
                cmd.Parameters.AddWithValue("@id",rel.Id);
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

        public List<Relative> GetRelationsIDs(string studUserId, string newstudId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT studentrelations.relauserid FROM studentrelations WHERE studentrelations.studuserid = @studuserid AND studentrelations.relauserid NOT IN (SELECT studentrelations.relauserid FROM studentregistration WHERE studentrelations.studuserid = @newstudID)";

            List<Relative> relList = new List<Relative>();
            Relative rel;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studuserid", studUserId);
                cmd.Parameters.AddWithValue("@newstudID", newstudId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("LOADING RELATIVES BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rel = new Relative();
                     
                        rel.RelaUserId = dr.GetString(0);
                       
                        relList.Add(rel);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR LOADING RELATIVE BY STUDENT ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return relList;

        }
    }
}
