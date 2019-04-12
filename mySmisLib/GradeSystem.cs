using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class GradeSystem
    {
        public int GsId { get; set; }
        public string GsType { get; set; }
        public int GsTypeId { get; set; }
        public string xGingsType { get; set; }
        
        public GradeSystem() { }
    }

    public class GradeSystemService
    {
        public bool AddGradeSystem(GradeSystem fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `gradesystem`(`gstype`, `gstypeid`) VALUES (@gstype,@gstypeid)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@gstype", fp.GsType);
            cmd.Parameters.AddWithValue("@gstypeid", fp.GsTypeId);
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdateGradeSystem(GradeSystem fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `gradesystem` SET `gstype`=@gstype,`gstypeid`=@gstypeid WHERE  gsvid = @gsvid";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@gstype", fp.GsType);
            cmd.Parameters.AddWithValue("@gstypeid", fp.GsTypeId);
            cmd.Parameters.AddWithValue("@gsid", fp.GsId);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteGradeSystem(int gsid, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "DELETE FROM `gradesystem` WHERE gsid = @gsid";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@gsid", gsid);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public List<GradeSystem> GetAllGradeSystem(string userID)
        {
            List<GradeSystem> retVal = new List<GradeSystem>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `gsid`, `gstype`, `gstypeid` FROM `gradesystem`";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@gsvgsid", gsgsId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                GradeSystem Mod = new GradeSystem();
                Mod.GsId = dr.GetInt32(0);
                Mod.GsType = dr.GetString(1);
                Mod.GsTypeId = dr.GetInt32(2);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<GradeSystem> GetAllGradeSystem(int gstypeId, string userID)
        {
            List<GradeSystem> retVal = new List<GradeSystem>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT gradesystem.gsid,gradesystem.gstype,gradesystem.gstypeid,gradesystemtype.type FROM gradesystem INNER JOIN gradesystemtype ON gradesystem.gstypeid = gradesystemtype.id WHERE gradesystem.gstypeid = @gstypeid";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@gstypeid", gstypeId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                GradeSystem Mod = new GradeSystem();
                Mod.GsId = dr.GetInt32(0);
                Mod.GsType = dr.GetString(1);
                Mod.GsTypeId = dr.GetInt32(2);
                Mod.xGingsType = dr.GetString(3);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public GradeSystem GetGradeSystem(int Id, string userID)
        {
            GradeSystem Mod = new GradeSystem();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT gradesystem.gsid,gradesystem.gstype,gradesystem.gstypeid,gradesystemtype.type FROM gradesystem INNER JOIN gradesystemtype ON gradesystem.gstypeid = gradesystemtype.id WHERE gradesystem.gsid = @gsid ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@gsid", Id);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                // GradeSystem Mod = new GradeSystem();
                Mod.GsId = dr.GetInt32(0);
                Mod.GsType = dr.GetString(1);
                Mod.GsTypeId = dr.GetInt32(2);
                Mod.xGingsType = dr.GetString(3);

            }


            con.Close();

            return Mod;
        }
        public bool ExitGradeSystem(GradeSystem gs, string userID)
        {
            bool result = false;

            //int rows = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd = null;

            string sqlUpdate = "SELECT `gsid`, `gstype`, `gstypeid` FROM `gradesystem` WHERE gstype = @gstype AND `gstypeid` = @gstypeid";
            con.Open();
            cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@gstype", gs.GsType);
            cmd.Parameters.AddWithValue("@gstypeid", gs.GsTypeId);
            
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                result = true;
            }

            con.Close();


            return result;
        }
       
    }
}
