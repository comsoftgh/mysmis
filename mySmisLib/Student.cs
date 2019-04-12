using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mySmisLib
{
    public class Student
    {
        public string UserId { get; set; }
        public string IndexNo { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string SName { get; set; }
        public string FNames { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string ONames { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string PostAdd { get; set; }
        public string ResAdd { get; set; }
        public string Marital { get; set; }
        public string Mobile { get; set; }

        public DateTime Admissiondate { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        public string xFullName { get; set; }
        public string xContactInfo { get; set; }
        public int xAge { get; set; }
        public Student() { }
    }

    public class StudentService 
    {
        public bool AddStudent(Student stud, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `students`(userId,`indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate) VALUES (@userId,@indexNo, @title, @fname, @onames, @sname, @gender, @dob, @religion, @tel, @email, @nationality, @postadd, @resadd, @marital, @mobile,@dateCreated, @lastModified,@admintiondate)";

            try
            {
                con.Open();//opens connection to database

                cmd = new MySqlCommand(query, con);//insert data if connection is open
                cmd.Parameters.AddWithValue("@indexNo", stud.IndexNo);
                cmd.Parameters.AddWithValue("@title", stud.Title);
                cmd.Parameters.AddWithValue("@fname", stud.FNames);
                cmd.Parameters.AddWithValue("@onames", stud.ONames);
                cmd.Parameters.AddWithValue("@sname", stud.SName);
                cmd.Parameters.AddWithValue("@gender", stud.Gender);
                cmd.Parameters.AddWithValue("@dob", stud.Dob);
                cmd.Parameters.AddWithValue("@religion", stud.Religion);
                cmd.Parameters.AddWithValue("@tel", stud.Tel);
                cmd.Parameters.AddWithValue("@email", stud.Email);
                cmd.Parameters.AddWithValue("@nationality", stud.Nationality);
                cmd.Parameters.AddWithValue("@postadd", stud.PostAdd);
                cmd.Parameters.AddWithValue("@resadd", stud.ResAdd);
                cmd.Parameters.AddWithValue("@dateCreated", stud.DateCreated);
                cmd.Parameters.AddWithValue("@lastModified", stud.LastModified);
                cmd.Parameters.AddWithValue("@marital", stud.Marital);
                cmd.Parameters.AddWithValue("@mobile", stud.Mobile);
                cmd.Parameters.AddWithValue("@userId", stud.UserId);
                cmd.Parameters.AddWithValue("@admintiondate", stud.Admissiondate);
                int rowsAffec = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("REGISTER STUDENT", userId, new UserService().GetUserName(userId), "A new student with Index No: " + stud.IndexNo + " was registered", DateTime.Now);
                if (rowsAffec > 0)
                {
                    retVal = true;
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                new AuditLogService().AddAuditLog("ERROR REGISTERING STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                new AuditLogService().AddAuditLog("ERROR REGISTERING STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public bool UpdateStudent(Student stud, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "UPDATE `students` SET `indexNo`=@indexNo,`title`=@title,`fname`=@fname,`onames`=@onames,`sname`=@sname,`gender`=@gender,`dob`=@dob,`religion`=@religion,`mobile`=@mobile,`tel`=@tel,`email`=@email,`nationality`=@nationality,`postadd`=@postadd,`resadd`=@resadd,`marital`=@marital,`lastModified`=@lastModified,admintiondate = @admintiondate WHERE userId = @userId ";

            try
            {
                con.Open();//opens connection to database

                cmd = new MySqlCommand(query, con);//insert data if connection is open
                cmd.Parameters.AddWithValue("@indexNo", stud.IndexNo);
                cmd.Parameters.AddWithValue("@title", stud.Title);
                cmd.Parameters.AddWithValue("@fname", stud.FNames);
                cmd.Parameters.AddWithValue("@onames", stud.ONames);
                cmd.Parameters.AddWithValue("@sname", stud.SName);
                cmd.Parameters.AddWithValue("@gender", stud.Gender);
                cmd.Parameters.AddWithValue("@dob", stud.Dob);
                cmd.Parameters.AddWithValue("@religion", stud.Religion);
                cmd.Parameters.AddWithValue("@tel", stud.Tel);
                cmd.Parameters.AddWithValue("@email", stud.Email);
                cmd.Parameters.AddWithValue("@nationality", stud.Nationality);
                cmd.Parameters.AddWithValue("@postadd", stud.PostAdd);
                cmd.Parameters.AddWithValue("@resadd", stud.ResAdd);
                cmd.Parameters.AddWithValue("@lastModified", stud.LastModified);
                cmd.Parameters.AddWithValue("@marital", stud.Marital);
                cmd.Parameters.AddWithValue("@mobile", stud.Mobile);
                cmd.Parameters.AddWithValue("@userId", stud.UserId);
                cmd.Parameters.AddWithValue("@admintiondate",stud.Admissiondate);
                int rowsAffec = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("UPDATE STUDENT INFOMATION", userId, new UserService().GetUserName(userId), "A student with Index No: " + stud.IndexNo + "'s information was updated", DateTime.Now);
                if (rowsAffec > 0)
                {
                    retVal = true;
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING STUDENT INFOMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING STUDENT INFOMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public List<Student> GetAllStudent(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate FROM `students` ";
            Student member;
            List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
               // new AuditLogService().AddAuditLog("GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), "", DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();

                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.Title = dr.GetString(2);
                        member.FNames = dr.GetString(3);
                        member.ONames = dr.GetString(4);
                        member.SName = dr.GetString(5);
                        member.Gender = dr.GetString(6);
                        member.Dob = dr.GetDateTime(7);
                        member.Religion = dr.GetString(8);
                        member.Tel = dr.GetString(9);
                        member.Email = dr.GetString(10);
                        member.Nationality = dr.GetString(11);
                        member.PostAdd = dr.GetString(12);
                        member.ResAdd = dr.GetString(13);
                        member.Marital = dr.GetString(14);
                        member.Mobile = dr.GetString(15);
                        member.DateCreated = dr.GetDateTime(16);
                        member.LastModified = dr.GetDateTime(17);
                        member.Admissiondate = dr.GetDateTime(18);
                        member.xFullName = dr.GetString(3)+" "+dr.GetString(4) +" "+ dr.GetString(5);
                        member.xAge = DateTime.Now.Year - member.Dob.Year;
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public List<Student> GetAllStudent(char gender, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate FROM `students` WHERE gender=@gender";
            Student member;
            List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gender", gender);

                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING STUDENT BY GENDER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();

                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.Title = dr.GetString(2);
                        member.FNames = dr.GetString(3);
                        member.ONames = dr.GetString(4);
                        member.SName = dr.GetString(5);
                        member.Gender = dr.GetString(6);
                        member.Dob = dr.GetDateTime(7);
                        member.Religion = dr.GetString(8);
                        member.Tel = dr.GetString(9);
                        member.Email = dr.GetString(10);
                        member.Nationality = dr.GetString(11);
                        member.PostAdd = dr.GetString(12);
                        member.ResAdd = dr.GetString(13);
                        member.Marital = dr.GetString(14);
                        member.Mobile = dr.GetString(15);
                        member.DateCreated = dr.GetDateTime(16);
                        member.LastModified = dr.GetDateTime(17);
                        member.Admissiondate = dr.GetDateTime(18);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        member.xAge = DateTime.Now.Year - member.Dob.Year;
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STUDENT BY GENDER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STUDENT BY GENDER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public List<Student> GetAllStudent(string mobNumber, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate FROM `students` WHERE mobile=@tel";
            Student member;
            List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tel", mobNumber);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING STUDENT BY MOBILE NUMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();
                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.Title = dr.GetString(2);
                        member.FNames = dr.GetString(3);
                        member.ONames = dr.GetString(4);
                        member.SName = dr.GetString(5);
                        member.Gender = dr.GetString(6);
                        member.Dob = dr.GetDateTime(7);
                        member.Religion = dr.GetString(8);
                        member.Tel = dr.GetString(9);
                        member.Email = dr.GetString(10);
                        member.Nationality = dr.GetString(11);
                        member.PostAdd = dr.GetString(12);
                        member.ResAdd = dr.GetString(13);
                        member.Marital = dr.GetString(14);
                        member.Mobile = dr.GetString(15);
                        member.DateCreated = dr.GetDateTime(17);
                        member.LastModified = dr.GetDateTime(18);
                        member.Admissiondate = dr.GetDateTime(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        member.xAge = DateTime.Now.Year - member.Dob.Year;
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STUDENT BY MOBILE NUMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STUDENT BY MOBILE NUMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public Student GetStudent(string indexNo, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate FROM `students` WHERE `indexNo`= @indexNo ";
            Student member = new Student();
            //List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@indexNo", indexNo);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING A STUDENT'S INFORMATION", userId, new UserService().GetUserName(userId), "A student with the Index No. : "+indexNo+"'s information was selected", DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();
                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.Title = dr.GetString(2);
                        member.FNames = dr.GetString(3);
                        member.ONames = dr.GetString(4);
                        member.SName = dr.GetString(5);
                        member.Gender = dr.GetString(6);
                        member.Dob = dr.GetDateTime(7);
                        member.Religion = dr.GetString(8);
                        member.Tel = dr.GetString(9);
                        member.Email = dr.GetString(10);
                        member.Nationality = dr.GetString(11);
                        member.PostAdd = dr.GetString(12);
                        member.ResAdd = dr.GetString(13);
                        member.Marital = dr.GetString(14);
                        member.Mobile = dr.GetString(15);
                        member.DateCreated = dr.GetDateTime(16);
                        member.LastModified = dr.GetDateTime(17);
                        member.Admissiondate = dr.GetDateTime(18);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        member.xAge = DateTime.Now.Year - member.Dob.Year;
                        //memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING A STUDENT INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING A STUDENT INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return member;
        }
        public Student GetStudent(string studUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate FROM `students` WHERE `userId`= @userId ";
            Student member = new Student();
            //List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("GETTING A STUDENT'S INFORMATION", userId, new UserService().GetUserName(userId), "A student with the Index No. : " + indexNo + "'s information was selected", DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();
                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.Title = dr.GetString(2);
                        member.FNames = dr.GetString(3);
                        member.ONames = dr.GetString(4);
                        member.SName = dr.GetString(5);
                        member.Gender = dr.GetString(6);
                        member.Dob = dr.GetDateTime(7);
                        member.Religion = dr.GetString(8);
                        member.Tel = dr.GetString(9);
                        member.Email = dr.GetString(10);
                        member.Nationality = dr.GetString(11);
                        member.PostAdd = dr.GetString(12);
                        member.ResAdd = dr.GetString(13);
                        member.Marital = dr.GetString(14);
                        member.Mobile = dr.GetString(15);
                        member.DateCreated = dr.GetDateTime(16);
                        member.LastModified = dr.GetDateTime(17);
                        member.Admissiondate = dr.GetDateTime(18);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        member.xAge = DateTime.Now.Year - member.Dob.Year;
                        //memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GETTING A STUDENT INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GETTING A STUDENT INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return member;
        }
        public List<Student> GetStudentResult(string indexNo, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified` FROM `students` WHERE `indexNo`= @indexNo ";
            Student member;
            List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@indexNo", indexNo);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();
                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.Title = dr.GetString(2);
                        member.FNames = dr.GetString(3);
                        member.ONames = dr.GetString(4);
                        member.SName = dr.GetString(5);
                        member.Gender = dr.GetString(6);
                        member.Dob = dr.GetDateTime(7);
                        member.Religion = dr.GetString(8);
                        member.Tel = dr.GetString(9);
                        member.Email = dr.GetString(10);
                        member.Nationality = dr.GetString(11);
                        member.PostAdd = dr.GetString(12);
                        member.ResAdd = dr.GetString(13);
                        member.Marital = dr.GetString(14);
                        member.Mobile = dr.GetString(15);
                        member.DateCreated = dr.GetDateTime(16);
                        member.LastModified = dr.GetDateTime(17);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        member.xAge = DateTime.Now.Year - member.Dob.Year;
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public int IndexNo(string userId)
        {
            int result = 0;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT Count(students.userId) AS num FROM students WHERE DATE(students.dateCreated) = DATE(NOW())";
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        result = dr.GetInt32(0);
                       
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }


            return result;
        }
        public string IndexNumber()
        {
            string result = "";
            int num = 0;
            string dy = new InstanceConfigServices().GetConfig("indexDynamic");
            string sp = new InstanceConfigServices().GetConfig("indexSeperator");
            string tx = new InstanceConfigServices().GetConfig("indexString");
            string st = new InstanceConfigServices().GetConfig("indexStartingNo");

            if (st == "") { st = "0"; }

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT Count(students.userId) AS num FROM students ";//WHERE DATE(students.dateCreated) = DATE(NOW())";


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        num = int.Parse(st) + 1 + dr.GetInt32(0);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               // String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // //new AuditLogService().AddAuditLog("ERROR GETTING ALL STUDENT", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            if (tx != "")
            {
                if (sp != "None") { result = tx + sp; } else { result = tx; }
                
            }

            if (dy != "None")
            {
                if (sp != "None")
                {
                    if (dy == "Year") { result = result + DateTime.Now.ToString("yy") + sp; } else if (dy == "Month") { result = result + DateTime.Now.ToString("MM") + sp; } else if (dy == "Day") { result = result + DateTime.Now.ToString("dd") + sp; }
                }
                else
                {
                    if (dy == "Year") { result = result + DateTime.Now.ToString("yy"); } else if (dy == "Month") { result = result + DateTime.Now.ToString("MM"); } else if (dy == "Day") { result = result + DateTime.Now.ToString("dd"); }

                }
            }



            return result + num;
        }
        public List<Student> FindStudent(string searchString, int startIndex, int endIndex, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT `userId`,indexNo, CONCAT_WS(' ',fname, onames, sname) as fullname, CONCAT_WS(',',tel, email,mobile) as otherDetails from students WHERE indexNo LIKE ('{0}%') OR CONCAT_WS(' ',fname, onames, sname) LIKE ('%{0}%') order by indexNo LIMIT {1},{2} ", searchString, startIndex, endIndex - startIndex);
                            
            Student member;
            List<Student> memList = new List<Student>();
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("FINDING  MEMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();

                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.xFullName = dr.GetString(2);
                        member.xContactInfo = dr.GetString(3);
                        memList.Add(member);
                       
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR FINDING MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR FINDING MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memList;
        }
        public Student GetFindStudent(string studUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`,indexNo, CONCAT_WS(' ',fname, onames, sname) as fullname, CONCAT_WS(',',tel, email,mobile) as otherDetails from students WHERE `userId`= @userId ";
            Student member = new Student();
            //List<Student> memberList = new List<Student>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", studUserId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("GETTING A STUDENT'S INFORMATION", userId, new UserService().GetUserName(userId), "A student with the Index No. : " + indexNo + "'s information was selected", DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Student();
                        member.UserId = dr.GetString(0);
                        member.IndexNo = dr.GetString(1);
                        member.xFullName = dr.GetString(2);
                        member.xContactInfo = dr.GetString(3);
                        //memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GETTING A STUDENT INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GETTING A STUDENT INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return member;
        }
        public List<Student> GetAllStudentByBatchIdBGroup(string bgroup, int batchId, string userID)
        {
            List<Student> retVal = new List<Student>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT students.userId,students.indexNo,students.fname,students.onames,students.sname,students.gender,students.admintiondate, `dob` FROM studentregistration INNER JOIN students ON studentregistration.studuserid = students.userId WHERE studentregistration.batchid = @batchid AND studentregistration.bgroup = @bgroup";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@batchId", batchId);
            cmd.Parameters.AddWithValue("@bgroup", bgroup);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Student Mod = new Student();
                Mod.UserId = dr.GetString(0);
                Mod.IndexNo = dr.GetString(1);
                Mod.FNames = dr.GetString(2);
                Mod.ONames = dr.GetString(3);
                Mod.SName = dr.GetString(4);
                Mod.Gender = dr.GetString(5);
                Mod.Admissiondate = dr.GetDateTime(6);
                Mod.Dob = dr.GetDateTime(7);
                Mod.xFullName = dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);
                Mod.xAge = DateTime.Now.Year - Mod.Dob.Year;
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<Student> GetAllUnRegStudent(string studUserIds, string userID)
        {
            if (studUserIds == "") { studUserIds = "''"; }
            List<Student> retVal = new List<Student>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = string.Format("SELECT students.userId,students.indexNo,students.fname,students.onames,students.sname,students.gender,students.admintiondate, `dob` FROM studentregistration RIGHT OUTER JOIN students ON studentregistration.studuserid = students.userId WHERE students.userId NOT IN ({0})", studUserIds);
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@studUserId", studUserIds.TrimEnd(','));
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Student Mod = new Student();
                Mod.UserId = dr.GetString(0);
                Mod.IndexNo = dr.GetString(1);
                Mod.FNames = dr.GetString(2);
                Mod.ONames = dr.GetString(3);
                Mod.SName = dr.GetString(4);
                Mod.Gender = dr.GetString(5);
                Mod.Admissiondate = dr.GetDateTime(6);
                Mod.Dob = dr.GetDateTime(7);
                Mod.xFullName = dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);
                Mod.xAge = DateTime.Now.Year - Mod.Dob.Year;
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }

    }
}
