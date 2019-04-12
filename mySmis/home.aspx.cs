using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;

namespace mySmis
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            new SessionManager().InitDBConnection();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 5, 16, "ADD")) { btnNewStudent.Enabled = true; btnNewStudent.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 5, 17, "VIEW")) { btnStudents.Enabled = true; btnStudents.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 6, 19, "VIEW")) { btnStaffs.Enabled = true; btnStaffs.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 3, 7, "ADD")) { btnBatches.Enabled = true; btnBatches.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 10, 29, "ADD")) { btnParentUsers.Enabled = true; btnParentUsers.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 10, 26, "ADD")) { btnNewUser.Enabled = true; btnNewUser.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 7, 23, "ADD")) { btnPayFees.Enabled = true; btnPayFees.ToolTip = "Accessible"; }
            if (new PermissionService().CheckPermissions(new SessionManager().GetUserId(this.Session), 7, 24, "VIEW")) { btnPayments.Enabled = true; btnPayments.ToolTip = "Accessible"; }
        }

        protected void cmbSearchCustomers_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
           // ASPxComboBox comboBox = (ASPxComboBox)source;
           // List<MemberResult> mrList = new MemberService().FindMember(e.Filter, e.BeginIndex, e.EndIndex + 5, new SessionManager().GetUserId(this.Session));
            //comboBox.DataSource = mrList;
            //comboBox.DataBind();
        }

        protected void cmbSearchCustomers_ItemRequestedByValue(object source, DevExpress.Web.ListEditItemRequestedByValueEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() != "")
            {
               // MemberResult selected = new MemberResult();
              //  ASPxComboBox comboBox = (ASPxComboBox)source;
              //  List<MemberResult> mrList = new List<MemberResult>();
               // mrList.Add(new MemberService().GetMemberResult(e.Value.ToString().Trim(), new SessionManager().GetUserId(this.Session)));
               // comboBox.DataSource = mrList;
               // comboBox.DataBind();
            }
            else
            {
            }
        }

        protected void cmbSearchCustomers_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("~/newregistration.aspx?action=edit&id=" + cmbSearchCustomers.Value.ToString());
            }
            catch (Exception)
            {
                //ASPxWebControl.RedirectOnCallback("~/newregistration.aspx?action=edit&id=" + cmbSearchCustomers.Value.ToString());
            }   
        }

        protected void btnStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/studentlist.aspx");
        }

        protected void btnNewStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/studentnew.aspx");
        }

        protected void btnPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/feespaymentlist.aspx");
        }

        protected void btnPayFees_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/feespayment.aspx");
        }

        protected void btnParentUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/usersparent.aspx");
        }

        protected void btnBatches_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/classScheduler.aspx");
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/users.aspx");
        }

        protected void btnStaffs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/teachingstafflist.aspx");
        }
    }
}