using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.Collections.Generic;
using System.IO;

namespace mySmis.reports
{
    public partial class rptStudentProfile : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStudentProfile()
        {
            InitializeComponent();
        }

        public rptStudentProfile(string studUserId)
        {
            InitializeComponent();
            xrPicheader.ImageUrl = "~/pictures/letter_head.jpg";
            Student st = new StudentService().GetStudent(studUserId);
            xrAdmissDate.Text = st.Admissiondate.ToString("dd MMMM yyyy");
            xrID.Text = st.IndexNo;
            xrGender.Text = st.Gender;
            xrEmail.Text = st.Email;
            xrDoB.Text = st.Dob.ToString("dd MMMM yyyy");
            xrMobile.Text = st.Mobile;
            xrNationality.Text = st.Nationality;
            xrONames.Text = st.ONames;
            xrPostAdd.Text = st.PostAdd;
            xrReligon.Text = st.Religion;
            xrResAdd.Text = st.ResAdd;
            xrSname.Text = st.SName;
            xrTel.Text = st.Tel;
            xrFName.Text = st.FNames;

            string u = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "pictures\\img_" + st.UserId + ".jpg";
            if (File.Exists(u)) { xrPicbox.ImageUrl = "~/pictures/img_" + st.UserId + ".jpg"; } else { xrPicbox.ImageUrl = "~/images/default-person.jpg"; }



           List <AcademicDetails> ad = new AcademicDetailsService().GetAcademicDetails(studUserId);
           xrSubAcademicDetails.ReportSource = new mySmis.reports.rptSubStudentAcademics(ad);

           List<Relative> rl = new RelativeService().GetRelatives(studUserId);
           xrSubFamilyDetails.ReportSource = new mySmis.reports.rptSubRelatives(rl);
        }
    }
}
