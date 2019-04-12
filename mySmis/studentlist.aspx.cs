using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.XtraPrinting;
using DevExpress.Web;
using DevExpress.Export;

namespace mySmis
{
    public partial class studentlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadUserPermissions();
        }

        private void LoadStudents()
        {
            gvStudents.DataSource = new StudentService().GetAllStudent(new SessionManager().GetUserId(this.Session));
            gvStudents.DataBind();
        }

       

        protected void gvStudents_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

        }

        protected void gvStudents_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                gvStudents.CancelEdit();
                Session["fromwhere"] = "~/studentlist.aspx";
                Session["report"] = new mySmis.reports.rptStudentProfile(e.EditingKeyValue.ToString());

                Response.Redirect("~/documentviewer.aspx");
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Oops something is not right!','Message')", true);
            }
        }

        protected void gvStudents_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/studentnew.aspx?action=edit&stdid=" + gvStudents.GetRowValues(gvStudents.FocusedRowIndex, "IndexNo") + "&userid=" + gvStudents.GetRowValues(gvStudents.FocusedRowIndex,"UserId"));
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Oops something is not right!','Message')", true);
            }
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "EXPORT":
                        mMain.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                        mMain.Items.FindByName("mitReport").Enabled = true;
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
                case "mitReport":
                    Session["fromwhere"] = "~/teachingstafflist.aspx";
                    Session["report"] = new mySmis.reports.rptProgramsLevels();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
        }

        protected void gvStudents_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Select:
                    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
            }
        }
    }
}