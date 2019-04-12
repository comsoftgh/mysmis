using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class StudentLessonsRegistration
    {
        public int ID { get; set; }
        public int BatchId { get; set; }
        public string StuduserId { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string Bgroup { get; set; }
        public int LessonId { get; set; }
        public int ProgramId { get; set; }
        public int SubjectId { get; set; }
        public decimal TestMarks { get; set; }
        public decimal ExamsMarks { get; set; }
        public string Remarks { get; set; }

        public decimal xTotalMarks { get; set; }
        public string xIndexNo { get; set; }
        public string xGender { get; set; }
        public string xSName { get; set; }
        public string xFNames { get; set; }
        public string xONames { get; set; }
        public string xFullName { get; set; }
        public DateTime xAdmissiondate { get; set; }
        public string xBatchTitle { get; set; }
        public string xLesson { get; set; }
        public string xCourse { get; set; }
        public string xProgram { get; set; }
        public string xLessCode { get; set; }
        public int xCredit { get; set; }
        public string xGrade { get; set;}
        public string xGradeDesc { get; set; }
        public decimal xGradepiont { get; set; }

        public StudentLessonsRegistration() { }
    }

   public class StudentLessonsRegistrationService
   {
       public bool AddStudentLessonsRegistration(StudentLessonsRegistration fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentlessonsregistration`(  `studuserid`, `batchid`, `bgroup`, `lessonid`, `subjectid`, `programid`, `testmark`, `examsmark`, `remarks`, `createdate`, `modifydate`) VALUES (@studregid,@studuserid,@batchid,@bgroup,@lessonid,@subjectid,@programid,@testmark,@examsmark,@remarks, @createdate, @modifydate)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@lessonid", fp.LessonId);
           cmd.Parameters.AddWithValue("@subjectid", fp.SubjectId);
           cmd.Parameters.AddWithValue("@programid", fp.ProgramId);
           cmd.Parameters.AddWithValue("@testmark", fp.TestMarks);
           cmd.Parameters.AddWithValue("@examsmark", fp.ExamsMarks);
           cmd.Parameters.AddWithValue("@remarks", fp.Remarks);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool AddStudentLessonsRegistrationList(string lessonsRegList, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = string.Format("INSERT INTO `studentlessonsregistration`(  `studuserid`, `batchid`, `bgroup`, `lessonid`, `subjectid`, `programid`, `testmark`, `examsmark`, `remarks`, `createdate`, `modifydate`) VALUES {0}", lessonsRegList);
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@generalAttendanceList", generalAttendanceList);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateStudentLessonsRegistration(StudentLessonsRegistration fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentlessonsregistration` SET `studuserid`=@studuserid,`batchid`=@batchid,`bgroup`=@bgroup,`lessonid`=@lessonid,`subjectid`=@subjectid,`programid`=@programid,`testmark`=@testmark,`examsmark`=@examsmark,`remarks`=@remarks,`modifydate`=@modifydate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@lessonid", fp.LessonId);
           cmd.Parameters.AddWithValue("@subjectid", fp.SubjectId);
           cmd.Parameters.AddWithValue("@programid", fp.ProgramId);
           cmd.Parameters.AddWithValue("@testmark", fp.TestMarks);
           cmd.Parameters.AddWithValue("@examsmark", fp.ExamsMarks);
           cmd.Parameters.AddWithValue("@remarks", fp.Remarks);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@id", fp.ID);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateStudentLessonsRegistrationIA(StudentLessonsRegistration fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentlessonsregistration` SET `testmark`=@testmark,`modifydate`=@modifydate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@testmark", fp.TestMarks);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@id", fp.ID);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateStudentLessonsRegistrationExams(StudentLessonsRegistration fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentlessonsregistration` SET `examsmark`=@examsmark,`modifydate`=@modifydate WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@examsmark", fp.ExamsMarks);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@id", fp.ID);

           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteStudentLessonsRegistration(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `studentlessonsregistration` WHERE id = @id";
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
       public List<StudentLessonsRegistration> GetAllStudentLessonsRegistration(string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonsregistration.id,studentlessonsregistration.studuserid,studentlessonsregistration.batchid,studentlessonsregistration.bgroup,studentlessonsregistration.lessonid,studentlessonsregistration.subjectid,studentlessonsregistration.programid,studentlessonsregistration.testmark,studentlessonsregistration.examsmark,studentlessonsregistration.remarks,studentlessonsregistration.createdate,studentlessonsregistration.modifydate,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentlessons.title,studentlessons.`code`,studentlessons.credit,studentprograms.moduleName,studentcourses.title FROM studentlessonsregistration INNER JOIN students ON studentlessonsregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentlessonsregistration.batchid = studentcoursesschedule.id INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id INNER JOIN studentprograms ON studentlessonsregistration.programid = studentprograms.id INNER JOIN studentcourses ON studentlessonsregistration.subjectid = studentcourses.id";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.SubjectId = dr.GetInt32(5);
               Mod.ProgramId = dr.GetInt32(6);
               Mod.TestMarks = dr.GetDecimal(7);
               Mod.ExamsMarks = dr.GetDecimal(8);
               Mod.Remarks = dr.GetString(9);
               Mod.DateCreted = dr.GetDateTime(10);
               Mod.LastModified = dr.GetDateTime(11);
               Mod.xIndexNo = dr.GetString(12);
               Mod.xFullName = dr.GetString(13) + " " + dr.GetString(14) + " " + dr.GetString(15);
               Mod.xBatchTitle = dr.GetString(16);
               Mod.xLesson = dr.GetString(17);
               Mod.xLessCode = dr.GetString(18);
               Mod.xCredit = dr.GetInt32(19);
               Mod.xProgram = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.xTotalMarks = dr.GetDecimal(7) + dr.GetDecimal(8);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<StudentLessonsRegistration> GetAllStudentLessonsRegistration(int batchId,string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonsregistration.id,studentlessonsregistration.studuserid,studentlessonsregistration.batchid,studentlessonsregistration.bgroup,studentlessonsregistration.lessonid,studentlessonsregistration.subjectid,studentlessonsregistration.programid,studentlessonsregistration.testmark,studentlessonsregistration.examsmark,studentlessonsregistration.remarks,studentlessonsregistration.createdate,studentlessonsregistration.modifydate,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentlessons.title,studentlessons.`code`,studentlessons.credit,studentprograms.moduleName,studentcourses.title FROM studentlessonsregistration INNER JOIN students ON studentlessonsregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentlessonsregistration.batchid = studentcoursesschedule.id INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id INNER JOIN studentprograms ON studentlessonsregistration.programid = studentprograms.id INNER JOIN studentcourses ON studentlessonsregistration.subjectid = studentcourses.id WHERE studentlessonsregistration.batchid = @batchId";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.SubjectId = dr.GetInt32(5);
               Mod.ProgramId = dr.GetInt32(6);
               Mod.TestMarks = dr.GetDecimal(7);
               Mod.ExamsMarks = dr.GetDecimal(8);
               Mod.Remarks = dr.GetString(9);
               Mod.DateCreted = dr.GetDateTime(10);
               Mod.LastModified = dr.GetDateTime(11);
               Mod.xIndexNo = dr.GetString(12);
               Mod.xFullName = dr.GetString(13) + " " + dr.GetString(14) + " " + dr.GetString(15);
               Mod.xBatchTitle = dr.GetString(16);
               Mod.xLesson = dr.GetString(17);
               Mod.xLessCode = dr.GetString(18);
               Mod.xCredit = dr.GetInt32(19);
               Mod.xProgram = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.xTotalMarks = dr.GetDecimal(7) + dr.GetDecimal(8);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<StudentLessonsRegistration> GetAllStudentLessonsRegistration(int batchId,int lessonId, string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonsregistration.id,studentlessonsregistration.studuserid,studentlessonsregistration.batchid,studentlessonsregistration.bgroup,studentlessonsregistration.lessonid,studentlessonsregistration.subjectid,studentlessonsregistration.programid,studentlessonsregistration.testmark,studentlessonsregistration.examsmark,studentlessonsregistration.remarks,studentlessonsregistration.createdate,studentlessonsregistration.modifydate,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentlessons.title,studentlessons.`code`,studentlessons.credit,studentprograms.moduleName,studentcourses.title FROM studentlessonsregistration INNER JOIN students ON studentlessonsregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentlessonsregistration.batchid = studentcoursesschedule.id INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id INNER JOIN studentprograms ON studentlessonsregistration.programid = studentprograms.id INNER JOIN studentcourses ON studentlessonsregistration.subjectid = studentcourses.id WHERE studentlessonsregistration.batchid = @batchId AND studentlessonsregistration.lessonid =@lessonId ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           cmd.Parameters.AddWithValue("@lessonId", lessonId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.SubjectId = dr.GetInt32(5);
               Mod.ProgramId = dr.GetInt32(6);
               Mod.TestMarks = dr.GetDecimal(7);
               Mod.ExamsMarks = dr.GetDecimal(8);
               Mod.Remarks = dr.GetString(9);
               Mod.DateCreted = dr.GetDateTime(10);
               Mod.LastModified = dr.GetDateTime(11);
               Mod.xIndexNo = dr.GetString(12);
               Mod.xFullName = dr.GetString(13) + " " + dr.GetString(14) + " " + dr.GetString(15);
               Mod.xBatchTitle = dr.GetString(16);
               Mod.xLesson = dr.GetString(17);
               Mod.xLessCode = dr.GetString(18);
               Mod.xCredit = dr.GetInt32(19);
               Mod.xProgram = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.xTotalMarks = dr.GetDecimal(7) + dr.GetDecimal(8);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<StudentLessonsRegistration> GetDistinctLessons(int batchId, string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT DISTINCT studentlessonsregistration.lessonid,studentlessons.title,studentlessons.`code` FROM studentlessonsregistration INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id  WHERE studentlessonsregistration.batchid = @batchId";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.LessonId = dr.GetInt32(0);
               Mod.xLesson = dr.GetString(1);
               Mod.xLessCode = dr.GetString(2);
               
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public bool ExistStudentLessonsRegistration(int studRegId,string studUserId, string userID)
       {
           bool result = false;
           int numRow = 0;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT COUNT(id) FROM `studentlessonsregistration` WHERE studregid = @studregid AND studuserid = @studuserid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
          
           cmd.Parameters.AddWithValue("@studregid", studRegId);
           cmd.Parameters.AddWithValue("@studuserid", studUserId);
           dr = cmd.ExecuteReader();
           while (dr.Read()) //iterate through the records in the result dataset
           {
               numRow = dr.GetInt32(0);
           }

           if (numRow > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public List<StudentLessonsRegistration> GetStudentExamsResults(int batchId, string studuserid,int gradsysId, string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonsregistration.id,studentlessonsregistration.studuserid,studentlessonsregistration.batchid,studentlessonsregistration.bgroup,studentlessonsregistration.lessonid,studentlessonsregistration.subjectid,studentlessonsregistration.programid,studentlessonsregistration.testmark,studentlessonsregistration.examsmark,studentlessonsregistration.remarks,studentlessonsregistration.createdate,studentlessonsregistration.modifydate,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentlessons.title,studentlessons.`code`,studentlessons.credit,studentprograms.moduleName,studentcourses.title FROM studentlessonsregistration INNER JOIN students ON studentlessonsregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentlessonsregistration.batchid = studentcoursesschedule.id INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id INNER JOIN studentprograms ON studentlessonsregistration.programid = studentprograms.id INNER JOIN studentcourses ON studentlessonsregistration.subjectid = studentcourses.id WHERE studentlessonsregistration.batchid = @batchId AND studentlessonsregistration.studuserid = @studuserid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           cmd.Parameters.AddWithValue("@studuserid", studuserid);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.SubjectId = dr.GetInt32(5);
               Mod.ProgramId = dr.GetInt32(6);
               Mod.TestMarks = dr.GetDecimal(7);
               Mod.ExamsMarks = dr.GetDecimal(8);
               Mod.Remarks = dr.GetString(9);
               Mod.DateCreted = dr.GetDateTime(10);
               Mod.LastModified = dr.GetDateTime(11);
               Mod.xIndexNo = dr.GetString(12);
               Mod.xFullName = dr.GetString(13) + " " + dr.GetString(14) + " " + dr.GetString(15);
               Mod.xBatchTitle = dr.GetString(16);
               Mod.xLesson = dr.GetString(17);
               Mod.xLessCode = dr.GetString(18);
               Mod.xCredit = dr.GetInt32(19);
               Mod.xProgram = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.xTotalMarks = dr.GetDecimal(7) + dr.GetDecimal(8);
               GradingSystem gs = new GradingSystemService().GetGradingSystem(gradsysId,Mod.xTotalMarks);
               Mod.xGrade = gs.GsGrade;
               Mod.xGradeDesc = gs.GSDescription;
               Mod.xGradepiont = gs.GsPoint;
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

       public List<StudentLessonsRegistration> GetStudentExamsTranscripts(string studuserid, int gradsysId, string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonsregistration.id,studentlessonsregistration.studuserid,studentlessonsregistration.batchid,studentlessonsregistration.bgroup,studentlessonsregistration.lessonid,studentlessonsregistration.subjectid,studentlessonsregistration.programid,studentlessonsregistration.testmark,studentlessonsregistration.examsmark,studentlessonsregistration.remarks,studentlessonsregistration.createdate,studentlessonsregistration.modifydate,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentlessons.title,studentlessons.`code`,studentlessons.credit,studentprograms.moduleName,studentcourses.title FROM studentlessonsregistration INNER JOIN students ON studentlessonsregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentlessonsregistration.batchid = studentcoursesschedule.id INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id INNER JOIN studentprograms ON studentlessonsregistration.programid = studentprograms.id INNER JOIN studentcourses ON studentlessonsregistration.subjectid = studentcourses.id WHERE studentlessonsregistration.studuserid = @studuserid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@batchId", batchId);
           cmd.Parameters.AddWithValue("@studuserid", studuserid);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.SubjectId = dr.GetInt32(5);
               Mod.ProgramId = dr.GetInt32(6);
               Mod.TestMarks = dr.GetDecimal(7);
               Mod.ExamsMarks = dr.GetDecimal(8);
               Mod.Remarks = dr.GetString(9);
               Mod.DateCreted = dr.GetDateTime(10);
               Mod.LastModified = dr.GetDateTime(11);
               Mod.xIndexNo = dr.GetString(12);
               Mod.xFullName = dr.GetString(13) + " " + dr.GetString(14) + " " + dr.GetString(15);
               Mod.xBatchTitle = dr.GetString(16);
               Mod.xLesson = dr.GetString(17);
               Mod.xLessCode = dr.GetString(18);
               Mod.xCredit = dr.GetInt32(19);
               Mod.xProgram = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.xTotalMarks = dr.GetDecimal(7) + dr.GetDecimal(8);
               GradingSystem gs = new GradingSystemService().GetGradingSystem(gradsysId, Mod.xTotalMarks);
               Mod.xGrade = gs.GsGrade;
               Mod.xGradeDesc = gs.GSDescription;
               Mod.xGradepiont = gs.GsPoint;
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

       public List<StudentLessonsRegistration> GetStudentExamsTranscripts(int batchId, int gradsysId, string userID)
       {
           List<StudentLessonsRegistration> retVal = new List<StudentLessonsRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentlessonsregistration.id,studentlessonsregistration.studuserid,studentlessonsregistration.batchid,studentlessonsregistration.bgroup,studentlessonsregistration.lessonid,studentlessonsregistration.subjectid,studentlessonsregistration.programid,studentlessonsregistration.testmark,studentlessonsregistration.examsmark,studentlessonsregistration.remarks,studentlessonsregistration.createdate,studentlessonsregistration.modifydate,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentlessons.title,studentlessons.`code`,studentlessons.credit,studentprograms.moduleName,studentcourses.title FROM studentlessonsregistration INNER JOIN students ON studentlessonsregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentlessonsregistration.batchid = studentcoursesschedule.id INNER JOIN studentlessons ON studentlessonsregistration.lessonid = studentlessons.id INNER JOIN studentprograms ON studentlessonsregistration.programid = studentprograms.id INNER JOIN studentcourses ON studentlessonsregistration.subjectid = studentcourses.id WHERE studentlessonsregistration.batchid = @batchId";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           //cmd.Parameters.AddWithValue("@studuserid", studuserid);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentLessonsRegistration Mod = new StudentLessonsRegistration();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.LessonId = dr.GetInt32(4);
               Mod.SubjectId = dr.GetInt32(5);
               Mod.ProgramId = dr.GetInt32(6);
               Mod.TestMarks = dr.GetDecimal(7);
               Mod.ExamsMarks = dr.GetDecimal(8);
               Mod.Remarks = dr.GetString(9);
               Mod.DateCreted = dr.GetDateTime(10);
               Mod.LastModified = dr.GetDateTime(11);
               Mod.xIndexNo = dr.GetString(12);
               Mod.xFullName = dr.GetString(13) + " " + dr.GetString(14) + " " + dr.GetString(15);
               Mod.xBatchTitle = dr.GetString(16);
               Mod.xLesson = dr.GetString(17);
               Mod.xLessCode = dr.GetString(18);
               Mod.xCredit = dr.GetInt32(19);
               Mod.xProgram = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.xTotalMarks = dr.GetDecimal(7) + dr.GetDecimal(8);
               GradingSystem gs = new GradingSystemService().GetGradingSystem(gradsysId, Mod.xTotalMarks);
               Mod.xGrade = gs.GsGrade;
               Mod.xGradeDesc = gs.GSDescription;
               Mod.xGradepiont = gs.GsPoint;
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
   }
}
