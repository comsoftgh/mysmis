using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.Web;

namespace mySmis
{
    public partial class usersadministrator : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadMainMenu();

            //if (IsPostBack)
            //{
            //    if (Session["editpermission"] != null)
            //    {
            //        reloadEditPermissions(Session["editpermission"].ToString());
            //    }
            //}
        }

        private void LoadUsers()
        {
            gvStaffUsers.DataSource = new UserService().GetAllUsers("Administrator", new SessionManager().GetUserId(this.Session));
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
            gvStaffUsers.CancelEdit();

            txtstaffId.Text = gvStaffUsers.GetRowValues(gvStaffUsers.FocusedRowIndex, "UserId").ToString();
            div_permissions.Visible = true;
            div_editpermissions.Visible = false;
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
                    gvPrivillages.DataSource = new MenuSubService().GetMenuSubUserHasNot(int.Parse(cmbMainMenu.Value.ToString()), txtstaffId.Text, new SessionManager().GetUserId(this.Session));
                    gvPrivillages.DataBind();
                }
            }
            else
            {
                cleargvPrivillages();
                
            }
            uPanel.Update();
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

                if(new UserAccessService().ExistUserAccess(us,new SessionManager().GetUserId(this.Session)))
                {
             
                }
                else 
                {
                    us.DateCreated = DateTime.Now;
                    us.LastModify = DateTime.Now;
                    if(new UserAccessService().AddUserAccess(us,new SessionManager().GetUserId(this.Session)))
                    {

                    for (int i = 0; i < e.UpdateValues.Count; i++)
                    {
                        pvbatch += "('" + txtstaffId.Text + "','" + int.Parse(cmbMainMenu.Value.ToString()) + "','" + int.Parse(e.UpdateValues[i].NewValues[1].ToString()) + "','" + e.UpdateValues[i].NewValues[2].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                    }

                    if (new UserPermissionService().AddUserPermissionList(pvbatch.TrimEnd(','), new SessionManager().GetUserId(this.Session)))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
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
            }
            
            uPanel.Update();
        }

        protected void gvStaffUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            //Session["editpermission"] = e.Values[0].ToString();
           
            //if (Session["editpermission"].ToString() != null)
            //{
            reloadEditPermissions(e.Values[0].ToString());
           // }
            div_editpermissions.Visible = true;
            div_permissions.Visible = false;
            uPanel.Update();
        }

        private void reloadEditPermissions(string staffID)
        {
            gvEditpermissions.DataSource = new UserPermissionService().GetUserPermissions(staffID, new SessionManager().GetUserId(this.Session));
            gvEditpermissions.DataBind();
        }

        protected void mMaineditpermissions_ItemClick(object source, MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitCancel")
            {

                div_editpermissions.Visible = false;
                
            }

            uPanel.Update();
        }

        protected void gvEditpermissions_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void gvEditpermissions_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {

        }

        protected void gvEditpermissions_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

        }

        protected void gvEditpermissions_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

        protected void gvEditpermissions_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

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

        


        

       
    }
}