﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Cotizaciones.Common;

namespace Cotizaciones.Common
{
    public class Logger
    {
        public static void LogException(Exception e)
        {
            StreamWriter SW;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + ConfigurationHelper.GetConfigurationValue("RoamingFolder");
            SW = File.AppendText(path + "\\" + ConfigurationHelper.GetConfigurationValue("LogFile"));
            SW.WriteLine("--------------------------------------------------");
            SW.WriteLine(DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
            SW.WriteLine(e.Message);
            SW.WriteLine("");
            SW.WriteLine(e.InnerException);
            SW.WriteLine("");
            SW.WriteLine(e.StackTrace);
            SW.Close();
        }
    }
}
