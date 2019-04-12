using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class Tutor
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
        public string Stafftype { get; set; }
        public DateTime Admissiondate { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        public string xFullName { get; set; }
        public string xContactInfo { get; set; }
        public string xAge { get; set; }
        public Tutor(){}
    }

    public class TutorService
    {
        public bool AddTutor(Tutor stud, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "INSERT INTO `tutors`(userId,`indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype) VALUES (@userId,@indexNo, @title, @fname, @onames, @sname, @gender, @dob, @religion, @tel, @email, @nationality, @postadd, @resadd, @marital, @mobile,@dateCreated, @lastModified,@admintiondate,@stafftype)";

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
                cmd.Parameters.AddWithValue("@stafftype", stud.Stafftype);
                int rowsAffec = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("REGISTER STAFF", userId, new UserService().GetUserName(userId), "A new staff with staff ID : " + stud.IndexNo + " was registered", DateTime.Now);
                if (rowsAffec > 0)
                {
                    retVal = true;
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                new AuditLogService().AddAuditLog("ERROR REGISTERING STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                new AuditLogService().AddAuditLog("ERROR REGISTERING STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public bool UpdateTutor(Tutor stud, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = "UPDATE `tutors` SET `userId`=@userId,`indexNo`=@indexNo,`title`=@title,`fname`=@fname,`onames`=@onames,`sname`=@sname,`gender`=@gender,`dob`=@dob,`religion`=@religion,`mobile`=@mobile,`tel`=@tel,`email`=@email,`nationality`=@nationality,`postadd`=@postadd,`resadd`=@resadd,`marital`=@marital,`lastModified`=@lastModified,admintiondate = @admintiondate, stafftype = @stafftype WHERE userId = @userId ";

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
                cmd.Parameters.AddWithValue("@stafftype", stud.Stafftype);
                int rowsAffec = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("UPDATE STAFF INFOMATION", userId, new UserService().GetUserName(userId), "A staff with staff ID : " + stud.IndexNo + "'s information was updated", DateTime.Now);
                if (rowsAffec > 0)
                {
                    retVal = true;
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING STAFF INFOMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                new AuditLogService().AddAuditLog("ERROR UPDATING STAFF INFOMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public List<Tutor> GetAllTutor(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` ";
            Tutor member;
            List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
               // new AuditLogService().AddAuditLog("GETTING ALL STAFF", userId, new UserService().GetUserName(userId), "", DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();

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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3)+" "+dr.GetString(4) +" "+ dr.GetString(5);
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public List<Tutor> GetAllTutor(char gender, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` WHERE gender=@gender";
            Tutor member;
            List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gender", gender);

                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING STAFF BY GENDER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();

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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY GENDER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY GENDER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public List<Tutor> GetAllTutor(string mobNumber, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` WHERE mobile=@tel";
            Tutor member;
            List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tel", mobNumber);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING STAFF BY MOBILE NUMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();
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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY MOBILE NUMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY MOBILE NUMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public List<Tutor> GetAllTutorByStaffTypeNotINLessons(string stafftype,string stafftype2,int lessonID, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` WHERE stafftype=@stafftype OR stafftype = @stafftype2 AND userId NOT IN(SELECT instructorID FROM studentlessonsinstructors WHERE lessonID = @lessonID)";
            Tutor member;
            List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@stafftype", stafftype);
                cmd.Parameters.AddWithValue("@stafftype2", stafftype2);
                cmd.Parameters.AddWithValue("@lessonID", lessonID);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING STAFF BY STAFF TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();
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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY STAFF TYPE", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY STAFF TYPE", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public List<Tutor> GetTutorByStaffTypeNotInList(string stafftype, string stafftype2,string stafftype3, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` WHERE `tutors`.userId NOT IN (SELECT userId FROM `user` WHERE usertype = @stafftype OR usertype = @stafftype2 OR usertype = @stafftype3)";
            Tutor member;
            List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@stafftype", stafftype);
                cmd.Parameters.AddWithValue("@stafftype2", stafftype2);
                cmd.Parameters.AddWithValue("@stafftype3", stafftype3);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING STAFF BY STAFF TYPE", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();
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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY STAFF TYPE", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING STAFF BY STAFF TYPE", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memberList;
        }
        public Tutor GetTutor(string staffuserId, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` WHERE `userId`= @userId ";
            Tutor member = new Tutor();
            //List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", staffuserId);
                dr = cmd.ExecuteReader();
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();
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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        //memberList.Add(member);
                    }

                    new AuditLogService().AddAuditLog("GETTING A STAFF'S INFORMATION", userId, new UserService().GetUserName(userId), "A STAFF with the Index No. : " + member.IndexNo + "'s information was selected", DateTime.Now);
                
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING A STAFF INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING A STAFF INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return member;
        }
        public Tutor GetTutor(string tutorUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified`,admintiondate,stafftype FROM `tutors` WHERE `userId`= @userId ";
            Tutor member = new Tutor();
            //List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", tutorUserId);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("GETTING A STAFF'S INFORMATION", userId, new UserService().GetUserName(userId), "A STAFF with the Index No. : " + indexNo + "'s information was selected", DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();
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
                        member.Stafftype = dr.GetString(19);
                        member.xFullName = dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                        //memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GETTING A STAFF INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GETTING A STAFF INFORMATION", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return member;
        }
        public List<Tutor> GetTutorResult(string indexNo, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT `userId`, `indexNo`, `title`, `fname`, `onames`, `sname`, `gender`, `dob`, `religion`, `tel`, `email`, `nationality`, `postadd`, `resadd`, `marital`, `mobile`, `dateCreated`, `lastModified` FROM `tutors` WHERE `indexNo`= @indexNo ";
            Tutor member;
            List<Tutor> memberList = new List<Tutor>();

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@indexNo", indexNo);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING ALL STAFF", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();
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
                        memberList.Add(member);
                    }
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
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

            string query = "SELECT Count(tutors.userId) AS num FROM tutors WHERE DATE(tutors.dateCreated) = DATE(NOW())";
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                new AuditLogService().AddAuditLog("GETTING ALL STAFF", userId, new UserService().GetUserName(userId), query, DateTime.Now);
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
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }


            return result;
        }
        public string TutorIDNumber()
        {
            string result = "";
            int num = 0;
            string dy = new InstanceConfigServices().GetConfig("tutorIDdynamic");
            string sp = new InstanceConfigServices().GetConfig("tutorIDSeperator");
            string tx = new InstanceConfigServices().GetConfig("tutorIDString");
            string st = new InstanceConfigServices().GetConfig("tutorIDStartingNo");

            if (st == "") { st = "0"; }

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;

            string query = "SELECT Count(tutors.userId) AS num FROM tutors "; //WHERE DATE(tutors.dateCreated) = DATE(NOW())";


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("GETTING ALL STAFF", userId, new UserService().GetUserName(userId), query, DateTime.Now);
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
               // new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               // String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // //new AuditLogService().AddAuditLog("ERROR GETTING ALL STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            
            if ( tx != "" )
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
        public List<Tutor> FindTutor(string searchString, int startIndex, int endIndex, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `memberID`, `indexNo`, `onames`, `sname`, `gender`, `tel`, `email`, `dateCreated`, `lastModified` FROM `tutors`  WHERE indexNo LIKE ('@indexNo%') OR CONCAT_WS(' ',onames,sname) LIKE ('%@fullname%') order by indexNo LIMIT @startIndex,@endIndex ";
                            
            Tutor member;
            List<Tutor> memList = new List<Tutor>();
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@indexNo",searchString);
                cmd.Parameters.AddWithValue("@fullname",searchString);
                cmd.Parameters.AddWithValue("@startIndex", startIndex);
                cmd.Parameters.AddWithValue("@endIndex", (endIndex - startIndex));
                dr = cmd.ExecuteReader();
                //new AuditLogService().AddAuditLog("FINDING  MEMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (dr.HasRows) //if the executed query returns any records
                {
                    while (dr.Read()) //iterate through the records in the result dataset
                    {
                        member = new Tutor();

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
    }
}
