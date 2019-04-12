using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class FeesCategory
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string Applyto { get; set; }
        public int Active { get; set; }

        public double xFeevalue { get; set; }

        public FeesCategory(){}

    }

   public class FeesCategoryService
   {
       public bool AddFeesCategory(FeesCategory fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `feescategory`(`title`, `description`, `createdate`, `modifydate`,applyto) VALUES (@title,@description,@createdate,@modifydate,@applyto)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@title", fp.Title);
           cmd.Parameters.AddWithValue("@description", fp.Description);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@applyto", fp.Applyto);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateFeesCategory(FeesCategory fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `feescategory` SET `title`=@title,`description`=@description,`modifydate`=@modifydate,applyto =@applyto WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@title", fp.Title);
           cmd.Parameters.AddWithValue("@description", fp.Description);
           cmd.Parameters.AddWithValue("@id", fp.ID);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@applyto", fp.Applyto);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteFeesCategory(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `feescategory` SET active = 0 WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@id", fp);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool ExistFeesCategory(FeesCategory fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT id FROM `feescategory` WHERE title = @title AND applyto = @applyto AND active = 1";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           MySqlDataReader dr = null;
           
           cmd.Parameters.AddWithValue("@title", fp.Title);
           cmd.Parameters.AddWithValue("@applyto", fp.Applyto);
           dr = cmd.ExecuteReader();
           //new AuditLogService().AddAuditLog("LOADING RELATIVES BY TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);
           if (dr.HasRows)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public List<FeesCategory> GetAllFeesCategory(string userID)
       {
           List<FeesCategory> retVal = new List<FeesCategory>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `title`, `description`, `createdate`, `modifydate`,applyto,active FROM `feescategory` WHERE active = 1";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesCategory Mod = new FeesCategory();
               Mod.ID = dr.GetInt32(0);
               Mod.Title = dr.GetString(1);
               Mod.Description = dr.GetString(2);
               Mod.DateCreted = dr.GetDateTime(3);
               Mod.LastModified = dr.GetDateTime(4);
               Mod.Applyto = dr.GetString(5);
               Mod.Active = dr.GetInt32(6);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<FeesCategory> GetAllFeesCategoryByBatchid(int batchId, string applyto, string userID)
       {
           List<FeesCategory> retVal = new List<FeesCategory>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT feescategory.id,feescategory.title,feescategory.description,feescategory.createdate,feescategory.modifydate,feescategory.applyto,feescategory.active FROM feescategory WHERE feescategory.id NOT IN (SELECT feesbatches.feecateid FROM feesbatches WHERE feesbatches.batchid = @batchid) AND feescategory.applyto = @applyto";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@applyto", applyto);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesCategory Mod = new FeesCategory();
               Mod.ID = dr.GetInt32(0);
               Mod.Title = dr.GetString(1);
               Mod.Description = dr.GetString(2);
               Mod.DateCreted = dr.GetDateTime(3);
               Mod.LastModified = dr.GetDateTime(4);
               Mod.Applyto = dr.GetString(5);
               Mod.Active = dr.GetInt32(6);
               Mod.xFeevalue = 0;
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
   }

}
