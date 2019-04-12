using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mySmisLib;
using System.IO;
using System.Collections.Generic;

namespace mySmis.reports
{
    public partial class rptTutorProfile : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTutorProfile()
        {
            InitializeComponent();
        }
        public rptTutorProfile(string studUserId)
        {
            InitializeComponent();
            xrPicheader.ImageUrl = "~/pictures/letter_head.jpg";
            Tutor st = new TutorService().GetTutor(studUserId);
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

            if (File.Exists("~/pictures/img_" + st.UserId + ".jpeg"))
            {

                xrPicbox.ImageUrl = "~/pictures/img_" + st.UserId + ".jpg";

            }
            else
            {
                //xrPicbox.ImageUrl = "~/images/default-person.jpg";
                xrPicbox.ImageUrl = "~/pictures/img_" + st.UserId + ".jpg";
            }


           List <TutorAcademics> ad = new TutorAcademicsService().GetTutorAcademics(studUserId);
           xrSubAcademicDetails.ReportSource = new mySmis.reports.rptSubTutorAcademics(ad);

           List<TutorRelatives> rl = new TutorRelativesService().GetTutorRelatives(studUserId);
           xrSubFamilyDetails.ReportSource = new mySmis.reports.rptSubTutorFamily(rl);
        }
    }
}
