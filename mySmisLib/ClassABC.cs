using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class ClassABC
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int ModuleID { get; set; }
        public int Active { get; set; }
        public string ModuleName { get; set; }

        public ClassABC() { }

       
    }
   public class ClassABCServices
   {

       public bool AddClass(ClassABC insMod,string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentcourses`(`moduleID`, `title`, `description`) VALUES (@moduleID,@title,@description)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@moduleID", insMod.ModuleID);
           cmd.Parameters.AddWithValue("@title", insMod.Title);
           cmd.Parameters.AddWithValue("@description", insMod.Description);

           int affectedrows = cmd.ExecuteNonQuery();
           if (affectedrows > 0)
           {
               result = true;
           }

           con.Close();
           return result;
       }
       public List<ClassABC> GetAllClass(string userID)
       {
           List<ClassABC> listMod = new List<ClassABC>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `title`, `description`, `active` FROM `studentcourses` WHERE `active` = 1";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassABC Mod = new ClassABC();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.Title = dr.GetString(2);
               Mod.Description = dr.GetString(3);
               Mod.Active = dr.GetInt32(4);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassABC> GetAllClassNotStudReg(int indexNo, int modID, string userID)
       {
           List<ClassABC> listMod = new List<ClassABC>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentcourses.id, studentcourses.moduleID,studentcourses.title,studentcourses.description,studentcourses.active FROM studentcourses WHERE studentcourses.id NOT IN (SELECT classID FROM tbl_registration WHERE indexNo = @indexNo) AND studentcourses.moduleID = @modID AND active = 1";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           
           cmd.Parameters.AddWithValue("@modID", modID);
           cmd.Parameters.AddWithValue("@indexNo", indexNo);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassABC Mod = new ClassABC();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.Title = dr.GetString(2);
               Mod.Description = dr.GetString(3);
               Mod.Active = dr.GetInt32(4);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassABC> GetAllClassModule(string userID)
       {
           List<ClassABC> listMod = new List<ClassABC>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentcourses.id,studentcourses.moduleID,studentcourses.title,studentcourses.description,studentcourses.active,studentprograms.moduleName FROM studentcourses LEFT JOIN studentprograms ON studentcourses.moduleID = studentprograms.id WHERE studentcourses.active = 1 ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassABC Mod = new ClassABC();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.Title = dr.GetString(2);
               Mod.Description = dr.GetString(3);
               Mod.Active = dr.GetInt32(4);
               Mod.ModuleName = dr.GetString(5);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassABC> GetAllClassByModule(int modID,string userID)
       {
           List<ClassABC> listMod = new List<ClassABC>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentcourses.id,studentcourses.moduleID,studentcourses.title,studentcourses.description,studentcourses.active,studentprograms.moduleName FROM studentcourses LEFT JOIN studentprograms ON studentcourses.moduleID = studentprograms.id WHERE studentcourses.active = 1 AND studentcourses.moduleID=@modID";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@modID",modID);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassABC Mod = new ClassABC();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.Title = dr.GetString(2);
               Mod.Description = dr.GetString(3);
               Mod.Active = dr.GetInt32(4);
               Mod.ModuleName = dr.GetString(5);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public bool UpdateClass(ClassABC upMod, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "UPDATE `studentcourses` SET `moduleID`=@moduleID,`title`=@title,`description`=@description WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@id", upMod.ID);
           cmd.Parameters.AddWithValue("@title", upMod.Title);
           cmd.Parameters.AddWithValue("@description", upMod.Description);
           cmd.Parameters.AddWithValue("@moduleID", upMod.ModuleID);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteClass(int classID,string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "UPDATE `studentcourses` SET `active`= 0 WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@id", classID);
           
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       


   }

}
