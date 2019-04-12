using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using mySmis.Code;
using mySmisLib;
using DevExpress.Web;
using System.Globalization;

namespace mySmis
{
    public partial class programregistration : System.Web.UI.Page
    {
        private string user_id = "0";
        ASPxComboBox _TutorcomboBox;

        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            
            new SessionManager().InitDBConnection();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            loadPrograms();
           // cmbProgram.GridView.Width = 600;
        }

        private void loadPrograms()
        {
            
            cmbProgram.DataSource = new ModuleServices().GetAllModule(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            gvClassLessons.DataSource = new StudentService().GetAllStudent(new SessionManager().GetUserId(Session));
            gvClassLessons.DataBind();
        }

        protected void cmbMemberSearch_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            
        }

        protected void cmbMemberSearch_ValueChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnFamilyAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnFamilyCancel_Click(object sender, EventArgs e)
        {

        }

        protected void tbNew_Click(object sender, EventArgs e)
        {
            clearfields();
            divEdit.Visible = true;
            uPanel.Update();
        }
  
        private void clearfields()
        {
            //txtFamilyId.Text = "0";
            txtFamilyLastName.Text = "";
            cmbMember.Text = "";
            txtemail.Text = "";
            txtFamilyTel.Text = "";
            txtFamilyOtherNames.Text = "";
            txtmemID.Text = "0";
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            btnRefreshReg.Visible = true;
            reloadLessonSchudel();
            getStudRegistration();
            UpdateRegistration.Update();
        }

        private void getStudRegistration()
        {
            dgStudenProgram.DataSource = new RegistrationService().GetAllRegistrationByStudIDByModID(int.Parse(cmbSearchStud.Value.ToString()), int.Parse(cmbProgram.Value.ToString()),new SessionManager().GetUserId(Session));
            dgStudenProgram.DataBind();
        }

        private void reloadLessonSchudel()
        {
            //List<int> studClassID = new List<int>();
            //List<Registration> studRegs = new RegistrationService().GetAllRegistrationByStudIDByModID(int.Parse(cmbSearchStud.Value.ToString()), int.Parse(cmbProgram.Value.ToString()), new SessionManager().GetUserId(Session));
            //foreach (Registration studReg in studRegs) 
            //{
            //    studClassID.Add(studReg.ClassID);
            //}

            //string studRegsList = string.Join(",",studClassID);

            int programID = int.Parse(cmbProgram.Value.ToString());


            gvRegisterStud.DataSource = new ClassABCServices().GetAllClassNotStudReg(int.Parse(cmbSearchStud.Value.ToString()), programID, new SessionManager().GetUserId(Session));
            gvRegisterStud.DataBind();

            UpdateRegistration.Update();
        }

        protected void cmbStudtype_ValueChanged(object sender, EventArgs e)
        {
            if (cmbStdtype.Value.ToString() == "0")
            {
                cmbMember.Enabled = true;
                cmbMember.Focus();
            }
            else
            {
                cmbMember.Enabled = false;
                txtFamilyLastName.Focus();
            }
            uPanel.Update();
        }

        protected void cmbMember_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() != "")
            {
                //MemberResult selected = new MemberResult();
               // ASPxComboBox comboBox = (ASPxComboBox)source;
                //List<MemberResult> mList = new List<MemberResult>();
                //mList.Add(new MemberService().GetMemberResult(e.Value.ToString().Trim(), user_id));
                //comboBox.DataSource = mList;

                //comboBox.DataBind();
            }
            uPanel.Update();
        }

        protected void cmbMember_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            //ASPxComboBox comboBox = (ASPxComboBox)source;
           // List<MemberResult> mList = new MemberService().FindMember(e.Filter, e.BeginIndex, e.EndIndex + 5, user_id);
           // comboBox.DataSource = mList;
           // comboBox.DataBind();
        }

        protected void cmbMember_ValueChanged(object sender, EventArgs e)
        {
            if (cmbMember.Value == null) { return; }
            else
            {

              //  Member relativeMember = new MemberService().GetMemberById(cmbMember.Value.ToString(), new SessionManager().GetUserId(this.Session));
               // txtFamilyLastName.Text = relativeMember.LastName.Trim();
               // txtFamilyOtherNames.Text = (relativeMember.FirstName + " " + relativeMember.OtherNames).Trim().Replace("  ", " ");
               // txtFamilyTel.Text = (relativeMember.Tel + "," + relativeMember.MobileNo).Trim(',').Replace(",,", ",");
               // txtmemID.Text = relativeMember.MemberId.Trim();
            }
            uPanel.Update();
        }

        protected void btnSaveStudent_Click(object sender, EventArgs e)
        {
            string inedxNo = "101";
            string indexD = DateTime.Now.ToString("dd", CultureInfo.InvariantCulture);
            string indexM = DateTime.Now.ToString("MM", CultureInfo.InvariantCulture);
            string indexY = DateTime.Now.ToString("yy", CultureInfo.InvariantCulture);
            int studNo = new StudentService().IndexNo(new SessionManager().GetUserId(this.Session));
            if (studNo == 0)
            {
                inedxNo = inedxNo + indexD + indexM + indexY;
            }
            else 
            {
                int i = int.Parse(inedxNo) + studNo ;
                inedxNo =  i + indexD + indexM + indexY;
            }

            Student stud = new Student();
            stud.IndexNo = inedxNo;
            stud.SName = txtFamilyLastName.Text;
            stud.ONames = txtFamilyOtherNames.Text;
            stud.Tel = txtFamilyTel.Text;
            stud.IndexNo = txtmemID.Text;
            stud.DateCreated = DateTime.Now;
            stud.LastModified = DateTime.Now;
            stud.Email = txtemail.Text;
            stud.Gender = cmbGender.Text;

            if (new StudentService().AddStudent(stud, new SessionManager().GetUserId(this.Session)))
            {
                clearfields();
                loadPrograms();
                uPanel.Update();
            }

        }

        protected void btnClearStudent_Click(object sender, EventArgs e)
        {
            clearfields();
        }

        protected void cmbSearchStud_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;
            List<Student> stud = new StudentService().GetAllStudent(user_id);

            comboBox.DataSource = (from s in stud where (s.IndexNo.StartsWith(e.Filter) || s.SName.Contains(e.Filter) || s.ONames.Contains(e.Filter)) select s).ToList();
           // comboBox.DataSource = new StudentService().FindStudent(e.Filter, e.BeginIndex, e.EndIndex + 5, user_id);
            comboBox.DataBind();
        }

        protected void cmbSearchStud_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() != "")
            {
                Student selected = new Student();
                ASPxComboBox comboBox = (ASPxComboBox)source;
                comboBox.DataSource = new StudentService().GetStudentResult(e.Value.ToString().Trim(), user_id);
                comboBox.DataBind();
            }
            UpdateRegistration.Update();
        }

        protected void cmbSearchStud_ValueChanged(object sender, EventArgs e)
        {
           // getStudRegistration();
            //UpdateRegistration.Update();
        }

        protected void gvRegisterStud_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (cmbProgram.SelectedIndex >= 0)
            {

                if (e.Column.Name == "ClassShud")
                {
                    ASPxComboBox c = e.Editor as ASPxComboBox; //gvClassLessons.FindEditRowCellTemplateControl(gvClassLessons.Columns["TutorName"] as GridViewDataComboBoxColumn, "lbTutorList2")
                    c.TextField = "Title";
                    c.ValueField = "ID";
                    //*******var lessonID = gvClassLessons.GetRowValuesByKeyValue(e.KeyValue,"LessonID");
                    c.DataSource = new ClassSchedulerServices().GetAllClassSchedulerByClassIDAvailable(int.Parse(gvRegisterStud.GetRowValuesByKeyValue(e.KeyValue, "ID").ToString()), new SessionManager().GetUserId(Session));
                    c.DataBind();

                }
            }

            UpdateRegistration.Update();

        }

        protected void gvRegisterStud_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            e.Cancel = true;
            ASPxGridView g = (ASPxGridView)sender;
            Registration i = new Registration();


            i.ModuleID = int.Parse(cmbProgram.Value.ToString());
            i.ClassID = int.Parse(gvRegisterStud.GetRowValuesByKeyValue(e.Keys["ID"], "ID").ToString());
            //i.ID = int.Parse(e.Keys["ID"].ToString());
            i.ClassScheduleID = int.Parse(Session["classid"].ToString());
            i.StudID = int.Parse(cmbSearchStud.Value.ToString());
            GridViewDataColumn c = gvClassLessons.DataColumns["ClassShud"] as GridViewDataColumn;

            i.DateModified = DateTime.Now;
            i.DateReg = DateTime.Now;



            if (Session["classid"].ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('You must select a Class Schedule or Create one to use','Message')", true);
                
            }
            else
            {

                if (new RegistrationService().AddRegistration(i, new SessionManager().GetUserId(this.Session)))
                {
                    List<Lesson> allLessons = new LessonService().GetAllLessonsByClassID(int.Parse(gvRegisterStud.GetRowValuesByKeyValue(e.Keys["ID"], "ID").ToString()), new SessionManager().GetUserId(Session));

                    foreach (Lesson allLesson in allLessons)
                    {
                        Attendance l = new Attendance();

                        l.ClassID = allLesson.ClassID;
                        l.ModuleID = allLesson.ModuleID;
                        l.LessonID = allLesson.ID;
                        l.ClassSchedID = int.Parse(Session["classid"].ToString());
                        l.DateCreted = DateTime.Now;
                        l.IndexNo = int.Parse(cmbSearchStud.Value.ToString());
                        l.Attended = "No";
                        l.Completed = "Not Completed";

                        new AttendanceServices().AddAttendance(l, new SessionManager().GetUserId(Session));

                    }
                }

            }

            gvRegisterStud.CancelEdit();
            reloadLessonSchudel();
            UpdateRegistration.Update();
        }

        protected void cmbClassSched_Validation(object sender, ValidationEventArgs e)
        {
            Session["classid"] = 0;
            Session["classid"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbClassSched_Init(object sender, EventArgs e)
        {
            var d = gvRegisterStud.GetRowValues(gvRegisterStud.EditingRowVisibleIndex, "ID");
            _TutorcomboBox = (ASPxComboBox)sender;
            //_TutorcomboBox.Width = new Unit(100, UnitType.Percentage);
            _TutorcomboBox.DataSource = new ClassSchedulerServices().GetAllClassSchedulerByClassIDAvailable(int.Parse(gvRegisterStud.GetRowValues(gvRegisterStud.EditingRowVisibleIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            _TutorcomboBox.DataBind();
        }

        protected void cmbClassSched_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["classid"] = 0;
            }
        }

        protected void gvClassLessons_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void gvClassLessons_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
           
        }

        protected void dgStudenProgram_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            
            
            if (new RegistrationService().DeleteRegistration(int.Parse(dgStudenProgram.GetRowValues(dgStudenProgram.FocusedRowIndex,"ID").ToString()), new SessionManager().GetUserId(Session)))
            {
                new AttendanceServices().DeleteAttendanceByStudIDClassID(int.Parse(dgStudenProgram.GetRowValues(dgStudenProgram.FocusedRowIndex,"StudID").ToString()),int.Parse(dgStudenProgram.GetRowValues(dgStudenProgram.FocusedRowIndex,"ClassID").ToString()), new SessionManager().GetUserId(Session));
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
                loadPrograms();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }
            dgStudenProgram.CancelEdit();
            getStudRegistration();
            //UpdateRegistration.Update();
            uPanel.Update();
        }

        protected void btnRefreshReg_Click(object sender, EventArgs e)
        {
            
            reloadLessonSchudel();
            getStudRegistration();
            UpdateRegistration.Update();
        }

       
    }
}