using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Export;
//using mySmis.Code;

namespace mySmis
{
    public partial class classScheduler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
            loadPrograms();
            cmbProgram.GridView.Width = 400;
            LoadLookUps();
            LoadUserPermissions();
           
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smBatchesScheduling")).Split(';');
            foreach(string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                        mMain.Items.FindByName("mitNew").Enabled = true;
                        //mMainProgram.Items.FindByName("mitCancel").Enabled = true;
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

        private void LoadLookUps()
        {
            List<ClassABC> empList = new ClassABCServices().GetAllClassModule(new SessionManager().GetUserId(Session));
            cmbProgram.DataSource = empList;
            cmbProgram.DataBind();

            cmbTerms.DataSource = new LookUpService().GetAcademicTerms();
            cmbTerms.TextField = "LValue";
            cmbTerms.ValueField = "LKey";
            cmbTerms.DataBind();

            cmbGradSystem.DataSource = new LookUpService().GetGradingSystems();
            cmbGradSystem.TextField = "LValue";
            cmbGradSystem.ValueField = "LKey";
            cmbGradSystem.DataBind();
        }

        private void loadPrograms()
        {
            
            dgProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            dgProgram.DataBind();
        }

        private void clearfields()
        {
            txtId.Text = "0";
            txtModuleID.Text = "";
            txtClassID.Text = "";
            txtDesc.Text = "";
            cmbTerms.Value = null;
            txtAcademicYear.Text = "";
            cmbProgram.Value = null;
            spnSize.Value = "1";
            cmbGradSystem.Value = null;

            txtDesc.Enabled = true;
            cmbProgram.Enabled = true;
            txtAcademicYear.Enabled = true;
            cmbTerms.Enabled = true;
        }
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divLessons.Visible = false;
            uPanel.Update();
        }

        protected void btnSaveClassSchedule_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }

            ClassScheduler classABC = new ClassScheduler();

            classABC.Term = cmbTerms.Text.ToString();
            classABC.AcademicYear = txtAcademicYear.Text;
            classABC.ClassSize = int.Parse(spnSize.Value.ToString());
            classABC.ModifyDate = DateTime.Now;
            classABC.CreatedDate = DateTime.Now;
            classABC.BgsId = int.Parse(cmbGradSystem.Value.ToString());
            
            string classLessons = "";

            if (txtId.Text == "0")
            {
                //CKECKING IF THE CLASS SCHEDULE IS ALREADY CREATED FOR THIS START AND END DATE TO CREATE SPERTE CLASSES FOR THE SAME DATE PERIOD

                classABC.ClassID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString());
                string groups = new ClassSchedulerServices().NumberingClassScheduler(classABC,new SessionManager().GetUserId(Session));
                
                
                classABC.Title = cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Title") + " : " + cmbTerms.Text + " - " + txtAcademicYear.Text + " GROUP " + groups;
                classABC.ModuleID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ModuleID").ToString());
                string yrgroup = new ClassSchedulerServices().GroupClassScheduler(classABC, new SessionManager().GetUserId(Session));
                if (yrgroup == "") { classABC.Bgroup = new UserService().GenerateUserID(); } else { classABC.Bgroup = yrgroup; }
                //POPULATE THE LESSON SCHEDULER TABLE 

                List<Lesson> allLessons = new LessonService().GetAllLessonsByClassID(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()),new SessionManager().GetUserId(Session));

                if (allLessons.Count > 0)
                {
                    if (new ClassSchedulerServices().AddClassScheduler(classABC, new SessionManager().GetUserId(Session)))
                    {
                        //bool addClasses = new ClassSchedulerServices().AddClassScheduler(classABC, new SessionManager().GetUserId(Session));

                        foreach (Lesson allLesson in allLessons)
                        {
                            LessonScheduler l = new LessonScheduler();

                            int ClassID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString());
                            int ModuleID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ModuleID").ToString());
                            int ClassScheID = new ClassSchedulerServices().GetLastClassScheduleID(new SessionManager().GetUserId(Session));
                            int LessonID = allLesson.ID;

                            classLessons += "('" + ClassScheID + "','" + ModuleID + "','" + ClassID + "','" + LessonID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";

                        }

                        if (new LessonSchedulerServices().AddLessonSchedulerList(classLessons.TrimEnd(','), new SessionManager().GetUserId(Session)))
                        {
                            clearfields();
                            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Add Courses to this Program before creating a Batch','Message')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Add Courses to this Program before creating a Batch','Message')", true);

                }
            }
            else
            {
                classABC.ID = int.Parse(txtId.Text);
                classABC.Title = txtDesc.Text;
                classABC.ModuleID = int.Parse(txtModuleID.Text);
                classABC.ClassID = int.Parse(txtClassID.Text);

                if (new ClassSchedulerServices().UpdateClassScheduler(classABC, new SessionManager().GetUserId(Session)))
                {
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                }
            }

            loadPrograms();
            uPanel.Update();
        }

        private bool validateInputs()
        {
            bool isvalid = true;

            if (cmbTerms.Value == null)
            {
                cmbTerms.IsValid = false;
                isvalid = false;
                cmbTerms.ErrorText = "*";
            }
            if (txtAcademicYear.Text.Trim() == "")
            {
                txtAcademicYear.IsValid = false;
                isvalid = false;
                txtAcademicYear.ErrorText = "*";
            }
            if (txtId.Text == "0")
            {
                if (cmbProgram.Value == null)
                {
                    cmbProgram.IsValid = false;
                    isvalid = false;
                    cmbProgram.ErrorText = "*";
                }
            }
            if (cmbGradSystem.Value == null)
            {
                cmbGradSystem.IsValid = false;
                isvalid = false;
                cmbGradSystem.ErrorText = "*";
            }
            if (spnSize.Value == null)
            {
                spnSize.IsValid = false;
                isvalid = false;
                spnSize.ErrorText = "*";
            }
            return isvalid;
        }
        protected void dgProgram_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString());

            if (new ClassSchedulerServices().DeleteClassScheduler(id, new SessionManager().GetUserId(Session)))
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

        protected void dgProgram_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgProgram.CancelEdit();
            clearfields();

            txtDesc.Enabled = false;
            cmbProgram.Enabled = false;
            txtAcademicYear.Enabled = false;
            cmbTerms.Enabled = false;

            txtId.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString();
            txtClassID.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ClassID").ToString();
            txtModuleID.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ModuleID").ToString();
            txtDesc.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Title").ToString();
            spnSize.Value = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ClassSize").ToString();
            cmbTerms.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Term").ToString();
            txtAcademicYear.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "AcademicYear").ToString();
            cmbProgram.Value = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ClassID");
            //cmbGradSystem.Value = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "xBgsid");

            //var d = cmbProgram.GridView.GetRowValuesByKeyValue(txtId.Text, "ClassID");
            
            divLessons.Visible = true;
            uPanel.Update();
        }

        protected void dgProgram_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smBatchesScheduling"));

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
                    Session["fromwhere"] = "~/classScheduler.aspx";
                    Session["report"] = new mySmis.reports.rptAcademicBatch();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
            
        }

    }
}