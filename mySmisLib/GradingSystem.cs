using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class GradingSystem
    {
       public int GsId { get; set; }
       public decimal GsPoint { get; set; }
       public string GsGrade { get; set; }
       public int GsLowScore { get; set; }
       public int GsUpScore { get; set; }
       public string GSDescription { get; set; }
       public int GsgsId { get; set; }
       public DateTime GsDateCreated {get;set;}
       public DateTime GsLastModified { get; set; }
       public int Gsvgstypeid { get; set; }

       public int xGsId { get; set; }
       public string xGsType { get; set; }
       public GradingSystem(){}
    }

   public class GradingSystemService
   {
       public bool AddGradingSystem(GradingSystem fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `gradesystemvalue`(`gsvpoint`, `gsvgrade`, `gsvlowscore`, `gsvupscore`, `gsvdescription`, `gsvgsid`, `gsvDateCreated`, `gsvLastModified`,gsvgstypeid) VALUES (@gsvpoint,@gsvgrade,@gsvlowscore,@gsvupscore,@gsvdescription,@gsvgsid,@gsvDateCreated,@gsvLastModified,@gsvgstypeid)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@gsvpoint", fp.GsPoint);
           cmd.Parameters.AddWithValue("@gsvgrade", fp.GsGrade);
           cmd.Parameters.AddWithValue("@gsvlowscore", fp.GsLowScore);
           cmd.Parameters.AddWithValue("@gsvupscore", fp.GsUpScore);
           cmd.Parameters.AddWithValue("@gsvdescription", fp.GSDescription);
           cmd.Parameters.AddWithValue("@gsvgsid", fp.GsgsId);
           cmd.Parameters.AddWithValue("@gsvDateCreated", fp.GsDateCreated);
           cmd.Parameters.AddWithValue("@gsvLastModified", fp.GsLastModified);
           cmd.Parameters.AddWithValue("@gsvgstypeid", fp.Gsvgstypeid);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateGradingSystem(GradingSystem fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `gradesystemvalue` SET `gsvpoint`=@gsvpoint,`gsvgrade`=@gsvgrade,`gsvlowscore`=@gsvlowscore,`gsvupscore`=@gsvupscore,`gsvdescription`=@gsvdescription,`gsvgsid`=@gsvgsid,`gsvLastModified`=@gsvLastModified,gsvgstypeid = @gsvgstypeid WHERE  gsvid = @gsvid";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@gsvpoint", fp.GsPoint);
           cmd.Parameters.AddWithValue("@gsvgrade", fp.GsGrade);
           cmd.Parameters.AddWithValue("@gsvlowscore", fp.GsLowScore);
           cmd.Parameters.AddWithValue("@gsvupscore", fp.GsUpScore);
           cmd.Parameters.AddWithValue("@gsvdescription", fp.GSDescription);
           cmd.Parameters.AddWithValue("@gsvgsid", fp.GsgsId);
           cmd.Parameters.AddWithValue("@gsvLastModified", fp.GsLastModified);
           cmd.Parameters.AddWithValue("@gsvid", fp.GsId);
           cmd.Parameters.AddWithValue("@gsvgstypeid", fp.Gsvgstypeid);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteGradingSystem(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `gradesystemvalue` WHERE gsvid = @gsvid";
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
       public List<GradingSystem> GetAllGradingSystem(string userID)
       {
           List<GradingSystem> retVal = new List<GradingSystem>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT gradesystem.gsid,gradesystem.gstype,gradesystemvalue.gsvid,gradesystemvalue.gsvpoint,gradesystemvalue.gsvgrade,gradesystemvalue.gsvlowscore,gradesystemvalue.gsvupscore,gradesystemvalue.gsvdescription,gradesystemvalue.gsvgsid,gradesystemvalue.gsvDateCreated,gradesystemvalue.gsvLastModified FROM gradesystem LEFT JOIN gradesystemvalue ON gradesystem.gsid = gradesystemvalue.gsvgsid ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@gsvgsid", gsgsId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               GradingSystem Mod = new GradingSystem();
               Mod.xGsId = dr.GetInt32(0);
               Mod.xGsType = dr.GetString(1);
               Mod.GsId = dr.GetInt32(2);
               Mod.GsPoint = dr.GetDecimal(3);
               Mod.GsGrade = dr.GetString(4);
               Mod.GsLowScore = dr.GetInt32(5);
               Mod.GsUpScore = dr.GetInt32(6);
               Mod.GSDescription = dr.GetString(7);
               Mod.GsgsId = dr.GetInt32(8);
               Mod.GsDateCreated = dr.GetDateTime(9);
               Mod.GsLastModified = dr.GetDateTime(10);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<GradingSystem> GetAllGradingSystem(int gsgsId, string userID)
       {
           List<GradingSystem> retVal = new List<GradingSystem>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT gradesystem.gsid,gradesystem.gstype,gradesystemvalue.gsvid,gradesystemvalue.gsvpoint,gradesystemvalue.gsvgrade,gradesystemvalue.gsvlowscore,gradesystemvalue.gsvupscore,gradesystemvalue.gsvdescription,gradesystemvalue.gsvgsid,gradesystemvalue.gsvDateCreated,gradesystemvalue.gsvLastModified FROM gradesystem LEFT JOIN gradesystemvalue ON gradesystem.gsid = gradesystemvalue.gsvgsid WHERE gsvgsid = @gsvgsid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@gsvgsid", gsgsId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               GradingSystem Mod = new GradingSystem();
               Mod.xGsId = dr.GetInt32(0);
               Mod.xGsType = dr.GetString(1);
               Mod.GsId = dr.GetInt32(2);
               Mod.GsPoint = dr.GetDecimal(3);
               Mod.GsGrade = dr.GetString(4);
               Mod.GsLowScore = dr.GetInt32(5);
               Mod.GsUpScore = dr.GetInt32(6);
               Mod.GSDescription = dr.GetString(7);
               Mod.GsgsId = dr.GetInt32(8);
               Mod.GsDateCreated = dr.GetDateTime(9);
               Mod.GsLastModified = dr.GetDateTime(10);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public GradingSystem GetGradingSystem(int Id, string userID)
       {
           GradingSystem Mod = new GradingSystem();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT gradesystem.gsid,gradesystem.gstype,gradesystemvalue.gsvid,gradesystemvalue.gsvpoint,gradesystemvalue.gsvgrade,gradesystemvalue.gsvlowscore,gradesystemvalue.gsvupscore,gradesystemvalue.gsvdescription,gradesystemvalue.gsvgsid,gradesystemvalue.gsvDateCreated,gradesystemvalue.gsvLastModified,gsvgstypeid FROM gradesystem LEFT JOIN gradesystemvalue ON gradesystem.gsid = gradesystemvalue.gsvgsid  WHERE gsvid = @gsvid ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@gsvid", Id);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
              // GradingSystem Mod = new GradingSystem();
               Mod.xGsId = dr.GetInt32(0);
               Mod.xGsType = dr.GetString(1);
               Mod.GsId = dr.GetInt32(2);
               Mod.GsPoint = dr.GetDecimal(3);
               Mod.GsGrade = dr.GetString(4);
               Mod.GsLowScore = dr.GetInt32(5);
               Mod.GsUpScore = dr.GetInt32(6);
               Mod.GSDescription = dr.GetString(7);
               Mod.GsgsId = dr.GetInt32(8);
               Mod.GsDateCreated = dr.GetDateTime(9);
               Mod.GsLastModified = dr.GetDateTime(10);
               Mod.Gsvgstypeid = dr.GetInt32(11);
               
           }


           con.Close();

           return Mod;
       }
       public bool ExitGradingSystem(GradingSystem gs, string userID)
       {
           bool result = false;

           //int rows = 0;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlDataReader dr = null;
           MySqlCommand cmd = null;

           string sqlUpdate = "SELECT gsvgsid FROM gradesystemvalue WHERE gsvgsid = @gsvgsid AND `gsvpoint` = @gsvpoint  AND `gsvgrade` = @gsvgrade AND gsvgstypeid = @gsvgstypeid ";
           con.Open();
           cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@gsvgsid", gs.GsgsId);
           cmd.Parameters.AddWithValue("@gsvpoint", gs.GsPoint);
           cmd.Parameters.AddWithValue("@gsvgrade", gs.GsGrade);
           cmd.Parameters.AddWithValue("@gsvgstypeid", gs.Gsvgstypeid);

           dr = cmd.ExecuteReader();
           if (dr.HasRows)
           {
               result = true;
           }

           con.Close();
          

           return result;
       }
       public GradingSystem GetGradingSystem(int gsgsId, decimal score)
       {
           GradingSystem Mod = new GradingSystem();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT gradesystemvalue.gsvid,gradesystemvalue.gsvpoint,gradesystemvalue.gsvgrade,gradesystemvalue.gsvlowscore,gradesystemvalue.gsvupscore,gradesystemvalue.gsvdescription,gradesystemvalue.gsvgsid FROM gradesystemvalue WHERE @score BETWEEN gradesystemvalue.gsvlowscore AND  gradesystemvalue.gsvupscore AND gsvgsid = @gsvgsid ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@gsvgsid",gsgsId);
           cmd.Parameters.AddWithValue("@score", score);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               // GradingSystem Mod = new GradingSystem();
               Mod.GsId = dr.GetInt32(0);
               Mod.GsPoint = dr.GetDecimal(1);
               Mod.GsGrade = dr.GetString(2);
               Mod.GsLowScore = dr.GetInt32(3);
               Mod.GsUpScore = dr.GetInt32(4);
               Mod.GSDescription = dr.GetString(5);
               Mod.GsgsId = dr.GetInt32(6);

           }


           con.Close();

           return Mod;
       }
      

   }
}
