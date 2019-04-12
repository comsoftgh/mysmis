using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class settingstutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new InstanceConfigServices().GetConfig("staffID") == "No")
            { 
              tutorIDdynamic.Enabled = false;
              tutorIDSeperator.Enabled = false;
              tutorIDStartingNo.Enabled = false;
              tutorIDString.Enabled = false;
              btnSave.Enabled = false;
            }

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
            tutorIDdynamic.Value = new InstanceConfigServices().GetConfig(tutorIDdynamic.ID);
            tutorIDSeperator.Value = new InstanceConfigServices().GetConfig(tutorIDSeperator.ID);
            tutorIDStartingNo.Text = new InstanceConfigServices().GetConfig(tutorIDStartingNo.ID);
            tutorIDString.Text = new InstanceConfigServices().GetConfig(tutorIDString.ID);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            new InstanceConfigServices().AddConfig(tutorIDdynamic.ID, tutorIDdynamic.Value.ToString(), new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(tutorIDSeperator.ID, tutorIDSeperator.Value.ToString(), new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(tutorIDStartingNo.ID, tutorIDStartingNo.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(tutorIDString.ID, tutorIDString.Text, new SessionManager().GetUserId(this.Session));


            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saving Failed','Message')", true);

            LoadGeneralConfig();
            upPanel.Update();
        }
    }
}