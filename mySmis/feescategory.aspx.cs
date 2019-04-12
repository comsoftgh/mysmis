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

namespace mySmis
{
    public partial class feescategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            loadPrograms();
            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smFeeCategory")).Split(';');
            foreach (string perm in perms)
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
        protected void btnSaveProgram_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }

            FeesCategory fc = new FeesCategory();
            fc.Description = txtDesc.Text;
            fc.DateCreted = DateTime.Now;
            fc.LastModified = DateTime.Now;
            fc.Title = txtName.Text;
            fc.Applyto = cmbApplyto.Value.ToString();

            if (new FeesCategoryService().ExistFeesCategory(fc, new SessionManager().GetUserId(this.Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('This already exist','Message')", true);
            }
            else
            {

                if (txtId.Text == "0")
                {
                    if (new FeesCategoryService().AddFeesCategory(fc, new SessionManager().GetUserId(this.Session)))
                    {
                        clearfields();
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                    }
                }
                else
                {
                    fc.ID = int.Parse(txtId.Text);
                    if (new FeesCategoryService().UpdateFeesCategory(fc, new SessionManager().GetUserId(this.Session)))
                    {
                        clearfields();
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updaing Failed','Message')", true);
                    }
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
            if (cmbApplyto.Value == null)
            {
                cmbApplyto.IsValid = false;
                isvalid = false;
                cmbApplyto.ErrorText = "*";
            }

            return isvalid;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divProgram.Visible = false;
            uPanel.Update();
        }

        protected void gvFeesCategory_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(gvFeesCategory.GetRowValues(gvFeesCategory.FocusedRowIndex, "ID").ToString());

            if (new FeesCategoryService().DeleteFeesCategory(id, new SessionManager().GetUserId(Session)))
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

        private void loadPrograms()
        {
            gvFeesCategory.DataSource = new FeesCategoryService().GetAllFeesCategory(new SessionManager().GetUserId(Session));
            gvFeesCategory.DataBind();
        }

        protected void gvFeesCategory_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            gvFeesCategory.CancelEdit();
            clearfields();
            txtId.Text = gvFeesCategory.GetRowValues(gvFeesCategory.FocusedRowIndex, "ID").ToString();
            txtDesc.Text = gvFeesCategory.GetRowValues(gvFeesCategory.FocusedRowIndex, "Description").ToString();
            txtName.Text = gvFeesCategory.GetRowValues(gvFeesCategory.FocusedRowIndex, "Title").ToString();
            cmbApplyto.Value = gvFeesCategory.GetRowValues(gvFeesCategory.FocusedRowIndex, "Applyto").ToString();
            cmbApplyto.Text = gvFeesCategory.GetRowValues(gvFeesCategory.FocusedRowIndex, "Applyto").ToString();

            divProgram.Visible = true;
            uPanel.Update();
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
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
                    Session["fromwhere"] = "~/feescategory.aspx";
                    Session["report"] = new mySmis.reports.rptFeesCategory();
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

        protected void gvFeesCategory_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
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