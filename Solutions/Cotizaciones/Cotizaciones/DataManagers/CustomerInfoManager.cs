using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;
using System.Transactions;

namespace Cotizaciones.DataManagers
{
    static class CustomerInfoManager
    {
        public static Quotation GetQuotationInfo(int quotationID)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Quotations
                         where p.QuotationID == quotationID
                         select p;
            foreach (var item in result)
            {
                return item;
            }
            return null;
        }

        public static int CreateCustomer(string Description, string User)
        {
            int customerID;
            Customer c = new Customer();
            c.Description = Description;
            c.Active = "A";
            c.Creator = User;
            c.Created = DateTime.Now;
            c.Add();
            customerID = c.CustomerID;
            return customerID;
        }

        public static int CreateCustomerContact(string ContactName, string Email, int CustomerID, string User)
        {
            int contactID;
            CustomerContact cc = new CustomerContact();
            cc.ContactName = ContactName;
            cc.Email = Email;
            cc.CustomerID = CustomerID;
            cc.Active = "A";
            cc.Creator = User;
            cc.Created = DateTime.Now;
            cc.Add();
            contactID = cc.CustomerContactID;
            return contactID;
        }

        public static void SaveCustomerInfo(int quotationID, int companyID, int customerID, int contactID, string email, string user)
        {
            bool callSP = false;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //
                    Quotation q = new Quotation();
                    q.SetIsLoaded(true);
                    q.QuotationID = quotationID;
                    if (customerID > 0)
                    {
                        q.CustomerID = customerID;
                    }
                    if (contactID > 0)
                    {
                        q.CustomerContactID = contactID;
                    }
                    else
                    {
                        callSP = true;
                    }
                    q.CompanyID = companyID;
                    q.EmailTo = email;
                    q.Modifier = user;
                    q.Modified = DateTime.Now;
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
            if (callSP == true)//Call to explicitely remove the reference to a customer
            {
                FersumDB fdb = new FersumDB();
                StoredProcedure sp = fdb.Fersum_Upd_CustomerContact(quotationID);
                sp.ExecuteDataSet();
            }
        }
    }
}
