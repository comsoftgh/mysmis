using DevExpress.XtraReports.UI;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class documentviewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["fromwhere"] != null)
            {
                mMain.Visible = true;
            }

            if (Session["report"] != null)
            {

                XtraReport report = Session["report"] as XtraReport;
               
                report.CreateDocument();
                //report.RequestParameters = true;
                docViewer.EnableViewState = false;
                docViewer.ReportTypeName = report.GetType().ToString();
                docViewer.Report = report;

                docViewer.Visible = true;
            }

            if (Session["document"] !=null)
            {
                docViewers.Src = Session["document"].ToString();
                docViewers.Visible = true;
            }

        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitBack")
            {

                Response.Redirect(Session["fromwhere"].ToString());

            }
        }
    }
}