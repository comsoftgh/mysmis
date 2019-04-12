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
    public partial class abcclass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            loadLookUps();
            loadPrograms();
            LoadUserPermissions();
            
        }

        private void loadLookUps()
        {
            cmbProgram.DataSource = new ModuleServices().GetAllModule(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms")).Split(';');
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

        protected void mMainProgram_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
                        
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearfields();
                divClasses.Visible = true;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/abcclass.aspx";
                    Session["report"] = new mySmis.reports.rptProgramsLevels();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
        }

        private void clearfields()
        {
            txtId.Text = "0";
            txtName.Text = "";
            txtDesc.Text = "";
        }

        private void loadPrograms()
        {
           dgProgram.DataSource = new ClassABCServices().GetAllClassModule(new SessionManager().GetUserId(Session));
           dgProgram.DataBind();
        }

        protected void btnSaveClasses_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }
            ClassABC classABC = new ClassABC();
            classABC.ModuleID = int.Parse(cmbProgram.Value.ToString());
            classABC.Title = txtName.Text;
            classABC.Description = txtDesc.Text;

            if (txtId.Text == "0")
            {
              
               
                if (new ClassABCServices().AddClass(classABC, new SessionManager().GetUserId(Session)))
                {
                    clearfields();

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);


                }
            }
            else
            {
                classABC.ID = int.Parse(txtId.Text);
                
                if (new ClassABCServices().UpdateClass(classABC, new SessionManager().GetUserId(Session)))
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
            if (txtDesc.Text.Trim() == "")
            {
                txtDesc.IsValid = false;
                isvalid = false;
                txtDesc.ErrorText = "*";
            }
            if (cmbProgram.Value == null)
            {
                cmbProgram.IsValid = false;
                isvalid = false;
                cmbProgram.ErrorText = "*";
            }

            return isvalid;
        }
        protected void dgProgram_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString());

            if (new ClassABCServices().DeleteClass(id, new SessionManager().GetUserId(Session)))
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
            cmbProgram.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ModuleID").ToString();
            divClasses.Visible = true;
            uPanel.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divClasses.Visible = false;
            uPanel.Update();
        }

        protected void dgProgram_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms"));

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

    }
}