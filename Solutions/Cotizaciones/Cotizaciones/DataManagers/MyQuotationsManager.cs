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
    static class MyQuotationsManager
    {
        public static DataSet GetMyQuotationsReferenceData()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetMyQuotationsReferenceData();
            return sp.ExecuteDataSet();
        }

        public static DataSet GetMyQuotations(string Creator, string DateFrom, string DateTo, int SectionTypeID, int PipeDiameterTypeID, int QuotationID, int CustomerID, int CustomerContactID, int QuotationStatusTypeID, int CompanyID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetMyQuotations(Creator, DateFrom, DateTo, SectionTypeID, PipeDiameterTypeID, QuotationID, CustomerID, CustomerContactID, QuotationStatusTypeID, CompanyID);
            return sp.ExecuteDataSet();
        }

        public static void DeleteQuotation(int QuotationID, string User)
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
                    q.Active = "I";
                    q.SetIsNew(false);
                    q.Save();
                    //
                    scope.Complete();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public static void SetQuotationSold(int QuotationID, string User)
        {
            UpdateQuotationStatus(QuotationID, User, Cotizaciones.Enums.QuotationStatusType.Sold);
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

        public static int CloneQuotation(int QuotationID, string User)
        {
            int NewQuotationID;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //
                    DataSet ds;
                    FersumDB fdb = new FersumDB();
                    StoredProcedure sp = fdb.Fersum_Ins_CloneQuotation(QuotationID, User);
                    ds = sp.ExecuteDataSet();
                    NewQuotationID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    //
                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return NewQuotationID;
        }

        public static int CreateQuotation(string User)
        {
            int newQuotationID;
            UserPreference up = GetUserPreference(User);
            Quotation q = new Quotation();
            q.Active = "A";
            q.Creator = User;
            q.Created = DateTime.Now;
            q.ValidPeriodDescription = "";
            q.PaymentDescription = "";
            q.InvoiceMethodDescription = "";
            q.QuotationStatusTypeID = 1;    //Incompleta
            q.FootNoteDescription = "";
            q.CompanyID = up.DefaultCompanyID;
            q.Notes = up.DefaultNotes;
            q.FootNoteDescription = up.DefaultFootNotes;
            q.Add();
            newQuotationID = q.QuotationID;
            return newQuotationID;
        }

        public static User GetUser(string user)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Users
                         where p.ShortName == user
                         select p;
            foreach (User u in result)
            {
                return u;
            }
            return null;
        }

        public static UserPreference GetUserPreference(string user)
        {
            User u = GetUser(user);
            FersumDB db = new FersumDB();
            var result = from up in db.UserPreferences
                         where up.UserID == u.UserID
                         select up;
            foreach (UserPreference up in result)
            {
                return up;
            }
            return null;
        }

    }
}
