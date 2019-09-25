using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;

namespace Cotizaciones.DataManagers
{
    class EditCatalogsManager
    {
        public string GetDeliveryTypes()
        {
            FersumDB fdb = new FersumDB();
            StringBuilder sb = new StringBuilder();
            foreach (var dt in fdb.DeliveryTypes)
            {
                sb.AppendLine(dt.Description);
            }
            return (string)sb.ToString();
        }

        public string GetDeliveryTimeTypes()
        {
            FersumDB fdb = new FersumDB();
            List<string> dts = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (var dt in fdb.DeliveryTimeTypes)
            {
                sb.AppendLine(dt.Description);
            }
            return (string)sb.ToString();
        }
        public void UpdateDeliveryTypes(string dts)
        {
            FersumDB fdb = new FersumDB();
            foreach (var dt in fdb.DeliveryTypes)
            {
                dt.Delete();
            }

            string[] separators = new[] { "\r\n", "\r", "\n" };
            string[] splitted = dts.Split(separators, StringSplitOptions.None);
            foreach (var s in splitted)
            {
                DeliveryType dt = new DeliveryType();
                dt.Description = s;
                dt.Save();
            }
        }
        public void UpdateDeliveryTimeTypes(string dts)
        {
            FersumDB fdb = new FersumDB();
            foreach (var dt in fdb.DeliveryTimeTypes)
            {
                dt.Delete();
            }

            string[] separators = new[] { "\r\n", "\r", "\n" };
            string[] splitted = dts.Split(separators, StringSplitOptions.None);
            foreach (var s in splitted)
            {
                DeliveryTimeType dt = new DeliveryTimeType();
                dt.Description = s;
                dt.Save();
            }
        }
    }
}
