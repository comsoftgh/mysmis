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
    public partial class feespayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPrograms();
            if (IsPostBack)
            {
                if (cmbProgram.Value != null)
                {
                    loadBatchFees();
                }
            }
            else
            {
                dtPayDate.Date = DateTime.Now;
            }
        }

        private void loadBatchFees()
        {
            gvStudents.DataSource = new StudentFeesService().GetStudentFeesAccounts(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            gvStudents.DataBind();

            uPanel.Update();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 600;

            cmbPayType.DataSource = new LookUpService().GetAllPaymetype();
            cmbPayType.ValueField = "lKey";
            cmbPayType.TextField = "lKey";
            cmbPayType.DataBind();

            uPanel.Update();
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                loadBatchFees();
            }
            else
            {
                div_payment.Visible = false;
                clearfields();
            }
            uPanel.Update();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smFeesPayment")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                       // mMainProgram.Items.FindByName("mitNew").Enabled = true;
                        //mMainProgram.Items.FindByName("mitCancel").Enabled = true;
                        break;
                    case "EXPORT":
                        //mMainProgram.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                       // mMainProgram.Items.FindByName("mitReport").Enabled = true;
                        break;
                }

            }
        }

        private void clearfields()
        {
            gvStudents.DataSource = null;
            gvStudents.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            div_payment.Visible = false;
            uPanel.Update();
        }

        private void clearFields()
        {
            spntAmt.Text = "";
            cmbBank.DataSource = null;
            cmbBank.DataBind();
            txtBranch.Text = "";
            txtCashedBy.Text = "";
            txtChequeNo.Text = "";
            txtstudID.Text = "";
            txtbatchID.Text = "";
            txtbgroup.Text = "";
            txtregID.Text = "";

            //cmbSearchCustomers.Value = null;
            div_payment.Visible = false;
        }

        protected void cmbPayType_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Value.ToString() == "Cheque")
            {
                cmbBank.DataSource = new LookUpService().GetAllBanks();
                cmbBank.ValueField = "lKey";
                cmbBank.TextField = "lValue";
                cmbBank.DataBind();

                txtBranch.Text = "";
                txtChequeNo.Text = "";
                txtCashedBy.Text = " ";
                txtCleared.Text = "No";
                div_Checque.Visible = true;
            }
            else
            {
                //value for bank is the id which is int.
                cmbBank.Value = "0";
                txtBranch.Text = "N/A";
                txtChequeNo.Text = "N/A";
                txtCashedBy.Text = "N/A";
                txtCleared.Text = "Yes";
                div_Checque.Visible = false;
            }

            uPanel.Update();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateInputs())
            {
                uPanel.Update();
                return;
            }
      
            FeesPayment fp = new FeesPayment();
            fp.Bank = int.Parse(cmbBank.Value.ToString());
            fp.BatchId = int.Parse(txtbatchID.Text);
            fp.Bgroup = txtbgroup.Text;
            fp.Branch = txtBranch.Text;
            fp.CashedBy = txtCashedBy.Text;
            fp.ChequeNo = txtChequeNo.Text;
            fp.Cleared = txtCleared.Text;
            fp.DateCreated = dtPayDate.Date;
            fp.LastModified = DateTime.Now;
            fp.PaidBy = txtPaidinBy.Text;
            fp.PayType = cmbPayType.Value.ToString();
            fp.Payvalue = double.Parse(spntAmt.Value.ToString());
            fp.ReceiptNo = txtReciept.Text;
            fp.StuduserId = txtstudID.Text;

            if(txtFpid.Text == "0")
            {

                if (new FeesPaymentService().AddFeesPayment(fp, new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    clearFields();

                
                Session["fromwhere"] = "~/feespayment.aspx";
                Session["report"] = new mySmis.reports.rptFeesReceipt(fp.ReceiptNo,new SessionManager().GetUserId(this.Session));

                Response.Redirect("~/documentviewer.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                }
            }
            else
            {
                fp.ID = int.Parse(txtFpid.Text);
                if (new FeesPaymentService().UpdateChequePayments(fp, new SessionManager().GetUserId(this.Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                clearFields();
                    
            Session["fromwhere"] = "~/feespayment.aspx";
            Session["report"] = new mySmis.reports.rptFeesReceipt(fp.ReceiptNo,new SessionManager().GetUserId(this.Session));

            Response.Redirect("~/documentviewer.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
            }
            }
            uPanel.Update();

        }

        private bool validateInputs()
        {
            bool isvalid = true;

            if (txtBranch.Text.Trim() == "")
            {
                txtBranch.IsValid = false;
                isvalid = false;
                
            }
            
            if (cmbProgram.Value == null)
            {
                cmbProgram.IsValid = false;
                isvalid = false;
                
            }
            if (txtChequeNo.Text.Trim() == "")
            {
                txtChequeNo.IsValid = false;
                isvalid = false;

            }
            if (cmbPayType.Value == null)
            {
                cmbPayType.IsValid = false;
                isvalid = false;

            }
            if (cmbBank.Value == null)
            {
                cmbBank.IsValid = false;
                isvalid = false;

            }
            if (txtCleared.Text.Trim() == "")
            {
                txtCleared.IsValid = false;
                isvalid = false;

            }
            if (txtPaidinBy.Text.Trim() == "")
            {
                txtPaidinBy.IsValid = false;
                isvalid = false;

            }
            if (txtReciept.Text.Trim() == "")
            {
                txtReciept.IsValid = false;
                isvalid = false;

            }
            if (dtPayDate.Date == null)
            {
                dtPayDate.IsValid = false;
                isvalid = false;

            }

            return isvalid;
        }
        protected void gvStudents_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;

            StudentFees sf = new StudentFeesService().GetStudentFeesById(int.Parse(e.EditingKeyValue.ToString()),new SessionManager().GetUserId(this.Session));
            txtbatchID.Text = sf.BatchId.ToString();
            txtbgroup.Text = sf.Bgroup.ToString();
            txtstudID.Text = sf.UserId.ToString();
            spntAmt.Value = new StudentFeesService().GetStudentFeesById(sf.ID,new SessionManager().GetUserId(this.Session)).xFeesLeft.ToString();
            spntAmt.MaxValue = decimal.Parse(sf.Feevalue.ToString());
            txtStudentName.Text = sf.xFullName;
            txtIndexNo.Text = sf.xIndexNo;
            txtReciept.Text = (new InstanceConfigServices().GetConfig("receiptNo") + new FeesPaymentService().CountFeesPayment(new SessionManager().GetUserId(this.Session))).ToString();
            div_payment.Visible = true;
            gvStudents.CancelEdit();
            uPanel.Update();
        }

        protected void gvStudents_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smFeesPayment"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }


        protected void gvPayments_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            if (cmbProgram.Value != null)
            {
                gv.DataSource = new FeesPaymentService().GetAllFeesPayment(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ClassID").ToString()), new StudentFeesService().GetStudentFeesById(int.Parse(gv.GetMasterRowKeyValue().ToString()), new SessionManager().GetUserId(this.Session)).UserId, new SessionManager().GetUserId(Session));
            }
        }

        protected void gvPayments_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            if(new FeesPaymentService().DeleteFeesPayment(int.Parse(e.Values.ToString()), new SessionManager().GetUserId(this.Session)))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }

            upFeesBatches.Update();
            uPanel.Update();
        }

        protected void gvPayments_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smFeesPayment"));

            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            { if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            { if (perms.Contains("DELETE")) { e.Visible = true; } else { e.Enabled = false; } }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            { if (perms.Contains("VIEW")) { e.Visible = true; } else { e.Enabled = false; } }
        }

        protected void gvPayments_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;
            FeesPayment sf = new FeesPaymentService().GetFeesPayment(int.Parse(e.EditingKeyValue.ToString()), new SessionManager().GetUserId(this.Session));
            txtbatchID.Text = sf.BatchId.ToString();
            txtbgroup.Text = sf.Bgroup.ToString();
            txtstudID.Text = sf.StuduserId.ToString();
            txtStudentName.Text = sf.xFullName;
            txtIndexNo.Text = sf.xIndexNo;
            txtReciept.Text = sf.ReceiptNo;
            spntAmt.Text = sf.Payvalue.ToString();
            txtbatchID.Text = sf.BatchId.ToString();
            txtPaidinBy.Text = sf.PaidBy;
            txtFpid.Text = sf.ID.ToString();

            if (sf.PayType.ToString() == "Cheque")
            {
                
                cmbBank.DataSource = new LookUpService().GetAllBanks();
                cmbBank.ValueField = "lKey";
                cmbBank.TextField = "lValue";
                cmbBank.Value = sf.Bank.ToString();
                cmbBank.Text = sf.Bank.ToString();
                cmbBank.DataBind();

                txtBranch.Text = sf.Branch;
                txtCashedBy.Text = sf.CashedBy;
                txtChequeNo.Text = sf.ChequeNo;
                txtCleared.Value = sf.Cleared.ToString();
                div_Checque.Visible = true;
            }
            else
            {
                cmbBank.Value = "N/A";
                txtBranch.Text = "N/A";
                txtChequeNo.Text = "N/A";
                txtCashedBy.Text = "N/A";
                txtCleared.Text = "Yes";
                div_Checque.Visible = false;
            }

            div_payment.Visible = true;
            gvStudents.CancelEdit();
            uPanel.Update();
        }

        protected void gvStudents_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Session["fromwhere"] = "~/feespayment.aspx";
            Session["report"] = new mySmis.reports.rptProgramsLevels();
            Response.Redirect("~/documentviewer.aspx");
        }

        protected void gvPayments_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView gv = (ASPxGridView)sender;
            Session["fromwhere"] = "~/feespayment.aspx";
            Session["report"] = new mySmis.reports.rptFeesReceipt(gv.GetRowValues(gv.FocusedRowIndex,"ReceiptNo").ToString(), new SessionManager().GetUserId(this.Session));

            Response.Redirect("~/documentviewer.aspx");
        }

       



    }
}