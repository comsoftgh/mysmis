using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using mySmisLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class feesshedules : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            loadBatchFees();
            cmbStudentBatch.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbStudentBatch.DataBind();
            cmbStudentBatch.GridView.Width = 500;
            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            string[] perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smFeesSchedule")).Split(';');
            foreach (string perm in perms)
            {
                switch (perm)
                {

                    case "ADD":
                        mMain.Items.FindByName("mitNew").Enabled = true;
                        //mMainProgram.Items.FindByName("mitCancel").Enabled = true;
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
        private void loadBatchFees()
        {
            gvBatchFees.DataSource = new FeesBatchesService().GetAllFeesBatches("All Students", new SessionManager().GetUserId(Session));
            gvBatchFees.DataBind();

            uPanel.Update();
        }

        private void loadPrograms()
        {
            cmbProgram.DataSource = new ClassSchedulerServices().GetAllClassScheduler(new SessionManager().GetUserId(Session));
            cmbProgram.DataBind();
            cmbProgram.GridView.Width = 600;
            
            uPanel.Update();
        }

        protected void cmbProgram_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProgram.Value != null)
            {
                reloadFeesBatch();
            }
            else
            {
                clearfields();
            }
            uPanel.Update();
        }

        private void reloadFeesBatch()
        {
            //if ((new FeesBatchesService().GetAllFeesBatchesByBatchid(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()),"All",new SessionManager().GetUserId(Session))).Count == 0)
            //{
            //    gvFeesBatch.DataSource = new FeesBatchesService().GetAllFeesBatches("All",new SessionManager().GetUserId(Session));
            //    gvFeesBatch.DataBind();
            //}
            //else
            //{
            gvFeesBatch.DataSource = new FeesCategoryService().GetAllFeesCategoryByBatchid(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), "All Students", new SessionManager().GetUserId(Session));
                gvFeesBatch.DataBind();
            //}
                
        }

        protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mitNew":
                    clearfields();
                    div_FeesBatch.Visible = true;
                    loadPrograms();
                    break;
                case "mitCancel":
                    clearfields();
                    div_FeesBatch.Visible = false;
                    break;
                case "mitExportxls":
                    dataExporter.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "mitReport":
                    Session["fromwhere"] = "~/feesshedules.aspx";
                    Session["report"] = new mySmis.reports.rptProgramsLevels();
                    Response.Redirect("~/documentviewer.aspx");
                    break;
            }
                            
                uPanel.Update();
            
        }

        private void clearfields()
        {
            loadPrograms();

            gvFeesBatch.DataSource = null;
            gvFeesBatch.DataBind();
        }

        protected void gvFeesBatch_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {

            e.Handled = true;
            string fbatch = "";
            string studFees = "";
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                
                //get all batch of the same program/course 
               // List<int> batchIDs = new ClassSchedulerServices().GetClassSchedulerIDs(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ClassID").ToString()), cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(), new SessionManager().GetUserId(Session));
                
               // foreach (int batchID in batchIDs)
               // {
                    //prepare the data for all the batches fees 
                //fbatch += "('" + int.Parse(e.UpdateValues[i].NewValues[2].ToString()) + "','" + int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()) + "','" + double.Parse(e.UpdateValues[i].NewValues[0].ToString()) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString() + "'),";
                    //get all the sudent registered under that batch by the batch IDs
                List<StudentRegistration> batchRegStud = new StudentRegistrationService().GetAllStudentRegistrationByBatchIdBgroup(int.Parse(cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString()), cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString(), new SessionManager().GetUserId(Session));
                    if (batchRegStud.Count > 0)
                    {
                        foreach (StudentRegistration studUserId in batchRegStud)
                        {
                            studFees += "('" + int.Parse(e.UpdateValues[i].NewValues[2].ToString()) + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "ID").ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + studUserId.StuduserId + "','" + cmbProgram.GridView.GetRowValues(cmbProgram.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + double.Parse(e.UpdateValues[i].NewValues[0].ToString()) + "'),";
                        }
                    }
                //}
            
            }
            //if (fbatch.Length != 0 && studFees.Length != 0)
            if (studFees.Length != 0)
            {
                //new FeesBatchesService().AddFeesBatchesList(fbatch.TrimEnd(','), new SessionManager().GetUserId(Session));
                new StudentFeesService().AddStudentFeesList(studFees.TrimEnd(','), new SessionManager().GetUserId(Session));
               
                //Session["alertmsg"] = "1";
               ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
            }
            else
            {
                //Session["alertmsg"] = "2";
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops something is not right! No student registered for this batch','Message')", true);
                        
            }
            loadBatchFees();
            uPanel.Update();

        }

        protected void cmbStudentBatch_ValueChanged(object sender, EventArgs e)
        {
            if (cmbStudentBatch.Value != null)
            {
                loadIndividualFee();
                loadBatchStudents();
            }
            else
            {
                clearfieldsStudentBatch();
            }
            div_students.Visible = true;

        }

        private void clearfieldsStudentBatch()
        {
            loadBatchFees();
            gvIndividualFee.DataSource = null;
            gvIndividualFee.DataBind();

            gvStudents.DataSource = null;
            gvStudents.DataBind();
        }

        private void loadBatchStudents()
        {
            gvStudents.DataSource = new StudentService().GetAllStudentByBatchIdBGroup(cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "Bgroup").ToString(), int.Parse(cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "ID").ToString()), new SessionManager().GetUserId(Session));
            gvStudents.DataBind();
        }

        private void loadIndividualFee()
        {
            //if ((new FeesBatchesService().GetAllFeesBatchesByBatchid(int.Parse(cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "ID").ToString()), "Some", new SessionManager().GetUserId(Session))).Count == 0)
            //{
            //    gvIndividualFee.DataSource = new FeesBatchesService().GetAllFeesBatches("Some", new SessionManager().GetUserId(Session));
            //    gvIndividualFee.DataBind();
            //}
            //else
            //{
            gvIndividualFee.DataSource = new FeesCategoryService().GetAllFeesCategoryByBatchid(int.Parse(cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "ID").ToString()), "Particular Students", new SessionManager().GetUserId(Session));
                gvIndividualFee.DataBind();
           // }

        }
        protected void gvIndividualFee_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            e.Handled = true;
            string fbatch = "";
            string studFees = "";
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                //fbatch += "('" + int.Parse(e.UpdateValues[i].NewValues[2].ToString()) + "','" + cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "ID").ToString() + "','" + double.Parse(e.UpdateValues[i].NewValues[0].ToString()) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "Bgroup").ToString() + "'),";
                List<object> studUserIds = gvStudents.GetSelectedFieldValues("UserId");

                if (studUserIds.Count > 0)
                {

                    foreach (object studUserId in studUserIds)
                    {
                        studFees += "('" + int.Parse(e.UpdateValues[i].NewValues[2].ToString()) + "','" + cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "ID").ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + studUserId + "','" + cmbStudentBatch.GridView.GetRowValues(cmbStudentBatch.GridView.FocusedRowIndex, "Bgroup").ToString() + "','" + double.Parse(e.UpdateValues[i].NewValues[0].ToString()) + "'),";
                    }

                }
            }

            //if (fbatch.Length != 0 && studFees.Length != 0)
            if (studFees.Length != 0)
            {
               
                //new FeesBatchesService().AddFeesBatchesList(fbatch.TrimEnd(','), new SessionManager().GetUserId(Session));
                new StudentFeesService().AddStudentFeesList(studFees.TrimEnd(','), new SessionManager().GetUserId(Session));
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Saved Successfully','Message')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.info('Oops something is not right! No data to save','Message')", true);
                    
            }
            loadBatchFees();
            uPanel.Update();
           

           

        }

        protected void gvBatchFees_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms"));

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

        protected void gvFeesBatch_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms"));

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

        protected void gvIndividualFee_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms"));

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

        protected void gvStudents_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string perms = (new PermissionService().GetPermissionsActivity(new SessionManager().GetUserId(this.Session), "smPrograms"));

            switch (e.ButtonType)
            {
                
                case ColumnCommandButtonType.Select:
                    if (perms.Contains("EDIT")) { e.Enabled = true; } else { e.Enabled = false; }
                    break;
            }
        }

        
    }
}