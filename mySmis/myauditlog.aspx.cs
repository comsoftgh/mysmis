using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class myauditlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            new SessionManager().InitDBConnection();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            gvAuditLog.DataSource = new AuditLogService().GetAllAuditLogByUserID(new SessionManager().GetUserId(this.Session));
            gvAuditLog.DataBind();
        }
    }
}