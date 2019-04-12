using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySmis
{
    public partial class upload : System.Web.UI.Page
    {
        private const string UPLOAD_DIR = "~/studentedudocs/";
        private const string UPLOAD_DIR_CLIENTSIDE = "/picstudent/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            if (FileUpload1.HasFile)
                // Call a helper method routine to save the file.
                SaveFile(FileUpload1.PostedFile);
            else
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
        }

        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            //string savePath = UPLOAD_DIR;

            // Get the name of the file to upload.
            string fileName = FileUpload1.FileName;

            // Create the path and file name to check for duplicates.
           // string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
           // string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            //if (System.IO.File.Exists(pathToCheck))
            //{
            //    int counter = 2;
            //    while (System.IO.File.Exists(pathToCheck))
            //    {
            //        // if a file with this name already exists,
            //        // prefix the filename with a number.
            //        tempfileName = counter.ToString() + fileName;
            //        pathToCheck = savePath + tempfileName;
            //        counter++;
            //    }

               // fileName = tempfileName;

                // Notify the user that the file name was changed.
               // UploadStatusLabel.Text = "A file with the same name already exists." +
            //        "<br />Your file was saved as " + fileName;
            //}
            //else
            //{
                // Notify the user that the file was saved successfully.
                UploadStatusLabel.Text = "Your file was uploaded successfully.";
           // }

            // Append the name of the file to upload to the path.
                string savePath = Path.Combine(Server.MapPath(UPLOAD_DIR), fileName);

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload1.SaveAs(savePath);

        }
     

       

      
    }
}