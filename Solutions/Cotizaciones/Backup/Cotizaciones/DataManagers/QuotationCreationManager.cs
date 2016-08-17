using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;
using System.Data;

namespace Cotizaciones.DataManagers
{
    static class QuotationCreationManager
    {
        public static DataSet GetQuotationData(int QuotationID)
        {
            DataSet ds;
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationData(QuotationID);
            ds = sp.ExecuteDataSet();
            DataRelation rel = new DataRelation("QSQSD", ds.Tables["Table1"].Columns["QuotationSectionID"], ds.Tables["Table2"].Columns["QuotationSectionID"]);
            ds.Relations.Add(rel);
            return ds;

        }
    }
}
