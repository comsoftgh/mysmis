using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class usersstudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadLookups();
            loadAllUserStaff();
        }
        private void loadAllUserStaff()
        {
            gvStaff.DataSource = new UserService().GetStudentUsers(new SessionManager().GetUserId(this.Session));
            gvStaff.DataBind();
        }
        private void loadLookups()
        {
            cmbStaffs.DataSource = new TutorService().GetTutorByStaffTypeNotInList("Student","Student","Student", new SessionManager().GetUserId(this.Session));
            cmbStaffs.DataBind();
        }
        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitExcel")
            {

                //divLogin.Visible = true;
            }

            UpdatePanelStaff.Update();

        }
        
       
        protected void btnCancelLogin_Click(object sender, EventArgs e)
        {
            cleardata();
            divLogin.Visible = false;
            btnActive.Visible = false;
            btnReset.Visible = false;
            UpdatePanelStaff.Update();
        }

        private void cleardata()
        {   
            txtUserName.Text = "";
            cmbStaffs.Text = "";
            cmbStaffs.Value = "";
            btnActive.Visible = false;
            btnReset.Visible = false;
            cmbStaffs.Enabled = true;
        }
        protected void gvStaff_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            gvStaff.CancelEdit();
            User u = new UserService().GetUserByUserID(e.EditingKeyValue.ToString());
            txtUserName.Text = u.UserName;
            cmbStaffs.Value = u.UserId;
            cmbStaffs.Enabled = false;
            btnActive.Text = u.Active == 0 ? "Activate" : "Deactivate";
            txtActive.Text = u.Active == 0 ? "1" : "0";
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
                u.Password = "@student123";
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