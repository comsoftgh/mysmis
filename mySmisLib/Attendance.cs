using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class Attendance
    {
        public int ID { get; set; }
        public int ModuleID { get; set; }
        public int ClassSchedID { get; set; }
        public int ClassID { get; set; }
        public int LessonID { get; set; }
        public string LessonTitle { get; set; }
        public int IndexNo { get; set; }
        public string Attended { get; set; }
        public Decimal Score { get; set; }
        public string Completed { get; set; }
        
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string StudName { get; set; }

        public Attendance() { }

        
    }
    public class AttendanceServices
        {
            public bool AddAttendance(Attendance insAttend,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "INSERT INTO `studentattendance`( `moduleID`,`classID`, `lessonID`, `classSchedID`, `indexNo`, `attended`, `score`, `completed`,`createdDate`, `lastModify`) VALUES (@moduleID,@classID,@lessonID,@classSchedID,@indexNo,@attended,@score,@completed,@createdDate,@lastModify)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@moduleID",insAttend.ModuleID);
                cmd.Parameters.AddWithValue("@classID", insAttend.ClassID);
                cmd.Parameters.AddWithValue("@lessonID", insAttend.LessonID);
                cmd.Parameters.AddWithValue("@classSchedID", insAttend.ClassSchedID);
                cmd.Parameters.AddWithValue("@indexNo", insAttend.IndexNo);
                cmd.Parameters.AddWithValue("@attended", insAttend.Attended);
                cmd.Parameters.AddWithValue("@score", insAttend.Score);
                cmd.Parameters.AddWithValue("@completed", insAttend.Completed);
                cmd.Parameters.AddWithValue("@createdDate", insAttend.DateCreted);
                cmd.Parameters.AddWithValue("@lastModify", insAttend.LastModified);
                if (cmd.ExecuteNonQuery() >0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }

            public bool UpdateAttendance(Attendance insAttend, string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlUpdate = "UPDATE `studentattendance` SET `moduleID`=@moduleID,`lessonID`=@lessonID,`classSchedID`=@classSchedID,`indexNo`=@indexNo,`attended`=@attended,`score`=@score,`completed`=@completed,`lastModify`=@lastModify WHERE `id` = @id";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@moduleID", insAttend.ModuleID);
                cmd.Parameters.AddWithValue("@classID", insAttend.ClassID);
                cmd.Parameters.AddWithValue("@lessonID", insAttend.LessonID);
                cmd.Parameters.AddWithValue("@classSchedID", insAttend.ClassSchedID);
                cmd.Parameters.AddWithValue("@indexNo", insAttend.IndexNo);
                cmd.Parameters.AddWithValue("@attended", insAttend.Attended);
                cmd.Parameters.AddWithValue("@score", insAttend.Score);
                cmd.Parameters.AddWithValue("@completed", insAttend.Completed);
                cmd.Parameters.AddWithValue("@id", insAttend.ID);
                cmd.Parameters.AddWithValue("@lastModify", insAttend.LastModified);
                if (cmd.ExecuteNonQuery() >0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
            public bool DeleteAttendance(int delAttend,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlUpdate = "delete from studentattendance where `id`=@id";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@id", delAttend);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
            public bool DeleteAttendanceByStudIDClassID(int studID,int classID, string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlUpdate = "delete from studentattendance where `indexNo`= @indexNo AND classID = @classID";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@indexNo", studID);
                cmd.Parameters.AddWithValue("@classID", classID);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
            public List<Attendance> GetAllAttendanceByClassSchedul(int classSchedulID,string userID)
            {
                List<Attendance> retVal = new List<Attendance>();
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "SELECT studentattendance.id,studentattendance.moduleID,studentattendance.classID,studentattendance.lessonID,studentattendance.classSchedID,studentattendance.indexNo,studentattendance.attended,studentattendance.score,studentattendance.completed,studentlessons.title,students.onames FROM studentattendance LEFT OUTER JOIN studentlessons ON studentattendance.lessonID = studentlessons.id LEFT OUTER JOIN students ON studentattendance.indexNo = students.indexNo WHERE studentattendance.classSchedID = @classSchedID";
                MySqlDataReader dr = null;
                MySqlCommand cmd;
                con.Open();
                cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@classSchedID", classSchedulID);
                dr = cmd.ExecuteReader();

                while (dr.Read()) //iterate through the records in the result dataset
                {
                    Attendance Mod = new Attendance();
                    Mod.ID = dr.GetInt32(0);
                    Mod.ModuleID = dr.GetInt32(1);
                    Mod.ClassID = dr.GetInt32(2);
                    Mod.LessonID = dr.GetInt32(3);
                    Mod.ClassSchedID = dr.GetInt32(4);
                    Mod.IndexNo = dr.GetInt32(5);
                    Mod.Attended = dr.GetString(6);
                    Mod.Score = dr.GetDecimal(7);
                    Mod.Completed = dr.GetString(8);
                    Mod.LessonTitle = dr.GetString(9);
                    Mod.StudName = dr.GetString(10);
                    retVal.Add(Mod);
                }


                con.Close();

                return retVal;
            }
            public List<Attendance> GetAllAttendanceByStudID(int studID, string userID)
            {
                List<Attendance> retVal = new List<Attendance>();
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "SELECT studentattendance.id,studentattendance.moduleID,studentattendance.classID,studentattendance.lessonID,studentattendance.classSchedID,studentattendance.indexNo,studentattendance.attended,studentattendance.score,studentattendance.completed,studentlessons.title,students.onames FROM studentattendance LEFT OUTER JOIN studentlessons ON studentattendance.lessonID = studentlessons.id LEFT OUTER JOIN students ON studentattendance.indexNo = students.indexNo WHERE studentattendance.indexNo = @indexNo";
                MySqlDataReader dr = null;
                MySqlCommand cmd;
                con.Open();
                cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@indexNo", studID);
                dr = cmd.ExecuteReader();

                while (dr.Read()) //iterate through the records in the result dataset
                {
                    Attendance Mod = new Attendance();
                    Mod.ID = dr.GetInt32(0);
                    Mod.ModuleID = dr.GetInt32(1);
                    Mod.ClassID = dr.GetInt32(2);
                    Mod.LessonID = dr.GetInt32(3);
                    Mod.ClassSchedID = dr.GetInt32(4);
                    Mod.IndexNo = dr.GetInt32(5);
                    Mod.Attended = dr.GetString(6);
                    Mod.Score = dr.GetDecimal(7);
                    Mod.Completed = dr.GetString(8);
                    Mod.LessonTitle = dr.GetString(9);
                    Mod.StudName = dr.GetString(10);
                    retVal.Add(Mod);
                }


                con.Close();

                return retVal;
            }
            public List<Attendance> GetAllAttendanceByClassSchedulByStudID(int classSchedulID,int studID, string userID)
            {
                List<Attendance> retVal = new List<Attendance>();
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "SELECT studentattendance.id,studentattendance.moduleID,studentattendance.classID,studentattendance.lessonID,studentattendance.classSchedID,studentattendance.indexNo,studentattendance.attended,studentattendance.score,studentattendance.completed,studentlessons.title,students.onames FROM studentattendance LEFT OUTER JOIN studentlessons ON studentattendance.lessonID = studentlessons.id LEFT OUTER JOIN students ON studentattendance.indexNo = students.indexNo WHERE studentattendance.classSchedID = @classSchedID AND studentattendance.indexNo = @indexNo";
                MySqlDataReader dr = null;
                MySqlCommand cmd;
                con.Open();
                cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@classSchedID", classSchedulID);
                cmd.Parameters.AddWithValue("@indexNo", studID);
                dr = cmd.ExecuteReader();

                while (dr.Read()) //iterate through the records in the result dataset
                {
                    Attendance Mod = new Attendance();
                    Mod.ID = dr.GetInt32(0);
                    Mod.ModuleID = dr.GetInt32(1);
                    Mod.ClassID = dr.GetInt32(2);
                    Mod.LessonID = dr.GetInt32(3);
                    Mod.ClassSchedID = dr.GetInt32(4);
                    Mod.IndexNo = dr.GetInt32(5);
                    Mod.Attended = dr.GetString(6);
                    Mod.Score = dr.GetDecimal(7);
                    Mod.Completed = dr.GetString(8);
                    Mod.LessonTitle = dr.GetString(9);
                    Mod.StudName = dr.GetString(10);
                    retVal.Add(Mod);
                }


                con.Close();

                return retVal;
            }

        }
}
