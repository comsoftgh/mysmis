using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptSubRelatives : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSubRelatives()
        {
            InitializeComponent();
        }

        public rptSubRelatives(List<Relative> rl)
        {
            InitializeComponent();
            this.DataSource = rl;
            xrRelation.DataBindings.Add("Text", rl, "RelType");
            xrName.DataBindings.Add("Text", rl, "xFullName");
            xrNxtKin.DataBindings.Add("Text", rl, "NextOfKin");
            xrContact.DataBindings.Add("Text", rl, "Mobile");
        }
    }
}
