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
    public partial class academicstranscripts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            if (IsPostBack)
            {
                if (cmbProgram.Value != null)
                {
                    int gstypeId = new GradingSystemService().GetGradingSystem(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "BgsId").ToString()), new SessionManager().GetUserId(this.Session)).Gsvgstypeid;
                    if (gstypeId == 3)
                    {
                        loadgvTranscriptTertiary();
                    }
                    else if (gstypeId == 2)
                    {
                        loadgvTranscriptSecondCycle();
                    }
                    else if (gstypeId == 1)
                    {
                        loadgvTranscriptBasic();
                    }
                }
                else
                {
                    //loadPayments();
                }
            }
            else
            {
                //loadPayments();
            }
            loadPrograms();
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                int gstypeId = new GradingSystemService().GetGradingSystem(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "BgsId").ToString()), new SessionManager().GetUserId(this.Session)).Gsvgstypeid;
                if(gstypeId == 3)
                {
                loadgvTranscriptTertiary();
                }
                else if(gstypeId == 2)
                {
                loadgvTranscriptSecondCycle();
                }
                else if (gstypeId == 1)
                {
                loadgvTranscriptBasic();
                }
            }
            else
            {
                
                clearfields();
            }
            uPanel.Update();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassSchedulerTranscript(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 500;
        }
        private void clearfields()
        {
            gvTranscriptTertiary.DataSource = null;
            gvTranscriptTertiary.DataBind();
            

            gvTranscriptBasic.DataSource = null;
            gvTranscriptBasic.DataBind();
            

            gvTranscriptSecondCycle.DataSource = null;
            gvTranscriptSecondCycle.DataBind();
            
        }

        private void loadgvTranscriptTertiary()
        {
            clearfields();
            gvTranscriptTertiary.Visible = true;
            gvTranscriptTertiary.DataSource = new StudentRegistrationService().GetAllStudentRegistrationByBatchIdBgroup(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(), new SessionManager().GetUserId(Session));
            gvTranscriptTertiary.DataBind();

            uPanel.Update();
        }

        private void loadgvTranscriptSecondCycle()
        {
            clearfields();
            gvTranscriptTertiary.Visible = false;
            gvTranscriptSecondCycle.Visible = true;
            gvTranscriptSecondCycle.DataSource = new StudentRegistrationService().GetAllStudentRegistrationByBatchIdBgroup(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(), new SessionManager().GetUserId(Session));
            gvTranscriptSecondCycle.DataBind();

            uPanel.Update();
        }

        private void loadgvTranscriptBasic()
        {
            clearfields();
            gvTranscriptTertiary.Visible = false;
            gvTranscriptBasic.Visible = true;
            gvTranscriptBasic.DataSource = new StudentRegistrationService().GetAllStudentRegistrationByBatchIdBgroup(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(), new SessionManager().GetUserId(Session));
            gvTranscriptBasic.DataBind();

            uPanel.Update();
        }

        protected void gvTranscriptSecondCycle_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smClassLesson"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void gvTranscriptSecondCycleDetails_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            int batchId = int.Parse(gv.GetMasterRowFieldValues("BatchId").ToString());
            string studuserId = gv.GetMasterRowFieldValues("StuduserId").ToString();
            int gradesysId = int.Parse(gv.GetMasterRowFieldValues("xGsId").ToString());
            gv.DataSource = new StudentLessonsRegistrationService().GetStudentExamsResults(batchId, studuserId, gradesysId, new SessionManager().GetUserId(this.Session));
        }

        protected void gvTranscriptBasic_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smClassLesson"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void gvTranscriptBasicDetails_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            int batchId = int.Parse(gv.GetMasterRowFieldValues("BatchId").ToString());
            string studuserId = gv.GetMasterRowFieldValues("StuduserId").ToString();
            int gradesysId = int.Parse(gv.GetMasterRowFieldValues("xGsId").ToString());
            gv.DataSource = new StudentLessonsRegistrationService().GetStudentExamsResults(batchId, studuserId, gradesysId, new SessionManager().GetUserId(this.Session));
        }

        protected void gvTranscriptTertiary_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smClassLesson"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void gvTranscriptTertiaryDetails_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            int batchId = int.Parse(gv.GetMasterRowFieldValues("BatchId").ToString());
            string studuserId = gv.GetMasterRowFieldValues("StuduserId").ToString();
            int gradesysId = int.Parse(gv.GetMasterRowFieldValues("xGsId").ToString());
            gv.DataSource = new StudentLessonsRegistrationService().GetStudentExamsResults(batchId, studuserId, gradesysId, new SessionManager().GetUserId(this.Session));
        }

    }
}