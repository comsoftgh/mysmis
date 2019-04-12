using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptTimeTable : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTimeTable()
        {
            InitializeComponent();
        }

        public rptTimeTable(int batchID,string dbTableName)
        {
            InitializeComponent();

            List<LessonTimetable> tt = new LessonTimetableService().GetAllLessonTimetableByClassSchedID(batchID,dbTableName, "1");
            this.DataSource = tt;
            xrBatchTitle.DataBindings.Add("Text", tt, "xClassSche");
            xrDays.DataBindings.Add("Text", tt, "LessDay");
            xrPeriod.DataBindings.Add("Text", tt, "LessTime");
            xrSubject.DataBindings.Add("Text", tt, "xLessonTitle");
            xrVenu.DataBindings.Add("Text", tt, "xVenueName");
            xrTutor.DataBindings.Add("Text", tt, "xTutorName");
            xrCode.DataBindings.Add("Text", tt, "xLessonCode");

        }

    }
}
