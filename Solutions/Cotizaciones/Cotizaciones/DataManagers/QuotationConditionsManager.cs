using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;
using System.Data;
using System.Transactions;

namespace Cotizaciones.DataManagers
{
    static class QuotationConditionsManager
    {
        public static DataSet GetQuotationConditions(int QuotationID)
        {
            return SetQuotationConditionsDataRelationship(QuotationID);
        }

        private static DataSet GetQuotationConditionsData(int QuotationID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationConditionsByQuotationID(QuotationID);
            return sp.ExecuteDataSet();
        }

        public static DataSet GetQuotationConditionsReferenceData()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationConditionsReferenceData();
            return sp.ExecuteDataSet();
        }

        private static DataSet SetQuotationConditionsDataRelationship(int QuotationID)
        {
            DataSet ds = GetQuotationConditionsData(QuotationID);
            DataRelation rel =  new DataRelation("",ds.Tables[0].Columns["QuotationSectionID"], ds.Tables[1].Columns["QuotationSectionID"]);
            ds.Relations.Add(rel);
            return ds;
        }

        public static void SaveQuotationConditions(int QuotationID, string User, DataSet QuotationConditions, bool UpdateStatus)
        {
            foreach (DataRow row in QuotationConditions.Tables["Table"].Rows)
            {
                UpdateQuotationSection(row, User);
            }
            foreach (DataRow row in QuotationConditions.Tables["Table1"].Rows)
            {
                UpdateQuotationSectionDetail(row, User);
            }
            if (UpdateStatus)
            {
                UpdateQuotationStatus(QuotationID, User, Cotizaciones.Enums.QuotationStatusType.Complete);
            }
        }

        private static void UpdateQuotationSection(DataRow row, string User)
        {
            QuotationSection qs = new QuotationSection();
            qs.SetIsLoaded(true);
            qs.QuotationSectionID = Convert.ToInt32(row["QuotationSectionID"]);
            qs.SectionDescription = row["Description"].ToString();
            qs.Modifier = User;
            qs.Modified = DateTime.Now;
            qs.SetIsNew(false);
            qs.Save();
        }

        private static void UpdateQuotationSectionDetail(DataRow row, string User)
        {
            QuotationSectionDetail qsd = new QuotationSectionDetail();
            qsd.SetIsLoaded(true);
            qsd.QuotationSectionDetailID = Convert.ToInt32(row["QuotationSectionDetailID"]);
            qsd.Price = Convert.ToDecimal(row["Price"]);
            //qsd.PaymentDescription = row["PaymentDescription"].ToString();
            qsd.DeliveryDescription = row["DeliveryDescription"].ToString();
            qsd.DeliveryTimeDescription = row["DeliveryTimeDescription"].ToString();
            qsd.CurrencyDescription = row["CurrencyDescription"].ToString();
            qsd.Weight = row["Weight"].ToString();
            //qsd.ValidPeriodDescription = row["ValidPeriodDescription"].ToString();
            qsd.Modifier = User;
            qsd.Modified = DateTime.Now;
            qsd.SetIsNew(false);
            qsd.Save();
        }

        private static void UpdateQuotationStatus(int QuotationID, string User, Cotizaciones.Enums.QuotationStatusType newStatus)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //
                    Quotation q = new Quotation();
                    q.SetIsLoaded(true);
                    q.QuotationID = QuotationID;
                    q.Modifier = User;
                    q.Modified = DateTime.Now;
                    q.QuotationStatusTypeID = Convert.ToInt32(newStatus);
                    q.SetIsNew(false);
                    q.Save();
                    //
                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
