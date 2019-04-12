using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class FeesPenalty
    {
        public int ID { get; set; }
        public string Bgroup { get; set; }
        public DateTime Deadline { get; set; }
        public double Pvalue { get; set; }
        public string Penalty { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }


       public FeesPenalty(){}
    }

   public class FeesPenaltyService
   {
       public bool AddFeesPenalty(FeesPenalty fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `feespenalty`(`bgroup`, `deadline`, `penalty`, `pvalue`, `createdate`, `modifydate`) VALUES (@bgroup,@deadline,@penalty,@pvalue,@createdate,@modifydate)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@deadline", fp.Deadline);
           cmd.Parameters.AddWithValue("@penalty", fp.Penalty);
           cmd.Parameters.AddWithValue("@pvalue", fp.Pvalue);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateFeesPenalty(FeesPenalty fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `feespenalty` SET `bgroup`=@bgroup,`deadline`=@deadline,`penalty`=@penalty,`pvalue`=@pvalue,`modifydate`=@modifydate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@deadline", fp.Deadline);
           cmd.Parameters.AddWithValue("@penalty", fp.Penalty);
           cmd.Parameters.AddWithValue("@pvalue", fp.Pvalue);
           cmd.Parameters.AddWithValue("@id", fp.ID);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteFeesPenalty(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `feespenalty` WHERE id = @id";
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
       public List<FeesPenalty> GetAllFeesPenalty(string userID)
       {
           List<FeesPenalty> retVal = new List<FeesPenalty>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `bgroup`, `deadline`, `penalty`, `pvalue`, `createdate`, `modifydate` FROM `feespenalty`";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesPenalty Mod = new FeesPenalty();
               Mod.ID = dr.GetInt32(0);
               Mod.Bgroup = dr.GetString(1);
               Mod.Deadline = dr.GetDateTime(2);
               Mod.Penalty = dr.GetString(3);
               Mod.Pvalue = dr.GetDouble(4);
               Mod.DateCreted = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

   }
}
