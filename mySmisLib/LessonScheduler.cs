using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class LessonScheduler
    {
        public int ID { get; set; }
        public int LessonID { get; set; }
        public int ModuleID { get; set; }
        public int ClassID { get; set; }
        public int ClassScheID { get; set; }
        public string xClassSche { get; set; }
        public int xTutorID { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string xLessonTitle { get; set; }
        public string xLessonDescrip { get; set; }
        public string xTutorName { get; set; }
        public string xLessDay { get; set; }
        public string xLessTime { get; set; }
        public int xVenuroomID { get; set; }
        public string xVenueName { get; set; }
        public string xLessonCode { get; set; }
        

        public LessonScheduler() { }

       
    }
    public class LessonSchedulerServices
   {
        public bool AddLessonScheduler(LessonScheduler insMod, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentlessonschedule`( `classScheduleID`, `moduleID`, `classID`, `lessonID`, `createDate`, `modifyDate`) VALUES (@classScheduleID,@moduleID,@classID,@lessonID,@createDate,@modifyDate)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@classScheduleID", insMod.ClassScheID);
           cmd.Parameters.AddWithValue("@moduleID", insMod.ModuleID);
           cmd.Parameters.AddWithValue("@lessonID", insMod.LessonID);
           cmd.Parameters.AddWithValue("@classID", insMod.ClassID);
           cmd.Parameters.AddWithValue("@createDate", insMod.CreatedDate);
           cmd.Parameters.AddWithValue("@modifyDate", insMod.ModifyDate);
           

           int affectedrows = cmd.ExecuteNonQuery();
           if (affectedrows > 0)
           {
               result = true;
           }

           con.Close();
           return result;
       }

        public bool AddLessonSchedulerList(string classLessons, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = string.Format("INSERT INTO `studentlessonschedule`( `classScheduleID`, `moduleID`, `classID`, `lessonID`, `createDate`, `modifyDate`) VALUES {0}",classLessons);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            
            int affectedrows = cmd.ExecuteNonQuery();
            if (affectedrows > 0)
            {
                result = true;
            }

            con.Close();
            return result;
        }
        public List<LessonScheduler> GetAllLessonSchedulerByClassSchedID(int classSchedID,string userID)
       {
           List<LessonScheduler> listMod = new List<LessonScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonschedule.id,studentlessonschedule.classScheduleID,studentlessonschedule.moduleID,studentlessonschedule.classID,studentlessonschedule.lessonID,studentlessonschedule.createDate,studentlessonschedule.modifyDate,studentlessonschedule.active,studentlessons.title,studentlessons.description,studentlessons.`code`,studentcoursesschedule.schdTitle FROM studentlessonschedule INNER JOIN studentlessons ON studentlessonschedule.lessonID = studentlessons.id INNER JOIN studentcoursesschedule ON studentlessonschedule.classScheduleID = studentcoursesschedule.id WHERE classScheduleID = @classScheduleID ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@classScheduleID", classSchedID);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               LessonScheduler Mod = new LessonScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ClassScheID = dr.GetInt32(1);
               Mod.ModuleID = dr.GetInt32(2);
               Mod.ClassID = dr.GetInt32(3);
               Mod.LessonID = dr.GetInt32(4);
               Mod.CreatedDate = dr.GetDateTime(5);
               Mod.ModifyDate = dr.GetDateTime(6);
               Mod.Active = dr.GetInt32(7);
               Mod.xLessonTitle = dr.GetString(8);
               Mod.xLessonDescrip = dr.GetString(9);
               Mod.xLessonCode = dr.GetString(10);
               Mod.xClassSche = dr.GetString(11);
               Mod.xTutorName = "Select Tutor";
               Mod.xTutorID = 0;
               Mod.xLessTime = "Select Period";
               Mod.xVenueName = "Select Venue";
               Mod.xVenuroomID = 0;
               Mod.xLessDay = "Select Day";
               
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
        public List<LessonScheduler> GetAllLessonScheduler(string userID)
        {
            List<LessonScheduler> listMod = new List<LessonScheduler>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT studentlessonschedule.id,studentlessonschedule.classScheduleID,studentlessonschedule.moduleID,studentlessonschedule.classID,studentlessonschedule.lessonID,studentlessonschedule.createDate,studentlessonschedule.modifyDate,studentlessonschedule.active,studentlessons.title,studentlessons.description,studentlessons.`code`,studentcoursesschedule.schdTitle FROM studentlessonschedule INNER JOIN studentlessons ON studentlessonschedule.lessonID = studentlessons.id INNER JOIN studentcoursesschedule ON studentlessonschedule.classScheduleID = studentcoursesschedule.id";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LessonScheduler Mod = new LessonScheduler();
                Mod.ID = dr.GetInt32(0);
                Mod.ClassScheID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.ClassID = dr.GetInt32(3);
                Mod.LessonID = dr.GetInt32(4);
                Mod.CreatedDate = dr.GetDateTime(5);
                Mod.ModifyDate = dr.GetDateTime(6);
                Mod.Active = dr.GetInt32(7);
                Mod.xLessonTitle = dr.GetString(8);
                Mod.xLessonDescrip = dr.GetString(9);
                Mod.xLessonCode = dr.GetString(10);
                Mod.xClassSche = dr.GetString(11);
                Mod.xTutorName = "Select Tutor";
                Mod.xTutorID = 0;
                Mod.xLessTime = "Select Period";
                Mod.xVenueName = "Select Venue";
                Mod.xVenuroomID = 0;
                Mod.xLessDay = "Select Day";
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
        public bool UpdateLessonScheduler(LessonScheduler insMod, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "UPDATE `studentlessonschedule` SET `classScheduleID`=@classScheduleID,`moduleID`=@moduleID,`classID`=@classID,`lessonID`=@lessonID,`tutorID`=@tutorID,`modifyDate`=@modifyDate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@classScheduleID", insMod.ClassScheID);
           cmd.Parameters.AddWithValue("@moduleID", insMod.ModuleID);
           cmd.Parameters.AddWithValue("@lessonID", insMod.LessonID);
           cmd.Parameters.AddWithValue("@classID", insMod.ClassID);
           cmd.Parameters.AddWithValue("@createDate", insMod.CreatedDate);
           cmd.Parameters.AddWithValue("@modifyDate", insMod.ModifyDate);
           cmd.Parameters.AddWithValue("@id", insMod.ID);
           
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
        public bool DeleteLessonScheduler(int lessonID, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "DELETE FROM `studentlessonschedule` WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@id", lessonID);
           
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
   
   }
}
