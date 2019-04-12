using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    /// <summary>
    /// Object class for user permission
    /// </summary>
    public class UserPermission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SubMenu { get; set; }
        public int SubId { get; set; }
        public string MainMenu { get; set; }
        public int MainId { get; set; }
        public string Activity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModify { get; set; }

        public UserPermission(){ }
    }

    /// <summary>
    /// The service class for user permission
    /// </summary>
    public class UserPermissionService
    {
       
        public bool AddUserPermission(UserPermission uPerm, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `userpermission`(`userId`, `mainid`, `subid`, `activity`, `dateCreated`, `lastModify`) VALUES (@userId,@mainid,@subid,@activity,@dateCreated,@lastModify)";

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", uPerm.UserId);
                cmd.Parameters.AddWithValue("@mainid", uPerm.MainId);
                cmd.Parameters.AddWithValue("@subid", uPerm.SubId);
                cmd.Parameters.AddWithValue("@activity", uPerm.Activity);
                cmd.Parameters.AddWithValue("@dateCreated", uPerm.DateCreated);
                cmd.Parameters.AddWithValue("@lastModify", uPerm.LastModify);
                int affecRow = cmd.ExecuteNonQuery();
                //new AuditLogService().AddAuditLog("ADD USER PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR ADD USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR ADD USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public bool AddUserPermissionList(string uPerm, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("INSERT INTO `userpermission`(`userId`, `mainid`, `subid`, `activity`, `dateCreated`, `lastModify`) VALUES {0}",uPerm);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@userId", uPerm.UserId);
                //cmd.Parameters.AddWithValue("@mainid", uPerm.MainId);
                //cmd.Parameters.AddWithValue("@subid", uPerm.SubId);
                //cmd.Parameters.AddWithValue("@activity", uPerm.Activity);
                //cmd.Parameters.AddWithValue("@dateCreated", uPerm.DateCreated);
                //cmd.Parameters.AddWithValue("@lastModify", uPerm.LastModify);
                int affecRow = cmd.ExecuteNonQuery();
                //new AuditLogService().AddAuditLog("ADD USER PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR ADD USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR ADD USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public List<UserPermission> GetUserPermissions(string userId)
        {

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT userpermission.id,userpermission.userId,userpermission.mainid,userpermission.subid,userpermission.activity,userpermission.dateCreated,userpermission.lastModify,mainmenu.title AS mainmenu,submenu.title AS submenu FROM userpermission INNER JOIN mainmenu ON userpermission.mainid = mainmenu.id INNER JOIN submenu ON userpermission.subid = submenu.id";
            List<UserPermission> uPermList = new List<UserPermission>();
            UserPermission uPerm;


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                // new AuditLogService().AddAuditLog("GET ALL USER PERMISSION", userId, new UserService().GetUserName(userId),   query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uPerm = new UserPermission();
                        uPerm.Id = dr.GetInt32(0);
                        uPerm.UserId = dr.GetString(1);
                        uPerm.MainId = dr.GetInt32(2);
                        uPerm.SubId = dr.GetInt32(3);
                        uPerm.Activity = dr.GetString(4);
                        uPerm.DateCreated = dr.GetDateTime(5);
                        uPerm.LastModify = dr.GetDateTime(6);
                        uPerm.MainMenu = dr.GetString(7);
                        uPerm.SubMenu = dr.GetString(8);

                        uPermList.Add(uPerm);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING ALL USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING ALL USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return uPermList;
        }
        public List<UserPermission> GetUserPermissions(string staffId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT userpermission.id,userpermission.userId,userpermission.mainid,userpermission.subid,userpermission.activity,userpermission.dateCreated,userpermission.lastModify,mainmenu.title AS mainmenu,submenu.title AS submenu FROM userpermission INNER JOIN mainmenu ON userpermission.mainid = mainmenu.id INNER JOIN submenu ON userpermission.subid = submenu.id WHERE userId='{0}'", staffId);
            List<UserPermission> uPermList = new List<UserPermission>();
            UserPermission uPerm;


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                //  new AuditLogService().AddAuditLog("LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uPerm = new UserPermission();
                        uPerm.Id = dr.GetInt32(0);
                        uPerm.UserId = dr.GetString(1);
                        uPerm.MainId = dr.GetInt32(2);
                        uPerm.SubId = dr.GetInt32(3);
                        uPerm.Activity = dr.GetString(4);
                        uPerm.DateCreated = dr.GetDateTime(5);
                        uPerm.LastModify = dr.GetDateTime(6);
                        uPerm.MainMenu = dr.GetString(7);
                        uPerm.SubMenu = dr.GetString(8);
                        uPermList.Add(uPerm);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return uPermList;
        }

        public List<UserPermission> GetUserDistinctPermissions(string staffId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT DISTINCT(userpermission.mainid),mainmenu.title FROM userpermission INNER JOIN mainmenu ON userpermission.mainid = mainmenu.id INNER JOIN submenu ON userpermission.subid = submenu.id WHERE userId='{0}'", staffId);
            List<UserPermission> uPermList = new List<UserPermission>();
            UserPermission uPerm;


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                //  new AuditLogService().AddAuditLog("LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uPerm = new UserPermission();
                        //uPerm.Id = dr.GetInt32(2);
                        uPerm.MainMenu = dr.GetString(1);
                        uPerm.MainId = dr.GetInt32(0);
                        
                        uPermList.Add(uPerm);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return uPermList;
        }
        public List<UserPermission> GetUserPermissions(string staffId,int mainId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT userpermission.id,userpermission.userId,userpermission.mainid,userpermission.subid,userpermission.activity,userpermission.dateCreated,userpermission.lastModify,mainmenu.title AS mainmenu,submenu.title AS submenu FROM userpermission INNER JOIN mainmenu ON userpermission.mainid = mainmenu.id INNER JOIN submenu ON userpermission.subid = submenu.id WHERE userId='{0}' AND userpermission.mainid ='{1}'", staffId,mainId);
            List<UserPermission> uPermList = new List<UserPermission>();
            UserPermission uPerm;


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                //  new AuditLogService().AddAuditLog("LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uPerm = new UserPermission();
                        uPerm.Id = dr.GetInt32(0);
                        uPerm.UserId = dr.GetString(1);
                        uPerm.MainId = dr.GetInt32(2);
                        uPerm.SubId = dr.GetInt32(3);
                        uPerm.Activity = dr.GetString(4);
                        uPerm.DateCreated = dr.GetDateTime(5);
                        uPerm.LastModify = dr.GetDateTime(6);
                        uPerm.MainMenu = dr.GetString(7);
                        uPerm.SubMenu = dr.GetString(8);
                        uPermList.Add(uPerm);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("ERROR LOADING USER PERMISSION BY USER ID", logUserId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return uPermList;
        }
        public bool DeleteUserPermission(int id, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("DELETE FROM userPermission WHERE id='{0}'", id);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                int affecRow = cmd.ExecuteNonQuery();
                //   new AuditLogService().AddAuditLog("DELETE USER PERMISSION", logUserId, new UserService().GetUserName(logUserId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //   new AuditLogService().AddAuditLog("ERROR DELETING USER PERMISSION", logUserId, new UserService().GetUserName(logUserId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //  new AuditLogService().AddAuditLog("ERROR DELETING USER PERMISSION", logUserId, new UserService().GetUserName(logUserId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public bool UpdateUserPermission(UserPermission uPerm, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;

            string query = "UPDATE `userpermission` SET `activity`=@activity,`lastModify`=@lastModify WHERE `id` = @id";
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@activity", uPerm.Activity);
                cmd.Parameters.AddWithValue("@id", uPerm.Id);
                cmd.Parameters.AddWithValue("@lastModify", uPerm.LastModify);
                int affecRow = cmd.ExecuteNonQuery();
                //  new AuditLogService().AddAuditLog("UPDATE USER PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("ERROR UPDATING USER PERMISSION" , userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("ERROR UPDATING USER PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
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
