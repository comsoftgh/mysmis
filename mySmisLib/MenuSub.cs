using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class MenuSub
    {
        public int ID { get; set; }
        public string Submenu { get; set; }
        public string Title { get; set; }
        public int MainId { get; set; }
        public int Active { get; set; }
        public string xActivity { get; set; }
        //public string xMenu { get; set; }
       // public string xTitle { get; set; }
        public MenuSub() {}
    }

   public class MenuSubService
   {
       public List<MenuSub> GetMenuSub(int mainId, string userId)
       {

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT `id`, `submenu`, `title`, `mainid`, `active` FROM `submenu` WHERE `active` = 1 AND `mainid` = @mainid";
           List<MenuSub> permList = new List<MenuSub>();
           MenuSub perm;


           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@mainid", mainId);
               //new AuditLogService().AddAuditLog("LOAD PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       perm = new MenuSub();
                       perm.ID = dr.GetInt32(0);
                       perm.Submenu = dr.GetString(1);
                       perm.Title = dr.GetString(2);
                       perm.MainId = dr.GetInt32(3);
                       perm.Active = dr.GetInt32(4);
                       
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
       public List<MenuSub> GetMenuSubUserHasNot(int mainId, string staffId,string userId)
       {

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT submenu.id,submenu.submenu,submenu.title,submenu.mainid,submenu.active FROM submenu WHERE submenu.mainid = @mainid AND submenu.active = 1 AND submenu.id NOT IN (SELECT subid FROM userpermission WHERE userId = @staffId )";
           List<MenuSub> permList = new List<MenuSub>();
           MenuSub perm;


           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@mainid", mainId);
               cmd.Parameters.AddWithValue("@staffId", staffId);
               //new AuditLogService().AddAuditLog("LOAD PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       perm = new MenuSub();
                       perm.ID = dr.GetInt32(0);
                       perm.Submenu = dr.GetString(1);
                       perm.Title = dr.GetString(2);
                       perm.MainId = dr.GetInt32(3);
                       perm.Active = dr.GetInt32(4);
                       perm.xActivity = "";

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
   }
}
