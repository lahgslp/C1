using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace Cotizaciones
{
    public static class Utilities
    {
        public static bool isEmail(string inputEmail)
        {
            //inputEmail = NulltoString(inputEmail);
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool CheckConnection()
        {
            bool result;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Fersum"].ConnectionString);
            try
            {
                conn.Open();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}