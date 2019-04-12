using System;
using System.Web;
using System.Web.SessionState;
using DevExpress.Web;

namespace mySmisLib
{
    public class SessionManager
    {
        

        public Boolean IsSessionActive(HttpResponse httpResponse, HttpSessionState Session)
        {
            Boolean returnVal = true;

            if (Session["userid"] == null || Session["username"] == null)
            {
                httpResponse.Redirect("~/logout.aspx");
            }
            return returnVal;
        }

        public Boolean ValidateUser()
        {
            Boolean returnVal = true;

            return returnVal;
        }

        public Boolean ValidateUserRole(int userId, int roleId)
        {
            Boolean returnVal = true;

            return returnVal;
        }

        public void ClearAllSessions()
        {
        }

        public string GetUserId(HttpSessionState Session)
        {
            if (Session["userid"] != null)
                return Session["userid"].ToString();
            else
                return "0";
        }

        public string GetUserName(HttpSessionState Session)
        {
            string username  = "";
            if (Session["userid"] != null)
            {
                string userId = Session["userid"].ToString();
                username = new UserService().GetUserName(userId);
            }
            return username;
        }

        public void InitDBConnection()
        {
            //System.Configuration.Configuration rootWebConfig =
            //  System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/mySmis");
            //System.Configuration.ConnectionStringSettings connString;
            //if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            //{
            //String connString = System.Configuration.ConfigurationManager.ConnectionStrings["mySmisDB"].ConnectionString;
           // String connStringRemote = System.Configuration.ConfigurationManager.ConnectionStrings["remoteMISDB"].ConnectionString;
           // if (connString != null)
           // {
           //     mySmisLib.DbCon.connectionString = connString;
           //     mySmisLib.DbCon.connectionStringAllowUserVariables = connString + "Allow User Variables=True;";
           //     mySmisLib.DataConnect.connectionString = connString;                
            //}

           // if (connStringRemote != null)
           // {
               // mySmisLib.DataConnect.connectionStringRemote = connStringRemote;
           // }
            //}
        }
    }
}