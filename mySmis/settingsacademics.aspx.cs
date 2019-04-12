using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class settingsacademics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                LoadGeneralConfig();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            new InstanceConfigServices().AddConfig(lessonsRegistration.ID, lessonsRegistration.Value.ToString(), new SessionManager().GetUserId(this.Session));

            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saving Failed','Message')", true);

            LoadGeneralConfig();
            upPanel.Update();
        }

        private void LoadGeneralConfig()
        {
            
            lessonsRegistration.Value = new InstanceConfigServices().GetConfig(lessonsRegistration.ID);
            examshigerscore.Value = new InstanceConfigServices().GetConfig(examshigerscore.ID);
            studentAttendance.Value = new InstanceConfigServices().GetConfig(studentAttendance.ID);
            
        }
    }
}