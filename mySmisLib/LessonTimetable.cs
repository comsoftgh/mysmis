using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class LessonTimetable
    {
        public int ID { get; set; }
        public int LessonID { get; set; }
        public string LessDay { get; set; }
        public string LessTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int VenuroomID { get; set; }
        public int Classscheid { get; set; }
        public int ModuleID { get; set; }
        public int ClassID { get; set; }
        public string TutorID { get; set; }
        public string Bgroup { get; set; }

        public string xLessonTitle { get; set; }
        public string xLessonDescrip { get; set; }
        public string xVenueName { get; set; }
        public string xClassSche { get; set; }
        public string xLessonCode {get;set;}
        public string xTutorName { get; set; }

        public LessonTimetable(){}
    }

    public class LessonTimetableService
    {

        public bool AddLessonTimetable(LessonTimetable insMod, string dbtableName, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `"+dbtableName+ "`(`lesssonid`, `lessday`, `lesstime`, `venueroomid`, `datecreated`, `lastmodified`,classscheid,moduleid,classid,tutorid,bgroup) VALUES (@lesssonid,@lessday,@lesstime,@venueroomid,@datecreated,@lastmodified,@classscheid,@moduleid,@classid,@tutorID,@bgroup)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@lesssonid", insMod.LessonID);
            cmd.Parameters.AddWithValue("@lessday", insMod.LessDay);
            cmd.Parameters.AddWithValue("@lesstime", insMod.LessTime);
            cmd.Parameters.AddWithValue("@datecreated", insMod.CreatedDate);
            cmd.Parameters.AddWithValue("@lastmodified", insMod.ModifyDate);
            cmd.Parameters.AddWithValue("@venueroomid", insMod.VenuroomID);
            cmd.Parameters.AddWithValue("@classscheid", insMod.Classscheid);
            cmd.Parameters.AddWithValue("@moduleid",insMod.ModuleID);
            cmd.Parameters.AddWithValue("@classid", insMod.ClassID);
            cmd.Parameters.AddWithValue("@tutorID", insMod.TutorID);
            cmd.Parameters.AddWithValue("@bgroup", insMod.Bgroup);


            int affectedrows = cmd.ExecuteNonQuery();
            if (affectedrows > 0)
            {
                result = true;
            }

            con.Close();
            return result;
        }
        public bool ExitClassSheLessonDay1st( LessonTimetable lessTime,string dbtableName, string userID)
        {
            bool result = false;

            int rows = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd = null;

            string sqlUpdate = "SELECT COUNT(`id`) FROM `"+dbtableName+ "` WHERE `lessday` = @lessday AND classscheid = @classscheid ";
            con.Open();
            cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@lessday", lessTime.LessDay);
            cmd.Parameters.AddWithValue("@classscheid", lessTime.Classscheid);

            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                rows = dr.GetInt32(0);
            }
            con.Close();
            con.Open();
            int numtimep = 0;
            string q = "SELECT COUNT(id) FROM timeperiods";
            cmd = new MySqlCommand(q,con);
            dr = cmd.ExecuteReader();
            while (dr.Read()) //iterate through the records in the result dataset
            {
                numtimep = dr.GetInt32(0);
            }

            if (rows >= numtimep)
            {
                result = true;
            }
            con.Close();

            return result;
        }
        public bool ExitClassSheTimeDay2nd(LessonTimetable lessTime, string dbtableName, string userID)
        {
            bool result = false;
           
            int rows = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;

            string sqlUpdate = "SELECT COUNT(`id`) FROM `"+dbtableName+ "` WHERE `lessday` = @lessday AND `lesstime` = @lesstime AND classscheid = @classscheid ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@lesstime", lessTime.LessTime);
            cmd.Parameters.AddWithValue("@classscheid", lessTime.Classscheid);
            cmd.Parameters.AddWithValue("@lessday", lessTime.LessDay);

            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                rows = dr.GetInt32(0);
            }

            if (rows > 0)
            {
                result = true;
            }
            con.Close();

            return result;
        }
        public bool ExitVenueTimeDayGroup3rd(LessonTimetable lessTime, string dbtableName, string userID)
        {
            bool result = false;
            int rows = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;

            string sqlUpdate = "SELECT COUNT(`id`) FROM `"+dbtableName+ "` WHERE `lessday` = @lessday AND bgroup = @bgroup AND venueroomid = @venueroomid AND`lesstime` = @lesstime ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@venueroomid", lessTime.VenuroomID);
            cmd.Parameters.AddWithValue("@lesstime", lessTime.LessTime);
            cmd.Parameters.AddWithValue("@lessday", lessTime.LessDay);
            cmd.Parameters.AddWithValue("@bgroup", lessTime.Bgroup);


            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                rows = dr.GetInt32(0);
            }

            if (rows > 0)
            {
                result = true;
            }
            con.Close();

            return result;
        }
        public bool ExitTutorDayTimeGroup4th(LessonTimetable lessTime, string dbtableName, string userID)
        {
            bool result = false;
            int rows = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;

            string sqlUpdate = "SELECT COUNT(`id`) FROM `"+dbtableName+ "` WHERE `lessday` = @lessday AND bgroup = @bgroup AND`lesstime` = @lesstime AND tutorid = @tutorid";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@bgroup", lessTime.Bgroup);
            cmd.Parameters.AddWithValue("@tutorid", lessTime.TutorID);
            cmd.Parameters.AddWithValue("@lesstime", lessTime.LessTime);
            cmd.Parameters.AddWithValue("@lessday", lessTime.LessDay);
            cmd.Parameters.AddWithValue("@classscheid", lessTime.Classscheid);
            cmd.Parameters.AddWithValue("@venueroomid", lessTime.VenuroomID);

            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                rows = dr.GetInt32(0);
            }

            if (rows > 0)
            {
                result = true;
            }
            con.Close();

            return result;
        }
        public List<LessonTimetable> GetAllLessonTimetableByClassSchedID(int classSchedID, string dbtableName, string userID)
        {
            List<LessonTimetable> listMod = new List<LessonTimetable>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT lessontimetable.id,lessontimetable.lesssonid,lessontimetable.lessday,lessontimetable.lesstime,lessontimetable.venueroomid,lessontimetable.datecreated,lessontimetable.lastmodified,lessontimetable.classscheid,lessontimetable.moduleid,lessontimetable.classid,studentlessons.title,venurooms.roomname,studentcoursesschedule.schdTitle,lessontimetable.tutorid,studentlessons.`code`,lessontimetable.bgroup,tutors.fname,tutors.sname FROM lessontimetable LEFT OUTER JOIN studentlessons ON lessontimetable.lesssonid = studentlessons.id LEFT OUTER JOIN venurooms ON lessontimetable.venueroomid = venurooms.id LEFT OUTER JOIN studentcoursesschedule ON lessontimetable.classscheid = studentcoursesschedule.id LEFT OUTER JOIN timedays ON lessontimetable.lessday = timedays.tday INNER JOIN tutors ON lessontimetable.tutorid = tutors.userId WHERE lessontimetable.classscheid = @classScheduleID ORDER BY timedays.id,lessontimetable.lesstime  ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classScheduleID", classSchedID);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LessonTimetable Mod = new LessonTimetable();
                Mod.ID = dr.GetInt32(0);
                Mod.LessonID = dr.GetInt32(1);
                Mod.LessDay = dr.GetString(2);
                Mod.LessTime = dr.GetString(3);
                Mod.VenuroomID = dr.GetInt32(4);
                Mod.CreatedDate = dr.GetDateTime(5);
                Mod.ModifyDate = dr.GetDateTime(6);
                Mod.Classscheid = dr.GetInt32(7);
                Mod.ModuleID = dr.GetInt32(8);
                Mod.ClassID = dr.GetInt32(9);
                Mod.xLessonTitle = dr.GetString(10);
                Mod.xVenueName = dr.GetString(11);
                Mod.xClassSche = dr.GetString(12);
                Mod.TutorID = dr.GetString(13);
                Mod.xLessonCode = dr.GetString(14);
                Mod.Bgroup = dr.GetString(15);
                Mod.xTutorName = dr.GetString(16) + " " + dr.GetString(17);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
        public List<LessonTimetable> GetAllLessonTimetable(string dbtableName,string userID)
        {
            List<LessonTimetable> listMod = new List<LessonTimetable>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT lessontimetable.id,lessontimetable.lesssonid,lessontimetable.lessday,lessontimetable.lesstime,lessontimetable.venueroomid,lessontimetable.datecreated,lessontimetable.lastmodified,lessontimetable.classscheid,lessontimetable.moduleid,lessontimetable.classid,studentlessons.title,venurooms.roomname,studentcoursesschedule.schdTitle,lessontimetable.tutorid,studentlessons.`code`,lessontimetable.bgroup,tutors.fname,tutors.sname FROM lessontimetable LEFT OUTER JOIN studentlessons ON lessontimetable.lesssonid = studentlessons.id LEFT OUTER JOIN venurooms ON lessontimetable.venueroomid = venurooms.id LEFT OUTER JOIN studentcoursesschedule ON lessontimetable.classscheid = studentcoursesschedule.id LEFT OUTER JOIN timedays ON lessontimetable.lessday = timedays.tday INNER JOIN tutors ON lessontimetable.tutorid = tutors.userId WHERE studentcoursesschedule.active = 1 ORDER BY timedays.id,lessontimetable.lesstime";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LessonTimetable Mod = new LessonTimetable();
                Mod.ID = dr.GetInt32(0);
                Mod.LessonID = dr.GetInt32(1);
                Mod.LessDay = dr.GetString(2);
                Mod.LessTime = dr.GetString(3);
                Mod.VenuroomID = dr.GetInt32(4);
                Mod.CreatedDate = dr.GetDateTime(5);
                Mod.ModifyDate = dr.GetDateTime(6);
                Mod.Classscheid = dr.GetInt32(7);
                Mod.ModuleID = dr.GetInt32(8);
                Mod.ClassID = dr.GetInt32(9);
                Mod.xLessonTitle = dr.GetString(10);
                Mod.xVenueName = dr.GetString(11);
                Mod.xClassSche = dr.GetString(12);
                Mod.TutorID = dr.GetString(13);
                Mod.xLessonCode = dr.GetString(14);
                Mod.Bgroup = dr.GetString(15);
                Mod.xTutorName = dr.GetString(16) + " " + dr.GetString(17);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
        public bool UpdateLessonTimetable(LessonTimetable insMod, string dbtableName, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlUpdate = "UPDATE `"+dbtableName+ "` SET `lesssonid`=@lesssonid,`lessday`=@lessday,`lesstime`=@lesstime,`venueroomid`=@venueroomid,`lastmodified`=@lastmodified,`classscheid`=@classscheid, moduleid =@moduleid, classid =@classid, tutorid =@tutorid WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@lesssonid", insMod.LessonID);
            cmd.Parameters.AddWithValue("@lessday", insMod.LessDay);
            cmd.Parameters.AddWithValue("@lesstime", insMod.LessTime);
            cmd.Parameters.AddWithValue("@lastmodified", insMod.ModifyDate);
            cmd.Parameters.AddWithValue("@venueroomid", insMod.VenuroomID);
            cmd.Parameters.AddWithValue("@classscheid", insMod.Classscheid);
            cmd.Parameters.AddWithValue("@moduleid", insMod.ModuleID);
            cmd.Parameters.AddWithValue("@classid", insMod.ClassID);
            cmd.Parameters.AddWithValue("@tutorid", insMod.TutorID);
            cmd.Parameters.AddWithValue("@id",insMod.ID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteLessonTimetable(int ID, string dbtableName, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlUpdate = "DELETE FROM `"+dbtableName+ "` WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@id", ID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        //TUTORS TIMETABLE 
        public List<LessonTimetable> GetTutorLessonTimetableByClassSchedID(string tutorId, string dbtableName, int classSchedID, string userID)
        {
            List<LessonTimetable> listMod = new List<LessonTimetable>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT lessontimetable.id,lessontimetable.lesssonid,lessontimetable.lessday,lessontimetable.lesstime,lessontimetable.venueroomid,lessontimetable.datecreated,lessontimetable.lastmodified,lessontimetable.classscheid,lessontimetable.moduleid,lessontimetable.classid,studentlessons.title,venurooms.roomname,studentcoursesschedule.schdTitle,lessontimetable.tutorid,studentlessons.`code`,lessontimetable.bgroup,tutors.fname,tutors.sname FROM lessontimetable LEFT OUTER JOIN studentlessons ON lessontimetable.lesssonid = studentlessons.id LEFT OUTER JOIN venurooms ON lessontimetable.venueroomid = venurooms.id LEFT OUTER JOIN studentcoursesschedule ON lessontimetable.classscheid = studentcoursesschedule.id LEFT OUTER JOIN timedays ON lessontimetable.lessday = timedays.tday INNER JOIN tutors ON lessontimetable.tutorid = tutors.userId WHERE lessontimetable.classscheid = @classScheduleID AND lessontimetable.tutorid = @tutorId ORDER BY timedays.id,lessontimetable.lesstime  ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classScheduleID", classSchedID);
            cmd.Parameters.AddWithValue("@tutorId", tutorId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LessonTimetable Mod = new LessonTimetable();
                Mod.ID = dr.GetInt32(0);
                Mod.LessonID = dr.GetInt32(1);
                Mod.LessDay = dr.GetString(2);
                Mod.LessTime = dr.GetString(3);
                Mod.VenuroomID = dr.GetInt32(4);
                Mod.CreatedDate = dr.GetDateTime(5);
                Mod.ModifyDate = dr.GetDateTime(6);
                Mod.Classscheid = dr.GetInt32(7);
                Mod.ModuleID = dr.GetInt32(8);
                Mod.ClassID = dr.GetInt32(9);
                Mod.xLessonTitle = dr.GetString(10);
                Mod.xVenueName = dr.GetString(11);
                Mod.xClassSche = dr.GetString(12);
                Mod.TutorID = dr.GetString(13);
                Mod.xLessonCode = dr.GetString(14);
                Mod.Bgroup = dr.GetString(15);
                Mod.xTutorName = dr.GetString(16) + " " + dr.GetString(17);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
    }
}
