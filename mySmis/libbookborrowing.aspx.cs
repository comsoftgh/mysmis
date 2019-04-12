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
    public partial class libbookborrowing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLookUps();
            LoadUserPermissions();
            LoodBooks();
        }

        private void LoadLookUps()
        {
            
        }

        private void LoadUserPermissions()
        {
            
        }

        private void LoodBooks()
        {
            dgBook.DataSource = new LibraryBookService().GetAllAvailableLibraryBook(new SessionManager().GetUserId(this.Session));
            dgBook.DataBind();
        }

        protected void dgBook_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            
        }

        protected void dgBook_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;
            LibraryBook b = new LibraryBookService().GetLibraryBook(int.Parse(e.EditingKeyValue.ToString()), new SessionManager().GetUserId(this.Session));
            txtId.Text = b.ID.ToString();
            txtISBN.Text = b.BookISBN;
            txtSubtitle.Text = b.SubTitle;
            txtTitle.Text = b.BookTitle;
            cmbAuthor.Value = b.AuthorID;
            cmbPublisher.Value = b.PubID;
            divClasses.Visible = true;
            dgBook.CancelEdit();
            uPanel.Update();
        }

        protected void cmbSearcUser_ItemRequestedByValue(object source, DevExpress.Web.ListEditItemRequestedByValueEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() != "")
            {
                User selected = new User();
                ASPxComboBox comboBox = (ASPxComboBox)source;
                List<User> mrList = new List<User>();
                mrList.Add(new UserService().GetFindUser(e.Value.ToString().Trim(), new SessionManager().GetUserId(this.Session)));
                comboBox.DataSource = mrList;
                comboBox.DataBind();
            }
            else
            {
            }
        }

        protected void cmbSearcUser_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;
            List<User> mrList = new UserService().FindUsers(e.Filter, e.BeginIndex, e.EndIndex + 5, new SessionManager().GetUserId(this.Session));
            comboBox.DataSource = mrList;
            comboBox.DataBind();
            
        }
    }
}