using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class ClassScheduler
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ModuleID { get; set; }
        public int ClassID { get; set; }
        public int ClassSize { get; set; }
        public int Active { get; set; }
        public string Term { get; set; }
        public string AcademicYear { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Bgroup { get; set; }
        public int BgsId { get; set; }
        public string xBgsid { get; set; }

        public string xTutorId { get; set; }
        public string xLesson { get; set; }
        public string xLessonId { get; set; }
        public string xLessonCode { get; set; }
        public int IA { get; set; }
        public string xIA { get; set; }
        public int Timetable { get; set; }
        public string xTimetable { get; set; }
        public int Registration { get; set; }
        public string xRegistration { get; set; }
        public int Exams { get; set; }
        public string xExams { get; set; }

        public ClassScheduler() { }

       
    }
   public class ClassSchedulerServices
   {
       public bool AddClassScheduler(ClassScheduler insMod, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentcoursesschedule`(`moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`,bgroup,bgsid) VALUES (@moduleID,@classID,@schdTitle,@classSize,@term,@academicyear,@createDate,@modifyDate,@bgroup,@bgsid)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@moduleID", insMod.ModuleID);
           cmd.Parameters.AddWithValue("@schdTitle", insMod.Title);
           cmd.Parameters.AddWithValue("@classID", insMod.ClassID);
           cmd.Parameters.AddWithValue("@term", insMod.Term);
           cmd.Parameters.AddWithValue("@academicyear", insMod.AcademicYear);
           cmd.Parameters.AddWithValue("@createDate", insMod.CreatedDate);
           cmd.Parameters.AddWithValue("@modifyDate", insMod.ModifyDate);
           cmd.Parameters.AddWithValue("@classSize", insMod.ClassSize);
           cmd.Parameters.AddWithValue("@bgroup", insMod.Bgroup);
           cmd.Parameters.AddWithValue("@bgsid", insMod.BgsId);
           int affectedrows = cmd.ExecuteNonQuery();
           if (affectedrows > 0)
           {
               result = true;
           }

           con.Close();
           return result;
       }
       public List<ClassScheduler> GetAllClassScheduler(string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`, `active`,bgroup,`timetable`,`ia`,`exams`,`registration`,bgsid,gstype FROM `studentcoursesschedule` INNER JOIN gradesystem ON studentcoursesschedule.bgsid = gradesystem.gsid WHERE `active` = 1";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.Timetable = dr.GetInt32(11);
               Mod.IA = dr.GetInt32(12);
               Mod.Exams = dr.GetInt32(13);
               Mod.Registration = dr.GetInt32(14);
               Mod.BgsId = dr.GetInt32(15);
               Mod.xBgsid = dr.GetString(16);
               if (dr.GetInt32(11) == 0) { Mod.xTimetable = "Not Completed"; } else if (dr.GetInt32(11) == 1) { Mod.xTimetable = "Completed"; }
               Mod.IA = dr.GetInt32(12);
               if (dr.GetInt32(11) == 0) { Mod.xIA = "Not Completed"; } else if (dr.GetInt32(12) == 1) { Mod.xIA = "Completed"; }
               Mod.Exams = dr.GetInt32(13);
               if (dr.GetInt32(13) == 0) { Mod.xExams = "Not Completed"; } else if (dr.GetInt32(13) == 1) { Mod.xExams = "Completed"; }
               Mod.Registration = dr.GetInt32(14);
               if (dr.GetInt32(14) == 0) { Mod.xRegistration = "Not Completed"; } else if (dr.GetInt32(14) == 1) { Mod.xRegistration = "Completed"; }
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassScheduler> GetAllClassSchedulerTranscript(string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`, `active`,bgroup,bgsid FROM `studentcoursesschedule` WHERE `active` = 1 AND ia = 1 AND exams = 1 ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.BgsId = dr.GetInt32(11);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassScheduler> GetAllClassSchedulerTimetable(string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`, `active`,bgroup FROM `studentcoursesschedule` WHERE `active` = 1 AND ia = 1 AND exams = 1 ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassScheduler> GetAllClassSchedulerRegistration(string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`, `active`,bgroup FROM `studentcoursesschedule` WHERE `active` = 1 AND registration = 1 ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassScheduler> GetAllClassSchedulerByClassID(int classID,string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`, `active`,bgroup,`timetable`,`ia`,`exams`,`registration`,bgsid FROM `studentcoursesschedule` WHERE `active` = 1 AND classID =@classID";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@classID", classID);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.Timetable = dr.GetInt32(11);
               Mod.BgsId = dr.GetInt32(12);
               if (dr.GetInt32(11) == 0) { Mod.xTimetable = "NOT COMPLETED"; } else if (dr.GetInt32(11) == 1) { Mod.xTimetable = "COMPLETED"; }
               Mod.IA = dr.GetInt32(12);
               if (dr.GetInt32(11) == 0) { Mod.xIA = "NOT COMPLETED"; } else if (dr.GetInt32(12) == 1) { Mod.xIA = "COMPLETED"; }
               Mod.Exams = dr.GetInt32(13);
               if (dr.GetInt32(13) == 0) { Mod.xExams = "NOT COMPLETED"; } else if (dr.GetInt32(13) == 1) { Mod.xExams = "COMPLETED"; }
               Mod.Registration = dr.GetInt32(14);
               if (dr.GetInt32(14) == 0) { Mod.xRegistration = "NOT COMPLETED"; } else if (dr.GetInt32(14) == 1) { Mod.xRegistration = "COMPLETED"; }
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassScheduler> GetAllClassSchedulerByClassID(int classID, DateTime createDate, string bGroup, string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `moduleID`, `classID`, `schdTitle`, `classSize`, `term`, `academicyear`, `createDate`, `modifyDate`, `active`,bgroup,`timetable`,`ia`,`exams`,`registration`,bgsid FROM `studentcoursesschedule` WHERE `active` = 1 AND classID = @classID AND createDate > @createDate AND bgroup != @bgroup";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@classID", classID);
           cmd.Parameters.AddWithValue("@createDate", createDate);
           cmd.Parameters.AddWithValue("@bgroup", bGroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.Timetable = dr.GetInt32(11);
               Mod.BgsId = dr.GetInt32(12);
               if (dr.GetInt32(11) == 0) { Mod.xTimetable = "NOT COMPLETED"; } else if (dr.GetInt32(11) == 1) { Mod.xTimetable = "COMPLETED"; }
               Mod.IA = dr.GetInt32(12);
               if (dr.GetInt32(11) == 0) { Mod.xIA = "NOT COMPLETED"; } else if (dr.GetInt32(12) == 1) { Mod.xIA = "COMPLETED"; }
               Mod.Exams = dr.GetInt32(13);
               if (dr.GetInt32(13) == 0) { Mod.xExams = "NOT COMPLETED"; } else if (dr.GetInt32(13) == 1) { Mod.xExams = "COMPLETED"; }
               Mod.Registration = dr.GetInt32(14);
               if (dr.GetInt32(14) == 0) { Mod.xRegistration = "NOT COMPLETED"; } else if (dr.GetInt32(14) == 1) { Mod.xRegistration = "COMPLETED"; }
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public List<ClassScheduler> GetAllClassSchedulerByClassIDAvailable(int classID, string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentcoursesschedule.id,studentcoursesschedule.moduleID,studentcoursesschedule.classID,studentcoursesschedule.schdTitle,studentcoursesschedule.classSize,studentcoursesschedule.term,studentcoursesschedule.academicyear,studentcoursesschedule.createDate,studentcoursesschedule.modifyDate,studentcoursesschedule.active,bgroup FROM studentcoursesschedule LEFT OUTER JOIN tbl_registration ON studentcoursesschedule.id = tbl_registration.classScheduleID WHERE (SELECT Count(tbl_registration.classScheduleID) AS numreg FROM tbl_registration WHERE tbl_registration.classScheduleID = studentcoursesschedule.id ) < studentcoursesschedule.classSize AND studentcoursesschedule.classID = @classID GROUP BY studentcoursesschedule.schdTitle, studentcoursesschedule.classSize";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@classID", classID);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.ModuleID = dr.GetInt32(1);
               Mod.ClassID = dr.GetInt32(2);
               Mod.Title = dr.GetString(3);
               Mod.ClassSize = dr.GetInt32(4);
               Mod.Term = dr.GetString(5);
               Mod.AcademicYear = dr.GetString(6);
               Mod.CreatedDate = dr.GetDateTime(7);
               Mod.ModifyDate = dr.GetDateTime(8);
               Mod.Active = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       public int GetLastClassScheduleID(string userID)
       {
           int classScheduleID = 0;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id` FROM `studentcoursesschedule` WHERE `active` = 1 ORDER BY `id` DESC LIMIT 1";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
              classScheduleID = dr.GetInt32(0);
           
           }


           con.Close();
           return classScheduleID;
       }
       public bool UpdateClassScheduler(ClassScheduler upMod, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "UPDATE `studentcoursesschedule` SET `moduleID`=@moduleID,`classID`=@classID,`schdTitle`=@schdTitle,`classSize`=@classSize,`term`=@term,`academicyear`=@academicyear,`modifyDate`=@modifyDate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@id", upMod.ID);
           cmd.Parameters.AddWithValue("@schdTitle", upMod.Title);
           cmd.Parameters.AddWithValue("@moduleID", upMod.ModuleID);
           cmd.Parameters.AddWithValue("@classID", upMod.ClassID);
           cmd.Parameters.AddWithValue("@classSize", upMod.ClassSize);
           cmd.Parameters.AddWithValue("@term", upMod.Term);
           cmd.Parameters.AddWithValue("@academicyear", upMod.AcademicYear);
           cmd.Parameters.AddWithValue("@modifyDate", upMod.ModifyDate);
           
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateClassSchedulerActivity(ClassScheduler upMod, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "UPDATE `studentcoursesschedule` SET `timetable`=@timetable,`ia`=@ia,`exams`=@exams,`registration`=@registration,`modifyDate`=@modifyDate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@id", upMod.ID);
           cmd.Parameters.AddWithValue("@exams", upMod.Exams);
           cmd.Parameters.AddWithValue("@timetable", upMod.Timetable);
           cmd.Parameters.AddWithValue("@ia", upMod.IA);
           cmd.Parameters.AddWithValue("@registration", upMod.Registration);
           cmd.Parameters.AddWithValue("@modifyDate", upMod.ModifyDate);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteClassScheduler(int classID, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "DELETE FROM `studentcoursesschedule` WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@id", classID);
           
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public string NumberingClassScheduler(ClassScheduler upMod, string userID)
       {
           string results = "";
           int result = 0;
           string bgroup = "";
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "SELECT COUNT(`id`) FROM `studentcoursesschedule` WHERE `classID` = @classID AND `term` = @term AND `academicyear` = @academicyear";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@classID", upMod.ClassID);
           cmd.Parameters.AddWithValue("@term", upMod.Term);
           cmd.Parameters.AddWithValue("@academicyear", upMod.AcademicYear);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
              result = dr.GetInt32(0);
              
           }

           switch (result)
           {
               case 0:
                   results = "ONE";
                   break;
               case 1:
                   results = "TWO";
                   break;
               case 2:
                   results = "THREE";
                   break;
               case 3:
                   results = "FOUR";
                   break;
               case 4:
                   results = "FIVE";
                   break;
               case 5:
                   results = "SIX";
                   break;
               case 6:
                   results = "SEVEN";
                   break;
               case 7:
                   results = "EIGHT";
                   break;
               case 8:
                   results = "NINE";
                   break;
               case 9:
                   results = "TEN";
                   break;  
           }



           con.Close();
           return results;
       }
       public string GroupClassScheduler(ClassScheduler upMod, string userID)
       {
           string results = "";
         
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlUpdate = "SELECT bgroup FROM `studentcoursesschedule` WHERE `term` = @term AND `academicyear` = @academicyear";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlUpdate, con);
           cmd.Parameters.AddWithValue("@term", upMod.Term);
           cmd.Parameters.AddWithValue("@academicyear", upMod.AcademicYear);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               results = dr.GetString(0);

           }

           //switch (result)
           //{
           //    case 0:
           //        results = "ONE";
           //        break;
           //    case 1:
           //        results = "TWO";
           //        break;
           //    case 2:
           //        results = "THREE";
           //        break;
           //    case 3:
           //        results = "FOUR";
           //        break;
           //    case 4:
           //        results = "FIVE";
           //        break;
           //    case 5:
           //        results = "SIX";
           //        break;
           //    case 6:
           //        results = "SEVEN";
           //        break;
           //    case 7:
           //        results = "EIGHT";
           //        break;
           //    case 8:
           //        results = "NINE";
           //        break;
           //    case 9:
           //        results = "TEN";
           //        break;
           //}

           con.Close();
           return results;
       }
       public List<int> GetClassSchedulerIDs(int classID, string bGroup, string userID)
       {
           List<int> listMod = new List<int>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`FROM `studentcoursesschedule` WHERE `active` = 1 AND classID = @classID AND bgroup = @bgroup";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@classID", classID);
           cmd.Parameters.AddWithValue("@bgroup", bGroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               int Mod = 0;
               Mod = dr.GetInt32(0);
               
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }

       //TUTORS BATCH SCHEDULES 

       public List<ClassScheduler> GetTutorsBatchSchedules(string tutorId, string userID)
       {
           List<ClassScheduler> listMod = new List<ClassScheduler>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentcoursesschedule.id,studentcoursesschedule.schdTitle,studentcoursesschedule.classSize,studentcoursesschedule.term,studentcoursesschedule.academicyear,lessontimetable.tutorid,studentlessons.title,studentlessons.`code`,studentcoursesschedule.bgroup,lessontimetable.lesssonid FROM studentcoursesschedule LEFT OUTER JOIN lessontimetable ON studentcoursesschedule.id = lessontimetable.classscheid INNER JOIN studentlessons ON lessontimetable.lesssonid = studentlessons.id WHERE lessontimetable.tutorid =@tutorId AND studentcoursesschedule.ia = 0 AND studentcoursesschedule.active = 1 AND studentcoursesschedule.exams = 0 GROUP BY studentcoursesschedule.id, studentlessons.id";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@tutorId", tutorId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               ClassScheduler Mod = new ClassScheduler();
               Mod.ID = dr.GetInt32(0);
               Mod.Title = dr.GetString(1);
               Mod.ClassSize = dr.GetInt32(2);
               Mod.Term = dr.GetString(3);
               Mod.AcademicYear = dr.GetString(4);
               Mod.xTutorId = dr.GetString(5);
               Mod.xLesson = dr.GetString(6);
               Mod.xLessonCode = dr.GetString(7);
               Mod.Bgroup = dr.GetString(8);
               Mod.xLessonId = dr.GetString(9);
               listMod.Add(Mod);
           }


           con.Close();
           return listMod;
       }
       
   }
}
