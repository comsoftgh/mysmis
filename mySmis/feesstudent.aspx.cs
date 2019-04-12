using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace mySmis
{
    public partial class feesstudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            loadPrograms();
            LoadUserPermissions();
            if (IsPostBack)
            {
                if (cmbProgram.Value != null)
                {
                    loadBatchFees();
                }
            }
            else
            {

            }
        }

        private void loadBatchFees()
        {
            gvStudenFess.DataSource = new StudentFeesService().GetAllStudentFees(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ClassID").ToString()), new SessionManager().GetUserId(Session));
            gvStudenFess.DataBind();

            uPanel.Update();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 600;

            uPanel.Update();
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                loadBatchFees();
            }
            else
            {
                clearfields();
            }
            uPanel.Update();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smStudentFees")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "EXPORT":
                        mMain.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                        mMain.Items.FindByName("mitReportOne").Enabled = true;
                        mMain.Items.FindByName("mitReportAll").Enabled = true;
                        break;
                }

            }
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReportOne":
                    Session["fromwhere"] = "~/feesstudent.aspx";
                    Session["report"] = new mySmis.reports.rptProgramsLevels();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
                case "mitReportAll":
                    Session["fromwhere"] = "~/feesstudent.aspx";
                    Session["report"] = new mySmis.reports.rptProgramsLevels();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();

        }
        private void clearfields()
        {
            gvStudenFess.DataSource = null;
            gvStudenFess.DataBind();

            
        }

        protected void gvBatchFees_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smStudentFees"));

            switch (e.ButtonType)
            {
                
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
               
            }
        }

        protected void gvBatchFees_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            if (cmbProgram.Value != null)
            {
                gv.DataSource = new StudentFeesService().GetStudentFees(gv.GetMasterRowKeyValue().ToString(), int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ClassID").ToString()), new SessionManager().GetUserId(Session));
            }
        }

        protected void gvStudenFess_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            gvStudenFess.CancelEdit();
            

            if (cmbProgram.Value != null)
            {
                Session["fromwhere"] = "~/feesstudent.aspx";
                string cid = e.EditingKeyValue.ToString();//gvStudenFess.GetRowValues(gvStudenFess.FocusedRowIndex, "UserId").ToString();
                Session["report"] = new mySmis.reports.rptFeesSlip( cid, int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ClassID").ToString()));
                Response.Redirect("~/documentviewer.aspx");
            }

           
            e.Cancel = true;
        }

       

        
        
    }
}