using DevExpress.Web;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class academicsexams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            loadPrograms();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassSchedulerRegistration(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 400;
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                cmbLessons.DataSource = new StudentLessonsRegistrationService().GetDistinctLessons(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
                cmbLessons.ValueField = "LessonId";
                cmbLessons.TextField = "xLesson";
                cmbLessons.DataBind();
                cmbLessons.Enabled = true;
            }
            else
            {

                clearfields();
            }
            uPanel.Update();
        }

        private void clearfields()
        {
            gvStudents.DataSource = null;
            gvStudents.DataBind();

            cmbLessons.DataSource = null;
            cmbLessons.DataBind();

            cmbProgram.DataSource = null;
            cmbProgram.DataBind();
        }

        private void loadBatchstudents()
        {
            gvStudents.DataSource = new StudentLessonsRegistrationService().GetAllStudentLessonsRegistration(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), int.Parse(cmbLessons.Value.ToString()), new SessionManager().GetUserId(Session));
            gvStudents.DataBind();

            uPanel.Update();
        }

        protected void cmbLessons_ValueChanged(object sender, EventArgs e)
        {
            if (cmbLessons.Value != null)
            {
                loadBatchstudents();
            }
            else
            {

                clearfields();
            }
            uPanel.Update();
        }

        protected void gvStudents_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;
            StudentLessonsRegistration lg = new StudentLessonsRegistration();
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                lg.ID = int.Parse(e.UpdateValues[i].Keys[0].ToString());
                lg.ExamsMarks = decimal.Parse(e.UpdateValues[i].NewValues[3].ToString());
                lg.LastModified = DateTime.Now;
                new StudentLessonsRegistrationService().UpdateStudentLessonsRegistrationExams(lg,new SessionManager().GetUserId(this.Session));
            
            }

            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
            loadBatchstudents();
            uPanel.Update();
        }

        protected void gvStudents_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smClassLesson"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void gvStudents_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.Name == "examsMarks") { ASPxSpinEdit ts = (ASPxSpinEdit)e.Editor; ts.MaxValue = int.Parse(new InstanceConfigServices().GetConfig("examshigerscore")); }

        }
    }
}