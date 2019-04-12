using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace mySmisLib
{
    public class ServiceObjectSecurity : MarshalByRefObject
    {
        public string EncodePasswordMD5(string p_inputPassword)
        {
            try
            {
                Byte[] origionalBytes;
                Byte[] encryptedBytes;
                MD5 md5 = new MD5CryptoServiceProvider();
                //convert input string to bytes
                origionalBytes = ASCIIEncoding.Default.GetBytes(p_inputPassword);
                //encrypt the input bytes to md5
                encryptedBytes = md5.ComputeHash(origionalBytes);
                //convert the encrypted bytes to readable format and return

                String encryptedPassword = BitConverter.ToString(encryptedBytes);
                encryptedPassword = encryptedPassword.Replace("-", "");
                return encryptedPassword;
            }
            catch (CryptographicException cex)
            {
                //ErrorLogService errLog = new ErrorLogService();
                //errLog.SaveErrorToLocalLog(101, "Crypto Hashing", cex.Message, DateTime.Now, "1122334455", ShowErrorDialog.Yes);
                return "";
            }
            catch (Exception ex)
            {
                //ErrorLogService errLog = new ErrorLogService();
                //errLog.SaveErrorToLocalLog(101, "Crypto Hashing", ex.Message, DateTime.Now, "1122334455", ShowErrorDialog.No);
                return "";
            }
        }

        public string EncodeMD5(string p_inputPassword)
        {
            try
            {
                Byte[] origionalBytes;
                Byte[] encryptedBytes;
                MD5 md5 = new MD5CryptoServiceProvider();
                //convert input string to bytes
                origionalBytes = ASCIIEncoding.Default.GetBytes(p_inputPassword);
                //encrypt the input bytes to md5
                encryptedBytes = md5.ComputeHash(origionalBytes);
                //convert the encrypted bytes to readable format and return

                String encryptedPassword = BitConverter.ToString(encryptedBytes);
                encryptedPassword = encryptedPassword.Replace("-", "");
                return encryptedPassword;
            }
            catch (CryptographicException cex)
            {
                //ErrorLogService errLog = new ErrorLogService();
                //errLog.SaveErrorToLocalLog(101, "Crypto Hashing", cex.Message, DateTime.Now, "1122334455", ShowErrorDialog.Yes);
                return "";
            }
            catch (Exception ex)
            {
                //ErrorLogService errLog = new ErrorLogService();
                //errLog.SaveErrorToLocalLog(101, "Crypto Hashing", ex.Message, DateTime.Now, "1122334455", ShowErrorDialog.No);
                return "";
            }
        }
    }

    //public static class UserSessionService
    //{
    //    public static LicenseIInfo License;
    //}


}