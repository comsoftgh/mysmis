using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;

namespace mySmis.reports
{
    public partial class rptSchsDpts : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSchsDpts()
        {
            InitializeComponent();

            xrPicheader.ImageUrl = "~/pictures/letter_head.jpg";
            //xrPicheader.Sizing;
            
        }

    }
}
