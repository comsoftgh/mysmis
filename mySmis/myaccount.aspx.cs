using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;

namespace mySmis
{
    public partial class myaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Session["username"].ToString();
        }

        private bool validateSaveData()
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
                isvalid = false;
            }
            if (txtOldPass.Text.Trim() == "")
            {
                txtOldPass.IsValid = false;
                isvalid = false;
            }
           

            return isvalid;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateSaveData())
            {
                UpdatePanelUser.Update();
                return;
            }

            try
            {
                User u = new User();
                u.UserName = Session["username"].ToString();
                u.Password = txtOldPass.Text;
                if (new UserService().ValidateLogin(u))
                {
                    User uu = new User();
                    uu.Password = txtPass.Text;
                    uu.UserId = new SessionManager().GetUserId(this.Session).ToString();
                    if (new UserService().ChangePassword(uu, new SessionManager().GetUserId(this.Session).ToString()))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Password Changed Successfully','Message')", true);

                        Response.Redirect("~/logout.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Password Changing Failed','Message')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Your password is incorrect','Message')", true);
                }
            }
            catch (Exception)
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops something is not right','Message')", true);
            }

        }
    }
}