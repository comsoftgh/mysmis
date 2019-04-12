using DevExpress.DataAccess.ConnectionParameters;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class adminstudentpopulationdashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters param = e.ConnectionParameters as MySqlConnectionParameters;

            if (param != null)
            {

                param.DatabaseName = new InstanceConfigServices().GetConfig("dbname");
                param.Password = new InstanceConfigServices().GetConfig("dbpws");
                param.ServerName = new InstanceConfigServices().GetConfig("dbserver");
                param.UserName = new InstanceConfigServices().GetConfig("dbuser");
            }
        }
    }
}