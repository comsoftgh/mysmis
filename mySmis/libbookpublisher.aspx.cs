using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class libbookpublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            loadLookUps();
            loadAuthors();
            LoadUserPermissions();
        }

        private void loadLookUps()
        {
            
            cmbNationality.DataSource = new LookUpService().GetCountryList();
            cmbNationality.ValueField = "LValue";
            cmbNationality.TextField = "LValue";
            cmbNationality.DataBind();
        }

        private void loadAuthors()
        {
            dgAuthor.DataSource = new LibraryBookService().GetAllPublisher(new SessionManager().GetUserId(this.Session));
            dgAuthor.DataBind();
        }

        protected void btnSaveClasses_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }

            LibraryBook a = new LibraryBook();
            a.PubName = txtFName.Text;
            a.Country = cmbNationality.Value.ToString();

            if (txtId.Text == "0")
            {
                if (new LibraryBookService().AddPublisher(a, new SessionManager().GetUserId(this.Session)))
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
                a.ID = int.Parse(txtId.Text);
                if (new LibraryBookService().UpdatePublisher(a, new SessionManager().GetUserId(this.Session)))
                {
                    clearfields();

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                }
            }

            loadAuthors();
            uPanel.Update();
        }

        private void clearfields()
        {
            txtId.Text = "0";
            txtFName.Text = "";
        }

        private bool validateInputs()
        {
            bool isvalid = true;

            if (txtFName.Text.Trim() == "")
            {
                txtFName.IsValid = false;
                isvalid = false;
                txtFName.ErrorText = "*";
            }

            
            if (cmbNationality.Value == null)
            {
                cmbNationality.IsValid = false;
                isvalid = false;
                cmbNationality.ErrorText = "*";
            }

            return isvalid;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divClasses.Visible = false;
            uPanel.Update();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smBookPublisher")).Split(';');
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
        protected void dgAuthor_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smBookPublisher"));

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

        protected void dgAuthor_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = int.Parse(dgAuthor.GetRowValues(dgAuthor.FocusedRowIndex, "ID").ToString());

            if (new LibraryBookService().DeletePublisher(id, new SessionManager().GetUserId(Session)))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }
            loadAuthors();
            uPanel.Update();
        }

        protected void dgAuthor_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgAuthor.CancelEdit();
            clearfields();
            txtId.Text = dgAuthor.GetRowValues(dgAuthor.FocusedRowIndex, "ID").ToString();
            cmbNationality.Text = dgAuthor.GetRowValues(dgAuthor.FocusedRowIndex, "Country").ToString();
            txtFName.Text = dgAuthor.GetRowValues(dgAuthor.FocusedRowIndex, "PubName").ToString();
            //cmbGender.Text = dgAuthor.GetRowValues(dgAuthor.FocusedRowIndex, "Gender").ToString();
            divClasses.Visible = true;
            uPanel.Update();
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
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
    }
}