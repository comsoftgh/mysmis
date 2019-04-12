using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace mySmisLib
{
   public class Permission
    {
       public int Id { get; set; }
       public string UserId { get; set; }
       public int MainId { get; set; }
       public int SubMenuId { get; set; }
       public string Activity { get; set; }
       public DateTime DateCreated { get; set; }
       public DateTime LastModify { get; set; }

       public string xSubMenu { get;set; }
       public string xSubTitle { get; set; }

       public Permission() { }
    }
   public class PermissionService
   {
       /// <summary>
       /// Adds permission to database
       /// </summary>
       /// <param name="perm">permission object</param>
       /// <returns>True or False</returns>
       public bool AddPermission(Permission perm, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "INSERT INTO `userpermission`(`userId`, `role`, `activity`, `dateCreated`, `lastModify`) VALUES (@userId,@role,@activity,@dateCreated,@lastModify)";

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userId", perm.UserId);
               cmd.Parameters.AddWithValue("@role", perm.MainId);
               cmd.Parameters.AddWithValue("@activity", perm.Activity);
               cmd.Parameters.AddWithValue("@dateCreated", perm.DateCreated);
               cmd.Parameters.AddWithValue("@lastModify", perm.LastModify);
               new AuditLogService().AddAuditLog("ADD PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now); 
               int affecRow = cmd.ExecuteNonQuery();
               if (affecRow > 0)
               {
                   retVal = true;
               }
           }
           catch (MySqlException ex)
           {
               new AuditLogService().AddAuditLog("ERROR ADD PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           catch (Exception ex)
           {
               new AuditLogService().AddAuditLog("ERROR ADD PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }

           return retVal;
       }

       /// <summary>
       /// Gets a list of permission in database
       /// </summary>
       /// <returns>List of permision</returns>
       public List<Permission> GetPermissions(string userId,int mainId)
       {

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT userpermission.id,userpermission.userId,userpermission.mainid,userpermission.subid,userpermission.activity,userpermission.dateCreated,userpermission.lastModify,submenu.submenu,submenu.title FROM userpermission INNER JOIN submenu ON userpermission.subid = submenu.id WHERE userpermission.userId = @userId AND userpermission.mainid = @mainId";
           List<Permission> permList = new List<Permission>();
           Permission perm;

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userId",userId);
               cmd.Parameters.AddWithValue("@mainId",mainId);
               new AuditLogService().AddAuditLog("LOAD PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now); 
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       perm = new Permission();
                       perm.Id = dr.GetInt32(0);
                       perm.UserId = dr.GetString(1);
                       perm.MainId = dr.GetInt32(2);
                       perm.SubMenuId = dr.GetInt32(3);
                       perm.Activity = dr.GetString(4);
                       perm.DateCreated = dr.GetDateTime(5);
                       perm.LastModify = dr.GetDateTime(6);
                       perm.xSubMenu = dr.GetString(7);
                       perm.xSubTitle = dr.GetString(8);

                       permList.Add(perm);
                   }
               }
           }
           catch (MySqlException ex)
           {
               new AuditLogService().AddAuditLog("ERROR LOADING PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           catch (Exception ex)
           {
               new AuditLogService().AddAuditLog("ERROR LOADING PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           finally
           {
               dr.Close();
               con.Close();
           }

           return permList;
       }

       /// <summary>
       /// Gets a list of permission by permision id
       /// </summary>
       /// <param name="upermId">permission Id</param>
       /// <returns>List of permision of a particular Id</returns>
       public List<Permission> GetPermissions(string upermId, string userId)
       {
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT `id`, `userId`, `role`, `activity`, `dateCreated`, `lastModify` FROM `userpermission` WHERE userId =@userId";
           List<Permission> permList = new List<Permission>();
           Permission perm;


           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userId", upermId);
               new AuditLogService().AddAuditLog("LOAD PERMISSION BY ID", userId, new UserService().GetUserName(userId), query, DateTime.Now); 
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       perm = new Permission();
                       perm.Id = dr.GetInt32(0);
                       perm.UserId = dr.GetString(1);
                       perm.MainId = dr.GetInt32(2);
                       perm.DateCreated = dr.GetDateTime(3);
                       perm.LastModify = dr.GetDateTime(4);

                       permList.Add(perm);
                   }
               }
           }
           catch (MySqlException ex)
           {
               new AuditLogService().AddAuditLog("ERROR LOADING PERMISSION BY ID", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           catch (Exception ex)
           {
               new AuditLogService().AddAuditLog("ERROR LOADING PERMISSION BY ID", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           finally
           {
               dr.Close();
               con.Close();
           }
           return permList;
       }


       /// <summary>
       /// Deletes permission
       /// </summary>
       /// <param name="permId">permission Id</param>
       /// <returns>True or False</returns>
       public bool DeletePermission(int permId, string userId)
       {
           Boolean retVal = false;

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = string.Format("DELETE FROM userpermission WHERE id='{0}'", permId);

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               int affecRow = cmd.ExecuteNonQuery();
               new AuditLogService().AddAuditLog("ERROR LOADING BY ROLE PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now); 
               if (affecRow > 0)
               {
                   retVal = true;
               }
           }
           catch (MySqlException ex)
           {
               new AuditLogService().AddAuditLog("ERROR DELETING PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           catch (Exception ex)
           {
               new AuditLogService().AddAuditLog("ERROR DELETING PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }
          
           return retVal;
       }

       /// <summary>
       /// Updates permissions
       /// </summary>
       /// <param name="perm">Permission Object</param>
       /// <returns>True or False</returns>
       public bool UpdatePermission(Permission perm, string userId)
       {
           Boolean retVal = false;

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;

           string query = "UPDATE `userpermission` SET `userId`=@userId,`role`=@role,`activity`=@activity,`lastModify`=@lastModify WHERE id=@id";
           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userId", perm.UserId);
               cmd.Parameters.AddWithValue("@role", perm.MainId);
               cmd.Parameters.AddWithValue("@activity", perm.Activity);
               cmd.Parameters.AddWithValue("@id", perm.Id);
               cmd.Parameters.AddWithValue("@lastModify", perm.LastModify);
               int affecRow = cmd.ExecuteNonQuery();
               new AuditLogService().AddAuditLog("UPDATE PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now); 
               if (affecRow > 0)
               {
                   retVal = true;
               }
           }
           catch (MySqlException ex)
           {
               new AuditLogService().AddAuditLog("ERROR UPDATE PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           catch (Exception ex)
           {
               new AuditLogService().AddAuditLog("ERROR UPDATE PERMISSION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now); 
               string errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }
           return retVal;
       }

       public string GetPermissionsActivity(string userId,string permActity)
       {

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT userpermission.activity FROM userpermission INNER JOIN submenu ON userpermission.subid = submenu.id INNER JOIN mainmenu ON userpermission.mainid = mainmenu.id WHERE userId = @userId AND submenu = @submenu ";
           string uPermList = "";



           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@submenu", permActity);
               cmd.Parameters.AddWithValue("@userId", userId);
               dr = cmd.ExecuteReader();
               // new AuditLogService().AddAuditLog("GET ALL USER PERMISSION", userId, new UserService().GetUserName(userId),   query, DateTime.Now);
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {

                       uPermList = dr.GetString(0);


                       //uPermList.Add(uPerm);
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

       public bool CheckPermissions(string userId, int mainId,int subId,string activity)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = string.Format("SELECT userpermission.id FROM userpermission WHERE userpermission.userId = {0} AND userpermission.subid = {1} AND userpermission.activity LIKE '%{2}%' AND userpermission.mainid = {3}",userId,subId,activity,mainId);
                      
           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               //cmd.Parameters.AddWithValue("@userId", userId);
               //cmd.Parameters.AddWithValue("@mainId", mainId);
               //cmd.Parameters.AddWithValue("@subId", subId);
               //cmd.Parameters.AddWithValue("@activity", activity);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   retVal = true;
               }
           }
           catch (MySqlException ex)
           {
              
              
           }
           catch (Exception ex)
           {
               
               
           }
           finally
           {
               dr.Close();
               con.Close();
           }

           return retVal;
       }
   }
}
