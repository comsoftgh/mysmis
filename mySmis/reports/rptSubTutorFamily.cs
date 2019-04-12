using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptSubTutorFamily : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSubTutorFamily()
        {
            InitializeComponent();
        }

        public rptSubTutorFamily(List<TutorRelatives> rl)
        {
            InitializeComponent();
            this.DataSource = rl;
            xrRelation.DataBindings.Add("Text", rl, "RelType");
            xrName.DataBindings.Add("Text", rl, "xFullName");
            xrContact.DataBindings.Add("Text", rl, "NextOfKin");
            xrContact.DataBindings.Add("Text", rl, "Mobile");
        }
    }
}
