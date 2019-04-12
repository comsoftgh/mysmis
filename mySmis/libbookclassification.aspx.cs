using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;

namespace mySmis
{
    public partial class libbookclassification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dgLibClassification.DataSource = new LibraryClassificationService().GetAllLibraryClassification(new SessionManager().GetUserId(this.Session));
            dgLibClassification.DataBind();
        }

        protected void mMenu_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/abcprogram.aspx";
                    Session["report"] = new mySmis.reports.rptSchsDpts();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }


            uPanel.Update();
        }
    }
}