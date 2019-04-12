using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class InstanceConfig
    {
        public string LKey { get; set; }
        public string LValue { get; set; }

        public InstanceConfig() { }
        public InstanceConfig( string lKey,string lValue) 
        {
            this.LKey = lKey;
            this.LValue = lValue;
        }
    }

    public class InstanceConfigServices
    {

        public bool AddConfig(string LKey , string LValue,String userId)
        {

            Boolean retVal = false;


            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd = null;
            MySqlDataReader read = null;

            try
            {

                con.Open();
                string query = "UPDATE instconfig SET lValue = @lValue WHERE lKey = @lKey ";
                cmd = new MySqlCommand(query, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@lKey", LKey);
                cmd.Parameters.AddWithValue("@lValue",LValue);
                int afecRow = cmd.ExecuteNonQuery();
                new AuditLogService().AddAuditLog("ADDING SYSTEM CONFIGURATON", userId, new UserService().GetUserName(userId), query, DateTime.Now);
                if (afecRow > 0)
                {
                    retVal = true;
                }
            }
            catch (MySqlException ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADDING SYSTEM CONFIGURATON", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            catch (Exception ex)
            {
                new AuditLogService().AddAuditLog("ERROR ADDING SYSTEM CONFIGURATON", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                string errorString = ex.Message;
            }
            finally
            {
                con.Close();
            }


            return retVal;
        }
        public String GetConfig(String lkey)
        {

            String config = "";


            MySqlConnection conn = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd = null;
            MySqlDataReader read = null;

            try
            {

                conn.Open();
                string sqlQuery = "SELECT lValue FROM instconfig WHERE lKey = @lKey ";
                cmd = new MySqlCommand(sqlQuery, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@lKey", lkey);
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    
                    config = read.GetString(0);
 
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {

                conn.Close();
                read.Close();
                read.Dispose();

            }


            return config;
        }
    }
}
