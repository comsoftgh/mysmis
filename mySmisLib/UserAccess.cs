using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class UserAccess
    {
       public int ID { get; set; }
       public string UserId { get; set; }
       public int MainId { get; set; }
       public DateTime DateCreated { get; set; }
       public DateTime LastModify { get; set; }

       public string xMenu { get; set; }
       public string xTitle { get; set; }

       public UserAccess(){}
    }

   public class UserAccessService
   {
       public bool AddUserAccess(UserAccess uPerm, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "INSERT INTO `useraccess`(`userid`, `mainid`, `dateCreated`, `dateModify`) VALUES (@userid,@mainid,@dateCreated,@dateModify)";
              

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userid", uPerm.UserId);
               cmd.Parameters.AddWithValue("@mainid", uPerm.MainId);
               cmd.Parameters.AddWithValue("@dateCreated", uPerm.DateCreated);
               cmd.Parameters.AddWithValue("@dateModify", uPerm.LastModify);
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
       public List<UserAccess> GetUserAccess(string userId)
       {

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT useraccess.id,useraccess.userid,useraccess.mainid,useraccess.dateCreated,useraccess.dateModify,mainmenu.menu,mainmenu.title FROM useraccess INNER JOIN mainmenu ON useraccess.mainid = mainmenu.id WHERE useraccess.userid =@userid";
           List<UserAccess> permList = new List<UserAccess>();
           UserAccess perm;


           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userid", userId);
               new AuditLogService().AddAuditLog("LOAD PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       perm = new UserAccess();
                       perm.ID = dr.GetInt32(0);
                       perm.UserId = dr.GetString(1);
                       perm.MainId = dr.GetInt32(2);
                       perm.DateCreated = dr.GetDateTime(3);
                       perm.LastModify = dr.GetDateTime(4);
                       perm.xMenu = dr.GetString(5);
                       perm.xTitle = dr.GetString(6);

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
       public bool DeleteUserAccess(int uPermId, string userId)
       {
           Boolean retVal = false;

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "DELETE FROM `useraccess` WHERE id=@id";

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@id",uPermId);
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
       public bool ExistUserAccess(UserAccess uPerm, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlDataReader dr = null;
           MySqlCommand cmd;

           string query = "SELECT `userid` `useraccess` WHERE userid=@userid AND mainid =@mainid ";


           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userid", uPerm.UserId);
               cmd.Parameters.AddWithValue("@mainid", uPerm.MainId);
               
               //int affecRow = cmd.ExecuteNonQuery();
               //new AuditLogService().AddAuditLog("ADD USER PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
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
   }
}
