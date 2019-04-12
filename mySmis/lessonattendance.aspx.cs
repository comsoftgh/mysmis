using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
//using mySmis.Code;
using DevExpress.Web;

namespace mySmis
{
    public partial class lessonattendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
            new SessionManager().InitDBConnection();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            cmbClassSchudle.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(this.Session));
            cmbClassSchudle.DataBind();
        }


        private void loadAttedScheduls()
        {

            if (cmbSearchStud.Value == null && cmbClassSchudle.Value != null)
            {
                gvAttendance.DataSource = new AttendanceServices().GetAllAttendanceByClassSchedul(int.Parse(cmbClassSchudle.Value.ToString()), new SessionManager().GetUserId(this.Session));
                gvAttendance.DataBind();
            }
            else if (cmbClassSchudle.Value == null && cmbSearchStud.Value != null)
            {
                gvAttendance.DataSource = new AttendanceServices().GetAllAttendanceByStudID(int.Parse(cmbSearchStud.Value.ToString()), new SessionManager().GetUserId(this.Session));
                gvAttendance.DataBind();
            }
            else if (cmbClassSchudle.Value != null && cmbSearchStud.Value != null)
            {
                gvAttendance.DataSource = new AttendanceServices().GetAllAttendanceByClassSchedulByStudID(int.Parse(cmbClassSchudle.Value.ToString()), int.Parse(cmbSearchStud.Value.ToString()), new SessionManager().GetUserId(this.Session));
                gvAttendance.DataBind();
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('You Must Select An Option','Message')", true);
                
            }

            
        }

        protected void gvAttendance_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            
        }

        protected void gvAttendance_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
           
        }

        protected void gvAttendance_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;
            int j=0;
   
            while (j < e.UpdateValues.Count)
            {
                Attendance att = new Attendance();
                att.ClassID = int.Parse(gvAttendance.GetRowValues(j, "ClassID").ToString());
                att.LessonID = int.Parse(gvAttendance.GetRowValues(j, "LessonID").ToString());
                att.Attended = e.UpdateValues[j].NewValues["Attended"].ToString();
                att.Score = Decimal.Parse(e.UpdateValues[j].NewValues["Score"].ToString());
                att.ClassSchedID = int.Parse(gvAttendance.GetRowValues(j, "ClassSchedID").ToString());
                att.Completed = e.UpdateValues[j].NewValues["Completed"].ToString();
                att.ModuleID = int.Parse(gvAttendance.GetRowValues(j, "ModuleID").ToString());
                att.LastModified = DateTime.Now;
                att.ID = int.Parse(gvAttendance.GetRowValues(j, "ID").ToString());
                att.IndexNo = int.Parse(gvAttendance.GetRowValues(j, "IndexNo").ToString());

                


                new AttendanceServices().UpdateAttendance(att,new SessionManager().GetUserId(this.Session));
                j++;
            }
            loadAttedScheduls();
        }

        protected void cmbSearchStud_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;
            List<Student> stud = new StudentService().GetAllStudent(new SessionManager().GetUserId(this.Session));

            comboBox.DataSource = (from s in stud where (s.IndexNo.StartsWith(e.Filter) || s.SName.Contains(e.Filter) || s.ONames.Contains(e.Filter)) select s).ToList();
            // comboBox.DataSource = new StudentService().FindStudent(e.Filter, e.BeginIndex, e.EndIndex + 5, user_id);
            comboBox.DataBind();
        }

        protected void cmbSearchStud_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() != "")
            {
                Student selected = new Student();
                ASPxComboBox comboBox = (ASPxComboBox)source;
                comboBox.DataSource = new StudentService().GetStudentResult(e.Value.ToString().Trim(), new SessionManager().GetUserId(this.Session));
                comboBox.DataBind();
            }
        }

        protected void cmbSearchStud_ButtonClick(object source, ButtonEditClickEventArgs e)
        {
            cmbSearchStud.Value = null;
        }

        protected void cmbClassSchudle_ButtonClick(object source, ButtonEditClickEventArgs e)
        {
            cmbClassSchudle.Value = null;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadAttedScheduls();
        }
    }
}