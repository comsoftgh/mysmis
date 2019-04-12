using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class StudentGeneralAttendance
    {
        public int ID { get; set; }
        public int Present { get; set; }
        public int BatchId { get; set; }
        public string StuduserId { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string Bgroup { get; set; }
        
        public StudentGeneralAttendance(){}
    }

    public class StudentGeneralAttendanceService
    {
        public bool AddStudentGeneralAttendance(StudentGeneralAttendance fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `studentgeneralattendance`(`studuserid`, `batchid`, `bgroup`, `present`, `createdate`, `modifydate`) VALUES (@studuserid,@batchid,@bgroup,@present,@createdate,@modifydate)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
            cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
            cmd.Parameters.AddWithValue("@present", fp.Present);
            cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
            cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
            cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool AddStudentGeneralAttendanceList(string generalAttendanceList, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `studentgeneralattendance`(`studuserid`, `batchid`, `bgroup`, `present`, `createdate`, `modifydate`) VALUES @generalAttendanceList";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@generalAttendanceList", generalAttendanceList.TrimEnd());
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdateStudentGeneralAttendance(StudentGeneralAttendance fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `studentgeneralattendance` SET `studuserid`=@studuserid,`batchid`=@batchid,`present`=@present,`modifydate`=@modifydate,bgroup = @bgroup WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
            cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
            cmd.Parameters.AddWithValue("@present", fp.Present);
            cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
            cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
            cmd.Parameters.AddWithValue("@id", fp.ID);
           
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteStudentGeneralAttendance(int fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "DELETE FROM `studentgeneralattendance` WHERE id = @id";
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
        public List<StudentGeneralAttendance> GetAllStudentGeneralAttendance(string userID)
        {
            List<StudentGeneralAttendance> retVal = new List<StudentGeneralAttendance>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `studuserid`, `batchid`, `bgroup`, `present`, `createdate`, `modifydate` FROM `studentgeneralattendance` ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                StudentGeneralAttendance Mod = new StudentGeneralAttendance();
                Mod.ID = dr.GetInt32(0);
                Mod.StuduserId = dr.GetString(1);
                Mod.BatchId = dr.GetInt32(2);
                Mod.Bgroup = dr.GetString(3);
                Mod.Present = dr.GetInt32(4);
                Mod.DateCreted = dr.GetDateTime(5);
                Mod.LastModified = dr.GetDateTime(6);
                
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
    }
}
