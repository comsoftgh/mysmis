using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;

namespace mySmis
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           new SessionManager().InitDBConnection();
           
           div_name.InnerHtml = new InstanceConfigServices().GetConfig("schName");//+ "<br>" + new InstanceConfigServices().GetConfig("schLocation");
        }

        protected override void FrameworkInitialize()
        {
            base.FrameworkInitialize();
            DevExpress.Web.ASPxWebControl.GlobalTheme = new InstanceConfigServices().GetConfig("theme");
        }

        private Boolean ValidateLogin()
        {
            User usr = new User();
            usr.UserName = txtUsername.Value.ToString();
            usr.Password = txtPassword.Value.ToString();
            if (new UserService().ValidateLogin(usr))
                return true;
            else
               return false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (ValidateLogin())
            {
                User us = new UserService().GetUser(txtUsername.Value.ToString());
                Session["username"] = us.UserName.ToString();
                Session["userid"] = us.UserId;
                Session["usertype"] = us.UserType;
                List<UserPermission> pm = new UserPermissionService().GetUserPermissions(us.UserId, us.UserId);
                Session["Role"] = pm;
               
                new AuditLogService().AddAuditLog("LOGIN ATTEMPT", us.UserId, us.UserName, "Successfully Logged in", DateTime.Now);


                if (us.UserType == "Administrator" || us.UserType == "System")
                {
                    Tutor st = new TutorService().GetTutor(Session["userid"].ToString());
                    Session["userfname"] = st.FNames != null ? st.FNames.ToString() : "ComSoft";
                    if (us.DateCreated.Date >= us.LastModify.Date)
                    {
                    }
                    else
                    {
                        Response.Redirect("~/home.aspx");
                    }
                }
                else if (us.UserType == "Tutor")
                {
                    Tutor st = new TutorService().GetTutor(Session["userid"].ToString());
                    Session["userfname"] = st.FNames.ToString();
                    Response.Redirect("~/teachingstaffdashboard.aspx");
                }
                else if (us.UserType == "Administrator & Tutor")
                {
                    Tutor st = new TutorService().GetTutor(Session["userid"].ToString());
                    Session["userfname"] = st.FNames.ToString();
                    Response.Redirect("~/admintutordashboard.aspx");
                }
                else if (us.UserType == "Student")
                {
                    Student st = new StudentService().GetStudent(Session["userid"].ToString());
                    Session["userfname"] = st.FNames.ToString();
                    Response.Redirect("~/studentdashboard.aspx");
                }
                else if (us.UserType == "Parent")
                {
                    Response.Redirect("~/parentdashboard.aspx");
                }

            }
            else
            {
                txtPassword.Focus();
                txtUsername.Focus();
                txtUsername.Style.Add("border-color", "red");
                txtPassword.Style.Add("border-color", "red");
                //UpdatePanelLogin.Update();
            }
        }
    }
}