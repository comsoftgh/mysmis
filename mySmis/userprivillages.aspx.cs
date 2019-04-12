using DevExpress.Web;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class userprivillages : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);

            LoadUsers();
            LoadMainMenu();

            if (IsPostBack)
            {
                if (txtEditStafid.Text != "0")
                {
                    loadStaffAccess(txtEditStafid.Text);
                }
                if (cmbEditpermissions.Value != null)
                {
                    reloadEditPermissions(txtEditStafid.Text, int.Parse(cmbEditpermissions.Value.ToString()));
                    uPanel.Update();
                }

            }
        }

        private void LoadUsers()
        {
            gvStaffUsers.DataSource = new UserService().GetAdminUsers("Administrator", "Administrator", "Administrator - Tutor", new SessionManager().GetUserId(this.Session));
            gvStaffUsers.DataBind();
        }

        protected void gvStaffPermission_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            gv.DataSource = new UserPermissionService().GetUserPermissions(gv.GetMasterRowKeyValue().ToString(), new SessionManager().GetUserId(this.Session));
        }

        protected void gvStaffUsers_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {

        }

        protected void gvStaffUsers_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;

            
            txtstaffName.Text = gvStaffUsers.GetRowValues(gvStaffUsers.FocusedRowIndex, "xFullName").ToString();
            txtstaffId.Text = gvStaffUsers.GetRowValues(gvStaffUsers.FocusedRowIndex, "UserId").ToString();
            div_permissions.Visible = true;
            div_editpermissions.Visible = false;
            cleargvPrivillages();
            gvStaffUsers.CancelEdit();
            uPanel.Update();

        }

        private void LoadMainMenu()
        {
            cmbMainMenu.DataSource = new MenuMainService().GetMenuMain(new SessionManager().GetUserId(this.Session));
            cmbMainMenu.DataBind();
        }

        protected void gvStaffPermission_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {

        }

        protected void cmbMainMenu_ValueChanged(object sender, EventArgs e)
        {
            if (cmbMainMenu.Value != null)
            {
                if (txtstaffId.Text != "0")
                {
                    loadprivillages(int.Parse(cmbMainMenu.Value.ToString()), txtstaffId.Text);
                   
                }
            }
            else
            {
                cleargvPrivillages();

            }
            uPanel.Update();
        }

        private void loadprivillages(int mmid,string staffid)
        {
            gvPrivillages.DataSource = new MenuSubService().GetMenuSubUserHasNot(mmid, staffid, new SessionManager().GetUserId(this.Session));
            gvPrivillages.DataBind();
        }

        private void cleargvPrivillages()
        {
            gvPrivillages.DataSource = null;
            gvPrivillages.DataBind();

        }

        protected void gvPrivillages_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.Name == "xActivity")
            {
                GridViewDataTokenBoxColumn pTokenBox = gvPrivillages.Columns["xActivity"] as GridViewDataTokenBoxColumn;
                pTokenBox.PropertiesTokenBox.DataSource = new LookUpService().GetPrivillages();
                pTokenBox.PropertiesTokenBox.DataMember = "LValue";

            }
        }

        protected void gvPrivillages_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {

        }

        protected void gvPrivillages_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;
            string pvbatch = "";
            //CHECK IF MAIN MENU ACCESS HAS BEEN ASSIGNED TO THIS STAFF ALREADY
            if (cmbMainMenu.Value != null)
            {

                UserAccess us = new UserAccess();
                us.MainId = int.Parse(cmbMainMenu.Value.ToString());
                us.UserId = txtstaffId.Text;

                if (new UserAccessService().ExistUserAccess(us, new SessionManager().GetUserId(this.Session)))
                {

                }
                else
                {
                    us.DateCreated = DateTime.Now;
                    us.LastModify = DateTime.Now;
                    if (new UserAccessService().AddUserAccess(us, new SessionManager().GetUserId(this.Session)))
                    {

                        for (int i = 0; i < e.UpdateValues.Count; i++)
                        {
                            pvbatch += "('" + txtstaffId.Text + "','" + int.Parse(cmbMainMenu.Value.ToString()) + "','" + int.Parse(e.UpdateValues[i].NewValues[1].ToString()) + "','" + e.UpdateValues[i].NewValues[2].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                        }

                        if (new UserPermissionService().AddUserPermissionList(pvbatch.TrimEnd(','), new SessionManager().GetUserId(this.Session)))
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                            loadprivillages(int.Parse(cmbMainMenu.Value.ToString()), us.UserId);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops something is not right!','Message')", true);

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Please select an Access Level.','Message')", true);
                cmbMainMenu.IsValid = false;

            }
            LoadUsers();
            cleargvPrivillages();
            LoadMainMenu();
            uPanel.Update();
            UpPrivillages.Update();
        }

        protected void mMainPrivilage_ItemClick(object source, MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitCancel")
            {
                div_permissions.Visible = false;
                txtstaffId.Text = "0";
                cleargvPrivillages();
            }

            uPanel.Update();
        }

        protected void gvStaffUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            txtEditStafid.Text = e.Values[0].ToString();

            loadStaffAccess(e.Values[0].ToString());
            txtEditStafName.Text = gvStaffUsers.GetRowValues(gvStaffUsers.FocusedRowIndex, "xFullName").ToString();
            div_editpermissions.Visible = true;
            div_permissions.Visible = false;
            uPanel.Update();
            UpPrivillages.Update();
        }

        private void loadStaffAccess(string staffId)
        {
            cmbEditpermissions.DataSource = new UserPermissionService().GetUserDistinctPermissions(staffId, new SessionManager().GetUserId(this.Session));
            cmbEditpermissions.TextField = "MainMenu";
            cmbEditpermissions.ValueField = "MainId";
            cmbEditpermissions.DataBind();
        }

        private void clearEditPermissions()
        {
            gvEditpermissions.DataSource = null;
            gvEditpermissions.DataBind();

            txtEditStafid.Text = "0";
            txtEditStafName.Text = "";
        }

        private void reloadEditPermissions(string staffID, int mainId)
        {
            gvEditpermissions.DataSource = new UserPermissionService().GetUserPermissions(staffID, mainId, new SessionManager().GetUserId(this.Session));
            gvEditpermissions.DataBind();
        }

        protected void cmbEditpermissions_ValueChanged(object sender, EventArgs e)
        {
            if (cmbEditpermissions.Value != null)
            {
                
                    reloadEditPermissions(txtEditStafid.Text, int.Parse(cmbEditpermissions.Value.ToString()));
                    uPanel.Update();
               
            }
            else
            {
                

            }
            
        }
        protected void mMaineditpermissions_ItemClick(object source, MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitCancel")
            {
                div_editpermissions.Visible = false;
                clearEditPermissions();
            }

            UpPrivillages.Update();
        }

        protected void gvStaffPermission_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }

        protected void gvStaffPermission_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;

            if (new UserPermissionService().DeleteUserPermission(int.Parse(gv.GetRowValues(gv.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }

            LoadUsers();
            uPanel.Update();
        }

        
        protected void gvEditpermissions_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.Name == "Activity")
            {

                GridViewDataTokenBoxColumn pTokenBox = gvEditpermissions.Columns["Activity"] as GridViewDataTokenBoxColumn;
                pTokenBox.PropertiesTokenBox.DataSource = new LookUpService().GetPrivillages();
                pTokenBox.PropertiesTokenBox.DataMember = "LValue";

            }
        }


        protected void gvEditpermissions_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;

            if (e.UpdateValues.Count != 0)
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    UserPermission up = new UserPermission();
                    up.Id = int.Parse(e.UpdateValues[i].Keys[0].ToString());
                    up.Activity = e.UpdateValues[i].NewValues[0].ToString();
                    new UserPermissionService().UpdateUserPermission(up, new SessionManager().GetUserId(this.Session));   
                    
                }

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
            }
            if (e.DeleteValues.Count != 0)
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    
                    new UserPermissionService().DeleteUserPermission(int.Parse(e.DeleteValues[i].Keys[0].ToString()), new SessionManager().GetUserId(this.Session));   
                    
                }

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }

            if (cmbEditpermissions.Value != null)
            {

                reloadEditPermissions(txtEditStafid.Text, int.Parse(cmbEditpermissions.Value.ToString()));
                uPanel.Update();

            }

            gvEditpermissions.CancelEdit();
            LoadUsers();
            UpPrivillages.Update();
        }

       
       
       

        


    }
}