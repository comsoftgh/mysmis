using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace mySmisLib
{
   public static class DbCon
    {
       public static string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString; 
       
    }
}
