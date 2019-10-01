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
    class EditCustomersManager
    {
        public DataSet getDiameter()
        {
            DataSet ds;
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetCustomerInfo();
            ds = sp.ExecuteDataSet();
            AddColumns(ds.Tables[0], 0);
            AddColumns(ds.Tables[1], 1);
            DataRelation rel = new DataRelation("", ds.Tables[0].Columns["CustomerID"], ds.Tables[1].Columns["CustomerID"]);
            ds.Relations.Add(rel);
            return ds;
        }

        private void AddColumns(DataTable dt, int table)
        {
            dt.Columns.Add("Activo", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Actualizado", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Index", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Table", System.Type.GetType("System.Int32"));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Active"].ToString() == "A")
                    dt.Rows[i]["Activo"] = true;
                else
                    dt.Rows[i]["Activo"] = false;
                dt.Rows[i]["Table"] = table;
                dt.Rows[i]["Index"] = i;
                dt.Rows[i]["Actualizado"] = false; ;
            }
        }

        private void UpdateCustomers(DataRow row, string User)
        {
            Customer c = new Customer();
            c.CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
            c.SetIsLoaded(true);
            c.Description = row["Description"].ToString();
            c.Active = row["Active"].ToString();
            c.Modified = DateTime.Now;
            c.Modifier = User.ToString();
            c.SetIsNew(false);
            c.Save();
        }

        public void getCustomers(DataSet ds, string User)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {   
                if (Convert.ToInt32(row["CustomerID"].ToString()) < 0 && row["Active"].ToString() == "I")
                {
                    foreach (DataRow dt in ds.Tables[1].Select("CustomerID = " + Convert.ToInt32(row["CustomerID"].ToString())))
                    {
                        dt["Active"] = "I";
                    }
                }
                else if (Convert.ToInt32(row["CustomerID"].ToString()) >= 0)
                {
                    if (Convert.ToBoolean(row["Actualizado"]))
                    {
                        UpdateCustomers(row, User);
                    }
                    foreach (DataRow dt in ds.Tables[1].Select("CustomerID = " + Convert.ToInt32(row["CustomerID"].ToString())))
                    {
                        if (Convert.ToBoolean(dt["Actualizado"]))
                        {
                            if (Convert.ToInt32(dt["CustomerContactID"].ToString()) >= 0)
                            {
                                UpdateContacts(dt, User);
                            }
                            else
                                if (Convert.ToInt32(dt["CustomerContactID"].ToString()) < 0 && dt["Active"].ToString() == "A")
                                {
                                    NewContactSave(dt, User);
                                }
                        }
                    }
                }
                else if (Convert.ToInt32(row["CustomerID"].ToString()) < 0 && row["Active"].ToString() == "A")
                {
                    int CustomerIDOld = Convert.ToInt32(row["CustomerID"].ToString());
                    int CustomerID = NewCustomerSave(row, User);
                    foreach (DataRow dt in ds.Tables[1].Select("CustomerID = " + CustomerIDOld))
                    {
                        if (dt["Active"].ToString() == "A")
                        {
                            dt["CustomerID"] = CustomerID;
                            NewContactSave(dt, User);
                        }
                    }
                }
                
            }
        }

        private void UpdateContacts(DataRow row, string User)
        {
            CustomerContact cc = new CustomerContact();            
            cc.SetIsLoaded(true);
            cc.CustomerContactID = Convert.ToInt32(row["CustomerContactID"].ToString());
            cc.ContactName = row["ContactName"].ToString();
            cc.Email = row["Email"].ToString().Replace(" ", "").Replace(",", ";");
            cc.Active = row["Active"].ToString();
            cc.Modified = DateTime.Now;
            cc.Modifier = User.ToString();
            cc.SetIsNew(false);
            cc.Save();
        }

        private int NewCustomerSave(DataRow row, string User)
        {
            Customer c = new Customer();
            c.Description = row["Description"].ToString();            
            c.Active = row["Active"].ToString();
            c.Creator = User;
            c.Created = DateTime.Now;
            c.Add();
            row["CustomerID"] = c.CustomerID;
            return c.CustomerID;
        }

        private void NewContactSave(DataRow row, string User)
        {
            CustomerContact cc = new CustomerContact();
            cc.CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
            cc.ContactName = row["ContactName"].ToString();
            cc.Email = row["Email"].ToString().Replace(" ", "").Replace(",",";");
            cc.Creator = User;
            cc.Created = DateTime.Now;
            cc.Active = row["Active"].ToString();
            cc.Add();
        }
    }
}
