using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class MenuMain
    {
        public int ID { get; set; }
        public string Menu { get; set; }
        public string Title { get; set; }
        public int UserType { get; set; }
        public int Active { get; set; }

        
       // public string xTitle { get; set; }
       public MenuMain(){}
    }

   public class MenuMainService
   {
       public List<MenuMain> GetMenuMain(string userId)
       {

           MySqlConnection con = new MySqlConnection(DbCon.connectionString);

           MySqlCommand cmd;
           MySqlDataReader dr = null;

           string query = "SELECT `id`, `menu`, `title`, `active`, `usertype` FROM `mainmenu` WHERE `active` = 1";
           List<MenuMain> permList = new List<MenuMain>();
           MenuMain perm;


           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               //cmd.Parameters.AddWithValue("@userid", userId);
               //new AuditLogService().AddAuditLog("LOAD PERMISSION", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       perm = new MenuMain();
                       perm.ID = dr.GetInt32(0);
                       perm.Menu = dr.GetString(1);
                       perm.Title = dr.GetString(2);
                       perm.Active = dr.GetInt32(3);
                       perm.UserType = dr.GetInt32(4);
                       

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
