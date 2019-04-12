using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class studentregistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            loadRegStudents();

            if (IsPostBack)
            {
                if (cmbProgram.Value != null)
                {
                    loadUnRegStudents();
                }

                if (cmbProgramBB.Value != null)
                {
                    loadBatchRegStudents();
                }
            }
           

        }

        private void loadRegStudents()
        {
            gvRegisterdBatches.DataSource = new StudentRegistrationService().GetAllStudentRegistration(new SessionManager().GetUserId(Session));
            gvRegisterdBatches.DataBind();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 500;

            uPanel.Update();
        }
        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                loadUnRegStudents();
            }
            else
            {
                clearfields();
                uPanel.Update();
            }
            uPanel.Update();
        }

        private void loadUnRegStudents()
        {
            string regList = new StudentRegistrationService().GetStudentRegistrationByBatchIdBGroup(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(),new SessionManager().GetUserId(Session));
            gvStudents.DataSource = new StudentService().GetAllUnRegStudent(regList, new SessionManager().GetUserId(Session));
            gvStudents.DataBind();
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitNew")
            {
                clearfields();
                div_FeesBatch.Visible = true;
                loadPrograms();
                uPanel.Update();
            }
            else if (e.Item.Name == "mitCancel")
            {
                clearfields();
                div_FeesBatch.Visible = false;
                uPanel.Update();
            }
        }

        private void clearfields()
        {
            loadPrograms();

            gvStudents.DataSource = null;
            gvStudents.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string studReg = "";
            string studLessons = "";
            List<object> studUserIds = gvStudents.GetSelectedFieldValues("UserId");
            string regState = new InstanceConfigServices().GetConfig("lessonsRegistration");

            if (studUserIds.Count > 0)
            {
                if(cmbProgram.Value != null)
                {
                    List<Lesson> allLessons = new LessonService().GetAllLessonsByClassID(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));

                    if (allLessons.Count > 0)
                    { 
                    
                    foreach (object studUserId in studUserIds)
                    {
                        studReg += "('" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString() + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + studUserId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                        if (regState == "Administration")
                        {
                            foreach (Lesson allLesson in allLessons)
                            {
                                studLessons += "('" +studUserId +"','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString() + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + allLesson.ID +"','"+allLesson.ClassID +"','"+allLesson.ModuleID+ "','"+0+"','"+0+"','"+" "+"','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                            }
                        }
                    }
                
                    if (new StudentRegistrationService().AddStudentRegistrationList(studReg.TrimEnd(','), new SessionManager().GetUserId(Session)))
                    {
                        if (regState == "Administration")
                        {
                            new StudentLessonsRegistrationService().AddStudentLessonsRegistrationList(studLessons.TrimEnd(','), new SessionManager().GetUserId(Session));
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                        clearfields();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('There are no lessons/courses associated with this batch. ','Message')", true);
                }

                }
                else
                {
                    cmbProgram.IsValid = false;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Select at least a student','Message')", true);
            }
            loadRegStudents();
            uPanel.Update();
        }

        protected void gvRegisterdBatches_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            if (!new StudentLessonsRegistrationService().ExistStudentLessonsRegistration(int.Parse(gvRegisterdBatches.GetRowValues(gvRegisterdBatches.FocusedRowIndex, "ID").ToString()), gvRegisterdBatches.GetRowValues(gvRegisterdBatches.FocusedRowIndex, "StuduserId").ToString(), new SessionManager().GetUserId(Session)))
            {
                if (new StudentRegistrationService().DeleteStudentRegistration(int.Parse(gvRegisterdBatches.GetRowValues(gvRegisterdBatches.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Deleted Successfully','Message')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Deleting Failed','Message')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Deleting this record is not allowed. Delete all associated lessons before.','Message')", true);
            }
            loadRegStudents();
            uPanel.Update();
        }

        protected void mMainBB_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "mitNew")
            {
                clearfieldsBB();
                div_BB.Visible = true;
                loadProgramsBB();
                uPanel.Update();
            }
            else if (e.Item.Name == "mitCancel")
            {
                clearfieldsBB();
                div_BB.Visible = false;
                uPanel.Update();
            }
        }

        private void loadProgramsBB()
        {
            cmbProgramBB.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgramBB.DataBind();
            cmbProgramBB.GridView.Width = 600;

            uPanel.Update();
        }

        private void clearfieldsBB()
        {
            loadProgramsBB();
            cmbProgramBBNew.DataSource = "";
            cmbProgramBBNew.DataBind();
            gvBatchStudents.DataSource = null;
            gvBatchStudents.DataBind();
        }

        protected void cmbProgramBB_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgramBB.Value != null)
            {
                loadBatchRegStudents();
            }
            else
            {
                clearfieldsBB();
                
            }
            uPanel.Update();
        }

        private void loadBatchRegStudents()
        {
            cmbProgramBBNew.DataSource = new ClassSchedulerServices().GetAllClassSchedulerByClassID(int.Parse(cmbProgramBB.GridView.GetRowValues(cmbProgramBB.GridView.FocusedRowIndex, "ClassID").ToString()), DateTime.Parse(cmbProgramBB.GridView.GetRowValues(cmbProgramBB.GridView.FocusedRowIndex, "CreatedDate").ToString()), cmbProgramBB.GridView.GetRowValues(cmbProgramBB.GridView.FocusedRowIndex, "Bgroup").ToString(), new SessionManager().GetUserId(Session));
            cmbProgramBBNew.DataBind();
            cmbProgramBBNew.GridView.Width = 600;

            gvBatchStudents.DataSource = new StudentService().GetAllStudentByBatchIdBGroup(cmbProgramBB.GridView.GetRowValues(cmbProgramBB.GridView.FocusedRowIndex, "Bgroup").ToString(), int.Parse(cmbProgramBB.GridView.GetRowValues(cmbProgramBB.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            gvBatchStudents.DataBind();
            gvBatchStudents.Selection.SelectAll();
        }

        protected void btnSaveBB_Click(object sender, EventArgs e)
        {
            string studReg = "";
            List<object> studUserIds = gvBatchStudents.GetSelectedFieldValues("UserId");

            if (studUserIds.Count > 0)
            {
                    if(cmbProgramBBNew.Value != null)
                    {

                            if(cmbProgramBB.Value != null)
                            {
                                foreach (object studUserId in studUserIds)
                                {
                                    studReg += "('" + cmbProgramBBNew.GridView.GetRowValues(cmbProgramBBNew.GridView.FocusedRowIndex, "ID").ToString() + "','" + cmbProgramBBNew.GridView.GetRowValues(cmbProgramBBNew.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + studUserId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                                }
                                if (new StudentRegistrationService().AddStudentRegistrationList(studReg.TrimEnd(','), new SessionManager().GetUserId(Session)))
                                {
                                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
                                clearfieldsBB();
                                }
                                else
                                {
                                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Saving Failed','Message')", true);
                                }
                            }
                            else
                            {
                                cmbProgramBB.IsValid = false;
                            }
                    }
                    else
                    {
                    cmbProgramBBNew.IsValid = false;
                    }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Select at least a student','Message')", true);
            
            }

            loadRegStudents();
            uPanel.Update();
        }

        

        
    }
}