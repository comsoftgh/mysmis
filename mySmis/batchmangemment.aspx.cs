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
    public partial class batchmangemment : System.Web.UI.Page
    {
        //ASPxComboBox _TimetablecombBox;
        //ASPxComboBox _ExamsscorecombBox;
        //ASPxComboBox _TestscorescomboBox;
        //ASPxComboBox _RegistrationcomboBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            loadBatches();
        }

        private void loadBatches()
        {
            gvBatches.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            gvBatches.DataBind();
        }

        protected void cmbTimetable_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            Session["Timetable"] = "";
            Session["Timetable"] = ((ASPxComboBox)sender).Value;
        }

        

        protected void cmbTimetable_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
               
                Session["Timetable"] = 0;
            }
            else
            {
                Session["Timetable"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void gvBatches_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            e.Cancel = true;
            ClassScheduler bs = new ClassScheduler();
            bs.ID = int.Parse(e.Keys["ID"].ToString());
            bs.IA = int.Parse(Session["Testscores"].ToString());
            bs.Timetable = int.Parse(Session["Timetable"].ToString());
            bs.Registration = int.Parse(Session["Registration"].ToString());
            bs.Exams = int.Parse(Session["Examsscore"].ToString());
            bs.ModifyDate = DateTime.Now;

            if (new ClassSchedulerServices().UpdateClassSchedulerActivity(bs, new SessionManager().GetUserId(this.Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Oops something is not right! Saving Failed','Message')", true);

            }

            loadBatches();
            uPanel.Update();
        }

        protected void gvBatches_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            //string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smClassLesson"));

            //if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            //{ if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            //if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            //{ if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            //if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            //{ if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        
        protected void cmbRegistration_Validation(object sender, ValidationEventArgs e)
        {
            Session["Registration"] = "";
            Session["Registration"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbRegistration_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["Registration"] = "";
            }
            else
            {
                Session["Registration"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void cmbTestscores_Validation(object sender, ValidationEventArgs e)
        {
            Session["Testscores"] = "";
            Session["Testscores"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbTestscores_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["Testscores"] = "";
            }
            else
            {
                Session["Testscores"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void cmbExamsscore_Validation(object sender, ValidationEventArgs e)
        {
            Session["Examsscore"] = "";
            Session["Examsscore"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbExamsscore_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["Examsscore"] = "";
            }
            else
            {
                Session["Examsscore"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void gvBatches_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;
            //e.
        }

    }
}