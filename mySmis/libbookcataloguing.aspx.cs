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
using System.IO;
using System.Drawing;

namespace mySmis
{
    public partial class libbookcataloguing : System.Web.UI.Page
    {
        private const string UPEDU_DIR = "~/librarybooks/";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLookUps();         
            LoadUserPermissions();
            LoodBooks();
        }

        private void LoodBooks()
        {
            dgAuthor.DataSource = new LibraryBookService().GetAllLibraryBook(new SessionManager().GetUserId(this.Session));
            dgAuthor.DataBind();

            cmbAuthor.DataSource = new LibraryBookService().GetAllAuthors(new SessionManager().GetUserId(this.Session));
            cmbAuthor.TextField = "AuthorName";
            cmbAuthor.ValueField = "ID";
            cmbAuthor.DataBind();

            cmbPublisher.DataSource = new LibraryBookService().GetAllPublisher(new SessionManager().GetUserId(this.Session));
            cmbPublisher.TextField = "PubName";
            cmbPublisher.ValueField = "ID";
            cmbPublisher.DataBind();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smBookCataloguing")).Split(';');
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

        private void LoadLookUps()
        {
            cmbBlock.DataSource = new LibraryClassificationService().GetAllLibraryClassOne(1, new SessionManager().GetUserId(this.Session));
            cmbBlock.TextField = "TitleBlock";
            cmbBlock.ValueField = "ID";
            cmbBlock.DataBind();
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearInputs();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }

            LibraryBook b = new LibraryBook();
            b.AuthorID = int.Parse(cmbAuthor.Value.ToString());
            b.BookDesc = momDescription.Value.ToString();
            b.BookISBN = txtISBN.Text;
            b.BookPages = int.Parse(spinNoPages.Value.ToString());
            b.BookQty = int.Parse(spinQty.Value.ToString());
            b.BookTitle = txtTitle.Text;
            b.BookType = cmbCopy.Value.ToString();
            b.PubID = int.Parse(cmbPublisher.Value.ToString());
            b.SubTitle = txtSubtitle.Text;
            b.DateCreated = DateTime.Now;
            b.DateModify = DateTime.Now;
            b.xIDclassOne = int.Parse(cmbBlock.Value.ToString());
            b.xIDclassTwo = int.Parse(cmbShelve.Value.ToString());
            b.xIDclassThree = int.Parse(cmbStack.Value.ToString());

            if (txtId.Text == "0")
            {
                if(new LibraryBookService().AddBook(b,new SessionManager().GetUserId(this.Session)))
                {
                    if (fileUp.HasFile)
                    {
                        string newName = txtISBN.Text;
                        string ext = Path.GetExtension(fileUp.PostedFile.FileName);
                        string savePath = Path.Combine(Server.MapPath(UPEDU_DIR), newName + ext);
                        fileUp.SaveAs(savePath);

                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    clearInputs();
               }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                }
            }
            else
            {
                b.ID = int.Parse(txtId.Text);
                if (new LibraryBookService().UpdateBook(b,new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                    clearInputs();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                }
            }
            LoodBooks();
            uPanel.Update();
        }

        private bool validateInputs()
        {
            bool isvalid = true;

            if (txtTitle.Text.Trim() == "")
            {
                txtTitle.IsValid = false;
                isvalid = false;
                txtTitle.ErrorText = "*";
            }
            if (txtISBN.Text.Trim() == "")
            {
                txtISBN.IsValid = false;
                isvalid = false;
                txtISBN.ErrorText = "*";
            }
            else { 
                if (new LibraryBookService().ExitLibraryBook(txtISBN.Text.Trim(), new SessionManager().GetUserId(this.Session)))
                {
                    txtISBN.IsValid = false;
                    isvalid = false;
                    txtISBN.ErrorText = "This ISBN Exist";
                }
            }
            if (cmbAuthor.Value == null)
            {
                cmbAuthor.IsValid = false;
                isvalid = false;
                cmbAuthor.ErrorText = "*";
            }
            if (cmbPublisher.Value == null)
            {
                cmbPublisher.IsValid = false;
                isvalid = false;
                cmbPublisher.ErrorText = "*";
            }
            if (cmbBlock.Value == null)
            {
                cmbBlock.IsValid = false;
                isvalid = false;
                cmbBlock.ErrorText = "*";
            }
            if (cmbShelve.Value == null)
            {
                cmbShelve.IsValid = false;
                isvalid = false;
                cmbShelve.ErrorText = "*";
            }
            if (cmbStack.Value == null)
            {
                cmbStack.IsValid = false;
                isvalid = false;
                cmbStack.ErrorText = "*";
            }
            if (txtSubtitle.Text.Trim() == "")
            {
                txtSubtitle.IsValid = false;
                isvalid = false;
                txtSubtitle.ErrorText = "*";
            }
            if (momDescription.Text.Trim() == "")
            {
                momDescription.IsValid = false;
                isvalid = false;
                momDescription.ErrorText = "*";
            }
            if (spinNoPages.Value == null)
            {
                spinNoPages.IsValid = false;
                isvalid = false;
                spinNoPages.ErrorText = "*";
            }
            if (spinQty.Value == null)
            {
                spinQty.IsValid = false;
                isvalid = false;
                spinQty.ErrorText = "*";
            }

            if (fileUp.HasFile)
            {
                string exts = Path.GetExtension(fileUp.PostedFile.FileName);
                if (exts == ".pdf" || exts == ".doc" || exts == ".docx")
                { }
                else
                {
                    fileUp.BorderStyle = BorderStyle.Solid;
                    fileUp.BorderColor = Color.LightPink;
                    isvalid = false;
                }

            }        

            return isvalid;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputs();
            divClasses.Visible = false;
            uPanel.Update();
        }

        private void clearInputs()
        {
            txtId.Text = "0";
            txtISBN.Text = "";
            txtSubtitle.Text = "";
            txtTitle.Text = "";
            cmbAuthor.Value = null;
            cmbBlock.Value = null;
            cmbCopy.Value = null;
            cmbPublisher.Value = null;
            cmbShelve.Value = null;
            cmbStack.Value = null;
            momDescription.Value = "";
            spinNoPages.Value = 0;
            spinQty.Value = 0;
            cmbShelve.Enabled = false;
            cmbStack.Enabled = false;
        }

        protected void dgAuthor_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smBookCataloguing"));

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
            e.Cancel = true;
            if (new LibraryBookService().ArchiveBook(int.Parse(dgAuthor.GetRowValuesByKeyValue(dgAuthor.KeyFieldName,"ID").ToString()), new SessionManager().GetUserId(this.Session))) 
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Archived Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Archiving Failed','Message')", true);
            }

            LoodBooks();
            uPanel.Update();
        }

        protected void dgAuthor_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;
            LibraryBook b = new LibraryBookService().GetLibraryBook(int.Parse(e.EditingKeyValue.ToString()), new SessionManager().GetUserId(this.Session));
            txtId.Text = b.ID.ToString();
            txtISBN.Text = b.BookISBN;
            txtSubtitle.Text = b.SubTitle;
            txtTitle.Text = b.BookTitle;
            cmbAuthor.Value = b.AuthorID;
            cmbBlock.Value = b.xIDclassOne;
            cmbCopy.Value = b.BookType;
            cmbPublisher.Value = b.PubID;
            cmbShelve.Value = b.xIDclassTwo;
            cmbStack.Value = b.xIDclassThree;
            momDescription.Value = b.BookDesc;
            spinNoPages.Value = b.BookPages;
            spinQty.Value = b.BookQty;
            
            divClasses.Visible = true;
            dgAuthor.CancelEdit();
            uPanel.Update();

        }

        protected void cmbBlock_ValueChanged(object sender, EventArgs e)
        {
            cmbShelve.Enabled = true;
            cmbShelve.DataSource = new LibraryClassificationService().GetAllLibraryClassTwo(1,int.Parse(cmbBlock.Value.ToString()),new SessionManager().GetUserId(this.Session));
            cmbShelve.ValueField = "ID";
            cmbShelve.TextField = "TitleShelve";
            cmbShelve.DataBind();
            uPanel.Update();
        }

        protected void cmbShelve_ValueChanged(object sender, EventArgs e)
        {
            cmbStack.Enabled = true;
            cmbStack.DataSource = new LibraryClassificationService().GetAllLibraryClassThree(1, int.Parse(cmbShelve.Value.ToString()), new SessionManager().GetUserId(this.Session));
            cmbStack.ValueField = "ID";
            cmbStack.TextField = "TitleStack";
            cmbStack.DataBind();
            uPanel.Update();
        }

        protected void cmbCopy_ValueChanged(object sender, EventArgs e)
        {
            if(cmbCopy.Value != null)
            {
                if (cmbCopy.Value.ToString() == "Electronic") { fileUp.Visible = true; } else { fileUp.Visible = false; }
            }

            uPanel.Update();
        }
    }
}