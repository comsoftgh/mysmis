using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class feeschequeconciliation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            loadPayments();
        }

        private void loadPayments()
        {
            gvPayments.DataSource = new FeesPaymentService().GetAllUnclearedCheques("Cheque", new SessionManager().GetUserId(this.Session));
            gvPayments.DataBind();
        }

        protected void gvPayments_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;

            FeesPayment fp = new FeesPaymentService().GetFeesPayment(int.Parse(e.EditingKeyValue.ToString()),new SessionManager().GetUserId(this.Session));
            txtBranch.Text      = fp.Branch;
            txtChequeNo.Text    = fp.ChequeNo;
            txtIndexNo.Text     = fp.xIndexNo;
            txtpayID.Text       = fp.ID.ToString();
            txtStudentName.Text = fp.xFullName;
            txtBank.Text = fp.xBankName;
            div_payment.Visible = true;
            gvPayments.CancelEdit();
            loadPayments();
            uPanel.Update();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FeesPayment fp = new FeesPayment();
            fp.ID = int.Parse(txtpayID.Text);
            fp.LastModified = dtPayDate.Date;
            fp.CashedBy = txtCashedBy.Text;
            fp.Cleared = "Yes";

            if (new FeesPaymentService().UpdateChequePayments(fp, new SessionManager().GetUserId(this.Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
            }

            div_payment.Visible = false;
            clearfields();
            loadPayments();
            uPanel.Update();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            div_payment.Visible = false;

            clearfields();
            uPanel.Update();
        }

        private void clearfields()
        {
            txtpayID.Text = "0";
            txtIndexNo.Text = "";
            txtCleared.Text = "";
            txtChequeNo.Text = "";
            txtCashedBy.Text = "";
            txtBranch.Text = "";
            txtStudentName.Text = "";
        }

        protected void gvPayments_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smClassLesson"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }
    }
}