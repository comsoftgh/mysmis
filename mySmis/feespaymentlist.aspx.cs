using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace mySmis
{
    public partial class feespaymentlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (cmbProgram.Value != null)
                {
                    loadPaymentsBatch();
                }
                else
                {
                    loadPayments();
                }
            }
            else
            {
                loadPayments();
            }
            loadPrograms();
        }

        private void loadPaymentsBatch()
        {
            gvPayments.DataSource = new FeesPaymentService().GetAllFeesPayment(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(this.Session));
            gvPayments.DataBind();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 600;
            uPanel.Update();
        }


        private void loadPayments()
        {
            gvPayments.DataSource = new FeesPaymentService().GetAllFeesPayment(new SessionManager().GetUserId(this.Session));
            gvPayments.DataBind();
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                loadPaymentsBatch();
            }
            else
            {
                loadPayments();
            }
        }

        protected void gvPayments_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            gvPayments.CancelEdit();
            
        }

        protected void gvPayments_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                
                Session["fromwhere"] = "~/feespaymentlist.aspx";
                Session["report"] = new mySmis.reports.rptFeesReceipt(gvPayments.GetRowValues(gvPayments.FocusedRowIndex, "ReceiptNo").ToString(), new SessionManager().GetUserId(this.Session));

                Response.Redirect("~/documentviewer.aspx");
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Oops something is not right!','Message')", true);
            }
        }

        protected void gvPayments_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }
        protected void gvPayments_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPaymentList"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/feespaymentlist.aspx";
                    Session["report"] = new mySmis.reports.rptFeesPayments();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }
        }
    }
}