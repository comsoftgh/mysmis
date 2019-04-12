using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mySmisLib;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace mySmis
{
    public partial class lessonsScheduler : System.Web.UI.Page
    {
        ASPxComboBox _VenuroomsListBox;
        ASPxComboBox _TimeperiodsListBox;
        ASPxComboBox _TutorcomboBox;
        ASPxComboBox _TimedayscomboBox;

        protected void Page_Load(object sender, EventArgs e)
        {
            new SessionManager().IsSessionActive(this.Response, this.Session);
            loadPrograms();
            //cmbProgram.GridView.Width = 600;

            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjTutorSchedule")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                        mMain.Items.FindByName("mitNew").Enabled = true;
                        mMain.Items.FindByName("mitCancel").Enabled = true;
                        break;
                    case "EXPORT":
                        mMain.Items.FindByName("mitExportxls").Enabled = true;
                        break;
                    case "REPORT":
                        mMain.Items.FindByName("mitReport").Enabled = true;
                        break;
                }

            }
        }

        private void loadPrograms()
        {
           cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();

            dgProgram.DataSource = new LessonTimetableService().GetAllLessonTimetable("lessontimetable", new SessionManager().GetUserId(Session));
            dgProgram.DataBind();
            uPanel.Update();
        }

        protected void gvClassLessons_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjSchedule"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Select:
                    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
            }
        }
        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    loadPrograms();
                    clearfields();
                    divLessons.Visible = true;
                    break;
                case "mitCancel":
                    clearfields();
                    divLessons.Visible = false;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/lessonsScheduler.aspx";
                    Session["report"] = new mySmis.reports.rptCourseSubjectSchedule();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }

            uPanel.Update();
        }
        private void clearfields()
        {
            txtId.Text = "0";


            cmbProgram.Text = "";
            gvClassLessons.DataSource = null;

        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                reloadLessonSchudel(int.Parse(cmbProgram.Value.ToString()));
            }

            uPanel.Update();
        }

        private void reloadLessonSchudel(int classID)
        {
            //int classID = int.Parse(cmbProgram.Value.ToString()); //int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString());
            gvClassLessons.DataSource = new LessonSchedulerServices().GetAllLessonSchedulerByClassSchedID(classID, new SessionManager().GetUserId(Session));
            gvClassLessons.DataBind();
        }

        protected void gvClassLessons_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (cmbProgram.GridView.FocusedRowIndex >= 0)
            {
                
                if (e.Column.Name == "lessonVenus")
                {
                    ASPxComboBox c = e.Editor as ASPxComboBox;

                    c.DataSource = new VenuroomsService().GetAllVenurooms(new SessionManager().GetUserId(Session));
                    c.DataBind();

                }

                if (e.Column.Name == "clLessonTime")
                {
                    ASPxComboBox c = e.Editor as ASPxComboBox;

                    c.DataSource = new LookUpService().GetTimePeriods();
                    c.DataBind();

                }

                if (e.Column.Name == "clLessonDay")
                {
                    ASPxComboBox c = e.Editor as ASPxComboBox;

                    c.DataSource = new LookUpService().GetTimeDays();
                    c.DataBind();

                }

            }

            uPanel.Update();
        }

        protected void lessonVenuslist_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            Session["venuroomid"] = 0;
            Session["venuroomid"] = ((ASPxComboBox)sender).Value;
        }

        protected void lessonVenuslist_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["venuroomid"] = 0;
            }
            else
            {
                Session["venuroomid"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void lessonVenuslist_Init(object sender, EventArgs e)
        {
            _VenuroomsListBox = (ASPxComboBox)sender;
            _VenuroomsListBox.DataSource = new VenuroomsService().GetAllVenurooms(new SessionManager().GetUserId(Session));
            _VenuroomsListBox.DataBind();
            
        }

        protected void gvClassLessons_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            e.Cancel = true;
            ASPxGridView g = (ASPxGridView)sender;
            LessonTimetable i = new LessonTimetable();

            i.ClassID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ClassID").ToString());
            i.ModuleID = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ModuleID").ToString());
            i.Classscheid = int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString());
            i.LessonID = int.Parse(gvClassLessons.GetRowValuesByKeyValue(e.Keys["ID"], "LessonID").ToString());
            i.Bgroup = cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString();
            i.ID = int.Parse(e.Keys["ID"].ToString());
            i.VenuroomID = int.Parse(Session["venuroomid"].ToString());
            //GridViewDataColumn c = gvClassLessons.DataColumns["lessonVenus"] as GridViewDataColumn;

            i.CreatedDate = DateTime.Now;
            i.ModifyDate = DateTime.Now;
            i.LessTime = Session["timeperiod"].ToString();
            i.LessDay = Session["timedays"].ToString();
            i.TutorID = Session["tutorid"].ToString();

            int numer = 0;
            if (i.VenuroomID == 0 )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Please select a Venue','Message')", true);
            }
            else if (i.TutorID == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Please select a Tutor','Message')", true);
            }
            else if (i.LessDay == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Please select a Day','Message')", true);
            }
            else if (i.LessTime == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Please select a Time Period','Message')", true);
               
            }
            else
            {
                if (new LessonTimetableService().ExitClassSheLessonDay1st(i, "lessontimetable", new SessionManager().GetUserId(Session)))
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Day is not avialable for this Batch','Message')", true);
                    numer = numer + 1;
                }
                if (new LessonTimetableService().ExitClassSheTimeDay2nd(i, "lessontimetable", new SessionManager().GetUserId(Session)))
                {
                   // ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Period is not avialable for this Batch','Message')", true);
                    numer = numer + 2;
                    
                }
                if (new LessonTimetableService().ExitVenueTimeDayGroup3rd(i, "lessontimetable", new SessionManager().GetUserId(Session)))
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Period is not avialable for this Batch','Message')", true);
                    numer = numer + 3;
                }
                if (new LessonTimetableService().ExitTutorDayTimeGroup4th(i, "lessontimetable", new SessionManager().GetUserId(Session)))
                {
                   // ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Venue is not avialable at this Time','Message')", true);
                    numer = numer + 4;
                }

                if (numer == 0)
                {
                    if (new LessonTimetableService().AddLessonTimetable(i, "lessontimetable", new SessionManager().GetUserId(Session)))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                    }
                }
                else if (numer == 10)
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops ! There is a clash <br/><br/>" + "1. The Day is not avialable for this Batch <br/>" + "2. The Period is not avialable for this Day <br/>" + "3. The Venue is not avialable at this Time <br/>" + "4. The Tutor is not avialable at this Time','Message')", true);
                    
                    uPanel.Update();
                    //ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops could not save. There may be a clash of Venue, Time, Day and or the Tutor is not avialable this period','Message')", true);
                }
                else if (numer == 9)
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops ! There is a clash <br/><br/>" + "1. The Period is not avialable for this Day <br/>" + "2. The Venue is not avialable at this Time <br/>" + "3. The Tutor is not avialable at this Time', 'Message')", true);
      
                    uPanel.Update();
                    //ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops could not save. There may be a clash of Venue, Time, Day and or the Tutor is not avialable this period','Message')", true);
                }
                else if (numer == 7)
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops ! There is a clash <br/><br/>" + "1. The Venue is not avialable at this Time <br/>" + "2. The Tutor is not avialable at this Time','Message')", true);
              
                    uPanel.Update();
                    //ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops could not save. There may be a clash of Venue, Time, Day and or the Tutor is not avialable this period','Message')", true);
                }
                else if (numer == 4)
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops ! There is a clash <br/><br/>" + "1. The Tutor is not avialable at this Time', 'Message')", true);
                    uPanel.Update();
                }

                

            }
            gvClassLessons.CancelEdit();
             loadPrograms();
            //lessErro(numer);
             reloadLessonSchudel(i.Classscheid);
            
            uPanel.Update();
            
        }

        private void lessErro(int numerro)
        {
            if (numerro == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
            }
            else if (numerro == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Day is not avialable for this Batch','Message')", true);
            }
            else if (numerro == 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Day is not avialable for this Batch','Message')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Period is not avialable for this Batch','Message')", true);
            }
            else if (numerro == 6)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Day is not avialable for this Batch','Message')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Period is not avialable for this Batch','Message')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Tutor is not avialable to teach this Lesson at this Period','Message')", true);
                    
            }
            else if (numerro == 10)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Day is not avialable for this Batch','Message')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Period is not avialable for this Batch','Message')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Tutor is not avialable to teach this Lesson at this Period','Message')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops This Venue is not avialable at this Time','Message')", true);
            }
            else if (numerro == -1)
            {
            ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('All fields are required','Message')", true);
            }
        }

        protected void dgProgram_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            int id = int.Parse(dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString());

            if (new LessonTimetableService().DeleteLessonTimetable(id, "lessontimetable", new SessionManager().GetUserId(Session)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
            }
            dgProgram.CancelEdit();
            loadPrograms();
            uPanel.Update();
        }

        protected void dgProgram_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgProgram.CancelEdit();
            clearfields();

            //cmbProgram.Value = dgProgram.GetMasterRowKeyValue();// (dgProgram.FocusedRowIndex, "xClassSche");
            reloadLessonSchudel(int.Parse(dgProgram.GetRowValues(dgProgram.FocusedRowIndex, "ID").ToString()));

            divLessons.Visible = true;
            uPanel.Update();
        }

        protected void cmbclLessonTime_Validation(object sender, ValidationEventArgs e)
        {
            Session["timeperiod"] = 0;
            Session["timeperiod"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbclLessonTime_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["timeperiod"] = 0;
            }
            else
            {
                Session["timeperiod"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void cmbclLessonTime_Init(object sender, EventArgs e)
        {
            _TimeperiodsListBox = (ASPxComboBox)sender;
            _TimeperiodsListBox.DataSource = new LookUpService().GetTimePeriods();
            _TimeperiodsListBox.DataBind();
        }

        protected void cmbTutorList_Validation(object sender, ValidationEventArgs e)
        {
            Session["tutorid"] = 0;
            Session["tutorid"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbTutorList_Init(object sender, EventArgs e)
        {
            var d = gvClassLessons.GetRowValues(gvClassLessons.EditingRowVisibleIndex, "LessonID");
            _TutorcomboBox = (ASPxComboBox)sender;
            _TutorcomboBox.DataSource = new LessonInstructorServices().GetAllLessonInstructorsByLessonID(int.Parse(gvClassLessons.GetRowValues(gvClassLessons.EditingRowVisibleIndex, "LessonID").ToString()), new SessionManager().GetUserId(Session));
            _TutorcomboBox.DataBind();
        }

        protected void cmbTutorList_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["tutorid"] = 0;
            }
            else
            {
                Session["tutorid"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void cmbLessonDay_Validation(object sender, ValidationEventArgs e)
        {
            Session["timedays"] = 0;
            Session["timedays"] = ((ASPxComboBox)sender).Value;
        }

        protected void cmbLessonDay_Init(object sender, EventArgs e)
        {
            _TimedayscomboBox = (ASPxComboBox)sender;
            _TimedayscomboBox.DataSource = new LookUpService().GetTimeDays();
            _TimedayscomboBox.DataBind();
        }

        protected void cmbLessonDay_Unload(object sender, EventArgs e)
        {
            if (((ASPxComboBox)sender).Value == null)
            {
                Session["timedays"] = 0;
            }
            else
            {
                Session["timedays"] = ((ASPxComboBox)sender).Value;
            }
        }

        protected void dgProgram_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smCourseSubjSchedule"));

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Edit:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                case ColumnCommandButtonType.Delete:
                    if (perms.Contains("DELETE")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
                //case ColumnCommandButtonType.Select:
                //    if (perms.Contains("VIEW")) { e.Enabled = true; } else { e.Enabled = false; }
                //    break;
            }
        }

       


        
    }
}