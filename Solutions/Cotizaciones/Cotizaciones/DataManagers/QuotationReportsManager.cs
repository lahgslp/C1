using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Schema;
using System.Data;
using Cotizaciones.DataModel;

namespace Cotizaciones.DataManagers
{
    static class QuotationReportsManager
    {
        public static DataSet GetQuotationReport(string DateFrom, string DateTo)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationsReport(DateFrom, DateTo);
            return sp.ExecuteDataSet();
        }
    }
}
