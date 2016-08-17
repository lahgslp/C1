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
/*            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //*/
                    Customer c = new Customer();
                    c.Description = Description;
                    c.Active = "A";
                    c.Creator = User;
                    c.Created = DateTime.Now;
                    c.Add();
                    customerID = c.CustomerID;
                    //
/*                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }*/

            return customerID;
        }

        public static int CreateCustomerContact(string ContactName, string Email, int CustomerID, string User)
        {
            int contactID;

            /*using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //*/
                    CustomerContact cc = new CustomerContact();
                    cc.ContactName = ContactName;
                    cc.Email = Email;
                    cc.CustomerID = CustomerID;
                    cc.Active = "A";
                    cc.Creator = User;
                    cc.Created = DateTime.Now;
                    cc.Add();
                    contactID = cc.CustomerContactID;
/*                    //
                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            */
            return contactID;
        }

        public static void SaveCustomerInfo(int quotationID, int customerID, int contactID, string email, string user)
        {

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
        }
    }
}
