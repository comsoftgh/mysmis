using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditLog
    {
        public int LogId { get; set; }
        public string LogEvent { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Details { get; set; }
        public DateTime LogTime { get; set; }
        public string FName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AuditLogService
    {

        public bool AddAuditLog(string logEvent, string userid, string username, string details, DateTime logtime)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;



            string insertQuery = string.Format("INSERT INTO auditLog(logEvent,userId,userName,details,logTime)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}')",
                 logEvent, userid, username, details.Replace("'","''"), logtime.ToString("yyyy-MM-dd HH:mm:ss"));



            try
            {
                con.Open();//opens connection to database

                cmd = new MySqlCommand(insertQuery, con);//insert data if connection is open
                int rowsAffec = cmd.ExecuteNonQuery();
                if (rowsAffec > 0)
                {
                    return retVal;
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }


            return retVal;
        }



        /// <summary>
        /// This add Details of any loging to the database
        /// </summary>
        /// <param name="log">AuditLog object</param>
        /// <returns>True if it is added Successfully </returns>
        public bool AddAuditLog(AuditLog log)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;


           
            string insertQuery = string.Format("INSERT INTO auditLog(logEvent,userId,userName,details,logTime)"+
                "VALUES('{0}','{1}','{2}','{3}','{4}')",
                 log.LogEvent, log.UserId, log.UserName, log.Details, log.LogTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    


            try
            {
                con.Open();//opens connection to database

                cmd = new MySqlCommand(insertQuery, con);//insert data if connection is open
                int rowsAffec = cmd.ExecuteNonQuery();
                if (rowsAffec > 0)
                {
                    return retVal;
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

           
            return retVal;
        }

        /// <summary>
        /// Gets all the loging details in the database
        /// </summary>
        /// <returns>A list of all the loging details</returns>
        public List<AuditLog> GetAuditLog()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string selectQuery = "SELECT * FROM auditLog";
            AuditLog aLog;

            List<AuditLog> aLogList = new List<AuditLog>();
            try
            {
                con.Open();
                cmd = new MySqlCommand(selectQuery, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aLog = new AuditLog();
                        aLog.LogId = dr.GetInt32(0);
                        aLog.LogEvent = dr.GetString(1);
                        aLog.UserId = dr.GetString(2);
                        aLog.UserName = dr.GetString(3);
                        aLog.Details = dr.GetString(4);
                        aLog.LogTime = dr.GetDateTime(5);

                        aLogList.Add(aLog);

                    }
                }
            }
            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return aLogList;
            
        }

        public List<AuditLog> GetAllAuditLog()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string selectQuery = "SELECT auditlog.logId,auditlog.logEvent,auditlog.userId,auditlog.userName,auditlog.details,auditlog.logTime,IFNULL(CONCAT(tutors.fname,' ',tutors.sname,' ',tutors.onames),'System') AS fName FROM auditlog LEFT OUTER JOIN tutors ON auditlog.userId = tutors.userid ORDER BY auditlog.logTime DESC ";
            AuditLog aLog;

            List<AuditLog> aLogList = new List<AuditLog>();
            try
            {
                con.Open();
                cmd = new MySqlCommand(selectQuery, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aLog = new AuditLog();
                        aLog.LogId = dr.GetInt32(0);
                        aLog.LogEvent = dr.GetString(1);
                        aLog.UserId = dr.GetString(2);
                        aLog.UserName = dr.GetString(3);
                        aLog.Details = dr.GetString(4);
                        aLog.LogTime = dr.GetDateTime(5);
                        aLog.FName = dr.GetString(6);

                        aLogList.Add(aLog);

                    }
                }
            }
            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return aLogList;

        }

        public List<AuditLog> GetAllAuditLogByUserID(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string selectQuery = "SELECT auditlog.logId,auditlog.logEvent,auditlog.userId,auditlog.userName,auditlog.details,auditlog.logTime,IFNULL(CONCAT(tutors.fname,' ',tutors.sname,' ',tutors.onames),'System') AS fName FROM auditlog LEFT OUTER JOIN tutors ON auditlog.userId = tutors.userid WHERE auditlog.userId = @userId ORDER BY auditlog.logTime DESC LIMIT 100";
            AuditLog aLog;

            List<AuditLog> aLogList = new List<AuditLog>();
            try
            {
                con.Open();
                cmd = new MySqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aLog = new AuditLog();
                        aLog.LogId = dr.GetInt32(0);
                        aLog.LogEvent = dr.GetString(1);
                        aLog.UserId = dr.GetString(2);
                        aLog.UserName = dr.GetString(3);
                        aLog.Details = dr.GetString(4);
                        aLog.LogTime = dr.GetDateTime(5);
                        aLog.FName = dr.GetString(6);

                        aLogList.Add(aLog);

                    }
                }
            }
            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return aLogList;

        }
        /// <summary>
        /// Get a particular user's loging details 
        /// </summary>
        /// <param name="userId">the user's Id</param>
        /// <returns>A list of all the details of a user's loging transactions</returns>
        public List<AuditLog> GetAuditLogByUser(string userId)
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

           AuditLog aLog;
            List<AuditLog> logList = new List<AuditLog>();

            string selectQuery = string.Format("SELECT * FROM auditLog WHERE userId='{0}'", userId);

            try
            {
                con.Open();
                cmd = new MySqlCommand(selectQuery, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aLog = new AuditLog();
                        aLog.LogId = dr.GetInt32(0);
                        aLog.LogEvent = dr.GetString(1);
                        aLog.UserId = dr.GetString(2);
                        aLog.UserName = dr.GetString(3);
                        aLog.Details = dr.GetString(4);
                        aLog.LogTime = dr.GetDateTime(5);

                        logList.Add(aLog);
                    }
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }


            return logList;
        }


        /// <summary>
        /// Gets all the loging details in the database between a particular date and time
        /// </summary>
        /// <param name="from">Beginning  date and time</param>
        /// <param name="to">Ending date and time</param>
        /// <returns>A List of all the loging transaction between a certain period of time</returns>
        public List<AuditLog> GetAuditLogBetween(DateTime from, DateTime to)
        {

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            AuditLog aLog;
            List<AuditLog> logList = new List<AuditLog>();

            string selectQuery = string.Format("SELECT * FROM auditLog WHERE logTime BETWEEN '{0}' AND '{1}'", from,to);

            try
            {
                con.Open();
                cmd = new MySqlCommand(selectQuery, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aLog = new AuditLog();
                        aLog.LogId = dr.GetInt32(0);
                        aLog.LogEvent = dr.GetString(1);
                        aLog.UserId = dr.GetString(2);
                        aLog.UserName = dr.GetString(3);
                        aLog.Details = dr.GetString(4);
                        aLog.LogTime = dr.GetDateTime(5);

                        logList.Add(aLog);
                    }
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return logList;

        }

        public List<AuditLog> GetAuditLogBetween(string userId, DateTime from, DateTime to)
        {

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            AuditLog aLog;
            List<AuditLog> logList = new List<AuditLog>();

            string selectQuery = string.Format("SELECT * FROM auditLog WHERE userId='{0}' AND logTime BETWEEN '{1}' AND '{2}'", userId, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                con.Open();
                cmd = new MySqlCommand(selectQuery, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aLog = new AuditLog();
                        aLog.LogId = dr.GetInt32(0);
                        aLog.LogEvent = dr.GetString(1);
                        aLog.UserId = dr.GetString(2);
                        aLog.UserName = dr.GetString(3);
                        aLog.Details = dr.GetString(4);
                        aLog.LogTime = dr.GetDateTime(5);

                        logList.Add(aLog);
                    }
                }
            }

            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return logList;

        }

        /// <summary>
        /// Deletes a loging details from the database by the loging Id
        /// </summary>
        /// <param name="logId"> The Id of a particular Loging</param>
        /// <returns>True if the deletion was successful and False if it wasn't successful </returns>
        public bool DeleteAuditLog(int logId)
        {
            Boolean retVal = false;

            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;


            string deleteQuery = string.Format("DELETE FROM auditLog WHERE logId='{0}'", logId);

            try
            {
                con.Open();
                cmd = new MySqlCommand(deleteQuery,con);

                int affecRows = cmd.ExecuteNonQuery();
                if (affecRows > 0)
                {
                    retVal = true;
                }

            }


            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return retVal;

        }

        /// <summary>
        /// Updates the loging details of a particular loging Id
        /// </summary>
        /// <param name="log">Log Id</param>
        /// <returns>True if the Update was successful and False if it wasn't successful</returns>
        public bool UpdateAuditLog(AuditLog log)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;

            string updateQuery = string.Format("UPDATE auditLog SET  logEvent='{1}',userId='{2}',userName='{3}',details='{4}',logTime='{5}'" +
                "WHERE (userId='{0}')",
                log.UserId, log.LogEvent, log.UserId, log.UserName, log.Details, log.LogTime.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                con.Open();
                cmd = new MySqlCommand(updateQuery, con);
                int affecRow = cmd.ExecuteNonQuery();
                if (affecRow > 0)
                {
                    retVal = true;
                }
            }


            catch (MySqlException ex) //first catch a specific exception
            {
                String errorString = ex.Message;
            }
            catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
            {
                String errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }




            return retVal;
        }

        
    }
}
