using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class LookUp
    {
        public string LKey { get; set; }
        public string LValue { get; set; }
    }
    public class LookUpService
    {

        public List<LookUp> GetAllContractStatus()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT contractstatus.id,contractstatus.`status` FROM contractstatus ";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAllIDTypes()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT id,type FROM idtype WHERE active = 1";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
           

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(0);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAllPayperiod()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `lKey`, `lValue` FROM `payperiod`";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
                       
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(0);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAllPaymetype()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `lKey`, `lValue` FROM `paymenttype`";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(0);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                //String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
             
        public List<LookUp> GetAllLessonTypes()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT id,type FROM lessontype ORDER BY type ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAllGroupRole()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM grouprole ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetInt32(0).ToString();
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Group Role", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Group Role", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetJobPositions()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM jobposition ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetInt32(0).ToString();
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Job Position", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Job Position", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetPrivillages()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `id`, `action` FROM `userfunction`";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Job Position", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Job Position", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetCountryList()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey, lValue FROM country ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            //lo.LKey = "";
            //lo.LValue = "Choose...";
            //lList.Add(lo);
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Country", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Country", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetCurrencyList()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey, lValue FROM currency ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
           
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Currency", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Currency", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAllBanks()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT `lKey`, `lValue` FROM bank ORDER BY lValue";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);


                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Banks", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Banks", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetMaritalStatus()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM maritalstatus";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetInt32(0).ToString();
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Marital Status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error Marital Status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetGender()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM gender ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetInt32(0).ToString();
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Gender", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Gender", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetReligion()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM religion ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetInt32(0).ToString();
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error Gender", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error Gender", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetRegions()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM region ORDER BY lkey ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            


            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetInt32(0).ToString();
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Regions", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error Regions", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
       
        public List<LookUp> GetEmploymentStatus()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT lkey,lvalue FROM employStatus ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
           

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetRelativeTypes()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT lkey,lvalue FROM relativeType ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
           

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAcademicTerms()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT id,term FROM academicterms ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
            
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAgeGroups()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT lkey,lvalue FROM agegroup ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
              //  new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetAcademicLevels()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT lkey,lvalue FROM academiclevel ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
               // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetTimePeriods()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT id,period FROM timeperiods ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
            

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetTimeDays()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT id,tday FROM timedays ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
           
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetThemes()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT id,theme FROM themes ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = "~/images/themes/" + dr.GetString(1) + ".png";
                        lo.LValue = dr.GetString(1);
                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetUserTypesAdminTutors()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT usertypes.id, usertypes.type FROM usertypes WHERE usertypes.id = 1 OR usertypes.id = 2 OR usertypes.id = 5 ORDER BY usertypes.type ASC ");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
          
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetUserTypes()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT usertypes.id, usertypes.type FROM usertypes");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
           

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(1);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }
        public List<LookUp> GetGradingSystems()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = string.Format("SELECT gsid,gstype FROM gradesystem");

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;

            lo = new LookUp();
           
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error employment status", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }

        public List<LookUp> GetAllTitles()
        {
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            MySqlCommand cmd;
            MySqlDataReader dr = null;

            string query = "SELECT lKey,lValue FROM title ORDER BY lValue ASC";

            List<LookUp> lList = new List<LookUp>();
            LookUp lo;
            lo = new LookUp();
           

            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lo = new LookUp();
                        lo.LKey = dr.GetString(0);
                        lo.LValue = dr.GetString(1);

                        lList.Add(lo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            catch (Exception ex)
            {
                // new AuditLogService().AddAuditLog("Lookup Error Title", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
                String errorString = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return lList;
        }

    }

}
