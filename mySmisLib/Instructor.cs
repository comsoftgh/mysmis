using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string SName { get; set; }
        public string OName { get; set; }
        public int MemberID { get; set; }
        public string Tel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public Instructor() { }

        
    }
    public class InstructorService
    {
      public bool insertInstructor(Instructor insInst,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "INSERT INTO `tbl_instructor`(`sName`, `oNames`, `memberID`, `tel`, `createdDate`, `lastModified`) VALUES (@sName,@oName,@memberID,@tel,@createdDate,@lastModified)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@memberID", insInst.MemberID);
                cmd.Parameters.AddWithValue("@sName", insInst.SName);
                cmd.Parameters.AddWithValue("@oName", insInst.OName);
                cmd.Parameters.AddWithValue("@createdDate", insInst.CreatedDate);
                cmd.Parameters.AddWithValue("@lastModified", insInst.LastModified);
                cmd.Parameters.AddWithValue("@tel", insInst.Tel);
                if (cmd.ExecuteNonQuery()>0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
      public bool updateInstructor(Instructor insInst,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "UPDATE `tbl_instructor` SET `sName`=@sName,`oNames`=@oNames,`memberID`=@memberID,`tel`=@tel,`lastModified`=@lastModified WHERE instructorID=@instructorID";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@instructorID", insInst.InstructorID);
                cmd.Parameters.AddWithValue("@memberID", insInst.MemberID);
                cmd.Parameters.AddWithValue("@sName", insInst.SName);
                cmd.Parameters.AddWithValue("@oNames", insInst.OName);
                cmd.Parameters.AddWithValue("@lastModified", insInst.LastModified);
                cmd.Parameters.AddWithValue("@tel", insInst.Tel);
                if (cmd.ExecuteNonQuery() >0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
      public bool deleteInstructor(int delInstr, string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "delete from tbl_instructor where instructorID=@instructorID";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@instructorID", delInstr);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
      public List<Instructor> GetAllInstructors(string userID) 
      {
          List<Instructor> listMod = new List<Instructor>();
          MySqlConnection con = new MySqlConnection(DbCon.connectionString);
          string sqlInsert = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `mobile`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `dateCreated`, `lastModified`, `admintiondate`, `active` FROM `tutors` WHERE `active` = 1";
          MySqlDataReader dr = null;
          MySqlCommand cmd;
          con.Open();
          cmd = new MySqlCommand(sqlInsert, con);
          dr = cmd.ExecuteReader();

          while (dr.Read()) //iterate through the records in the result dataset
          {
              Instructor Mod = new Instructor();
              Mod.InstructorID = dr.GetInt32(0);
              Mod.SName = dr.GetString(1);
              Mod.OName = dr.GetString(2);
              Mod.MemberID = dr.GetInt32(3);
              Mod.Tel = dr.GetString(4);
              Mod.CreatedDate = dr.GetDateTime(5);
              Mod.LastModified = dr.GetDateTime(6);
              listMod.Add(Mod);
          }


          con.Close();
          return listMod;
      }
    }
}
