using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;

namespace mySmis
{
    public partial class settingsgeneral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadlookUp();
            if (IsPostBack)
            {
            
            }
            else
            {
                LoadGeneralConfig();
            }
        }

        private void LoadGeneralConfig()
        {
            theme.Value = new InstanceConfigServices().GetConfig(theme.ID);
            schAddLine1.Text = new InstanceConfigServices().GetConfig(schAddLine1.ID);
            schAddLine2.Text = new InstanceConfigServices().GetConfig(schAddLine2.ID);
            schAddLine3.Text = new InstanceConfigServices().GetConfig(schAddLine3.ID);
            schName.Text = new InstanceConfigServices().GetConfig(schName.ID);
            schTel1.Text = new InstanceConfigServices().GetConfig(schTel1.ID);
            schTel2.Text = new InstanceConfigServices().GetConfig(schTel2.ID);
            schLocation.Text = new InstanceConfigServices().GetConfig(schLocation.ID);
            schEmail.Text = new InstanceConfigServices().GetConfig(schEmail.ID);
            staffID.Text = new InstanceConfigServices().GetConfig(staffID.ID);

        }

        private void LoadlookUp()
        {
            theme.DataSource = new LookUpService().GetThemes();
            theme.ValueField = "LValue";
            theme.TextField = "LValue";
            theme.ImageUrlField = "LKey";
            theme.DataBind();
        }



        protected void btnSaveStudent_Click(object sender, EventArgs e)
        {
            
            new InstanceConfigServices().AddConfig(theme.ID,theme.Value.ToString(),new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schAddLine1.ID, schAddLine1.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schAddLine2.ID, schAddLine2.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schAddLine3.ID, schAddLine3.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schName.ID, schName.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schTel1.ID, schTel1.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schTel2.ID, schTel2.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schLocation.ID, schLocation.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(schEmail.ID, schEmail.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(staffID.ID, staffID.Text, new SessionManager().GetUserId(this.Session));

            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

            LoadGeneralConfig();
            upPanel.Update();
        }
    }
}