using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace mySmisLib
{
    public class Utils
    {
        public Utils() 
        {
           
        }

        public static string GetConfig(string ConfigKey)
        {
            return new InstanceConfigServices().GetConfig(ConfigKey);
        }
    
        public string CreateAlertDiv(string message, AlertType alertType)
        {
            string returndiv =
                              "<div class='{0}' data-uk-alert><a href='' class='uk-alert-close uk-close'></a>" +
                              "<p>{1}</p></div>";
            if (alertType == AlertType.Default)
            {
                returndiv = string.Format(returndiv, "uk-alert", message);
            }
            else if (alertType == AlertType.Info)
            {
                returndiv = string.Format(returndiv, "uk-alert uk-alert-info", message);
            }
            else if (alertType == AlertType.Success)
            {
                returndiv = string.Format(returndiv, "uk-alert uk-alert-success", message);
            }
            else if (alertType == AlertType.Warning)
            {
                returndiv = string.Format(returndiv, "uk-alert uk-alert-warning", message);
            }
            else if (alertType == AlertType.Error)
            {
                returndiv = string.Format(returndiv, "uk-alert uk-alert-danger", message);
            }

            return returndiv;
        }

        public int GetReportStatus(StatusReportType statustype)
        {
            int status = 0;
            if (statustype == StatusReportType.Created)
            {
                status =  1;
            }
            if (statustype == StatusReportType.Saved)
            {
                status =  2;
            }
            if (statustype == StatusReportType.Completed)
            {
                status =  3;
            }
            if (statustype == StatusReportType.Submitted)
            {
                status =  4;
            }
            return status;

        }       
    }

    public enum AlertType
    {
        Default,
        Info,
        Success,
        Warning,
        Error
    }

     public enum StatusReportType
        {
            Created,
            Saved,
            Completed,
            Submitted
        }

//public static class UtilsCMIS
//    {
//        public static int WordCount(this String str)
//        {
//            return str.Split(new char[] { ' ', '.', '?' }, 
//                             StringSplitOptions.RemoveEmptyEntries).Length;
//        }
//    } 
      


}