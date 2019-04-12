using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class Venus
    {
       public int ID { get; set; }
   
       public string VenuName { get; set; }
       public string Description { get; set; }
       public int Active { get; set; }

       public Venus(){}
    }

    public class VenusService
    {
        public bool AddVenus(Venus vr, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `venus`(`venuname`,description) VALUES (@venuname,@description)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);

            cmd.Parameters.AddWithValue("@venuid", vr.VenuName);
            cmd.Parameters.AddWithValue("@description", vr.Description);
           

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool UpdateVenus(Venus vr, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `venus` SET `venuname`=@venuname,description =@description WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", vr.ID);
            cmd.Parameters.AddWithValue("@description", vr.Description);
            cmd.Parameters.AddWithValue("@venuname",vr.VenuName);
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool DeleteVenus(int vrid, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `venus` SET `active`= 0 WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", vrid);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public List<Venus> GetAllVenus(string userID)
        {
            List<Venus> listMod = new List<Venus>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `venuname`,description FROM `venus` WHERE `active` = 1";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Venus Mod = new Venus();
                Mod.ID = dr.GetInt32(0);
                Mod.VenuName = dr.GetString(1);
                Mod.Description = dr.GetString(2);

                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }


    }
}
