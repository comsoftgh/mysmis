using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;

namespace mySmis
{
    public partial class academicattendance : System.Web.UI.Page
    {
        string studAttendance = new InstanceConfigServices().GetConfig("studentAttendance");
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
            loadPrograms();
            if (IsPostBack)
            {
                //dtPayDate.Date = DateTime.Now;
            }
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassSchedulerRegistration(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 500;

            uPanel.Update();
        }
        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
              if (studAttendance == "Per Subject/Course")
                 {
                    cmbLessons.Visible = true;
                    cmbLessons.Enabled = false;
                    divCourse.Visible = true;
                 }
            }
            else
            {
                clearfields();
               
            }
            uPanel.Update();
        }

        private void loadBatchLesson()
        {
            cmbLessons.DataSource = new LessonService().GetAllLessonsByClassID(int.Parse(cmbProgram.Value.ToString()), new SessionManager().GetUserId(this.Session));
            cmbLessons.DataBind();
        }

        private void clearfields()
        {
            cmbLessons.Visible = false;
            cmbLessons.Enabled = false;
            divCourse.Visible = false;

            gvStudents.DataSource = null;
            gvStudents.DataBind();
        }

        private void loadRegStudentsDaily()
        {
            if (cmbProgram.Value != null)
            {

                if (new StudentLessonAttendanceService().GetAllStudentLessonIDAttendance(int.Parse(cmbProgram.Value.ToString()), dtPayDate.Date, new SessionManager().GetUserId(this.Session)).Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Attendance for this Academic Batch has already been taken for this date.','Message')", true);
                }

                else
                {
                    gvStudents.DataSource = new StudentRegistrationService().GetStudentRegistrationByBatchId(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session)); ;//new StudentService().GetAllUnRegStudent(regList, new SessionManager().GetUserId(Session));
                    gvStudents.DataBind();
                }
            }
        }

        private void loadRegStudentsLesson()
        {
            gvStudents.DataSource = new StudentLessonsRegistrationService().GetAllStudentLessonsRegistration(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), int.Parse(cmbLessons.Value.ToString()), new SessionManager().GetUserId(Session));
            gvStudents.DataBind();

            uPanel.Update();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string studAttend = "";
            List<object> studUserIds = new List<object>();
            List<string> uncheckstudUserIds = new List<string>();
            int lessonId = 0;
            if (studAttendance == "Daily Attendance")
                {
                    if (new StudentLessonAttendanceService().ExistStudentDatchAttendance(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), dtPayDate.Date, new SessionManager().GetUserId(this.Session)) == true)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Attendance is already recorded','Message')", true);
                        return;
                    }

                    lessonId = 0;
                }
            else if (studAttendance == "Per Subject/Course")
             {
                 lessonId = int.Parse(cmbLessons.Value.ToString());
                 if (new StudentLessonAttendanceService().ExistStudentLessonAttendance(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), lessonId, dtPayDate.Date, new SessionManager().GetUserId(this.Session)) == true)
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Attendance is already recorded','Message')", true);
                     return;
                 }
                 
             }

            studUserIds = gvStudents.GetSelectedFieldValues("StuduserId");
             uncheckstudUserIds = new StudentRegistrationService().GetStudentRegistrationByBatchIdBGroupNotInList(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(), string.Join(",", studUserIds.ToArray()),new SessionManager().GetUserId(this.Session));
            if (studUserIds.Count > 0)
            {
                if (cmbProgram.Value != null)
                {
                    //studuserid`, `batchid`, `bgroup`,lessonid, `present`, `createdate`, `modifydate`
                        foreach (object studUserId in studUserIds)
                        {
                            studAttend += "('" + studUserId.ToString() + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString() + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + lessonId + "','" + 1 + "','" + dtPayDate.Date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                            
                        }

                        foreach (string uncheckstudUserId in uncheckstudUserIds)
                        {
                            studAttend += "('" + uncheckstudUserId + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString() + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + lessonId + "','" + 0 + "','"+dtPayDate.Date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";

                        }

                    if(new StudentLessonAttendanceService().AddStudentLessonAttendanceList(studAttend,new SessionManager().GetUserId(this.Session)))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                    }

                }
                else
                {
                    cmbProgram.IsValid = false;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Select at least a student','Message')", true);
            }
            clearfields();
            uPanel.Update();
        }

        protected void cmbLessons_ValueChanged(object sender, EventArgs e)
        {
            if (cmbLessons.Value != null)
            {
                loadRegStudentsLesson();
            }
            else
            {

                clearfields();
            }
            uPanel.Update();
        }

        protected void gvStudents_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smStudentAttend"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void dtPayDate_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null && dtPayDate.Date != null)
            {
                
                switch(studAttendance)
                {
                    case "Daily Attendance" :
                        loadRegStudentsDaily();
                        break;
                    case "Per Subject/Course" :
                        cmbLessons.Enabled = true;
                        divCourse.Visible = true;
                        string lessons = new StudentLessonAttendanceService().GetAllStudentLessonIDAttendance(int.Parse(cmbProgram.Value.ToString()), dtPayDate.Date, new SessionManager().GetUserId(this.Session));
                        cmbLessons.DataSource = new LessonService().GetAllLessonsNotInList(lessons, int.Parse(cmbProgram.Value.ToString()), new SessionManager().GetUserId(this.Session));
                        cmbLessons.DataBind();
                        break;

                }
                
            }

            uPanel.Update();

        }

    }
}