using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class Registration
    {
        
        public int ID { get; set; }
        public int StudID { get; set; }
        public string OName { get; set; }
        public int ClassScheduleID { get; set; }
        public string SName { get; set; }
        public DateTime DateReg { get; set; }
        public DateTime DateModified { get; set; }
        public string FullName { get; set; }
        public string ModuleName { get; set; }
        public string ClassSchedule { get; set; }
        public string ClassTitle { get; set; }
        public string IsMember { get; set; }
        public string RegStatus { get; set; }
        public int ModuleID { get; set; }
        public int ClassID { get; set; }
       
        public Registration() { }

       

    }
    public class RegistrationService
    {
        public bool AddRegistration(Registration insReg, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `tbl_registration` (`moduleID`, `classID`, `dateRegistered`, `dateLastModified`, `classScheduleID`, `indexNo`) VALUES (@moduleID, @classID, @dateRegistered, @dateLastModified, @classScheduleID, @indexNo)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classScheduleID", insReg.ClassScheduleID);
            cmd.Parameters.AddWithValue("@moduleID", insReg.ModuleID);
            cmd.Parameters.AddWithValue("@classID", insReg.ClassID);
            cmd.Parameters.AddWithValue("@dateRegistered", insReg.DateReg);
            cmd.Parameters.AddWithValue("@indexNo", insReg.StudID);
            cmd.Parameters.AddWithValue("@dateLastModified", insReg.DateModified);
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool UpdateRegistration(Registration insReg, string userID)
        {
            
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `tbl_registration` SET `moduleID`=@moduleID, `dateLastModified`=@dateLastModified, `status`=@status, `classScheduleID`=@classScheduleID, `indexNo`=@indexNo WHERE id =@id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classScheduleID", insReg.ClassScheduleID);
            cmd.Parameters.AddWithValue("@moduleID", insReg.ModuleID);
            cmd.Parameters.AddWithValue("@classID", insReg.ClassID);
            cmd.Parameters.AddWithValue("@indexNo", insReg.StudID);
            cmd.Parameters.AddWithValue("@dateLastModified", insReg.DateModified);
            cmd.Parameters.AddWithValue("@id",insReg.ID);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool DeleteRegistration(int upReg, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "DELETE FROM `tbl_registration` WHERE id=@id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", upReg);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public List<Registration> GetAllRegistration(string userID) 
        {
            List<Registration> results = new List<Registration>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT tbl_registration.id, tbl_registration.moduleID, tbl_registration.classID,tbl_registration.dateRegistered,tbl_registration.dateLastModified,tbl_registration.`status`,tbl_registration.classScheduleID,tbl_registration.indexNo,students.onames,students.sname,studentcourses.title,studentcoursesschedule.schdTitle FROM tbl_registration LEFT OUTER JOIN students ON tbl_registration.indexNo = students.indexNo LEFT OUTER JOIN studentcourses ON tbl_registration.classID = studentcourses.id LEFT OUTER JOIN studentcoursesschedule ON tbl_registration.classScheduleID = studentcoursesschedule.id ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Registration Mod = new Registration();
                Mod.ID = dr.GetInt32(0);
                Mod.ModuleID = dr.GetInt32(1);
                Mod.ClassID = dr.GetInt32(2);
                Mod.DateReg = dr.GetDateTime(3);
                Mod.DateModified = dr.GetDateTime(4);
                Mod.RegStatus = dr.GetString(5);
                Mod.ClassScheduleID = dr.GetInt32(6);
                Mod.StudID = dr.GetInt32(7);
                Mod.OName = dr.GetString(8);
                Mod.SName = dr.GetString(9);
                Mod.ClassTitle = dr.GetString(10);
                Mod.ClassSchedule = dr.GetString(11);
                
                results.Add(Mod);
            }


            con.Close();
            return results; 
        }

        public List<Registration> GetAllRegistrationByStudIDByModID(int studtID, int moduleID, string userID)
        {
            List<Registration> results = new List<Registration>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT tbl_registration.id, tbl_registration.moduleID, tbl_registration.classID,tbl_registration.dateRegistered,tbl_registration.dateLastModified,tbl_registration.`status`,tbl_registration.classScheduleID,tbl_registration.indexNo,students.onames,students.sname,studentcourses.title,studentcoursesschedule.schdTitle FROM tbl_registration LEFT OUTER JOIN students ON tbl_registration.indexNo = students.indexNo LEFT OUTER JOIN studentcourses ON tbl_registration.classID = studentcourses.id LEFT OUTER JOIN studentcoursesschedule ON tbl_registration.classScheduleID = studentcoursesschedule.id  WHERE tbl_registration.indexNo = @indexNo AND tbl_registration.moduleID = @moduleID";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@indexNo",studtID);
            cmd.Parameters.AddWithValue("@moduleID", moduleID);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Registration Mod = new Registration();
                Mod.ID = dr.GetInt32(0);
                Mod.ModuleID = dr.GetInt32(1);
                Mod.ClassID = dr.GetInt32(2);
                Mod.DateReg = dr.GetDateTime(3);
                Mod.DateModified = dr.GetDateTime(4);
                Mod.RegStatus = dr.GetString(5);
                Mod.ClassScheduleID = dr.GetInt32(6);
                Mod.StudID = dr.GetInt32(7);
                Mod.OName = dr.GetString(8);
                Mod.SName = dr.GetString(9);
                Mod.ClassTitle = dr.GetString(10);
                Mod.ClassSchedule = dr.GetString(11);
               
                results.Add(Mod);
            }


            con.Close();
            return results;
        }

        public int GetLastRegistrationID(string userID) 
        {
            int retVal = 0;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT tbl_registration.id FROM tbl_registration ORDER BY tbl_registration.id DESC LIMIT 1  ";
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
    }
}


