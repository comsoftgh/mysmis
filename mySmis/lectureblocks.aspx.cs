using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class lectureblocks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);

            loadPrograms();
            loadLookUps();
            LoadUserPermissions();
        }

        private void loadPrograms()
        {
            dgBlocks.DataSource = new VenusService().GetAllVenus(new SessionManager().GetUserId(this.Session));
            dgBlocks.DataBind();
            dgRooms.DataSource = new VenuroomsService().GetAllVenurooms(new SessionManager().GetUserId(Session));
            dgRooms.DataBind();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smLectureHalls")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                        mMain.Items.FindByName("mitNew").Enabled = true;
                        mMainRooms.Items.FindByName("mitNew").Enabled = true;
                        break;
                    case "EXPORT":
                        mMain.Items.FindByName("mitExportxls").Enabled = true;
                        mMainRooms.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                        mMain.Items.FindByName("mitReport").Enabled = true;
                        mMainRooms.Items.FindByName("mitReport").Enabled = true;
                        break;
                }
            }

        }
        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearfields();
                    divProgram.Visible = true;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/abcprogram.aspx";
                    Session["report"] = new mySmis.reports.rptSchsDpts();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }


            uPanel.Update();
        }

        private void clearfields()
        {
            txtId.Text = "0";
            txtName.Text = "";
            txtDesc.Text = "";
        }

        private bool validateInputs()
        {
            bool isvalid = true;

            if (txtName.Text.Trim() == "")
            {
                txtName.IsValid = false;
                isvalid = false;
                txtName.ErrorText = "*";
            }
            if (txtDesc.Text.Trim() == "")
            {
                txtDesc.IsValid = false;
                isvalid = false;
                txtDesc.ErrorText = "*";
            }

            return isvalid;
        }
        protected void dgBlocks_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smLectureHalls"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Select:
                    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
            }

        }

        protected void dgBlocks_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgBlocks.CancelEdit();
            clearfields();
            txtId.Text = dgBlocks.GetRowValues(dgBlocks.FocusedRowIndex, "ID").ToString();
            txtDesc.Text = dgBlocks.GetRowValues(dgBlocks.FocusedRowIndex, "Description").ToString();
            txtName.Text = dgBlocks.GetRowValues(dgBlocks.FocusedRowIndex, "VenuName").ToString();

            divProgram.Visible = true;
            upBlocks.Update();
            uPanel.Update();
        }

        protected void btnSaveProgram_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                upBlocks.Update();
                uPanel.Update();
                return;
            }

            Venus mod = new Venus();

            mod.VenuName = txtName.Text;
            mod.Description = txtDesc.Text;

            if (txtId.Text == "0")
            {

                if (new VenusService().AddVenus(mod, new SessionManager().GetUserId(Session)))
                {
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

                }
            }
            else
            {
                mod.ID = int.Parse(txtId.Text);

                if (new VenusService().UpdateVenus(mod, new SessionManager().GetUserId(Session)))
                {
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);

                }
            }
            loadPrograms();
            upBlocks.Update();
            uPanel.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
            divProgram.Visible = false;
            upBlocks.Update();
            uPanel.Update();
        }

        protected void mMainRooms_ItemClick(object source, MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearfields();
                    divClasses.Visible = true;
                    break;
                case "mitExportxls":
                    expRooms.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/abcclass.aspx";
                    Session["report"] = new mySmis.reports.rptProgramsLevels();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
        }

        private void loadLookUps()
        {
            cmbVenus.DataSource = new VenusService().GetAllVenus(new SessionManager().GetUserId(Session));
            cmbVenus.DataBind();
        }
        protected void btnCanceRooms_Click(object sender, EventArgs e)
        {
            clearRooms();
            divClasses.Visible = false;
            upRooms.Update();
            uPanel.Update();
        }

        private void clearRooms()
        {
            txtIDRoom.Text = "0";
            txtNameRoms.Text = "";
            spinSize.Value = 0;
            cmbVenus.DataSource = null;
            cmbVenus.DataBind();
        }

        protected void btnSaveRooms_Click(object sender, EventArgs e)
        {
            if (!validateRooms())
            {
                upRooms.Update();
                uPanel.Update();
                return;
            }
            Venurooms classABC = new Venurooms();
            classABC.VenuId = int.Parse(cmbVenus.Value.ToString());
            classABC.RoomName = txtName.Text;
            classABC.Size = int.Parse(spinSize.Value.ToString());

            if (txtId.Text == "0")
            {


                if (new VenuroomsService().AddVenurooms(classABC, new SessionManager().GetUserId(Session)))
                {
                    clearRooms();

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);


                }
            }
            else
            {
                classABC.ID = int.Parse(txtIDRoom.Text);

                if (new VenuroomsService().UpdateVenurooms(classABC, new SessionManager().GetUserId(Session)))
                {
                    clearRooms();
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);

                }
            }
            loadPrograms();
            upRooms.Update();
            uPanel.Update();
        }

        private bool validateRooms()
        {
            bool isvalid = true;

            if (txtNameRoms.Text.Trim() == "")
            {
                txtNameRoms.IsValid = false;
                isvalid = false;
                txtNameRoms.ErrorText = "*";
            }
            if (spinSize.Value == null)
            {
                spinSize.IsValid = false;
                isvalid = false;
                spinSize.ErrorText = "*";
            }
            if (cmbVenus.Value == null)
            {
                cmbVenus.IsValid = false;
                isvalid = false;
                cmbVenus.ErrorText = "*";
            }

            return isvalid;
        }
        protected void dgRooms_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smLectureHalls"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Select:
                    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
            }
        }

        protected void dgRooms_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgRooms.CancelEdit();
            clearfields();
            txtIDRoom.Text = dgRooms.GetRowValues(dgRooms.FocusedRowIndex, "ID").ToString();
            spinSize.Value = dgRooms.GetRowValues(dgRooms.FocusedRowIndex, "Size").ToString();
            txtNameRoms.Text = dgRooms.GetRowValues(dgRooms.FocusedRowIndex, "RoomName").ToString();
            cmbVenus.Value = dgRooms.GetRowValues(dgRooms.FocusedRowIndex, "ID").ToString();
            divClasses.Visible = true;
            upRooms.Update();
            uPanel.Update();
        }
    }
}