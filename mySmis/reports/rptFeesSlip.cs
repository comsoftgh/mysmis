using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptFeesSlip : DevExpress.XtraReports.UI.XtraReport
    {
        public rptFeesSlip()
        {
            InitializeComponent();
        }

        public rptFeesSlip(string studUserId,int batchId)
        {
            InitializeComponent();
            xrPicheader.ImageUrl = "~/pictures/letter_head.jpg";

            
            StudentRegistration st = new StudentRegistrationService().GetStudentRegistrationByBatchId(batchId, studUserId, "1");
            xrID.Text = st.xIndexNo;
            xrAcademic.Text = st.xAcademicYear;
            xrProgram.Text = st.xProgram;
            xrONames.Text = st.xONames;
            xrSname.Text = st.xSName;
            xrFName.Text = st.xFNames;
            xrTerm.Text = st.xTerm;

            List<StudentFees> stf = new StudentFeesService().GetStudentFees(studUserId, batchId, "1");
            this.DataSource = stf;
            xrFees.DataBindings.Add("Text", stf, "xFeeTitle");
            xrFeeAmt.DataBindings.Add("Text", stf, "Feevalue");

            xrFessTotal.DataBindings.Add("Text", stf, "Feevalue");

        }
    }
}
