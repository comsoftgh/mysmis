using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;

namespace mySmis.reports
{
    public partial class rptFeesReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public rptFeesReceipt()
        {
            InitializeComponent();
        }

        public rptFeesReceipt(string receiptNo,string userId)
        {
            InitializeComponent();
            xrPicheader.ImageUrl = "~/pictures/letter_head.jpg";

            string curency = new InstanceConfigServices().GetConfig("moneyCurency");
            
            xrPowered.Text = "powered by : " + new InstanceConfigServices().GetConfig("developedBy") + " :: " + new InstanceConfigServices().GetConfig("developerWeb");

            FeesPayment fp = new FeesPaymentService().GetFeesPayment(receiptNo);
            xrStudID.Text = fp.xIndexNo.ToString();
            xrStudName.Text = fp.xFullName;
            xrPayDate.Text = fp.DateCreated.Date.ToString();
            xrChequeNo.Text = fp.ChequeNo;
            xrPayMode.Text = fp.PayType.ToString();
            xrCashier.Text = fp.xCashier;
            xrPaidBy.Text = fp.PaidBy;
            xrReceiptNo.Text = fp.ReceiptNo;
            xrTerm.Text = fp.xCourse +" "+ fp.xTerm;
            xrAcademic.Text = fp.xAcademic;
            xrAmtPaid.Text = curency + " " + fp.Payvalue.ToString();
            
            
            
            StudentFees sf = new StudentFeesService().GetStudentFeesAccounts(fp.StuduserId,fp.BatchId,userId);
            xrTotalFees.Text = curency + " " + sf.xFeevalue.ToString();
            xrTotalPayments.Text = curency + " " + sf.xPayments.ToString();
            xrFessBalance.Text = curency + " " + sf.xFeesLeft.ToString();
        }

    }
}
