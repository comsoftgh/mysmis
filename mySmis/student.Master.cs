using mySmisLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class student : System.Web.UI.MasterPage
    {

        private SessionManager sessMgr = new SessionManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null || Session["username"] == null)
            {
                Response.Redirect("~/logout.aspx");
            }

            //new SessionManager().IsSessionActive(this.Response, this.Session);
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

           // List<UserAccess> ua = new UserAccessService().GetUserAccess(Session["userid"].ToString());
            //string[] roleLists = Session["Role"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
           // foreach (UserAccess ac in ua)
           // {

                // mMain.Items.FindByName(ac.xMenu).Visible = true;
            //    mMain.Groups.FindByName(ac.xMenu).Visible = true;
            //    List<Permission> up = new PermissionService().GetPermissions(Session["userid"].ToString(), ac.MainId);
             //   foreach (Permission ap in up)
             //   {
                    //nbMain.Items.FindByName(ap.xSubMenu).Visible = true;
              //      mMain.Items.FindByName(ap.xSubMenu).Visible = true;

               // }
           // }



            if (File.Exists(Server.MapPath("~/pictures/img_" + Session["userid"].ToString() + ".jpg")))
            {

                imgStaff.ImageUrl = "~/pictures/img_" + Session["userid"].ToString() + ".jpg";

            }
            else
            {
                imgStaff.ImageUrl = "~/images/default-person.jpg";
            }

            lbStaffNames.Text = Session["userfname"].ToString();
            divSchName.InnerText = new InstanceConfigServices().GetConfig("schName");
            //mmHeader.Style.Add("background-image", "url(images/themes/"+ new InstanceConfigServices().GetConfig("theme") + ".png)");
            //mmHeader.InnerText = new InstanceConfigServices().GetConfig("schName");
            //ssHeader.Style.Add("background-image", "url(images/themes/"+ new InstanceConfigServices().GetConfig("theme") + ".png)");
        }
        protected override void FrameworkInitialize()
        {
            base.FrameworkInitialize();
            DevExpress.Web.ASPxWebControl.GlobalTheme = new InstanceConfigServices().GetConfig("theme");
        }


    }
}