﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Cotizaciones.Common
{
    class ConfigurationHelper
    {
        public static string ConnectionString { get; set; }
        public static string GetConfigurationValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
