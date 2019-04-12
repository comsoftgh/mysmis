using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class StudentLessonAttendance
    {
        public int ID { get; set; }
        public int Present { get; set; }
        public int BatchId { get; set; }
        public string StuduserId { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string Bgroup { get; set; }
        public int LessonId { get; set; }
       public StudentLessonAttendance(){}
    }

   public class StudentLessonAttendanceService
   {
       public bool AddStudentLessonAttendance(StudentLessonAttendance fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentlessonattendance`(`studuserid`, `batchid`, `bgroup`,lessonid, `present`, `createdate`, `modifydate`) VALUES (@studuserid,@batchid,@bgroup,@lessonid,@present,@createdate,@modifydate)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@present", fp.Present);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@lessonid", fp.LessonId);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool AddStudentLessonAttendanceList(string generalAttendanceList, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = string.Format("INSERT INTO `studentlessonattendance`(`studuserid`, `batchid`, `bgroup`,lessonid, `present`, `createdate`, `modifydate`) VALUES {0}", generalAttendanceList.TrimEnd(','));
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@generalAttendanceList", generalAttendanceList.TrimEnd());

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateStudentLessonAttendance(StudentLessonAttendance fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentlessonattendance` SET `studuserid`=@studuserid,`batchid`=@batchid,lessonid = @lessonid,`present`=@present,`modifydate`=@modifydate,bgroup = @bgroup WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@present", fp.Present);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@id", fp.ID);
           cmd.Parameters.AddWithValue("@lessonid", fp.LessonId);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteStudentLessonAttendance(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `studentlessonattendance` WHERE id = @id";
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
       public List<StudentLessonAttendance> GetAllStudentLessonAttendance(string userID)
       {
           List<StudentLessonAttendance> retVal = new List<StudentLessonAttendance>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `studuserid`, `batchid`, `bgroup`,lessonid, `present`, `createdate`, `modifydate` FROM `studentlessonattendance` ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonAttendance Mod = new StudentLessonAttendance();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.Present = dr.GetInt32(5);
               Mod.DateCreted = dr.GetDateTime(6);
               Mod.LastModified = dr.GetDateTime(7);

               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public int GetAllStudentLessonAttendance(int batchId,string bgroup, string userID)
       {
           int retVal = 0;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT COUNT(`id`) FROM `studentlessonattendance` WHERE `batchid` = @batchid AND DATE(createdate) = DATE(NOW()) AND bgroup = bgroup";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@bgroup", bgroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonAttendance Mod = new StudentLessonAttendance();
               retVal = dr.GetInt32(0);
               
           }


           con.Close();

           return retVal;
       }
       public int GetAllStudentLessonAttendance(int batchId, string bgroup, int lessonId, string userID)
       {
           int retVal = 0;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT COUNT(`id`) FROM `studentlessonattendance` WHERE `batchid` = @batchid AND DATE(createdate) = DATE(NOW()) AND lessonid = @lessonId AND bgroup = @bgroup";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@lessonId", lessonId);
           cmd.Parameters.AddWithValue("@bgroup", bgroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonAttendance Mod = new StudentLessonAttendance();
               retVal = dr.GetInt32(0);

           }


           con.Close();

           return retVal;
       }
       public string GetAllStudentLessonIDAttendance(int batchId, DateTime attenDate, string userID)
       {
           string retVal = "";
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT DISTINCT lessonid FROM `studentlessonattendance` WHERE `batchid` = @batchid AND DATE(createdate) = DATE(@attenDate) AND lessonid != 0 ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@attenDate", attenDate);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonAttendance Mod = new StudentLessonAttendance();
               retVal += dr.GetInt32(0)+ ",";

           }


           con.Close();

           return retVal == "" ? "''" : retVal.TrimEnd(',');
       }

       public Boolean ExistStudentLessonAttendance(int batchId,int lessonId, DateTime attenDate, string userID)
       {
           Boolean retVal;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT lessonid FROM `studentlessonattendance` WHERE `batchid` = @batchid AND DATE(createdate) = DATE(@attenDate) AND lessonid = @lessonId ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@attenDate", attenDate);
           cmd.Parameters.AddWithValue("@lessonId", lessonId);
           dr = cmd.ExecuteReader();

           if(dr.HasRows) 
           {
               retVal = true ;
           }
           else
           {
                retVal = false;
           }

           dr.Close();
           con.Close();

           return retVal;
       }

       public Boolean ExistStudentDatchAttendance(int batchId, DateTime attenDate, string userID)
       {
           Boolean retVal;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT lessonid FROM `studentlessonattendance` WHERE `batchid` = @batchid AND DATE(createdate) = DATE(@attenDate) ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@attenDate", attenDate);
           
           dr = cmd.ExecuteReader();

           if (dr.HasRows)
           {
               retVal = true;
           }
           else
           {
               retVal = false;
           }

           dr.Close();
           con.Close();

           return retVal;
       }
   }
}
