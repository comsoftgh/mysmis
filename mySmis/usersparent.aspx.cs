using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class usersparent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadLookups();
            loadAllUserStaff();
        }
        private void loadAllUserStaff()
        {
            gvStaff.DataSource = new UserService().GetParentUsers(new SessionManager().GetUserId(this.Session));
            gvStaff.DataBind();
        }
        private void loadLookups()
        {
            cmbStaffs.DataSource = new TutorService().GetTutorByStaffTypeNotInList("Student","Student","Student", new SessionManager().GetUserId(this.Session));
            cmbStaffs.DataBind();
        }
        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitNew")
            {

                divLogin.Visible = true;
            }

            UpdatePanelStaff.Update();

        }
        private bool validateSaveLogin()
        {
            bool isvalid = true;

            if (txtPass.Text.Trim() == "")
            {
                txtPass.IsValid = false;
                isvalid = false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                txtPassword.IsValid = false;
                isvalid = false;
            }
            if (txtPassword.Text.Trim() != txtPass.Text.Trim())
            {
                txtPassword.IsValid = false;
                txtPass.IsValid = false;
                txtPass.ErrorText = "Oops! Passwords did not match";
                isvalid = false;
            }
            if (txtUserName.Text.Trim() == "")
            {
                txtUserName.IsValid = false;
                isvalid = false;
            }
            if (new UserService().UserNameExists(txtUserName.Text.Trim()))
            {
                txtUserName.IsValid = false;
                txtUserName.ErrorText = "Oops! Username already exist";
                isvalid = false;
            }

            return isvalid;
        }
        protected void btnSaveLogin_Click(object sender, EventArgs e)
        {
            if (!validateSaveLogin())
            {
                UpdatePanelStaff.Update();
                return;
            }


            try
            {

                User us = new User();
                txtPass.Text = "";
                us.Password = txtPassword.Text;
                us.UserName = txtUserName.Text;
                us.LastModify = DateTime.Now;
                us.DateCreated = DateTime.Now;
                us.UserId = cmbStaffs.Value.ToString();
                us.UserType = "Parent";

                if (new UserService().AddUser(us, new SessionManager().GetUserId(this.Session)))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    divLogin.Visible = false;
                }

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops! Something is not right','Message')", true);
            }

            loadAllUserStaff();
            UpdatePanelStaff.Update();
        }
        protected void btnCancelLogin_Click(object sender, EventArgs e)
        {
            divLogin.Visible = false;
            btnActive.Visible = false;
            btnReset.Visible = false;
            UpdatePanelStaff.Update();
        }
        protected void gvStaff_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            gvStaff.CancelEdit();
            User u = new UserService().GetUserByUserID(e.EditingKeyValue.ToString());
            txtUserName.Text = u.UserName;
            cmbStaffs.Value = u.UserId;
            cmbStaffs.Enabled = false;
            txtPass.Text = u.Password;
            txtPass.Enabled = false;
            txtPassword.Text = u.Password;
            txtPassword.Enabled = false;
            btnActive.Text = u.Active == 1 ? "Activate" : "Deactivate";
            txtActive.Text = u.Active == 1 ? "1" : "0";
            btnActive.Visible = true;
            btnReset.Visible = true;
            divLogin.Visible = true;
            UpdatePanelStaff.Update();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (cmbStaffs.Value != null)
            {
                User u = new User();
                u.UserId = cmbStaffs.Value.ToString();
                u.Password = "@parent123";
                u.LastModify = DateTime.Now;
                if (new UserService().ChangePassword(u, new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Password Reset Successfully','Message')", true);
                }
            }
            loadAllUserStaff();
            UpdatePanelStaff.Update();
        }
        protected void btnActive_Click(object sender, EventArgs e)
        {
            if (cmbStaffs.Value != null)
            {

                if (new UserService().ActivateUser(int.Parse(txtActive.Text), cmbStaffs.Value.ToString(), new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('" + btnActive.Text + " Successfully','Message')", true);
                }
            }

            loadAllUserStaff();
            UpdatePanelStaff.Update();
        }
    }
}