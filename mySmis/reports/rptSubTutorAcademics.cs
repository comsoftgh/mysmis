using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptSubTutorAcademics : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSubTutorAcademics()
        {
            InitializeComponent();
        }

        public rptSubTutorAcademics(List <TutorAcademics> tu)
        {
            InitializeComponent();
            this.DataSource = tu;
            xrInstit.DataBindings.Add("Text", tu, "Institution");
            xrLevel.DataBindings.Add("Text", tu, "Qualification");
            xrLevel.DataBindings.Add("Text", tu, "AcademicLevel");
            xrFDate.DataBindings.Add("Text", tu, "DateAttended", "{0: dd MMM yyyy}");
            xrTDate.DataBindings.Add("Text", tu, "DateCompleted", "{0: dd MMM yyyy}");
            
        }

    }
}
