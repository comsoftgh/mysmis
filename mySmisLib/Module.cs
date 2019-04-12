using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{

    public class Module
    {
        public int ModuleID { get; set; }
        public String ModuleName { get; set; }
        public String Description { get; set; }
        public int Active { get; set; }

        public Module() { }

        
    }
    public class ModuleServices
    {
      public bool insertModule(Module insMod,string userId)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "INSERT INTO `studentprograms`(`moduleName`, `description`) VALUES (@moduleName,@description)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@moduleName", insMod.ModuleName);
                cmd.Parameters.AddWithValue("@description", insMod.Description);
                
                int affectedrows = cmd.ExecuteNonQuery();
                if (affectedrows > 0)
                {
                    result = true; 
                }
                
                con.Close();
                return result;
            }
      public List<Module> GetAllModule(string userId)
      {
          List<Module> listMod = new List<Module>();
          MySqlConnection con = new MySqlConnection(DbCon.connectionString);
          string sqlInsert = "SELECT `id`, `moduleName`, `description`, `active` FROM `studentprograms` WHERE `active` = 1 ";
          MySqlDataReader dr = null;
          MySqlCommand cmd;
          con.Open();
          cmd = new MySqlCommand(sqlInsert, con);
          dr = cmd.ExecuteReader();
          
          while (dr.Read()) //iterate through the records in the result dataset
            {
                Module Mod = new Module();
                Mod.ModuleID = dr.GetInt32(0);
                Mod.ModuleName = dr.GetString(1);
                Mod.Description = dr.GetString(2);
                Mod.Active = dr.GetInt32(3);
                listMod.Add(Mod);
            }

          
          con.Close();
          return listMod;
      }
      public bool updateModule(Module upMod,string userId)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlUpdate = "update studentprograms set moduleName=@moduleName,description=@description WHERE id = @moduleID";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@moduleID", upMod.ModuleID);
                cmd.Parameters.AddWithValue("@moduleName", upMod.ModuleName);
                cmd.Parameters.AddWithValue("@description", upMod.Description);
                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
      public bool deleteModule(int modID,string userId)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlUpdate = "update studentprograms set active = 0 WHERE id = @moduleID";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@moduleID", modID);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }

    }
}
