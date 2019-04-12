using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace mySmisLib
{
    public   class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModify { get; set; }
        public string UserType { get; set; }
        public string xFullName { get; set; }
        public string xIndexNo { get; set; }
        public string xContactInfo { get; set; }
        public int Active { get; set; }
        public string xActive { get; set; }

    }
    public class UserService
    {

        public string GenerateUserID()
        {
            string userId = Guid.NewGuid().ToString().Replace("-", string.Empty);
            
            return userId;
        }
        public bool AddUser(User user, string userId)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            ServiceObjectSecurity sos = new ServiceObjectSecurity();
            
            string pass = sos.EncodePasswordMD5(user.Password);

            string query = string.Format("INSERT INTO user(userId,userName,passwd,dateCreated,lastModified,usertype)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
            user.UserId,user.UserName, pass,  user.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"), user.LastModify.ToString("yyyy-MM-dd HH:mm:ss"),user.UserType);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                new AuditLogService().AddAuditLog("ADD USER", userId, new UserService().GetUserName(userId), query, DateTime.Now);              
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADD USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADD USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public List<User> GetAllUsers(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT userid,userName,passwd,dateCreated,lastModified,usertype,active FROM user";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
               // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.Password = dr.GetString(2);
                        user.DateCreated = dr.GetDateTime(3);
                        user.LastModify = dr.GetDateTime(4);
                        user.UserType = dr.GetString(5);
                        user.Active = dr.GetInt32(6);
                        
                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }
        public List<User> GetAllUsers(string userType,string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT userid,userName,dateCreated,lastModified,usertype,active FROM user WHERE usertype = @usertype";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usertype",userType);
                // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.DateCreated = dr.GetDateTime(2);
                        user.LastModify = dr.GetDateTime(3);
                        user.UserType = dr.GetString(4);
                        user.Active = dr.GetInt32(5);

                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }
        public User GetUserByUserID(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr =null;
            string query = string.Format("SELECT userid,userName,passwd,dateCreated,lastModified,usertype,active FROM user WHERE userId='{0}'", userId);

           
            User user = new User();
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //new AuditLogService().AddAuditLog("GET USER BY ID", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.Password = dr.GetString(2);
                        user.DateCreated = dr.GetDateTime(3);
                        user.LastModify = dr.GetDateTime(4);
                        user.UserType = dr.GetString(5);
                        user.Active = dr.GetInt32(6);


                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET USER BY ID", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GET USER BY ID", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return user;
        }
        public User GetLastUser(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;
            string query = string.Format("SELECT userid,userName,passwd,dateCreated,lastModified FROM user ORDER BY userid DESC LIMIT 1");


            User user = new User();
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //new AuditLogService().AddAuditLog("GET LAST USER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.Password = dr.GetString(2);
                        user.DateCreated = dr.GetDateTime(3);
                        user.LastModify = dr.GetDateTime(4);
                       


                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GET LAST USER ", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET LAST USER ", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return user;
        }
        public User GetUser(string userName)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;
            string query = string.Format("SELECT userid,userName,passwd,dateCreated,lastModified,usertype FROM user WHERE userName='{0}'", userName);


            User user = new User();
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
               // new AuditLogService().AddAuditLog("GET USER BY USERNAME", 0, userName, query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.Password = dr.GetString(2);
                        user.DateCreated = dr.GetDateTime(3);
                        user.LastModify = dr.GetDateTime(4);
                        user.UserType = dr.GetString(5);
                        


                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("ERROR GET USER BY USERNAME", 0, userName, ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
              //  new AuditLogService().AddAuditLog("ERROR GET USER BY USERNAME", 0, userName, ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return user;
        }
        public string GetUserName(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr =null;



            string seletQuery = string.Format("SELECT userName FROM user WHERE userId='{0}'", userId);

            string userName = "";

            try
            {
                con.Open();
                cmd = new MySqlCommand(seletQuery, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        userName = dr.GetString(0);


                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET USER NAME", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET USER NAME", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return userName;
        }
        public Boolean UserNameExists(string userName)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;
            Boolean returnVal = false;


            string seletQuery = string.Format("SELECT userName FROM user WHERE userName='{0}'", userName);

            try
            {
                con.Open();
                cmd = new MySqlCommand(seletQuery, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    returnVal = true;
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GET USER NAME", logUserId, new UserService().GetUserName(logUserId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("ERROR GET USER NAME", logUserId, new UserService().GetUserName(logUserId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return returnVal;
        }
        public Boolean ValidateLogin(User user)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null;
            Boolean returnVal = false;

            ServiceObjectSecurity sos = new ServiceObjectSecurity();
            string pass = sos.EncodePasswordMD5(user.Password);


            string seletQuery = string.Format("SELECT userName FROM user WHERE userName='{0}' AND passwd='{1}' AND active = 1", user.UserName, pass);

            try
            {
                con.Open();
                cmd = new MySqlCommand(seletQuery, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    returnVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("LOGIN ATTEMPT", "0", user.UserName, ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("LOGIN ATTEMPT", "0", user.UserName, ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return returnVal;
        }
        public bool DeleteUser(string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string query = string.Format("UPDATE user SET active = 0 WHERE userId='{0}'", userId);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                new AuditLogService().AddAuditLog("DELETE USER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR DELETE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR DELETE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }
        public bool UpdateUser(User user, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            ServiceObjectSecurity sos = new ServiceObjectSecurity();

            string pass = sos.EncodePasswordMD5(user.Password);

            string query = string.Format("UPDATE user SET  userName='{1}',passwd='{2}',lastModified='{3}'" +
                 "WHERE (userId='{0}')",
                 user.UserId, user.UserName, pass, user.LastModify.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                new AuditLogService().AddAuditLog("UPDATE  USER", userId, new UserService().GetUserName(userId), "User credentials were updated", DateTime.Now);
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }
        public bool ActivateUser(int active, string staffuserid, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            ServiceObjectSecurity sos = new ServiceObjectSecurity();

            //string pass = sos.EncodePasswordMD5(user.Password);

            string query = string.Format("UPDATE user SET  active= '{1}' WHERE (userId='{0}')", staffuserid, active);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                new AuditLogService().AddAuditLog("ACTIVATED  USER ACCOUNT", userId, new UserService().GetUserName(userId), "User credentials were activated", DateTime.Now);
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }
        public bool DeactivateUser(string userid, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            ServiceObjectSecurity sos = new ServiceObjectSecurity();

            //string pass = sos.EncodePasswordMD5(user.Password);

            string query = string.Format("UPDATE user SET  active= 0 WHERE (userId='{0}')", userId);

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                new AuditLogService().AddAuditLog("DEACTIVATED  USER ACCOUNT", userId, new UserService().GetUserName(userId), "User credentials were deactivated", DateTime.Now);
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }
        public bool ChangePassword(User user, string userId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            ServiceObjectSecurity sos = new ServiceObjectSecurity();

            string pass = sos.EncodePasswordMD5(user.Password);

            string query = string.Format("UPDATE user SET passwd='{1}',lastModified='{2}' " +
                  " WHERE (userId='{0}')",
                 user.UserId, pass, user.LastModify.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                new AuditLogService().AddAuditLog("CHANGE PASSWORD", userId, new UserService().GetUserName(userId), " Changed user password", DateTime.Now);
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR UPDATE USER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return retVal;
        }

        public List<User> GetAdminUsers(string userType1, string userType2, string userType3, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT `user`.userId,`user`.userName,`user`.dateCreated,`user`.lastModified,`user`.usertype,`user`.active,tutors.fname,tutors.onames,tutors.sname FROM `user` INNER JOIN tutors ON `user`.userId = tutors.userId WHERE usertype =@usertype1 OR usertype =@usertype2 OR usertype =@usertype3  ORDER BY  tutors.sname ASC ";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usertype1", userType1);
                cmd.Parameters.AddWithValue("@usertype2", userType2);
                cmd.Parameters.AddWithValue("@usertype3", userType3);
                // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.DateCreated = dr.GetDateTime(2);
                        user.LastModify = dr.GetDateTime(3);
                        user.UserType = dr.GetString(4);
                        user.Active = dr.GetInt32(5);
                        if (user.Active == 1) { user.xActive = "Activated"; } else { user.xActive = "Deactivated"; }
                        user.xFullName = dr.GetString(6) + " " + dr.GetString(8);

                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }
        public List<User> GetAdminUsers(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT `user`.userId,`user`.userName,`user`.dateCreated,`user`.lastModified,`user`.usertype,`user`.active,tutors.fname,tutors.onames,tutors.sname FROM `user` INNER JOIN tutors ON `user`.userId = tutors.userId WHERE usertype ='Administrator' OR usertype ='Administrator - Tutor' OR usertype ='Tutor'  ORDER BY  tutors.sname ASC ";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@usertype", userType);
                // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.DateCreated = dr.GetDateTime(2);
                        user.LastModify = dr.GetDateTime(3);
                        user.UserType = dr.GetString(4);
                        user.Active = dr.GetInt32(5);
                        if (user.Active == 1) { user.xActive = "Activated"; } else { user.xActive = "Deactivated"; }
                        user.xFullName = dr.GetString(6) + " " + dr.GetString(8);

                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }
        public List<User> GetTutorUsers(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT `user`.userId,`user`.userName,`user`.dateCreated,`user`.lastModified,`user`.usertype,`user`.active,tutors.fname,tutors.onames,tutors.sname FROM `user` INNER JOIN tutors ON `user`.userId = tutors.userId WHERE usertype ='Tutor' ORDER BY  `user`.active DESC ";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@usertype", userType);
                // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.DateCreated = dr.GetDateTime(2);
                        user.LastModify = dr.GetDateTime(3);
                        user.UserType = dr.GetString(4);
                        user.Active = dr.GetInt32(5);
                        if (user.Active == 1) { user.xActive = "Activated"; } else { user.xActive = "Deactivated"; }
                        user.xFullName = dr.GetString(6) + " " + dr.GetString(8);

                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }
        public List<User> GetStudentUsers(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT `user`.userId,`user`.userName,`user`.dateCreated,`user`.lastModified,`user`.usertype,`user`.active,students.fname,students.onames,students.sname FROM `user` INNER JOIN students ON `user`.userId = students.userId WHERE `user`.usertype = 'Student' ORDER BY  `user`.active DESC ";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@usertype", userType);
                // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.DateCreated = dr.GetDateTime(2);
                        user.LastModify = dr.GetDateTime(3);
                        user.UserType = dr.GetString(4);
                        user.Active = dr.GetInt32(5);
                        if (user.Active == 1) { user.xActive = "Activated"; } else { user.xActive = "Deactivated"; }
                        user.xFullName = dr.GetString(6) + " " + dr.GetString(8);

                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }
        public List<User> GetParentUsers(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);

            MySqlCommand cmd;
            MySqlDataReader dr = null; ;
            string query = "SELECT `user`.userId,`user`.userName,`user`.dateCreated,`user`.lastModified,`user`.usertype,`user`.active,studentrelatives.firstName,studentrelatives.otherName,studentrelatives.lastName FROM `user` INNER JOIN studentrelatives ON `user`.userId = studentrelatives.userId WHERE `user`.usertype = 'Parent' ORDER BY  `user`.active DESC";

            List<User> usersList = new List<User>();
            User user;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@usertype", userType);
                // new AuditLogService().AddAuditLog("GET ALL USERS", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user = new User();
                        user.UserId = dr.GetString(0);
                        user.UserName = dr.GetString(1);
                        user.DateCreated = dr.GetDateTime(2);
                        user.LastModify = dr.GetDateTime(3);
                        user.UserType = dr.GetString(4);
                        user.Active = dr.GetInt32(5);
                        if (user.Active == 1) { user.xActive = "Activated"; } else { user.xActive = "Deactivated"; }
                        user.xFullName = dr.GetString(6) + " " + dr.GetString(8);

                        usersList.Add(user);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR GET ALL USERS", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return usersList;

        }

        public List<User> FindUsers(string searchString, int startIndex, int endIndex, string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlCommand cmdStaff;
            MySqlDataReader dr = null;
            MySqlDataReader drStaff = null;

            string query = string.Format("SELECT `userId`,indexNo, CONCAT_WS(' ',fname, onames, sname) as fullname, CONCAT_WS(',',tel, email,mobile) as otherDetails from students WHERE indexNo LIKE ('{0}%') OR CONCAT_WS(' ',fname, onames, sname) LIKE ('%{0}%') order by indexNo LIMIT {1},{2} ", searchString, startIndex, endIndex - startIndex);
            string queryStaff = string.Format("SELECT `userId`,indexNo, CONCAT_WS(' ',fname, onames, sname) as fullname, CONCAT_WS(',',tel, email,mobile) as otherDetails,stafftype from tutors WHERE indexNo LIKE ('{0}%') OR CONCAT_WS(' ',fname, onames, sname) LIKE ('%{0}%') order by indexNo LIMIT {1},{2} ", searchString, startIndex, endIndex - startIndex);

            User member;
            List<User> memList = new List<User>();
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
                        member = new User();

                        member.UserId = dr.GetString(0);
                        member.xIndexNo = dr.GetString(1);
                        member.xFullName = dr.GetString(2);
                        member.xContactInfo = dr.GetString(3);
                        member.UserType = "Student";
                        memList.Add(member);

                    }
                }

                cmdStaff = new MySqlCommand(queryStaff, con);

                drStaff = cmdStaff.ExecuteReader();
                //new AuditLogService().AddAuditLog("FINDING  MEMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);

                if (drStaff.HasRows) //if the executed query returns any records
                {
                    while (drStaff.Read()) //iterate through the records in the result dataset
                    {
                        member = new User();

                        member.UserId = dr.GetString(0);
                        member.xIndexNo = dr.GetString(1);
                        member.xFullName = dr.GetString(2);
                        member.xContactInfo = dr.GetString(3);
                        member.UserType = dr.GetString(4);
                        memList.Add(member);

                    }
                }


            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("ERROR FINDING MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("ERROR FINDING MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);

                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }

            return memList;
        }
        public User GetFindUser(string userType, string studUserId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            string query = "";

            if( userType == "Student")
            {
             query = "SELECT `userId`,indexNo, CONCAT_WS(' ',fname, onames, sname) as fullname, CONCAT_WS(',',tel, email,mobile) as otherDetails from students WHERE `userId`= @userId ";
            }
            else
            {
                query = "SELECT `userId`,indexNo, CONCAT_WS(' ',fname, onames, sname) as fullname, CONCAT_WS(',',tel, email,mobile) as otherDetails from tutors WHERE `userId`= @userId ";
            }
            User member = new User();
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
                        member = new User();
                        member.UserId = dr.GetString(0);
                        member.xIndexNo = dr.GetString(1);
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
        
    }
}