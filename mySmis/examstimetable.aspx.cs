using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class examstimetable : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);

            loadPrograms();
            LoadUserPermissions();

            if(IsPostBack)
            {
                if (cmbProgram.Value != null)
                {
                    reloadLessonSchudel();
                }
            }
            else
            {
            
            }
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                reloadLessonSchudel();
                mMain.Items.FindByName("mitExportxls").Visible = true;
            }
            else
            {
                clearFields();
            }

            uPanel.Update();
        }

        private void clearFields()
        {

            //cmbProgram.DataSource = null;
            //cmbProgram.DataBind();
            mMain.Items.FindByName("mitExportxls").Visible = false;
            dgTimetable.DataSource = null;
            dgTimetable.DataBind();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            //cmbProgram.GridView.Width = 600;
        }

        private void reloadLessonSchudel()
        {

            dgTimetable.DataSource = new LessonTimetableService().GetAllLessonTimetableByClassSchedID(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), "examstimetable", new SessionManager().GetUserId(Session));
            dgTimetable.DataBind();
        }

        protected void mMain_ItemClick(object source, MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/lessontimetable.aspx";
                    Session["report"] = new mySmis.reports.rptCourseSubjectSchedule();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjTutorSchedule")).Split(';');
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

    }
}