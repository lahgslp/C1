using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Linq;
using SubSonic.Schema;
using Cotizaciones.DataModel;
using System.Data;
using Cotizaciones.DataManagers;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

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

        public static List<string> ValidateEmailList(string input)
        {
            List<string> values = new List<string>();

            char[] separators = new char[]{' ',',',';'};
            string[] emails = input.Split(separators);
            foreach (var email in emails)
            {
                if (email != "")
                {
                    if (!isEmail(email))
                    {
                        values.Add(email);
                    }
                }
            }
            return values;
        }

        public static bool isValidUserName(string name)
        {
            string strRegex = @"^[a-zA-Z][a-zA-Z0-9_\.\-]*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(name))
                return (true);
            else
                return (false);
        }

        public static bool isValidPassword(string name)
        {
            string strRegex = @"^[a-zA-Z0-9_\.\-]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(name))
                return (true);
            else
                return (false);
        }

        public static bool CheckConnection(string ConnectionStringName)
        {
            bool result;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
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

        public static string GetConfigurationKeyValue(string KeyName)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.ConfigurationKeys
                         where p.Name == KeyName
                         select p;
            foreach (ConfigurationKey ck in result)
            {
                return ck.Value;
            }
            throw new Exception("ConfigurationKey " + KeyName + " not found");
        }

        public static string GetFileExtension(string fileName)
        {
            if (fileName.LastIndexOf(".") > fileName.LastIndexOf("\\"))
            {
                return fileName.Substring(fileName.LastIndexOf(".") + 1);
            }
            return "";
        }

        public static string GetFileName(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf("\\") + 1);
        }

        public static string GetFilePath(string fileName)
        {
            return fileName.Substring(0, fileName.Length - fileName.LastIndexOf("\\"));
        }

        public static DateTime ConvertToDate(string datetime)
        {
            int year = Convert.ToInt32(datetime.Substring(0, 4));
            int month = Convert.ToInt32(datetime.Substring(4, 2));
            int day = Convert.ToInt32(datetime.Substring(6, 2));
            return new DateTime(year, month, day);
        }

        public static void CreateEmail(int QuotationID, DataSet QuotationData, bool IsDefaultAttachment, string AttachmentName)
        {
            bool accountFound = false;
            List<string> accountsFound = new List<string>();

            //Create the email
            Microsoft.Office.Interop.Outlook.Application objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mail = (Microsoft.Office.Interop.Outlook.MailItem)(objOutlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));
            mail.To = QuotationData.Tables["Table"].Rows[0]["EmailTo"].ToString();
            string CreatorEmail = QuotationData.Tables["Table"].Rows[0]["CreatorEmail"].ToString();
            foreach (Microsoft.Office.Interop.Outlook.Account account in objOutlook.Session.Accounts)
            {
                accountsFound.Add(account.SmtpAddress);
                if (account.SmtpAddress == CreatorEmail)
                {
                    mail.SendUsingAccount = (Microsoft.Office.Interop.Outlook.Account)account;
                    accountFound = true;
                }
            }
            if (QuotationData.Tables["Table"].Rows[0]["EmailTo"].ToString() != String.Empty)
            {
                mail.CC = QuotationData.Tables["Table"].Rows[0]["NotifyToEmail"].ToString();
            }
            mail.Subject = "Cotización para " + QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString();
            mail.Body = GetEmailBody(QuotationData);
            QuotationAttachment qa;
            if (IsDefaultAttachment)
            {
                qa = QuotationAttachmentManager.GetQuotationAttachment(QuotationID);
            }
            else
            {
                qa = QuotationAttachmentManager.GetQuotationAttachmentByName(QuotationID, AttachmentName);
            }
            if (qa != null)
            {
                string sourceFileName = Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + qa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(qa.ExternalFileName);
                string destFileName = Path.GetTempPath() + qa.ExternalFileName;
                File.Copy(sourceFileName, destFileName, true);
                mail.Attachments.Add(destFileName, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, qa.ExternalFileName);
                if (!accountFound)//If account not found in outlook
                {
                    string emails = "";
                    if (accountsFound.Count > 0)
                    {
                        emails = string.Join(",", accountsFound.ToArray());
                    }
                    MessageBox.Show("No se encontro la cuenta " + CreatorEmail + " en Outlook, favor de validar. Cuentas existentes: " + emails, "Validar cuenta de correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                mail.Display(false);
            }
            else
            {
                throw new Exception("Unable to locate quotation file");
            }
        }

        public static string GetEmailBody(DataSet QuotationData)
        {
            string body = "";
            if (QuotationData.Tables["Table"].Rows[0]["ContactName"] != null && QuotationData.Tables["Table"].Rows[0]["ContactName"].ToString().Trim() != String.Empty)
            {
                body += "Estimado(a) " + QuotationData.Tables["Table"].Rows[0]["ContactName"].ToString() + ",";
            }
            else
            {
                body += "A quien corresponda,";
            }
            body += Environment.NewLine;
            if (QuotationData.Tables["Table"].Rows[0]["CustomerName"] != null && QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString().Trim() != String.Empty)
            {
                body += QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString();
            }
            body += Environment.NewLine + Environment.NewLine;

            body += QuotationData.Tables["Table"].Rows[0]["GreetingsMessage"].ToString() + Environment.NewLine;

            body += QuotationData.Tables["Table"].Rows[0]["Signature"].ToString() + Environment.NewLine;
            return body;
        }
    }
}