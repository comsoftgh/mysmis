using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class tutortimetable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);

            loadPrograms();

            if (IsPostBack)
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

            dgTimetable.DataSource = null;
            dgTimetable.DataBind();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetTutorsBatchSchedules(Session["userid"].ToString(), new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 500;
        }

        private void reloadLessonSchudel()
        {

            dgTimetable.DataSource = new LessonTimetableService().GetTutorLessonTimetableByClassSchedID(Session["userid"].ToString(),"lessontimetable", int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            dgTimetable.DataBind();
        }
    }
}