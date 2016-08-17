using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataModel;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using Cotizaciones.DataManagers;

namespace Cotizaciones.Views
{
    public partial class CustomerInfoView : BaseView
    {
        DataSet ds;
        public CustomerInfoView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                this.UpdateQuotation();

                this.Cursor = Cursors.WaitCursor;
                MyQuotationsView myview = new MyQuotationsView();
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>0 if no data selected</returns>
        private int GetCustomerID()
        {
            int customerID = 0;
            if (this.uceCustomer.Value != null)
            {
                if (this.uceCustomer.Value.GetType().ToString() == "System.Int32")
                {
                    //Customer exists
                    customerID = Convert.ToInt32(this.uceCustomer.Value);
                }
                else
                {
                    //Customer NOT exists
                    customerID = CustomerInfoManager.CreateCustomer(Convert.ToString(this.uceCustomer.Value), this.User);
                }
            }
            return customerID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>0 if no data selected</returns>
        private int GetContactID(int customerID)
        {
            int contactID = 0;
            if (customerID > 0 && this.uceContact.Value != null)
            {
                if (this.uceContact.Value.GetType().ToString() == "System.Int32")
                {
                    //CustomerContact exists
                    contactID = Convert.ToInt32(this.uceContact.Value);
                }
                else
                {
                    //CustomerContact NOT exists
                    contactID = CustomerInfoManager.CreateCustomerContact(Convert.ToString(this.uceContact.Value), this.txtEmail.Text, customerID, this.User);
                }
            }
            return contactID;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                this.UpdateQuotation();

                ProductSelectionView myview = new ProductSelectionView();
                myview.QuotationID = this.QuotationID;
                myview.User = this.User;
                myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateQuotation()
        {
            if (!IsReadOnly)
            {
                int customerID, contactID;
                customerID = GetCustomerID();
                contactID = GetContactID(customerID);
                CustomerInfoManager.SaveCustomerInfo(this.QuotationID, customerID, contactID, this.txtEmail.Text, this.User);
            }
        }

        private void CustomerInfoView_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadCustomerInfo();
            LoadQuotationInfo();
            this.uceCustomer.Focus();

            EnableDisableControls();
            this.Cursor = Cursors.Default;
        }

        private void EnableDisableControls()
        {
            if (IsReadOnly == true)
            {
                this.uceCustomer.ReadOnly = true;
                this.uceContact.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
            }
        }

        private void LoadQuotationInfo()
        {
            Quotation q = CustomerInfoManager.GetQuotationInfo(this.QuotationID);
            if (q != null)
            {
                if (q.CustomerID != null)
                {
                    this.uceCustomer.Value = q.CustomerID;
                    this.uceContact.Value = q.CustomerContactID;
                    this.txtEmail.Text = q.EmailTo;
                }
            }
        }

        private void LoadCustomerInfo()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetCustomerInfo();

            ds = sp.ExecuteDataSet();

            this.uceCustomer.DataSource = ds;
            this.uceCustomer.DataMember = "Table";
            this.uceCustomer.DisplayMember = "Description";
            this.uceCustomer.ValueMember = "CustomerID";

            /*this.uceContact.DataSource = ds;
            this.uceContact.DataMember = "Table1";
            this.uceContact.DisplayMember = "ContactName";
            this.uceContact.ValueMember = "CustomerContactID";*/
        }

        private DataTable FilterContacts(int CustomerID)
        {
            DataTable dt = ds.Tables["Table1"].Clone();
            foreach (DataRow row in ds.Tables["Table1"].Select("CustomerID = " + CustomerID.ToString()))
            {
                dt.ImportRow(row);
            }
            return dt;
        }

        private void GetContactEmail(int CustomerContactID)
        {
            DataRow[] rows = ds.Tables["Table1"].Select("CustomerContactID = " + CustomerContactID.ToString());
            foreach (DataRow row in rows)
            {
                if (row["Email"] != null)
                {
                    this.txtEmail.Text = row["Email"].ToString();
                }
            }
        }

        private void uceCustomer_ValueChanged(object sender, EventArgs e)
        {
            //Resetting contacts
            this.uceContact.Value = null;
            this.uceContact.Text = "";
            this.txtEmail.Text = "";

            if (uceCustomer.Value != null)
            {
                if (uceCustomer.Value.GetType().ToString() == "System.Int32")
                {
                    //If its an existing customer
                    //lnklblNewCustomer.Visible = false;
                    //this.uceContact.Enabled = true;
                    this.GetFilteredDataset((int)uceCustomer.Value);
                }
                else
                {
                    //If its an unexisting customer
                    //lnklblNewCustomer.Visible = true;
                    //this.uceContact.Enabled = false;
                    this.GetFilteredDataset(0);
                }
            }
        }

        private void GetFilteredDataset(int CustomerID)
        {
            this.uceContact.DataSource = FilterContacts(CustomerID);
            this.uceContact.DisplayMember = "ContactName";
            this.uceContact.ValueMember = "CustomerContactID";
        }

        private void uceContact_ValueChanged(object sender, EventArgs e)
        {
            if (this.uceContact.Value != null)
            {
                if (uceContact.Value.GetType().ToString() == "System.Int32")
                {
                    //Its an existing contact
                    GetContactEmail((int)uceContact.Value);
                }
                else
                {
                    this.txtEmail.Text = "";
                    //Its an unexisting contact
                }
            }
        }

        private bool IsValidData()
        {
            if(this.txtEmail.Text!= String.Empty)
            {
                if (Utilities.isEmail(this.txtEmail.Text) == false)
                {
                    MessageBox.Show("El formato de correo electrónico no es válido");
                    return false;
                }
            }
            return true;
        }

        private void lnklblNewCustomer_Click(object sender, EventArgs e)
        {
            //CustomerEditInfoView myview = new CustomerEditInfoView();
            //MainController.Instance.Next(myview);
            ////MessageBox.Show("Nuevo Cliente");
        }

        private void lnklblNewContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nuevo Contacto");
        }
    }
}
