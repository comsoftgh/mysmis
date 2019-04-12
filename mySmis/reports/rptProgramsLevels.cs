using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mySmis.reports
{
    public partial class rptProgramsLevels : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProgramsLevels()
        {
            InitializeComponent();
            xrPicheader.ImageUrl = "~/pictures/letter_head.jpg";
        }

    }
}
