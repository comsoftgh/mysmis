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
    public partial class abcprogram : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
                loadPrograms();
                LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smModules")).Split(';');
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
        private void clearfields()
        {
            txtId.Text = "0";
            txtName.Text = "";
            txtDesc.Text = "";
        }

        protected void btnSaveProgram_Click(object sender, EventArgs e)
        {
            if(!validateInputs())
            {
                uPanel.Update();
                return;
            }

            Module mod = new Module();
            
            mod.ModuleName = txtName.Text;
            mod.Description = txtDesc.Text;

            if (txtId.Text == "0")
            {

                if (new ModuleServices().insertModule(mod, new SessionManager().GetUserId(Session)))
                {
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

                }
            }
            else
            {
                mod.ModuleID = int.Parse(txtId.Text);
               
                if (new ModuleServices().updateModule(mod, new SessionManager().GetUserId(Session)))
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
            
            return isvalid;
        }

        private void loadPrograms()
        {
            

            dgProgram.DataSource = new ModuleServices().GetAllModule(new SessionManager().GetUserId(Session));
            dgProgram.DataBind();
            
        }

        protected void dgProgram_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ModuleID").ToString());

            if (new ModuleServices().deleteModule(id, new SessionManager().GetUserId(Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Successfully','Message')", true);
            }
            divProgram.Visible = false;
            loadPrograms();
            uPanel.Update();
        }

        protected void dgProgram_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgProgram.CancelEdit();
            clearfields();
            txtId.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ModuleID").ToString();
            txtDesc.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "Description").ToString();
            txtName.Text = dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ModuleName").ToString();
           
            divProgram.Visible = true;
            uPanel.Update();
        }


        protected void dgProgram_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smModules"));

            switch(e.ButtonType)
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
                    divProgram.Visible = true;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/abcprogram.aspx";
                    Session["report"] = new mySmis.reports.rptSchsDpts();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }


            uPanel.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divProgram.Visible = false;
            uPanel.Update();
        }

               
    }
}