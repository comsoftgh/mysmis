using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;


namespace mySmis
{
    public partial class newstudent : System.Web.UI.Page
    {
        private SessionManager sessMgr = new SessionManager();

        private const string UPLOAD_DIR = "~/pictures/";
        private const string UPLOAD_DIR_CLIENTSIDE = "pictures/";
        private const string UPEDU_DIR = "~/studentedudocs/";

        protected void Page_Load(object sender, EventArgs e)
        {
           //txtIndexNo.Text = new StudentService().IndexNumber();
           LoadlookUps();
            
           if (!IsPostBack)
           {

               memberTabs.ActiveTabIndex = 0;

               if (Request.QueryString["action"] != null && Request.QueryString["action"] == "edit" && Request.QueryString["stdid"] != null && Request.QueryString["userid"] != null)
               {

                   memberTabs.TabPages[0].ClientEnabled = true;
                   memberTabs.TabPages[1].ClientEnabled = true;
                   memberTabs.TabPages[2].ClientEnabled = true;
                  // memberTabs.TabPages[3].ClientEnabled = true;

                   LoadStudent(Request.QueryString["stdid"].ToString());
                   LoadEducation(Request.QueryString["userid"].ToString());
                   LoadFamily(Request.QueryString["userid"].ToString());
                   if (new RelativeService().NextofKinExists(Request.QueryString["userid"].ToString(), new SessionManager().GetUserId(this.Session)))
                   {
                       cmbFamNxtKin.SelectedIndex = 1;
                       cmbFamNxtKin.Enabled = false;
                       
                   }
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
            }
            catch (Exception)
            {
                
               ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops something is not right','Message')", true);
            }
        }
       
        private void LoadStudent(string studID)
        {
            Student st = new StudentService().GetStudent(studID,new SessionManager().GetUserId(this.Session));
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
            }
            if (txtSName.Text.Trim() == "")
            {
                txtSName.IsValid = false;
                isvalid = false;
            }
            if (txtMobile.Text.Trim() == "")
            {
                txtMobile.IsValid = false;
                isvalid = false;
            }
            if (txtPostalAddress.Text.Trim() == "")
            {
                txtPostalAddress.IsValid = false;
                isvalid = false;
            }
            if (txtResAddress.Text.Trim() == "")
            {
                txtResAddress.IsValid = false;
                isvalid = false;
            }
            if (cmbGender.Value == null)
            {
                cmbGender.IsValid = false;
                isvalid = false;
            }
            if (dtDOB.Value == null)
            {
                dtDOB.IsValid = false;
                isvalid = false;
                dtDOB.ErrorText = "*";
            }
            if (dtAdmission.Value == null)
            {
                dtAdmission.IsValid = false;
                isvalid = false;
                dtAdmission.ErrorText = "*";
            }
            if (cmbNationality.Value == null)
            {
                cmbNationality.IsValid = false;
                isvalid = false;
            }
            if (cmbReligion.Value == null)
            {
                cmbReligion.IsValid = false;
                isvalid = false;
            }
            //if (cmbTitle.Value == null)
            //{
            //    cmbTitle.IsValid = false;
            //    isvalid = false;
            //}
            
            return isvalid;
        }

        protected void btnSaveStudent_Click(object sender, EventArgs e)
        {
            if (!validateStudent())
            {
                upStudent.Update();
                return;
            }

            Student st = new Student();
            st.DateCreated = DateTime.Now;
            st.Dob = dtDOB.Date;
            st.Email = txtEmail.Text;
            st.FNames = txtFName.Text;
            st.Gender = cmbGender.Value.ToString();
            st.IndexNo = new StudentService().IndexNumber();
            st.LastModified = DateTime.Now;
            st.Marital = cmbMarital.Value == null ? "NA": cmbMarital.Value.ToString();
            st.Mobile = txtMobile.Text;
            st.Nationality = cmbNationality.Value.ToString();
            st.ONames = txtONames.Text;
            st.PostAdd = txtPostalAddress.Text;
            st.Religion = cmbReligion.Value.ToString();
            st.ResAdd = txtResAddress.Text;
            st.SName = txtSName.Text;
            st.Tel = txtTel.Text;
            st.Title = cmbTitle.Value == null ? "NA" : cmbTitle.Value.ToString();
            st.Admissiondate = dtAdmission.Date;


            if (txtStudUserID.Text == "0")
            {
                st.UserId = new UserService().GenerateUserID();
                if (new StudentService().AddStudent(st, new SessionManager().GetUserId(this.Session).ToString()))
                {
                    User u = new User();
                    u.DateCreated = DateTime.Now;
                    u.LastModify = DateTime.Now;
                    u.Password = "@student123";
                    u.UserId = st.UserId;
                    u.UserName = st.IndexNo;
                    u.UserType = "Student";
                    
                    new UserService().AddUser(u,new SessionManager().GetUserId(this.Session).ToString());

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);

                    Response.Redirect("~/studentnew.aspx?action=edit&stdid=" + st.IndexNo + "&userid=" + st.UserId);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);

                }

            }
            else
            {
                st.UserId = txtStudUserID.Text;
                if (new  StudentService().UpdateStudent(st, new SessionManager().GetUserId(this.Session)))
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
            Response.Redirect("~/studentnew.aspx");

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
            if (dtEduSDate.Value == null)
            {
                dtEduSDate.IsValid = false;
                isvalid = false;
                dtEduSDate.ErrorText = "*";
            }
            if (dtEduCDate.Value == null)
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
            dgEducation.DataSource = new AcademicDetailsService().GetAllAcademicDetails(studUserID,new SessionManager().GetUserId(this.Session));
            dgEducation.DataBind();
        }

        private void LoadEducationEditing()
        {
            AcademicDetails ad = new AcademicDetailsService().GetAcademicDetailsById(int.Parse(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session));
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
            string docname = new AcademicDetailsService().GetAcademicDetailsById(int.Parse(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session)).Documment;
            
            if (new AcademicDetailsService().DeleteAcademicDetails(int.Parse(dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session)))
            {
                if (docname != "No Document")
                {
                    File.Delete(Path.Combine(Server.MapPath(UPEDU_DIR),docname));
                }
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

            AcademicDetails ad = new AcademicDetails();
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
                ad.Documment = "No Document";
            }

           
            if (txtEduID.Text == "0")
            {


                if(new AcademicDetailsService().AddAcademicDetails(ad,new SessionManager().GetUserId(this.Session)))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    div_education.Visible = false;
                    clearEdu();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                }
            }
            else
            {
                ad.Id = int.Parse(txtEduID.Text);
                if (new AcademicDetailsService().UpdateAcademicDetails(ad, new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                    div_education.Visible = false;
                    clearEdu();
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
            dtEduCDate.Value = null;
            dtEduSDate.Value = null;
            cmbEduLevel.Value = null;
        }

        protected void dgEducation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Documment").ToString() != "No Document")
                {
                    Session["fromwhere"] = "~/studentnew.aspx?action=edit&stdid=" + Request.QueryString["stdid"].ToString() + "&userid=" + Request.QueryString["userid"].ToString() + "";
                    Session["document"] = UPEDU_DIR + dgEducation.GetRowValues(dgEducation.FocusedRowIndex, "Documment").ToString();

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
            }
            if (txtFamSName.Text.Trim() == "")
            {
                txtFamSName.IsValid = false;
                isvalid = false;
            }
            if (txtFamMobile.Text.Trim() == "")
            {
                txtFamMobile.IsValid = false;
                isvalid = false;
            }
            if (cmbFamNxtKin.Value == null)
            {
                cmbFamNxtKin.IsValid = false;
                isvalid = false;
            }
            if (cmbFamRelative.Value == null)
            {
                cmbFamRelative.IsValid = false;
                isvalid = false;
            }
            if (txtFamPostAdd.Value.ToString().Trim() == "")
            {
                txtFamPostAdd.IsValid = false;
                isvalid = false;
            }


            return isvalid;
        }

        protected void mMainFam_ItemClick(object source, MenuItemEventArgs e)
        {
            
            if (e.Item.Name == "mitNewFam")
            {
                div_familySibling.Visible = true;
                clearFamily();
                upFamily.Update();
            }
            else if (e.Item.Name == "mitCancelFam")
            {
                clearFamily();
                div_familySibling.Visible = false;
                div_familyStud.Visible = false;
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
            gvFamily.DataSource = new RelativeService().GetRelatives(studUserID, new SessionManager().GetUserId(this.Session));
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

            Relative rel = new Relative();
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
            rel.RelaUserId = new UserService().GenerateUserID();

            if(new RelativeService().RelativeExists(rel.RelaUserId,rel.RelType,new SessionManager().GetUserId(this.Session)))
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('This relative has already been added','Message')", true);
                    
            }
            else
            {
                if (txtFamID.Text == "0")
                {
                    if (new RelativeService().AddRelative(rel, new SessionManager().GetUserId(this.Session)))
                    {
                        //if(rel.NextOfKin == "Yes")
                        //{
                        //    User u = new User();
                        //    u.Password = "parent@123";
                        //    u.UserId = rel.RelaUserId;
                        //    u.UserName = txtStudUserID.ToString() + "_" + rel.FirstName.Substring(1, 1).ToLower() + rel.LastName.Substring(1, 1).ToLower();
                        //    u.UserType = "Parent";
                        //    new UserService().AddUser(u,new SessionManager().GetUserId(this.Session));

                        //}
                        Relative ur = new Relative();
                        ur.xStudUserId = txtStudUserID.Text;
                        ur.RelaUserId = rel.RelaUserId;
                        ur.DateCreated = DateTime.Now;
                        ur.LastModified = DateTime.Now;
                        new RelativeService().AddRelation(ur, new SessionManager().GetUserId(this.Session));
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
                if (new RelativeService().UpdateRelative(rel, new SessionManager().GetUserId(this.Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Updated Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Updating Failed','Message')", true);
                }

                }
            }

            LoadFamily(txtStudUserID.Text);
            upFamily.Update();
            uPanel.Update();

        }

        protected void gvFamily_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            if (new RelativeService().DeleteRelative(int.Parse(gvFamily.GetRowValues(gvFamily.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session)))
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
           
            Relative rel = new RelativeService().GetRelativeById(int.Parse(gvFamily.GetRowValues(gvFamily.FocusedRowIndex, "Id").ToString()), new SessionManager().GetUserId(this.Session));
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

        protected void cmbFamilySiblings_ValueChanged(object sender, EventArgs e)
        {
            if(cmbFamilySiblings.Value != null)
            {
                if(cmbFamilySiblings.Value.ToString() == "Yes")
                {
                    div_family.Visible = false;
                    clearFamily();
                    div_familyStud.Visible = true;

                    upFamily.Update();
                }
                else if (cmbFamilySiblings.Value.ToString() == "No")
                {
                    div_familyStud.Visible = false;
                    clearFamily();
                    div_family.Visible = true;
                    upFamily.Update();
                }
            }
        }

        protected void cmbSearchStudent_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() != "")
            {
                 Student selected = new Student();
                 ASPxComboBox comboBox = (ASPxComboBox)source;
                 List<Student> mrList = new List<Student>();
                 mrList.Add(new StudentService().GetFindStudent(e.Value.ToString().Trim()));
                 comboBox.DataSource = mrList;
                 comboBox.DataBind();
            }
            else
            {
            }
        }

        protected void cmbSearchStudent_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;
            comboBox.DataSource = new StudentService().FindStudent(e.Filter, e.BeginIndex, e.EndIndex + 5, new SessionManager().GetUserId(this.Session));
            comboBox.DataBind();
        }

        protected void btnSaveSiblingRela_Click(object sender, EventArgs e)
        {
            if (cmbSearchStudent.Value == null) 
            {
                cmbSearchStudent.IsValid = false;
                cmbSearchStudent.ErrorText = "*";
                return;
            }
            List<Relative> r = new RelativeService().GetRelationsIDs(cmbSearchStudent.Value.ToString(),txtStudUserID.Text,new SessionManager().GetUserId(this.Session));
            if (r.Count > 0)
            {
                string relation = "";
                foreach(Relative rt in r)
                {
                    relation += "('" + cmbSearchStudent.Value.ToString() + "','" + rt.RelaUserId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                }

                if (new RelativeService().AddRelationList(relation.Trim(','), new SessionManager().GetUserId(this.Session)))
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
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops!, There are on families/guardians associated with this student','Message')", true);
            }

            LoadFamily(cmbSearchStudent.Value.ToString());
            upFamily.Update();
        }

        protected void dgEducation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void dgEducation_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            //if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Select)
            //{ if (dgEducation.GetRowValues(e.VisibleIndex, "Documment") == "No Document") { e.Enabled = false; } }//e.Visible = DocumentButtonVisibleCriteria((ASPxGridView)sender, e.VisibleIndex); }
           
        }

        private bool DocumentButtonVisibleCriteria(ASPxGridView grid, int visibleIndex)
        {
            object row = grid.GetRow(visibleIndex);
            return ((DataRowView)row)["Documment"].ToString() == "No Document";
        }
       

        protected void dgEducation_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            
        }

       

        

       

        
    }
}