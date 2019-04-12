using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using mySmis.Code;
using mySmisLib;
using DevExpress.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace mySmis
{
    public partial class trainingtutors : System.Web.UI.Page
    {
        private SessionManager sessMgr = new SessionManager();

        private const string UPLOAD_DIR = "~/pictures/";
        private const string UPLOAD_DIR_CLIENTSIDE = "pictures/";
        private const string UPEDU_DIR = "~/tutoredudoc/";

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtIndexNo.Text = new TutorService().IndexNumber();
            LoadlookUps();

            txtIndexNo.Text = new InstanceConfigServices().GetConfig("staffID") == "Yes" ? new TutorService().TutorIDNumber() : "99999";

            if (!IsPostBack)
            {

                memberTabs.ActiveTabIndex = 0;

                if (Request.QueryString["action"] != null && Request.QueryString["action"] == "edit" && Request.QueryString["stdid"] != null && Request.QueryString["userid"] != null)
                {

                    memberTabs.TabPages[0].ClientEnabled = true;
                    memberTabs.TabPages[1].ClientEnabled = true;
                    memberTabs.TabPages[2].ClientEnabled = true;
                    // memberTabs.TabPages[3].ClientEnabled = true;

                    LoadStudent(Request.QueryString["userid"].ToString());
                    LoadEducation(Request.QueryString["userid"].ToString());
                    LoadFamily(Request.QueryString["userid"].ToString());

                }

                else
                {

                    memberTabs.TabPages[0].ClientEnabled = true;
                    memberTabs.TabPages[1].ClientEnabled = false;
                    memberTabs.TabPages[2].ClientEnabled = false;
                    //memberTabs.TabPages[3].ClientEnabled = false;


                }
            }
        }

        /// <summary>
        /// LOOKUPS AND GRIDVIEWS FUNCTIONS 
        /// </summary>

        private void LoadlookUps()
        {

            try
            {
                cmbTitle.DataSource = new LookUpService().GetAllTitles();
                cmbTitle.ValueField = "LValue";
                cmbTitle.TextField = "LValue";
                cmbTitle.DataBind();

                cmbGender.DataSource = new LookUpService().GetGender();
                cmbGender.ValueField = "LValue";
                cmbGender.TextField = "LValue";
                cmbGender.DataBind();

                cmbReligion.DataSource = new LookUpService().GetReligion();
                cmbReligion.ValueField = "LValue";
                cmbReligion.TextField = "LValue";
                cmbReligion.DataBind();

                cmbMarital.DataSource = new LookUpService().GetMaritalStatus();
                cmbMarital.ValueField = "LValue";
                cmbMarital.TextField = "LValue";
                cmbMarital.DataBind();

                cmbNationality.DataSource = new LookUpService().GetCountryList();
                cmbNationality.ValueField = "LValue";
                cmbNationality.TextField = "LValue";
                cmbNationality.DataBind();

                cmbEduLevel.DataSource = new LookUpService().GetAcademicLevels();
                cmbEduLevel.ValueField = "LValue";
                cmbEduLevel.TextField = "LValue";
                cmbEduLevel.DataBind();

                cmbFamRelative.DataSource = new LookUpService().GetRelativeTypes();
                cmbFamRelative.ValueField = "LValue";
                cmbFamRelative.TextField = "LValue";
                cmbFamRelative.DataBind();

                cmbStaffType.DataSource = new LookUpService().GetUserTypesAdminTutors();
                cmbStaffType.ValueField = "LValue";
                cmbStaffType.TextField = "LValue";
                cmbStaffType.DataBind();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops something is not right','Message')", true);
            }
        }

        private void LoadStudent(string studID)
        {
            Tutor st = new TutorService().GetTutor(studID, new SessionManager().GetUserId(this.Session));
            txtFName.Text = st.FNames;
            txtIndexNo.Text = st.IndexNo;
            txtMobile.Text = st.Mobile;
            txtONames.Text = st.ONames;
            txtPostalAddress.Text = st.PostAdd;
            txtResAddress.Text = st.ResAdd;
            txtSName.Text = st.SName;
            txtStudUserID.Text = st.UserId;
            txtTel.Text = st.Tel;
            txtEmail.Text = st.Email;
            dtDOB.Date = st.Dob.Date;
            cmbGender.Value = st.Gender.ToString();
            cmbGender.Text = st.Gender.ToString();
            cmbMarital.Value = st.Marital.ToString();
            cmbMarital.Text = st.Marital.ToString();
            cmbNationality.Value = st.Nationality.ToString();
            cmbNationality.Text = st.Nationality.ToString();
            cmbReligion.Value = st.Religion.ToString();
            cmbReligion.Text = st.Religion.ToString();
            cmbTitle.Value = st.Title.ToString();
            cmbTitle.Text = st.Title.ToString();
            cmbStaffType.Value = st.Stafftype.ToString();
            cmbStaffType.Text = st.Stafftype.ToString();
            dtAdmission.Date = st.Admissiondate.Date;
            Session["studUserID"] = st.UserId;
            lblFirstname.Text = st.FNames;
            lblLastname.Text = st.SName;

            if (File.Exists(Server.MapPath(UPLOAD_DIR + "img_" + Session["studUserID"].ToString() + ".jpg")))
            {

                imgMember.ImageUrl = UPLOAD_DIR + "img_" + Session["studUserID"].ToString() + ".jpg";

            }
            else
            {
                imgMember.ImageUrl = "~/images/default-person.jpg";
            }

            divMemberPic.Visible = true;
            spbtnChangePic.Visible = true;
            UpdatePanelProfile.Update();
            upStudent.Update();
        }

        /// <summary>
        /// STUDENT DETAILS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChangePic_Click(object sender, EventArgs e)
        {
            if (!txtUpload.Visible)
            {
                txtUpload.Visible = true;
            }
            else
            {
                txtUpload.Visible = false;
            }
            UpdatePanelProfile.Update();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(UPLOAD_DIR + "img_" + Session["studUserID"].ToString() + ".jpg")))
            {

                imgMember.ImageUrl = UPLOAD_DIR + "img_" + Session["studUserID"].ToString() + ".jpg";

            }
            else
            {
                imgMember.ImageUrl = "~/images/default-person.jpg";
            }
        }

        private bool validateStudent()
        {
            bool isvalid = true;

            if (txtFName.Text.Trim() == "")
            {
                txtFName.IsValid = false;
                isvalid = false;
                txtFName.ErrorText = "*";
            }
            if (txtSName.Text.Trim() == "")
            {
                txtSName.IsValid = false;
                isvalid = false;
                txtSName.ErrorText = "*";
            }
            if (txtMobile.Text.Trim() == "")
            {
                txtMobile.IsValid = false;
                isvalid = false;
                txtMobile.ErrorText = "*";
            }
            if (txtPostalAddress.Text.Trim() == "")
            {
                txtPostalAddress.IsValid = false;
                isvalid = false;
                txtPostalAddress.ErrorText = "*";
            }
            if (cmbGender.Value == null)
            {
                cmbGender.IsValid = false;
                isvalid = false;
                cmbGender.ErrorText = "*";
            }
            if (cmbMarital.Value == null)
            {
                cmbMarital.IsValid = false;
                isvalid = false;
                cmbMarital.ErrorText = "*";
            }
            if (cmbNationality.Value == null)
            {
                cmbNationality.IsValid = false;
                isvalid = false;
                cmbNationality.ErrorText = "*";
            }
            if (cmbReligion.Value == null)
            {
                cmbReligion.IsValid = false;
                isvalid = false;
                cmbReligion.ErrorText = "*";
            }
            if (cmbTitle.Value == null)
            {
                cmbTitle.IsValid = false;
                isvalid = false;
                cmbTitle.ErrorText = "*";
            }
            if (cmbStaffType.Value == null)
            {
                cmbStaffType.IsValid = false;
                isvalid = false;
                cmbStaffType.ErrorText = "*";
            }
            if (dtDOB.Date == null)
            {
                dtDOB.IsValid = false;
                isvalid = false;
                dtDOB.ErrorText = "*";
            }
            if (dtAdmission.Date == null)
            {
                dtAdmission.IsValid = false;
                isvalid = false;
                dtAdmission.ErrorText = "*";
            }

            return isvalid;
        }

        protected void btnSaveStudent_Click(object sender, EventArgs e)
        {
            if (!validateStudent())
            {
                upStudent.Update();
                return;
            }

            Tutor st = new Tutor();
            st.DateCreated = DateTime.Now;
            st.Dob = dtDOB.Date;
            st.Email = txtEmail.Text;
            st.FNames = txtFName.Text;
            st.Gender = cmbGender.Value.ToString();
            st.IndexNo = txtIndexNo.Text; 
            st.LastModified = DateTime.Now;
            st.Marital = cmbMarital.Value.ToString();
            st.Mobile = txtMobile.Text;
            st.Nationality = cmbNationality.Value.ToString();
            st.ONames = txtONames.Text;
            st.PostAdd = txtPostalAddress.Text;
            st.Religion = cmbReligion.Value.ToString();
            st.ResAdd = txtResAddress.Text;
            st.SName = txtSName.Text;
            st.Tel = txtTel.Text;
            st.Title = cmbTitle.Value.ToString();
            st.Admissiondate = dtAdmission.Date;
            st.Stafftype = cmbStaffType.Value.ToString();


            if (txtStudUserID.Text == "0")
            {
                st.UserId = new UserService().GenerateUserID();
                if (new TutorService().AddTutor(st, new SessionManager().GetUserId(this.Session).ToString()))
                {
                               

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

                    Response.Redirect("~/trainingtutors.aspx?action=edit&stdid=" + st.IndexNo + "&userid=" + st.UserId);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);

                }

            }
            else
            {
                st.UserId = txtStudUserID.Text;
                if (new TutorService().UpdateTutor(st, new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                }

            }


        }

        protected void btnClearStudent_Click(object sender, EventArgs e)
        {
            ClearStudent();
        }

        protected void btnNewStudent_Click(object sender, EventArgs e)
        {
            ClearStudent();
            Response.Redirect("~/trainingtutors.aspx");

        }

        private void ClearStudent()
        {
            txtFName.Text = "";
            txtMobile.Text = "";
            txtONames.Text = "";
            txtPostalAddress.Text = "";
            txtResAddress.Text = "";
            txtSName.Text = "";
            txtStudUserID.Text = "0";
            txtTel.Text = "";
            cmbGender.Value = null;
            cmbGender.Text = "";
            cmbMarital.Value = null;
            cmbMarital.Text = "";
            cmbNationality.Value = null;
            cmbNationality.Text = "";
            cmbReligion.Value = null;
            cmbReligion.Text = "";
            cmbTitle.Value = null;
            cmbTitle.Text = "";
            dtDOB.Date = DateTime.Now;
            dtAdmission.Date = DateTime.Now;
        }

        private string SavePostedFile(UploadedFile uploadedFile)
        {
            if (!uploadedFile.IsValid)
                return "";

            string fileName = Path.Combine(MapPath(UPLOAD_DIR), "img_" + Session["studUserID"].ToString());

            System.Drawing.Image image = System.Drawing.Image.FromStream(uploadedFile.FileContent);

            int newwidthimg = 350;
            int newHeight = 350;
            if (image.Size.Width > image.Size.Width)
            {
                newwidthimg = 350;
                float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                newHeight = Convert.ToInt32(newwidthimg / AspectRatio);
            }
            else
            {
                newHeight = 350;
                float AspectRatio = (float)image.Size.Height / (float)image.Size.Width;
                newwidthimg = Convert.ToInt32(newHeight / AspectRatio);
            }

            Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newHeight);
            Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newwidthimg, newHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);
            thumbnailBitmap.Save(fileName + ".jpg", ImageFormat.Jpeg);
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();

            return (UPLOAD_DIR_CLIENTSIDE + "img_" + Session["studUserID"].ToString() + ".jpg");


        }
        protected void txtUpload_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedFile(e.UploadedFile);

            txtUpload.Visible = true;

            UpdatePanelProfile.Update();
        }

        /// <summary>
        /// EDUCATIONAL DETAILS 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        /// 

        private bool validateEducation()
        {
            bool isvalid = true;

            if (txtEduInstitution.Text.Trim() == "")
            {
                txtEduInstitution.IsValid = false;
                isvalid = false;
                txtEduInstitution.ErrorText = "*";
            }
            if (txtEduQuali.Text.Trim() == "")
            {
                txtEduQuali.IsValid = false;
                isvalid = false;
                txtEduQuali.ErrorText = "*";
            }
            if (dtEduSDate.Date == null)
            {
                dtEduSDate.IsValid = false;
                isvalid = false;
                dtEduSDate.ErrorText = "*";
            }
            if (dtEduCDate.Date == null)
            {
                dtEduCDate.IsValid = false;
                isvalid = false;
                dtEduCDate.ErrorText = "*";
            }
            if (cmbEduLevel.Value == null)
            {
                cmbEduLevel.IsValid = false;
                isvalid = false;
                cmbEduLevel.ErrorText = "*";
            }

            if (FileUpload1.HasFile)
            {
                string exts = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (exts == ".pdf" || exts == ".doc" || exts == ".docx")
                { }
                else
                {
                    FileUpload1.BorderStyle = BorderStyle.Solid;
                    FileUpload1.BorderColor = Color.LightPink;
                    isvalid = false;
                   
                }

            }
            return isvalid;
        }

        protected void mMainEdu_ItemClick(object source, MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitNewEdu")
            {
                clearEdu();
                div_education.Visible = true;
                upEducational.Update();
            }
            else if (e.Item.Name == "mitCancelEdu")
            {
                clearEdu();
                div_education.Visible = false;
                upEducational.Update();
            }
        }

        private void LoadEducation(string studUserID)
        {
            dgEducation.DataSource = new TutorAcademicsService().GetAllTutorAcademics(studUserID, new SessionManager().GetUserId(this.Session));
            dgEducation.DataBind();
        }

        private void LoadEducationEditing()
        {
            TutorAcademics ad = new TutorAcademicsService().GetTutorAcademicsById(int.Parse(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session));
            txtEduComment.Text = ad.Comment;
            txtEduID.Text = ad.Id.ToString();
            txtEduInstitution.Text = ad.Institution;
            txtEduQuali.Text = ad.Qualification;
            dtEduCDate.Date = ad.DateCompleted.Date;
            dtEduSDate.Date = ad.DateAttended.Date;
            cmbEduLevel.Value = ad.AcademicLevel.ToString();
            cmbEduLevel.Text = ad.AcademicLevel.ToString();

        }

        protected void dgEducation_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            if (new TutorAcademicsService().DeleteTutorAcademics(int.Parse(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }

            LoadEducation(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "UserId").ToString());
            upEducational.Update();
            uPanel.Update();
        }

        protected void dgEducation_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgEducation.CancelEdit();
            LoadEducationEditing();
            div_education.Visible = true;
            upEducational.Update();
        }

        protected void btnEduSave_Click(object sender, EventArgs e)
        {
            if (!validateEducation())
            {
                upEducational.Update();
                return;
            }

            TutorAcademics ad = new TutorAcademics();
            ad.AcademicLevel = cmbEduLevel.Value.ToString();
            ad.Comment = txtEduComment.Text;
            ad.DateAttended = dtEduSDate.Date;
            ad.DateCompleted = dtEduCDate.Date;
            ad.DateCreated = DateTime.Now;

            ad.Institution = txtEduInstitution.Text;
            ad.LastModified = DateTime.Now;
            ad.Qualification = txtEduQuali.Text;
            ad.UserId = txtStudUserID.Text;

            if (FileUpload1.HasFile)
            {
                string newName = txtEduQuali.Text + "_" + txtStudUserID.Text;
                string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string savePath = Path.Combine(Server.MapPath(UPEDU_DIR), newName + ext);
                FileUpload1.SaveAs(savePath);
                ad.Documment = newName + ext;

            }
            else
            {
                ad.Documment = "No Ducument";
            }


            if (txtEduID.Text == "0")
            {


                if (new TutorAcademicsService().AddTutorAcademics(ad, new SessionManager().GetUserId(this.Session)))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                }
            }
            else
            {
                ad.Id = int.Parse(txtEduID.Text);
                if (new TutorAcademicsService().UpdateTutorAcademics(ad, new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                }

            }


            LoadEducation(ad.UserId);
            upEducational.Update();
            uPanel.Update();

        }

        protected void btnEduClear_Click(object sender, EventArgs e)
        {
            clearEdu();
            upEducational.Update();
        }

        private void clearEdu()
        {
            txtEduComment.Text = "";
            txtEduID.Text = "0";
            txtEduInstitution.Text = "";
            txtEduQuali.Text = "";
            dtEduCDate.Date = DateTime.Now;
            dtEduSDate.Date = DateTime.Now;
            cmbEduLevel.Value = null;
        }
        protected void dgEducation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Documment").ToString() != "No Document")
                {
                    Session["fromwhere"] = "~/trainingtutors.aspx?action=edit&stdid=" + Request.QueryString["stdid"].ToString() + "&userid=" + Request.QueryString["userid"].ToString() + "";
                    Session["document"] = UPEDU_DIR + new TutorAcademicsService().GetTutorAcademicsById(int.Parse(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session)).DocummentFname.ToString();

                    Response.Redirect("~/documentviewer.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops! No Document is attached to this record!','Message')", true);
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Oops something is not right!','Message')", true);
            }
        }

        /// <summary>
        /// FAMILY/GUADIAN
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        /// 

        private bool validateFamily()
        {
            bool isvalid = true;

            if (txtFamFName.Text.Trim() == "")
            {
                txtFamFName.IsValid = false;
                isvalid = false;
                txtFamFName.ErrorText = "*";
            }
            if (txtFamSName.Text.Trim() == "")
            {
                txtFamSName.IsValid = false;
                isvalid = false;
                txtFamSName.ErrorText = "*";
            }
            if (txtFamMobile.Text.Trim() == "")
            {
                txtFamMobile.IsValid = false;
                isvalid = false;
                txtFamMobile.ErrorText = "*";
            }
            if (cmbFamNxtKin.Value == null)
            {
                cmbFamNxtKin.IsValid = false;
                isvalid = false;
                cmbFamNxtKin.ErrorText = "*";
            }
            if (cmbFamRelative.Value == null)
            {
                cmbFamRelative.IsValid = false;
                isvalid = false;
                cmbFamRelative.ErrorText = "*";
            }

            return isvalid;
        }

        protected void mMainFam_ItemClick(object source, MenuItemEventArgs e)
        {

            if (e.Item.Name == "mitNewFam")
            {
                div_family.Visible = true;
                clearFamily();
                upFamily.Update();
            }
            else if (e.Item.Name == "mitCancelFam")
            {
                clearFamily();
                div_family.Visible = false;
                upFamily.Update();
            }
        }

        protected void btnFamClear_Click(object sender, EventArgs e)
        {
            clearFamily();
            upFamily.Update();
            uPanel.Update();
        }

        private void clearFamily()
        {
            txtFamEmail.Text = "";
            txtFamFName.Text = "";
            txtFamID.Text = "0";
            txtFamMobile.Text = "";
            txtFamONames.Text = "";
            txtFamPostAdd.Text = "";
            txtFamSName.Text = "";
            txtFamTel.Text = "";
            cmbFamNxtKin.Value = null;
            cmbFamRelative.Value = null;

        }

        private void LoadFamily(string studUserID)
        {
            gvFamily.DataSource = new TutorRelativesService().GetTutorRelatives(studUserID, new SessionManager().GetUserId(this.Session));
            gvFamily.DataBind();
            upFamily.Update();
            uPanel.Update();
        }

        protected void btnFamSave_Click(object sender, EventArgs e)
        {
            if (!validateFamily())
            {
                upFamily.Update();
                return;
            }

            TutorRelatives rel = new TutorRelatives();
            rel.DateCreated = DateTime.Now;
            rel.Email = txtFamEmail.Text;
            rel.FirstName = txtFamFName.Text;
            rel.LastModified = DateTime.Now;
            rel.LastName = txtFamSName.Text;
            rel.Mobile = txtFamMobile.Text;
            rel.NextOfKin = cmbFamNxtKin.Value.ToString();
            rel.OtherName = txtFamONames.Text;
            rel.PostAddress = txtFamPostAdd.Text;
            rel.RelType = cmbFamRelative.Value.ToString();
            rel.Tel = txtFamTel.Text;
            rel.UserId = txtStudUserID.Text;

            if (new RelativeService().RelativeExists(rel.UserId, rel.RelType, new SessionManager().GetUserId(this.Session)))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('This relative has already been added','Message')", true);

            }
            else
            {
                if (txtFamID.Text == "0")
                {
                    if (new TutorRelativesService().AddTutorRelatives(rel, new SessionManager().GetUserId(this.Session)))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                    }
                }
                else
                {
                    rel.Id = int.Parse(txtFamID.Text);
                    if (new TutorRelativesService().UpdateTutorRelatives(rel, new SessionManager().GetUserId(this.Session)))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                    }

                }
            }

            LoadFamily(rel.UserId);
            upFamily.Update();
            uPanel.Update();

        }

        protected void gvFamily_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            if (new TutorRelativesService().DeleteTutorRelatives(int.Parse(gvFamily.GetRowValues(gvFamily.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }

            LoadFamily(gvFamily.GetRowValues(gvFamily.FocusedRowIndex, "UserId").ToString());
            upFamily.Update();
            uPanel.Update();
        }

        protected void gvFamily_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

            TutorRelatives rel = new TutorRelativesService().GetTutorRelativesById(int.Parse(gvFamily.GetRowValues(gvFamily.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session));
            txtFamEmail.Text = rel.Email;
            txtFamFName.Text = rel.FirstName;
            txtFamID.Text = rel.Id.ToString();
            txtFamMobile.Text = rel.Mobile;
            txtFamONames.Text = rel.OtherName;
            txtFamPostAdd.Text = rel.PostAddress;
            txtFamSName.Text = rel.LastName;
            txtFamTel.Text = rel.Tel;
            cmbFamNxtKin.Value = rel.NextOfKin;
            cmbFamNxtKin.Text = rel.NextOfKin;
            cmbFamRelative.Value = rel.RelType;
            cmbFamRelative.Text = rel.RelType;

            div_family.Visible = true;
            upFamily.Update();
            uPanel.Update();
            gvFamily.CancelEdit();

        }

       


    }

}