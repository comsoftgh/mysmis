using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class Venurooms
    {
       public int ID { get; set; }
       public int VenuId { get; set; }
       public string RoomName { get; set; }
       public int Size { get; set; }
       public int Active { get; set; }
       public string xVenuName { get; set; }
       public Venurooms(){}
    }

   public class VenuroomsService
   {
       public bool AddVenurooms(Venurooms vr, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `venurooms`(`venuid`, `roomname`, `size`) VALUES (@venuid,@roomname,@size)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);

           cmd.Parameters.AddWithValue("@venuid", vr.VenuId);
           cmd.Parameters.AddWithValue("@roomname", vr.RoomName);
           cmd.Parameters.AddWithValue("@size", vr.Size);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }

       public bool UpdateVenurooms(Venurooms vr, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `venurooms` SET `venuid`=@venuid,`roomname`=@roomname,`size`=@size WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@venuid", vr.VenuId);
           cmd.Parameters.AddWithValue("@roomname", vr.RoomName);
           cmd.Parameters.AddWithValue("@size", vr.Size);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }

       public bool DeleteVenurooms(int vrid, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `venurooms` SET `active`= 0 WHERE id = @id";
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

       public List<Venurooms> GetAllVenurooms(string userID)
       {
           List<Venurooms> listMod = new List<Venurooms>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT venurooms.id,venurooms.venuid,venurooms.roomname,venurooms.size,venurooms.active,venus.venuname FROM venurooms INNER JOIN venus ON venurooms.venuid = venus.id WHERE venurooms.active = 1";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               Venurooms Mod = new Venurooms();
               Mod.ID = dr.GetInt32(0);
               Mod.VenuId = dr.GetInt32(1);
               Mod.RoomName = dr.GetString(2);
               Mod.Size = dr.GetInt32(3);
               Mod.Active = dr.GetInt32(4);
               Mod.xVenuName = dr.GetString(5);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }

       public List<Venurooms> GetAllVenuroomsByVenuID(int vid, string userID)
       {
           List<Venurooms> listMod = new List<Venurooms>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT venurooms.id,venurooms.venuid,venurooms.roomname,venurooms.size,venurooms.active,venus.venuname FROM venurooms INNER JOIN venus ON venurooms.venuid = venus.id WHERE venurooms.active = 1 AND venurooms.venuid` = @venuid ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@venuid", vid);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               Venurooms Mod = new Venurooms ();
               Mod.ID = dr.GetInt32(0);
               Mod.VenuId = dr.GetInt32(1);
               Mod.RoomName = dr.GetString(2);
               Mod.Size = dr.GetInt32(3);
               Mod.Active = dr.GetInt32(4);
               Mod.xVenuName = dr.GetString(5);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }

   }
}
