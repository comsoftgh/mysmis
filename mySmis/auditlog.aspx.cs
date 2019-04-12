using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MantraEntity;

namespace Mantra
{
    public partial class auditlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            new SessionManager().InitDBConnection();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            gvAuditLog.DataSource = new AuditLogService().GetAllAuditLog();
            gvAuditLog.DataBind();
        }
    }
}