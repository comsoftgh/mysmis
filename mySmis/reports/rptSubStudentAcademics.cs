using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptSubStudentAcademics : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSubStudentAcademics()
        {
            InitializeComponent();
        }

        public rptSubStudentAcademics(List<AcademicDetails> ad)
        {
            InitializeComponent();
            this.DataSource = ad;
            xrInstit.DataBindings.Add("Text", ad, "Institution");
            xrQuali.DataBindings.Add("Text", ad, "Qualification");
            xrLevel.DataBindings.Add("Text", ad, "AcademicLevel");
            xrFDate.DataBindings.Add("Text", ad, "DateAttended","{0: dd MMM yyyy}");
            xrTDate.DataBindings.Add("Text", ad, "DateCompleted", "{0: dd MMM yyyy}");
        }

    }
}
