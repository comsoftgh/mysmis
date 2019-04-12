using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //new SessionManager().IsSessionActive(this.Response, this.Session);
            new SessionManager().InitDBConnection();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            try
            {
                new AuditLogService().AddAuditLog("LOGOUT", Session["userid"].ToString(), Session["username"].ToString(), "Successfully Logged out", DateTime.Now);
            }
            catch (Exception)
            {
                
                
            }

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Session.Clear();
            Session.Abandon(); 
            Session.RemoveAll();
            Response.Redirect("~/");
        }
    }
}