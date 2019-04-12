using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class FeesPayment
    {
        public int ID { get; set; }
        public int BatchId { get; set; }
        public string StuduserId { get; set; }
        public string Bgroup { get; set; }
        public double Payvalue { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string PayType { get; set; }
        public string PaidBy { get; set; }
        public string ChequeNo { get; set; }
        public int Bank { get; set; }
        public string Branch { get; set; }
        public string ReceiptNo { get; set; }
        public string CashedBy { get; set; }
        public string Cleared { get; set; }
        public string Receivedby { get; set; }

        public string xFullName { get; set; }
        public string xIndexNo { get; set; }
        public string xBankName { get; set; }
        public string xBatch { get; set; }
        public string xTerm { get; set; }
        public string xAcademic { get; set; }
        public string xCourse { get; set; }
        public string xCashier { get; set; }
        public FeesPayment(){}
    }

   public class FeesPaymentService
   {
       public bool AddFeesPayment(FeesPayment fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "INSERT INTO `studentfeepayment`(`studuserid`, `batchid`, `bgroup`, `payvalue`, `createdate`, `modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,receivedby) VALUES (@studuserid,@batchid,@bgroup,@payvalue,@createdate,@modifydate,@paytype,@paidby,@checqueno,@bank,@branch,@receiptno,@cashedby,@cleared,@receivedby)";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@payvalue", fp.Payvalue);
           cmd.Parameters.AddWithValue("@createdate", fp.DateCreated);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@paytype", fp.PayType);
           cmd.Parameters.AddWithValue("@paidby", fp.PaidBy);
           cmd.Parameters.AddWithValue("@checqueno", fp.ChequeNo);
           cmd.Parameters.AddWithValue("@bank", fp.Bank);
           cmd.Parameters.AddWithValue("@branch", fp.Branch);
           cmd.Parameters.AddWithValue("@receiptno", fp.ReceiptNo);
           cmd.Parameters.AddWithValue("@cashedby", fp.CashedBy);
           cmd.Parameters.AddWithValue("@cleared", fp.Cleared);
           cmd.Parameters.AddWithValue("@receivedby",userID);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }      
       public bool UpdateFeesPayment(FeesPayment fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentfeepayment` SET `studuserid`=@studuserid,`batchid`=@batchid,`bgroup`=@bgroup,`payvalue`=@payvalue,`modifydate`=@modifydate,`paytype`=@paytype,`paidby`=@paidby,`checqueno`=@checqueno,`bank`=@bank,`branch`=@branch,`receiptno`=@receiptno,`cashedby`=@cashedby,`cleared`=@cleared WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@studuserid", fp.StuduserId);
           cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
           cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
           cmd.Parameters.AddWithValue("@payvalue", fp.Payvalue);
           cmd.Parameters.AddWithValue("@id", fp.ID);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@paytype", fp.PayType);
           cmd.Parameters.AddWithValue("@paidby", fp.PaidBy);
           cmd.Parameters.AddWithValue("@checqueno", fp.ChequeNo);
           cmd.Parameters.AddWithValue("@bank", fp.Bank);
           cmd.Parameters.AddWithValue("@branch", fp.Branch);
           cmd.Parameters.AddWithValue("@receiptno", fp.ReceiptNo);
           cmd.Parameters.AddWithValue("@cashedby", fp.CashedBy);
           cmd.Parameters.AddWithValue("@cleared", fp.Cleared);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool UpdateChequePayments(FeesPayment fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "UPDATE `studentfeepayment` SET `modifydate`=@modifydate, `cashedby`=@cashedby,`cleared`=@cleared WHERE id = @id";
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@id", fp.ID);
           cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
           cmd.Parameters.AddWithValue("@cashedby", fp.CashedBy);
           cmd.Parameters.AddWithValue("@cleared", fp.Cleared);
           if (cmd.ExecuteNonQuery() > 0)
           {
               result = true;
           }
           con.Close();
           return result;
       }
       public bool DeleteFeesPayment(int fp, string userID)
       {
           bool result = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "DELETE FROM `studentfeepayment` WHERE id = @id";
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
       public int CountFeesPayment(string userID)
       {
           int retVal = 1;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT COUNT(`id`) FROM `studentfeepayment`";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               
               retVal = dr.GetInt32(0);
                
           }


           con.Close();

           return retVal;
       }
       public List<FeesPayment> GetAllFeesPayment(string userID)
       {
           List<FeesPayment> retVal = new List<FeesPayment>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL(bank.lValue,'N/A'),receivedby,IFNULL(CONCAT(tutors.fname,' ',tutors.onames,' ',tutors.sname),' ') FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId ORDER BY studentfeepayment.`id` DESC";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16);
               Mod.xBankName = dr.GetString(17);
               Mod.Receivedby = dr.GetString(18);
               Mod.xCashier = dr.GetString(19);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<FeesPayment> GetAllFeesPayment(int batchId,string userID)
       {
           List<FeesPayment> retVal = new List<FeesPayment>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL(bank.lValue,'N/A'),receivedby,IFNULL(CONCAT(tutors.fname,' ',tutors.onames,' ',tutors.sname),' ') FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId WHERE studentfeepayment.batchid = @batchid  ORDER BY studentfeepayment.`id` DESC";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid",batchId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16);
               Mod.xBankName = dr.GetString(17);
               Mod.Receivedby = dr.GetString(18);
               Mod.xCashier = dr.GetString(19);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

       public List<FeesPayment> GetAllFeesPayment(int batchId,string studuserid, string userID)
       {
           List<FeesPayment> retVal = new List<FeesPayment>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL(bank.lValue,'N/A'),receivedby,IFNULL(CONCAT(tutors.fname,' ',tutors.onames,' ',tutors.sname),' ') FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId WHERE studentfeepayment.batchid = @batchid AND studentfeepayment.`studuserid` = @studuserid  ORDER BY studentfeepayment.`id` DESC";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@batchid", batchId);
           cmd.Parameters.AddWithValue("@studuserid", studuserid);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16);
               Mod.xBankName = dr.GetString(17);
               Mod.Receivedby = dr.GetString(18);
               Mod.xCashier = dr.GetString(19);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public FeesPayment GetFeesPayment(int fpId,string userID)
       {
           FeesPayment Mod = new FeesPayment();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL(bank.lValue,'N/A'),receivedby,IFNULL(CONCAT(tutors.fname,' ',tutors.onames,' ',tutors.sname),' ') FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId WHERE id = @id ORDER BY studentfeepayment.`id` DESC";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@id",fpId);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               //FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16);
               Mod.xBankName = dr.GetString(17);
               Mod.Receivedby = dr.GetString(18);
               Mod.xCashier = dr.GetString(19);
               //retVal.Add(Mod);
           }


           con.Close();

           return Mod;
       }
       public FeesPayment GetFeesPayment(string receiptNo)
       {
           FeesPayment Mod = new FeesPayment();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL(bank.lValue,'N/A'),studentcoursesschedule.schdTitle,studentcoursesschedule.term,studentcoursesschedule.academicyear,studentcourses.title,receivedby,IFNULL( CONCAT(tutors.fname,tutors.onames,tutors.sname),' ') FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey INNER JOIN studentcoursesschedule ON studentfeepayment.batchid = studentcoursesschedule.id INNER JOIN studentcourses ON studentcoursesschedule.classID = studentcourses.id LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId WHERE receiptno = @receiptno ORDER BY studentfeepayment.`id` DESC";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@receiptno", receiptNo);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               //FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16);
               Mod.xBankName = dr.GetString(17);
               Mod.xBatch = dr.GetString(18);
               Mod.xTerm = dr.GetString(19);
               Mod.xAcademic = dr.GetString(20);
               Mod.xCourse = dr.GetString(21);
               Mod.Receivedby = dr.GetString(22);
               Mod.xCashier = dr.GetString(23);
               //retVal.Add(Mod);
           }


           con.Close();

           return Mod;
       }
       public List<FeesPayment> GetAllFeesPaymentByPaymentType(string payType,string userID)
       {
           List<FeesPayment> retVal = new List<FeesPayment>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,students.fname,students.onames,students.sname,IFNULL(bank.lValue,'N/A'),receivedby,tutors.fname,tutors.onames,tutors.sname FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId WHERE `paytype`=@paytype ORDER BY studentfeepayment.`id` DESC ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@paytype", payType);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16) + " " + dr.GetString(17) + " " + dr.GetString(18);
               Mod.xBankName = dr.GetString(19);
               Mod.Receivedby = dr.GetString(20);
               Mod.xCashier = dr.GetString(21) + " " + dr.GetString(23);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }
       public List<FeesPayment> GetAllUnclearedCheques(string payType, string userID)
       {
           List<FeesPayment> retVal = new List<FeesPayment>();
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           string sqlInsert = "SELECT studentfeepayment.`id`, studentfeepayment.`studuserid`, studentfeepayment.`batchid`, studentfeepayment.`bgroup`, `payvalue`, studentfeepayment.`createdate`, studentfeepayment.`modifydate`, `paytype`, `paidby`, `checqueno`, `bank`, `branch`, `receiptno`, `cashedby`, `cleared`,students.indexNo,CONCAT(students.fname,' ',students.onames,' ',students.sname),IFNULL(bank.lValue,'N/A'),receivedby,IFNULL(CONCAT(tutors.fname,' ',tutors.onames,' ',tutors.sname),' ') FROM `studentfeepayment` INNER JOIN students ON studentfeepayment.studuserid = students.userId LEFT OUTER JOIN bank ON studentfeepayment.bank = bank.lKey LEFT OUTER JOIN tutors ON studentfeepayment.receivedby = tutors.userId WHERE `paytype`=@paytype AND cleared = 'No' ORDER BY studentfeepayment.`id` DESC ";
           MySqlDataReader dr = null;
           MySqlCommand cmd;
           con.Open();
           cmd = new MySqlCommand(sqlInsert, con);
           cmd.Parameters.AddWithValue("@paytype", payType);
           dr = cmd.ExecuteReader();

           while (dr.Read()) //iterate through the records in the result dataset
           {
               FeesPayment Mod = new FeesPayment();
               Mod.ID = dr.GetInt32(0);
               Mod.StuduserId = dr.GetString(1);
               Mod.BatchId = dr.GetInt32(2);
               Mod.Bgroup = dr.GetString(3);
               Mod.Payvalue = dr.GetDouble(4);
               Mod.DateCreated = dr.GetDateTime(5);
               Mod.LastModified = dr.GetDateTime(6);
               Mod.PayType = dr.GetString(7);
               Mod.PaidBy = dr.GetString(8);
               Mod.ChequeNo = dr.GetString(9);
               Mod.Bank = dr.GetInt32(10);
               Mod.Branch = dr.GetString(11);
               Mod.ReceiptNo = dr.GetString(12);
               Mod.CashedBy = dr.GetString(13);
               Mod.Cleared = dr.GetString(14);
               Mod.xIndexNo = dr.GetString(15);
               Mod.xFullName = dr.GetString(16);
               Mod.xBankName = dr.GetString(17);
               Mod.Receivedby = dr.GetString(18);
               Mod.xCashier = dr.GetString(19);
               retVal.Add(Mod);
           }


           con.Close();

           return retVal;
       }

   }
}
