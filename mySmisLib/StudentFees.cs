using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class StudentFees
    {
        public int ID { get; set; }
        public int FeeCateId { get; set; }
        public int BatchId { get; set; }
        public string UserId { get; set; }
        public string Bgroup { get; set; } 
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public double Feevalue { get; set; }
        public string xFullName { get; set; }
        public string xIndexNo { get; set; }
        public string xFeeTitle { get; set; }
        public string xBatchTitle { get; set; }
        public double xFeevalue { get; set; }
        public double xPayments { get; set; }
        public double xFeesLeft { get; set; }
        



       public StudentFees(){}
    }

   public class StudentFeesService
   {
       public bool AddStudentFees(StudentFees fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentfees`(`feeid`, `batchid`, `createdate`, `modifydate`,studuserid,bgroup,feevalue) VALUES (@feeid,@batchid,@createdate,@modifydate,@studuserid,@bgroup,@feevalue)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@feeid", fp.FeeCateId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@studuserid", fp.UserId);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@feevalue",fp.Feevalue);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool AddStudentFeesList(string fpList, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = string.Format("INSERT INTO `studentfees`(`feeid`, `batchid`,`createdate`, `modifydate`,studuserid,bgroup,feevalue) VALUES {0}",fpList);
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@feeid", fp.FeeCateId);
           //cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           //cmd.Parameters.AddWithValue("@feevalue", fp.Feevalue);
           //cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
           //cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           //cmd.Parameters.AddWithValue("@studuserid", fp.UserId);
           //cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateStudentFees(StudentFees fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentfees` SET `feeid`=@feeid,`batchid`=@batchid,`modifydate`=@modifydate,studuserid = @studuserid, bgroup = @bgroup, feevalue =@feevalue WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@feeid", fp.FeeCateId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@id", fp.ID);
           cmd.Parameters.AddWithValue("@studuserid", fp.UserId);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@feevalue", fp.Feevalue);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteStudentFees(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `studentfees` WHERE id = @id";
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
       public List<StudentFees> GetAllStudentFees(string userID)
       {
           List<StudentFees> retVal = new List<StudentFees>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `feeid`, `batchid`,`createdate`, `modifydate`,studuserid,bgroup,feevalue FROM `studentfees`";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentFees Mod = new StudentFees();
               Mod.ID = dr.GetInt32(0);
               Mod.FeeCateId = dr.GetInt32(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.DateCreted = dr.GetDateTime(3);
               Mod.LastModified = dr.GetDateTime(4);
               Mod.UserId = dr.GetString(5);
               Mod.Bgroup = dr.GetString(6);
               Mod.Feevalue = dr.GetDouble(7);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<StudentFees> GetAllStudentFees(int batchId,string userID)
       {
           List<StudentFees> retVal = new List<StudentFees>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfees.id,studentfees.feeid,studentfees.batchid,studentfees.bgroup,studentfees.studuserid,studentfees.createdate,studentfees.modifydate,feescategory.title,feevalue,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentfees.feevalue FROM studentfees INNER JOIN feescategory ON studentfees.feeid = feescategory.id INNER JOIN students ON studentfees.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentfees.batchid = studentcoursesschedule.id WHERE studentfees.batchid = @batchId";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentFees Mod = new StudentFees();
               Mod.ID = dr.GetInt32(0);
               Mod.FeeCateId = dr.GetInt32(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.UserId = dr.GetString(4);
               Mod.DateCreted = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.xFeeTitle = dr.GetString(7);
               Mod.xFeevalue = dr.GetDouble(8);
               Mod.xIndexNo = dr.GetString(9);
               Mod.xFullName = dr.GetString(10) + " " + dr.GetString(11) + " " + dr.GetString(12);
               Mod.xBatchTitle = dr.GetString(13);
               Mod.Feevalue = dr.GetDouble(14);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

       public List<StudentFees> GetStudentFees(string studuserID,int batchId, string userID)
       {
           List<StudentFees> retVal = new List<StudentFees>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfees.id,studentfees.feeid,studentfees.batchid,studentfees.bgroup,studentfees.studuserid,studentfees.createdate,studentfees.modifydate,feescategory.title,feevalue,students.indexNo,students.fname,students.onames,students.sname,studentcoursesschedule.schdTitle,studentfees.feevalue FROM studentfees INNER JOIN feescategory ON studentfees.feeid = feescategory.id INNER JOIN students ON studentfees.studuserid = students.userId INNER JOIN studentcoursesschedule ON studentfees.batchid = studentcoursesschedule.id WHERE studentfees.batchid = @batchId AND studentfees.studuserid = @studUserId";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchId", batchId);
           cmd.Parameters.AddWithValue("@studUserId", studuserID);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentFees Mod = new StudentFees();
               Mod.ID = dr.GetInt32(0);
               Mod.FeeCateId = dr.GetInt32(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.UserId = dr.GetString(4);
               Mod.DateCreted = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.xFeeTitle = dr.GetString(7);
               Mod.xFeevalue = dr.GetDouble(8);
               Mod.xIndexNo = dr.GetString(9);
               Mod.xFullName = dr.GetString(10) + " " + dr.GetString(11) + " " + dr.GetString(12);
               Mod.xBatchTitle = dr.GetString(13);
               Mod.Feevalue = dr.GetDouble(14);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public StudentFees GetStudentFeesById(int Id, string userID)
       {
           StudentFees retVal = new StudentFees();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT `id`, `feeid`, `batchid`,`createdate`, `modifydate`,studuserid,bgroup,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),studentfees.feevalue,IFNULL((SELECT Sum(studentfeepayment.payvalue) FROM studentfeepayment WHERE studentfeepayment.studuserid = studentfees.studuserid AND studentfeepayment.batchid = studentfees.batchid AND studentfeepayment.bgroup = studentfees.bgroup),0) AS feepayments FROM `studentfees` INNER JOIN students ON studentfees.studuserid = students.userId WHERE id = @Id";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@Id", Id);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               //StudentFees Mod = new StudentFees();
               retVal.ID = dr.GetInt32(0);
               retVal.FeeCateId = dr.GetInt32(1);
               retVal.BatchId = dr.GetInt32(2);
               retVal.DateCreted = dr.GetDateTime(3);
               retVal.LastModified = dr.GetDateTime(4);
               retVal.UserId = dr.GetString(5);
               retVal.Bgroup = dr.GetString(6);
               retVal.xIndexNo = dr.GetString(7);
               retVal.xFullName = dr.GetString(8);
               retVal.Feevalue = dr.GetDouble(9);
               retVal.xPayments = dr.GetDouble(10);
               retVal.xFeesLeft = dr.GetDouble(9) - dr.GetDouble(10);
           }


           con.Close();

           return retVal;
       }
       public List<StudentFees> GetStudentFeesAccounts(string userID)
       {
           List<StudentFees> retVal = new List<StudentFees>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfees.id,studentfees.batchid,studentfees.bgroup,studentfees.studuserid,IFNULL(Sum(feevalue),0.00) AS studfess,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL((SELECT Sum(studentfeepayment.payvalue) FROM studentfeepayment WHERE studentfeepayment.studuserid = studentfees.studuserid AND studentfeepayment.batchid = studentfees.batchid AND studentfeepayment.bgroup = studentfees.bgroup),0) AS feepayments FROM studentfees LEFT OUTER JOIN feescategory ON studentfees.feeid = feescategory.id AND studentfees.batchid = feesbatches.batchid INNER JOIN students ON studentfees.studuserid = students.userId GROUP BY studentfees.bgroup,studentfees.batchid,studentfees.studuserid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           //cmd.Parameters.AddWithValue("@batchId", batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentFees Mod = new StudentFees();
               Mod.ID = dr.GetInt32(0);
               Mod.BatchId = dr.GetInt32(1);
               Mod.Bgroup = dr.GetString(2);
               Mod.UserId = dr.GetString(3);
               Mod.xFeevalue = dr.GetDouble(4);
               Mod.xIndexNo = dr.GetString(5);
               Mod.xFullName = dr.GetString(6);
               Mod.xPayments = dr.GetDouble(7);
               Mod.xFeesLeft = dr.GetDouble(4) - dr.GetDouble(7);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<StudentFees> GetStudentFeesAccounts(int batchId,string userID)
       {
           List<StudentFees> retVal = new List<StudentFees>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfees.id,studentfees.batchid,studentfees.bgroup,studentfees.studuserid,IFNULL(Sum(feevalue),0.00) AS studfess,students.indexNo,students.fname,students.onames,students.sname,IFNULL((SELECT Sum(studentfeepayment.payvalue) FROM studentfeepayment WHERE studentfeepayment.studuserid = studentfees.studuserid AND studentfeepayment.batchid = studentfees.batchid AND studentfeepayment.bgroup = studentfees.bgroup),0) AS feepayments FROM studentfees LEFT OUTER JOIN feescategory ON studentfees.feeid = feescategory.id INNER JOIN students ON studentfees.studuserid = students.userId WHERE studentfees.batchid = @batchid GROUP BY studentfees.bgroup,studentfees.batchid,studentfees.studuserid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               StudentFees Mod = new StudentFees();
               Mod.ID = dr.GetInt32(0);
               Mod.BatchId = dr.GetInt32(1);
               Mod.Bgroup = dr.GetString(2);
               Mod.UserId = dr.GetString(3);
               Mod.xFeevalue = dr.GetDouble(4);
               Mod.xIndexNo = dr.GetString(5);
               Mod.xFullName = dr.GetString(6) + " " + dr.GetString(7) + " " + dr.GetString(8);
               Mod.xPayments = dr.GetDouble(9);
               Mod.xFeesLeft = dr.GetDouble(4) - dr.GetDouble(9);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public StudentFees GetStudentFeesAccounts(string studUserId, int batchId, string userID)
       {
           StudentFees Mod = new StudentFees();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfees.id,studentfees.batchid,studentfees.bgroup,studentfees.studuserid,IFNULL(Sum(feevalue),0.00) AS studfess,students.indexNo,students.fname,students.onames,students.sname,IFNULL((SELECT Sum(studentfeepayment.payvalue) FROM studentfeepayment WHERE studentfeepayment.studuserid = studentfees.studuserid AND studentfeepayment.batchid = studentfees.batchid AND studentfeepayment.bgroup = studentfees.bgroup),0) AS feepayments FROM studentfees LEFT OUTER JOIN feescategory ON studentfees.feeid = feescategory.id INNER JOIN students ON studentfees.studuserid = students.userId WHERE studentfees.batchid = @batchid AND students.userId = @studUserId GROUP BY studentfees.bgroup,studentfees.batchid,studentfees.studuserid";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@studUserId", studUserId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               //StudentFees Mod = new StudentFees();
               Mod.ID = dr.GetInt32(0);
               Mod.BatchId = dr.GetInt32(1);
               Mod.Bgroup = dr.GetString(2);
               Mod.UserId = dr.GetString(3);
               Mod.xFeevalue = dr.GetDouble(4);
               Mod.xIndexNo = dr.GetString(5);
               Mod.xFullName = dr.GetString(6) + " " + dr.GetString(7) + " " + dr.GetString(8);
               Mod.xPayments = dr.GetDouble(9);
               Mod.xFeesLeft = dr.GetDouble(4) - dr.GetDouble(9);
               //retVal.Add(Mod);
           }


           con.Close();

           return Mod;
       }
   }
}
