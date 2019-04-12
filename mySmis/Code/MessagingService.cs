using mySmisLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace mySmis
{
    public class MessagingService
    {
        private string GHCode = "+233";

        public Boolean SendEmail(string from, List<string> to, string subject, string body)
        {
            Boolean returnVal = false;
            if (Utils.GetConfig("emailAlertActive") == "1")
            {
                SmtpClient smtpClient = null;
                try
                {
                    string email_alert_from_name = Utils.GetConfig("emailAlertFromName");
                    string smtp_server = Utils.GetConfig("smtpServer");
                    string smtp_port = Utils.GetConfig("smtpPort");
                    string smtp_user = Utils.GetConfig("smtpUser");
                    string smtp_password = Utils.GetConfig("smtpPassword");
                    int smtpPort = 25;
                    int.TryParse(smtp_port, out smtpPort);

                    smtpClient = new SmtpClient(smtp_server, smtpPort);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    //order of the two lines below is important for successful authentication in GMAIL
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(smtp_user, smtp_password);

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, email_alert_from_name);
                    foreach (string toAddress in to)
                    {
                        if (toAddress.Trim().Length > 0)
                        {
                            mail.To.Add(toAddress);
                        }
                    }
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = body;                    

                    smtpClient.Send(mail);
                    returnVal = true;
                }
                catch (SmtpException smtpEx)
                {

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    smtpClient.Dispose();
                }
            }

            return returnVal;
        }

        public Boolean SendSms(string from, List<string> to, string message)
        {
            Boolean returnVal = false;
            string toStr = "";
            foreach (string s in to)
            {
                toStr += s.Trim() + ",";
            }
            toStr = toStr.Trim(',');
            returnVal = SendSms(from, toStr, message);
            return returnVal;
        }

        public Boolean SendSms(string from, string to, string message)
        {
            Boolean returnVal = false;
            if (Utils.GetConfig("smsAlertActive") == "1")
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://txtconnect.co/api/send/");
                //WebRequest request = WebRequest.Create("http://62.129.149.58:5005/http_access.php");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                to = ValidatePhoneNumbers(to);
                string postData = string.Format("token=a1db616dff536426a04892a467c0c0beb29c64f2&from={0}&msg={1}&to={2}",
                    from, message, to.Replace("+",""));
                //string postData = string.Format("company=icgcht&ccode=icgc256114&sender={0}&message={1}&recipient={2}",
                // from, message ,to[0]);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                SmsApiResponse resp = js.Deserialize<SmsApiResponse>(responseFromServer);

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                if (resp.error.CompareTo("0") == 0 && resp.response.CompareTo("1") == 0)
                    returnVal = true;
                else
                    returnVal = false;
            }

            return returnVal;
        }

        public string ValidatePhoneNumbers(string mumbers)
        {
            string[] strArr = mumbers.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
            string toStr = "";
            foreach (string s in strArr)
            {
                if (s.StartsWith("00") || s.StartsWith(GHCode))
                {
                    //do nothing
                }
                else
                {
                    toStr += GHCode + s.TrimStart('0') + ",";
                }
            }

            toStr = toStr.Trim(',');

            return toStr;
        }
    }

    public class SmsApiResponse
    {
        public string error { get; set; }
        public string response { get; set; }
    }
}