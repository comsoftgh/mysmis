using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class settingsstudent : System.Web.UI.Page
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
            new InstanceConfigServices().AddConfig(indexDynamic.ID, indexDynamic.Value.ToString(), new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(indexSeperator.ID, indexSeperator.Value.ToString(), new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(indexStartingNo.ID, indexStartingNo.Text, new SessionManager().GetUserId(this.Session));
            new InstanceConfigServices().AddConfig(indexString.ID, indexString.Text, new SessionManager().GetUserId(this.Session));


            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saving Failed','Message')", true);

            LoadGeneralConfig();
            upPanel.Update();
        }
        
        private void LoadGeneralConfig()
        {
            indexDynamic.Value = new InstanceConfigServices().GetConfig(indexDynamic.ID);
            indexSeperator.Value = new InstanceConfigServices().GetConfig(indexSeperator.ID);
            indexStartingNo.Text = new InstanceConfigServices().GetConfig(indexStartingNo.ID);
            indexString.Text = new InstanceConfigServices().GetConfig(indexString.ID);
        }
    }
}