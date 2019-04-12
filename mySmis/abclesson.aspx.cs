using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.Web;
//using mySmis.Code;

namespace mySmis
{
    public partial class abclesson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
            loadPrograms();
            cmbProgram.GridView.Width = 600;
            LoadookUps();
            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCoursesSubject")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                        mMainProgram.Items.FindByName("mitNew").Enabled = true;
                        //mMainProgram.Items.FindByName("mitCancel").Enabled = true;
                        break;
                    case "EXPORT":
                        mMainProgram.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                        mMainProgram.Items.FindByName("mitReport").Enabled = true;
                        break;
                }

            }

        }

        private void LoadookUps()
        {
            cmbType.DataSource = new LookUpService().GetAllLessonTypes();
            cmbType.ValueField = "LValue";
            cmbType.TextField = "LValue";
            cmbType.DataBind();
        }

        protected void btnNewClass_Click(object sender, EventArgs e)
        {

            clearfields();
            divLessons.Visible = true;

            uPanel.Update();
        }

        private void clearfields()
        {
            txtId.Text     = "0";
            txtName.Text   = "";
            txtDesc.Text   = "";
            txtCode.Text   = "";
            spnCredit.Text = "";
        }

        private void loadPrograms()
        {
            List<ClassABC> empList = new ClassABCServices().GetAllClassModule(new SessionManager().GetUserId(Session));
            cmbProgram.DataSource = empList;
            cmbProgram.DataBind();

            dgProgram.DataSource = new LessonService().GetAllLessonClassModule(new SessionManager().GetUserId(Session));
            dgProgram.DataBind();

        }

        protected void dgProgram_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString());

            if (new LessonService().deleteLesson(id, new SessionManager().GetUserId(Session)))
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
            txtId.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString();
            txtDesc.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Description").ToString();
            txtName.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Title").ToString();
            txtCode.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Code").ToString();
            spnCredit.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Credit").ToString();
            cmbProgram.Value = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ClassID");
            cmbType.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Type").ToString();
            divLessons.Visible = true;
            uPanel.Update();
        }

        protected void btnSaveLesson_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }

            Lesson classABC = new Lesson();
            classABC.ModuleID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ModuleID").ToString());
            classABC.Title = txtName.Text;
            classABC.Description = txtDesc.Text;
            classABC.ClassID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString());
            classABC.Credit = int.Parse(spnCredit.Text);
            classABC.Code = txtCode.Text;
            classABC.Type = cmbType.Value.ToString();

            if (txtId.Text == "0")
            {

               
                if (new LessonService().insertLesson(classABC, new SessionManager().GetUserId(Session)))
                {
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

                }
            }
            else
            {
                classABC.ID = int.Parse(txtId.Text);
                
                if (new LessonService().updateLesson(classABC, new SessionManager().GetUserId(Session)))
                {
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);

                }
            }

            loadPrograms();
            uPanel.Update();
        }

        private bool validateInputs()
        {
            bool isvalid = true;

            if (txtName.Text.Trim() == "")
            {
                txtName.IsValid = false;
                isvalid = false;
                txtName.ErrorText = "*";
            }
            if (txtCode.Text.Trim() == "")
            {
                txtCode.IsValid = false;
                isvalid = false;
                txtCode.ErrorText = "*";
            }
            if (spnCredit.Text.Trim() == "" || spnCredit.Value.ToString() == "0")
            {
                spnCredit.IsValid = false;
                isvalid = false;
                spnCredit.ErrorText = "*";
            }
            if (cmbType.Value == null)
            {
                cmbType.IsValid = false;
                isvalid = false;
                cmbType.ErrorText = "*";
            }
            if (cmbProgram.Value == null)
            {
                cmbProgram.IsValid = false;
                isvalid = false;
                cmbProgram.ErrorText = "*";
            }

            return isvalid;
        }
        protected void dgProgram_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCoursesSubject"));

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

        protected void mMainProgram_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearfields();
                    divLessons.Visible = true;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/abclesson.aspx";
                    Session["report"] = new mySmis.reports.rptCoursesSubjects();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }
           
            uPanel.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divLessons.Visible = false;
            uPanel.Update();
        }
    }
}