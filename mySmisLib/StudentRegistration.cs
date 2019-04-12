using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class StudentRegistration
    {
        public int ID { get; set; }
        public int BatchId { get; set; }
        public string StuduserId { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string Bgroup { get; set; }

        public string xIndexNo { get; set; }
        public string xGender { get; set; }
        public string xSName { get; set; }
        public string xFNames { get; set; }
        public string xONames { get; set; }
        public string xFullName { get; set; }
        public DateTime xAdmissiondate { get; set; }
        public string xBatchTitle { get; set; }
        public int xGsId { get; set; }
        public string xTerm { get; set; }
        public string xAcademicYear { get; set; }
        public string xProgram { get; set; }
        public int xAge { get; set; }

       public StudentRegistration(){}
    }

   public class StudentRegistrationService
   {
       public bool AddStudentRegistration(StudentRegistration fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentregistration`( `batchid`, `bgroup`, `studuserid`, `createdate`, `modifydate`) VALUES (@batchid,@bgroup,@studuserid,@createdate,@modifydate)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
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
       public bool AddStudentRegistrationList(string generalAttendanceList, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = string.Format("INSERT INTO `studentregistration`( `batchid`, `bgroup`, `studuserid`, `createdate`, `modifydate`) VALUES {0}",generalAttendanceList);
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
       public bool UpdateStudentRegistration(StudentRegistration fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentregistration` SET `studuserid`=@studuserid,`batchid`=@batchid,`modifydate`=@modifydate, bgroup = @bgroup WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
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
       public bool DeleteStudentRegistration(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `studentregistration` WHERE id = @id";
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
       public List<StudentRegistration> GetAllStudentRegistration(string userID)
       {
           List<StudentRegistration> retVal = new List<StudentRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT students.userId,students.indexNo,students.fname,students.onames,students.sname,students.gender,students.admintiondate,studentcoursesschedule.schdTitle,studentregistration.id,`dob` FROM studentregistration INNER JOIN students ON studentregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentregistration.batchid = studentcoursesschedule.id";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentRegistration Mod = new StudentRegistration();
               Mod.StuduserId = dr.GetString(0);
               Mod.xIndexNo = dr.GetString(1);
               Mod.xFNames = dr.GetString(2);
               Mod.xONames = dr.GetString(3);
               Mod.xSName = dr.GetString(4);
               Mod.xGender = dr.GetString(5);
               Mod.xAdmissiondate = dr.GetDateTime(6);
               Mod.xBatchTitle = dr.GetString(7);
               Mod.ID = dr.GetInt32(8);
               Mod.xAge = DateTime.Now.Year - dr.GetDateTime(9).Year;
               Mod.xFullName = dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);

               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<StudentRegistration> GetAllStudentRegistrationByBatchIdBgroup(int batchId, string bGroup, string userID)
       {
           List<StudentRegistration> retVal = new List<StudentRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT students.userId,students.indexNo,students.fname,students.onames,students.sname,students.gender,students.admintiondate,studentcoursesschedule.schdTitle,studentregistration.id,studentcoursesschedule.bgsid,studentcoursesschedule.bgroup,studentregistration.batchid,dob FROM studentregistration INNER JOIN students ON studentregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentregistration.batchid = studentcoursesschedule.id WHERE studentregistration.batchid = @batchid AND studentregistration.bgroup = @bgroup";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid",batchId);
           cmd.Parameters.AddWithValue("@bgroup", bGroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentRegistration Mod = new StudentRegistration();
               Mod.StuduserId = dr.GetString(0);
               Mod.xIndexNo = dr.GetString(1);
               Mod.xFNames = dr.GetString(2);
               Mod.xONames = dr.GetString(3);
               Mod.xSName = dr.GetString(4);
               Mod.xGender = dr.GetString(5);
               Mod.xAdmissiondate = dr.GetDateTime(6);
               Mod.xBatchTitle = dr.GetString(7);
               Mod.ID = dr.GetInt32(8);
               Mod.xFullName = dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);
               Mod.xGsId = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.BatchId = dr.GetInt32(11);
               Mod.xAge = DateTime.Now.Year - dr.GetDateTime(12).Year;
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

       public List<StudentRegistration> GetStudentRegistrationByBatchId(int batchId, string userID)
       {
           List <StudentRegistration> retVal = new List <StudentRegistration>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT students.userId,students.indexNo,students.fname,students.onames,students.sname,students.gender,students.admintiondate,studentcoursesschedule.schdTitle,studentregistration.id,studentcoursesschedule.bgsid,studentcoursesschedule.bgroup,studentregistration.batchid,studentcoursesschedule.term,studentcoursesschedule.academicyear,studentcourses.title,dob FROM studentregistration INNER JOIN students ON studentregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentregistration.batchid = studentcoursesschedule.id INNER JOIN studentcourses ON studentcoursesschedule.classID = studentcourses.id WHERE studentregistration.batchid = @batchid ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentRegistration Mod = new StudentRegistration();
               Mod.StuduserId = dr.GetString(0);
               Mod.xIndexNo = dr.GetString(1);
               Mod.xFNames = dr.GetString(2);
               Mod.xONames = dr.GetString(3);
               Mod.xSName = dr.GetString(4);
               Mod.xGender = dr.GetString(5);
               Mod.xAdmissiondate = dr.GetDateTime(6);
               Mod.xBatchTitle = dr.GetString(7);
               Mod.ID = dr.GetInt32(8);
               Mod.xFullName = dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);
               Mod.xGsId = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.BatchId = dr.GetInt32(11);
               Mod.xTerm = dr.GetString(12);
               Mod.xAcademicYear = dr.GetString(13);
               Mod.xProgram = dr.GetString(14);
               Mod.xAge = DateTime.Now.Year - dr.GetDateTime(15).Year;
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public StudentRegistration GetStudentRegistrationByBatchId(int batchId, string studuserId, string userID)
       {
           StudentRegistration  Mod = new StudentRegistration();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT students.userId,students.indexNo,students.fname,students.onames,students.sname,students.gender,students.admintiondate,studentcoursesschedule.schdTitle,studentregistration.id,studentcoursesschedule.bgsid,studentcoursesschedule.bgroup,studentregistration.batchid,studentcoursesschedule.term,studentcoursesschedule.academicyear,studentcourses.title,dob FROM studentregistration INNER JOIN students ON studentregistration.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentregistration.batchid = studentcoursesschedule.id INNER JOIN studentcourses ON studentcoursesschedule.classID = studentcourses.id WHERE studentregistration.batchid = @batchid AND students.userId = @studuserId";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@studuserId", studuserId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               //StudentRegistration Mod = new StudentRegistration();
               Mod.StuduserId = dr.GetString(0);
               Mod.xIndexNo = dr.GetString(1);
               Mod.xFNames = dr.GetString(2);
               Mod.xONames = dr.GetString(3);
               Mod.xSName = dr.GetString(4);
               Mod.xGender = dr.GetString(5);
               Mod.xAdmissiondate = dr.GetDateTime(6);
               Mod.xBatchTitle = dr.GetString(7);
               Mod.ID = dr.GetInt32(8);
               Mod.xFullName = dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);
               Mod.xGsId = dr.GetInt32(9);
               Mod.Bgroup = dr.GetString(10);
               Mod.BatchId = dr.GetInt32(11);
               Mod.xTerm = dr.GetString(12);
               Mod.xAcademicYear = dr.GetString(13);
               Mod.xProgram = dr.GetString(14);
               Mod.xAge = DateTime.Now.Year - dr.GetDateTime(15).Year;
               //retVal.Add(Mod);
           }


           con.Close();

           return Mod;
       }
       public string GetStudentRegistrationByBatchIdBGroup(string bgroup,string userID)
       {
           string retVal = "";
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentregistration.studuserid FROM studentregistration WHERE studentregistration.bgroup = @bgroup";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@batchId", batchId);
           cmd.Parameters.AddWithValue("@bgroup", bgroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               retVal += "'"+dr.GetString(0)+"'"+",";
           }


           con.Close();

           return retVal.TrimEnd(',');
       }
       public List<string> GetStudentRegistrationByBatchIdBGroupNotInList(int batctId, string bgroup, string studuserIdList, string userID)
       {
           List<string> retVal = new List<string>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = string.Format("SELECT studentregistration.studuserid FROM studentregistration WHERE studentregistration.batchid = '{0}' AND studentregistration.bgroup = '{1}' AND studentregistration.studuserid NOT IN ('{2}') ",batctId,bgroup,studuserIdList);
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@batchId", batchId);
           //cmd.Parameters.AddWithValue("@bgroup", bgroup);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               retVal.Add(dr.GetString(0));
           }


           con.Close();

           return retVal;
       }
   }
}
