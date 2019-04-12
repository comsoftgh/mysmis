using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using mySmis.Code;
using mySmisLib;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.Web;

namespace mySmis
{
    public partial class lessoninstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
            loadPrograms();
            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjTutorSchedule")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                        mMain.Items.FindByName("mitNew").Enabled = true;
                        mMain.Items.FindByName("mitCancel").Enabled = true;
                        break;
                    case "EXPORT":
                        mMain.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                        mMain.Items.FindByName("mitReport").Enabled = true;
                        break;
                }

            }
        }
        private void loadPrograms()
        {
        
            
            cmbLessons.DataSource = new LessonService().GetAllLessonClassModule(new SessionManager().GetUserId(Session));
            cmbLessons.DataBind();
            cmbLessons.GridView.Width = 400;

            dgLessonsTutors.DataSource = new LessonInstructorServices().GetAllLessonInstructors(new SessionManager().GetUserId(Session));
            dgLessonsTutors.DataBind();

            
        }      

        private void clearfields()
        {
            txtId.Text = "0";
            cmbLessons.Text = "";
            gvLessonInstructors.DataSource = null;
            gvLessonInstructors.DataBind();
            gvAllInstructors.DataSource = null;
            gvAllInstructors.DataBind();
           

        }


        private void loadLessonInstructors()
        {
            gvLessonInstructors.DataSource = new LessonInstructorServices().GetAllLessonInstructorsByLessonID(int.Parse(cmbLessons.GridView.GetRowValues(cmbLessons.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            gvLessonInstructors.DataBind();
        }

        private void loadTutors()
        {
            gvAllInstructors.DataSource = new TutorService().GetAllTutorByStaffTypeNotINLessons("Tutor", "Administrator & Tutor", int.Parse(cmbLessons.GridView.GetRowValues(cmbLessons.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            gvAllInstructors.DataBind();

        }

        protected void gvAllInstructors_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            gvAllInstructors.CancelEdit();

            if (new LessonInstructorServices().IsLessonInstructorExit(int.Parse(cmbLessons.GridView.GetRowValues(cmbLessons.GridView.FocusedRowIndex, "ID").ToString()), e.EditingKeyValue.ToString()) == true)
            {
            }
            else
            {
                LessonInstructors lessonInst = new LessonInstructors();
                lessonInst.LessonID = int.Parse(cmbLessons.GridView.GetRowValues(cmbLessons.GridView.FocusedRowIndex, "ID").ToString());
                lessonInst.TutorID = e.EditingKeyValue.ToString();
                lessonInst.DateAssigned = DateTime.Now;
                lessonInst.LastModified = DateTime.Now;

                if (new LessonInstructorServices().AddLessonInstructor(lessonInst, new SessionManager().GetUserId(Session)) == true)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saving Failed','Message')", true);
                }
            }
            loadLessonInstructors();
            loadPrograms();
            uPanel.Update();
        }

        protected void gvLessonInstructors_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            //var v = int.Parse(gvLessonInstructors.GetRowValues(gvLessonInstructors.FocusedRowIndex, "ID").ToString());
            if (new LessonInstructorServices().DeleteLessonInstructor(int.Parse(gvLessonInstructors.GetRowValues(gvLessonInstructors.FocusedRowIndex,"ID").ToString()), new SessionManager().GetUserId(Session)) == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }

            loadLessonInstructors();
            loadPrograms();
            uPanel.Update();
        }

        protected void dgLessonsTutors_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgLessonsTutors.CancelEdit();
            clearfields();

            cmbLessons.Value = dgLessonsTutors.GetRowValues(dgLessonsTutors.FocusedRowIndex, "LessonID");
            gvLessonInstructors.DataSource = new LessonInstructorServices().GetAllLessonInstructorsByLessonID(int.Parse(dgLessonsTutors.GetRowValues(dgLessonsTutors.FocusedRowIndex, "LessonID").ToString()), new SessionManager().GetUserId(Session));
            gvLessonInstructors.DataBind();

            divLessons.Visible = true;
            uPanel.Update();
        }

        protected void cmbLessons_ValueChanged(object sender, EventArgs e)
        {
            if (cmbLessons.Value != null)
            {
            loadLessonInstructors();
            loadTutors();
            }
            uPanel.Update();
        }

        protected void dgLessonsTutors_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(dgLessonsTutors.GetRowValues(dgLessonsTutors.FocusedRowIndex, "ID").ToString());

            if (new LessonInstructorServices().DeleteLessonInstructor(id, new SessionManager().GetUserId(Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }

            loadPrograms();
            uPanel.Update();
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearfields();
                    divLessons.Visible = true;
                    break;
                    case "mitCancel":
                    clearfields();
                    divLessons.Visible = false;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/lessoninstructor.aspx";
                    Session["report"] = new mySmis.reports.rptCourseSubjectTutor();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
           
            
        }

        protected void dgLessonsTutors_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjTutorSchedule"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                //case ColumnCommandButtonType.Select:
                //    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                //    break;
            }
        }

        protected void gvLessonInstructors_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjTutorSchedule"));

            switch (e.ButtonType)
            {
                //case ColumnCommandButtonType.Edit:
                //    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                //    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                //case ColumnCommandButtonType.Select:
                //    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                //    break;
            }
        }

        protected void gvAllInstructors_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjTutorSchedule"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                //case ColumnCommandButtonType.Delete:
                //    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                //    break;
                //case ColumnCommandButtonType.Select:
                //    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                //    break;
            }
        }
      
    }
}