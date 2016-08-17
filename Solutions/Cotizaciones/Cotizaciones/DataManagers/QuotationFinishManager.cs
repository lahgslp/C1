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
    static class QuotationFinishManager
    {
        public static void SaveQuotationFinishDetails(int QuotationID, string User, string Notes, string FootNotes, string ValidPeriodDescription, string PaymentDescription, string InvoiceMethodDescription)
        {
            Quotation q = new Quotation();
            q.SetIsLoaded(true);
            q.QuotationID = QuotationID;
            q.ValidPeriodDescription = ValidPeriodDescription;
            q.PaymentDescription = PaymentDescription;
            q.InvoiceMethodDescription = InvoiceMethodDescription;
            q.FootNoteDescription = FootNotes;
            q.Modifier = User;
            q.Modified = DateTime.Now;
            q.Notes = Notes;
            q.SetIsNew(false);
            q.Save();

        }

        public static DataSet GetQuotationFinishReferenceData()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationFinishReferenceData();
            return sp.ExecuteDataSet();
        }

        public static Quotation GetQuotationEntity(int QuotationID)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Quotations
                         where p.QuotationID == QuotationID
                         select p;
            foreach (var item in result)
            {
                return item;
            }
            return null;
        }

        public static void FinalizeQuotation(int QuotationID, string User, Cotizaciones.Enums.QuotationStatusType status)
        {
            UpdateQuotationStatus(QuotationID, User, status);
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
