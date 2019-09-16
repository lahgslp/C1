using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Cotizaciones.Common
{
    class PreferencesHelper
    {
        static Dictionary<string, string> preferences = null;

        static string GetInitialValues()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DefaultUser=");
            sb.AppendLine("FilterLastUserValue=");
            sb.AppendLine("FilterLastQuotationIDValue=0");
            sb.AppendLine("FilterLastQuotationStatusTypeID=0");
            sb.AppendLine("FilterLastSectionTypeIDValue=0");
            sb.AppendLine("FilterLastPipeDiameterTypeIDValue=0");
            sb.AppendLine("FilterLastDateFromValue=");
            sb.AppendLine("FilterLastDateToValue=");
            sb.AppendLine("FilterLastCustomerIDValue=0");
            sb.AppendLine("FilterLastCustomerContactIDValue=0");
            sb.AppendLine("FilterLastCompanyIDValue=0");
            return sb.ToString();
        }
        static void CreateFile(string file, string content)
        {
            using (StreamWriter writer = File.CreateText(file))
            {
                writer.Write(content);
            }
        }
        static string GetFileFullPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + ConfigurationHelper.GetConfigurationValue("RoamingFolder");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + "\\" + ConfigurationHelper.GetConfigurationValue("PreferencesFile");
        }
        static Dictionary<string, string> GetPreferences()
        {
            if (preferences == null)
            {
                preferences = new Dictionary<string, string>();
                string file = GetFileFullPath();
                if (!File.Exists(file))
                {
                    CreateFile(file, GetInitialValues());
                }
                string content = File.ReadAllText(file);
                string[] keys = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string kv in keys)
                {
                    if (kv != "")
                    {
                        string[] splitted = kv.Split('=');
                        preferences.Add(splitted[0], splitted[1]);
                    }
                }
            }
            return preferences;
        }
        public static string GetPreference(string key)
        {
            Dictionary<string, string> prefs = GetPreferences();
            if (prefs.Keys.Contains(key))
            {
                return prefs[key];
            }
            return "";
        }

        public static void SetPreference(string key, string value)
        {
            Dictionary<string, string> prefs = GetPreferences();
            prefs[key] = value;
            SetPreferences(prefs);
        }

        static void SetPreferences(Dictionary<string, string> prefs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in prefs.Keys)
            {
                sb.AppendLine(key + "=" + prefs[key]);
            }
            CreateFile(GetFileFullPath(), sb.ToString());
        }
    }
}
