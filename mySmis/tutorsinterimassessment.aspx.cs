using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class tutorsinterimassessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPrograms();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetTutorsBatchSchedules(Session["userid"].ToString(), new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 500;
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                loadBatchstudents();
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


            cmbProgram.DataSource = null;
            cmbProgram.DataBind();
        }

        private void loadBatchstudents()
        {
            gvStudents.DataSource = new StudentLessonsRegistrationService().GetAllStudentLessonsRegistration(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "xLessonId").ToString()), new SessionManager().GetUserId(Session));
            gvStudents.DataBind();

            uPanel.Update();
        }

        

        protected void gvStudents_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;
            StudentLessonsRegistration lg = new StudentLessonsRegistration();
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                lg.ID = int.Parse(e.UpdateValues[i].Keys[0].ToString());
                lg.TestMarks = decimal.Parse(e.UpdateValues[i].NewValues[3].ToString());
                lg.LastModified = DateTime.Now;
                new StudentLessonsRegistrationService().UpdateStudentLessonsRegistrationIA(lg, new SessionManager().GetUserId(this.Session));

            }

            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
            loadBatchstudents();
            uPanel.Update();
        }
    }
}