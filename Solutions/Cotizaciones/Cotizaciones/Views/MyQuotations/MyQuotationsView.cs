using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.Common;
using Cotizaciones.DataModel;
using Cotizaciones.Enums;
using Cotizaciones.DataManagers;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Cotizaciones.Views
{
    public partial class MyQuotationsView : BaseView
    {
        int SelectedQuotationID = 0;
        int SelectedQuotationStatusTypeID = 0;
        DataSet ReferenceData;
        public MyQuotationsView(bool readOnlyMode)
        {
            ReadOnlyMode = readOnlyMode;
            InitializeComponent();
        }

        private void ResetStatusBarMessages()
        {
            //Changing status bar messages
            MainController.Instance.ChangeStatusBar(StatusBarElements.QuotationID, "Listo");
            MainController.Instance.ChangeStatusBar(StatusBarElements.Description, "");
            MainController.Instance.ChangeStatusBar(StatusBarElements.StatusMessage, "");
            MainController.Instance.ChangeStatusBar(StatusBarElements.CurrentUser, "Usuario: " + this.User);
        }

        private void btnNewQuotation_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CustomerInfoView custinfo = new CustomerInfoView(ReadOnlyMode);
            custinfo.QuotationID = MyQuotationsManager.CreateQuotation(this.User);
            custinfo.User = this.User;
            custinfo.QuotationStatusTypeID = (Cotizaciones.Enums.QuotationStatusType)1;

            //Changing status bar messages
            MainController.Instance.ChangeStatusBar(StatusBarElements.QuotationID, "Cotización #: " + custinfo.QuotationID.ToString());
            MainController.Instance.ChangeStatusBar(StatusBarElements.StatusMessage, "Modificable");
            MainController.Instance.Next(custinfo);
            this.Cursor = Cursors.Default;
        }

        private void MyQuotationsView_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.User = PreferencesHelper.GetPreference("DefaultUser");
            ResetStatusBarMessages();
            ReferenceData = MyQuotationsManager.GetMyQuotationsReferenceData();
            InitializeControls();
            LoadFilterValues();
            //this.cmbCompany.Value = 0;  //all companies
            GetMyQuotations();
            this.Cursor = Cursors.Default;
            //This is to avoid the Admin to create any quotations
            if (this.User == Utilities.GetConfigurationKeyValue("AdminUser"))
            {
                DisableControls();
            }
            this.btnNewQuotation.Enabled = !ReadOnlyMode;
            this.linkOldQuotations.Visible = !ReadOnlyMode;
        }

        private void LoadFilterValues()
        {
            string filterLastUserValue = PreferencesHelper.GetPreference("FilterLastUserValue");
            this.cmbCreator.Value = filterLastUserValue == String.Empty ? this.User.ToLower() : filterLastUserValue;

            int filterLastQuotationIDValue = Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastQuotationIDValue"));
            if (filterLastQuotationIDValue != 0)
            {
                this.uneQuotationID.Value = filterLastQuotationIDValue;
            }

            int filterLastQuotationStatusTypeID = Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastQuotationStatusTypeID"));
            if (filterLastQuotationStatusTypeID != 0)
            {
                this.cmbQuotationStatusType.Value = filterLastQuotationStatusTypeID;
            }

            string filterLastDateFromValue = PreferencesHelper.GetPreference("FilterLastDateFromValue");
            if (filterLastDateFromValue != "")
            {
                this.dtDateFrom.Value = Utilities.ConvertToDate(filterLastDateFromValue);
            }

            string filterLastDateToValue = PreferencesHelper.GetPreference("FilterLastDateToValue");
            if (filterLastDateToValue != "")
            {
                this.dtDateTo.Value = Utilities.ConvertToDate(filterLastDateToValue);
            }

            int filterLastSectionTypeIDValue = Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastSectionTypeIDValue"));
            if (filterLastSectionTypeIDValue != 0)
            {
                this.cmbSectionType.Value = filterLastSectionTypeIDValue;
            }

            int filterLastPipeDiameterTypeIDValue = Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastPipeDiameterTypeIDValue"));
            if (filterLastPipeDiameterTypeIDValue != 0)
            {
                this.cmbDiameterType.Value = filterLastPipeDiameterTypeIDValue;
            }

            int filterLastCustomerIDValue = Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastCustomerIDValue"));
            if (filterLastCustomerIDValue != 0)
            {
                this.cmbCustomer.Value = filterLastCustomerIDValue;
            }

            int filterLastCustomerContactIDValue = Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastCustomerContactIDValue"));
            if (filterLastCustomerContactIDValue != 0)
            {
                this.cmbCustomerContact.Value = filterLastCustomerContactIDValue;
            }

            this.cmbCompany.Value = PreferencesHelper.GetPreference("FilterLastCompanyIDValue");
        }

        void DisableControls()
        {
            this.cmbCreator.Enabled = false;
            this.btnFilter.Enabled = false;
            this.btnNewQuotation.Enabled = false;
            this.uneQuotationID.Enabled = false;
            this.cmbQuotationStatusType.Enabled = false;
            this.cmbSectionType.Enabled = false;
            this.cmbDiameterType.Enabled = false;
            this.dtDateFrom.Enabled = false;
            this.dtDateTo.Enabled = false;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomerContact.Enabled = false;
            this.btnClear.Enabled = false;
            this.cmbCompany.Enabled = false;
            this.ugMyQuotations.Enabled = false;
        }

        private void InitializeControls()
        {
            this.cmbCreator.DataSource = ReferenceData;
            this.cmbCreator.DataMember = "Table";
            this.cmbCreator.ValueMember = "ShortName";
            this.cmbCreator.DisplayMember = "FullName";
            this.cmbCreator.DisplayLayout.Bands[0].Columns["ShortName"].Hidden = true;
            this.cmbCreator.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbCreator.DisplayLayout.Bands[0].Columns["FullName"].Width = this.cmbCreator.Width;

            this.cmbSectionType.DataSource = ReferenceData;
            this.cmbSectionType.DataMember = "Table1";
            this.cmbSectionType.ValueMember = "SectionTypeID";
            this.cmbSectionType.DisplayMember = "ShortName";
            this.cmbSectionType.DisplayLayout.Bands[0].Columns["SectionTypeID"].Hidden = true;
            this.cmbSectionType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbSectionType.DisplayLayout.Bands[0].Columns["ShortName"].Width = this.cmbSectionType.Size.Width;

            this.cmbCustomer.DataSource = ReferenceData;
            this.cmbCustomer.DataMember = "Table2";
            this.cmbCustomer.ValueMember = "CustomerID";
            this.cmbCustomer.DisplayMember = "Description";
            this.cmbCustomer.DisplayLayout.Bands[0].Columns["CustomerID"].Hidden = true;
            this.cmbCustomer.DisplayLayout.Bands[0].ColHeadersVisible = false;

            this.cmbCustomerContact.DataSource = ReferenceData;
            this.cmbCustomerContact.DataMember = "Table3";
            this.cmbCustomerContact.ValueMember = "CustomerContactID";
            this.cmbCustomerContact.DisplayMember = "ContactName";
            this.cmbCustomerContact.DisplayLayout.Bands[0].Columns["CustomerContactID"].Hidden = true;
            this.cmbCustomerContact.DisplayLayout.Bands[0].Columns["CustomerID"].Hidden = true;
            this.cmbCustomerContact.DisplayLayout.Bands[0].ColHeadersVisible = false;

            this.cmbDiameterType.DataSource = ReferenceData;
            this.cmbDiameterType.DataMember = "Table4";
            this.cmbDiameterType.ValueMember = "PipeDiameterTypeID";
            this.cmbDiameterType.DisplayMember = "ShortName";
            this.cmbDiameterType.DisplayLayout.Bands[0].Columns["PipeDiameterTypeID"].Hidden = true;
            this.cmbDiameterType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            //this.cmbDiameterType.DisplayLayout.Bands[0].Columns["ShortName"].Width = this.cmbDiameterType.Size.Width;

            this.cmbQuotationStatusType.DataSource = ReferenceData;
            this.cmbQuotationStatusType.DataMember = "Table5";
            this.cmbQuotationStatusType.ValueMember = "QuotationStatusTypeID";
            this.cmbQuotationStatusType.DisplayMember = "ShortName";
            this.cmbQuotationStatusType.DisplayLayout.Bands[0].Columns["QuotationStatusTypeID"].Hidden = true;
            this.cmbQuotationStatusType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbQuotationStatusType.DisplayLayout.Bands[0].Columns["ShortName"].Width = this.cmbQuotationStatusType.Size.Width;

            this.cmbCompany.DataSource = ReferenceData;
            this.cmbCompany.DataMember = "Table6";
            this.cmbCompany.ValueMember = "CompanyID";
            this.cmbCompany.DisplayMember = "CompanyName";
            this.cmbCompany.DisplayLayout.Bands[0].Columns["CompanyID"].Hidden = true;
            this.cmbCompany.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbCompany.DisplayLayout.Bands[0].Columns["CompanyName"].Width = this.cmbCompany.Size.Width;
        }

        private void cmbCustomer_BeforeDropDown(object sender, CancelEventArgs e)
        {
            this.cmbCustomer.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbCustomer.Width;
        }

        private void cmbCustomerContact_BeforeDropDown(object sender, CancelEventArgs e)
        {
            this.cmbCustomerContact.DisplayLayout.Bands[0].Columns["ContactName"].Width = this.cmbCustomerContact.Width;
        }

        private void cmbCustomer_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //Change the dataset of the contact
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSavedFilters();
            string filterLastUserValue = PreferencesHelper.GetPreference("FilterLastUserValue");
            this.cmbCreator.Value = filterLastUserValue == String.Empty ? this.User : filterLastUserValue;
            this.cmbCustomer.Value = null;
            this.cmbCustomerContact.Value = null;
            this.dtDateFrom.Value = null;
            this.dtDateTo.Value = null;
            this.uneQuotationID.Value = null;
            this.cmbSectionType.Value = null;
            this.cmbDiameterType.Value = null;
            this.cmbQuotationStatusType.Value = null;
            this.cmbCompany.Value = 0;
        }

        private void ClearSavedFilters()
        {
            PreferencesHelper.SetPreference("FilterLastQuotationIDValue", "0");
            PreferencesHelper.SetPreference("FilterLastQuotationStatusTypeID", "0");
            PreferencesHelper.SetPreference("FilterLastDateFromValue", "");
            PreferencesHelper.SetPreference("FilterLastDateToValue", "");
            PreferencesHelper.SetPreference("FilterLastSectionTypeIDValue", "0");
            PreferencesHelper.SetPreference("FilterLastPipeDiameterTypeIDValue", "0");
            PreferencesHelper.SetPreference("FilterLastCustomerIDValue", "0");
            PreferencesHelper.SetPreference("FilterLastCustomerContactIDValue", "0");
            PreferencesHelper.SetPreference("FilterLastCompanyIDValue", "0");
        }

        private void GetMyQuotations()
        {
            DataSet ds;
            ds = MyQuotationsManager.GetMyQuotations(
                 this.cmbCreator.Value == null ? "" : this.cmbCreator.Value.ToString(),
                 this.dtDateFrom.Value == null ? "" : Convert.ToDateTime(this.dtDateFrom.Value).ToString("yyyyMMdd"),
                 this.dtDateTo.Value == null ? "" : Convert.ToDateTime(this.dtDateTo.Value).ToString("yyyyMMdd"),
                 Convert.ToInt32(this.cmbSectionType.Value),
                 Convert.ToInt32(this.cmbDiameterType.Value),
                 this.uneQuotationID.Value == DBNull.Value ? 0 : Convert.ToInt32(this.uneQuotationID.Value),
                 Convert.ToInt32(this.cmbCustomer.Value),
                 Convert.ToInt32(this.cmbCustomerContact.Value),
                 Convert.ToInt32(this.cmbQuotationStatusType.Value),
                 Convert.ToInt32(this.cmbCompany.Value));
            this.ugMyQuotations.DataSource = ds;
            this.ugMyQuotations.DataMember = "Table";

            RenameGridHeaders();
            HighlightRows();
        }

        private void HighlightRows()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ugMyQuotations.Rows)
            {
                if (Convert.ToInt32(row.Cells["QuotationStatusTypeID"].Value) == Convert.ToInt32(Cotizaciones.Enums.QuotationStatusType.Sold))
                {
                    row.Appearance.BackColor = Color.LightGreen;
                }
            }
        }

        private void RenameGridHeaders()
        {
            foreach (UltraGridColumn col in this.ugMyQuotations.DisplayLayout.Bands[0].Columns)
            {
                switch (col.Key)
                {
                    case "QuotationID":
                        col.Header.Caption = "Cotización #";
                        break;
                    case "CompanyName":
                        col.Header.Caption = "Empresa";
                        break;
                    case "CustomerName":
                        col.Header.Caption = "Cliente";
                        break;
                    case "ContactName":
                        col.Header.Caption = "Contacto";
                        break;
                    case "Email":
                        col.Header.Caption = "Correo Electrónico";
                        break;
                    case "Sections":
                        col.Header.Caption = "Secciones";
                        break;
                    case "Created":
                        col.Header.Caption = "Fecha";
                        break;
                    case "Creator":
                        col.Header.Caption = "Creador";
                        break;
                    case "QuotationStatusTypeID":
                        col.Hidden = true;
                        break;
                    case "Status":
                        col.Header.Caption = "Estado";
                        break;
                    case "QuotationFileName":
                        col.Hidden = true;
                        break;
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (PreferencesHelper.GetPreference("FilterLastUserValue") != this.cmbCreator.Value.ToString())
            {
                PreferencesHelper.SetPreference("FilterLastUserValue", this.cmbCreator.Value.ToString());
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastQuotationIDValue")) != (this.uneQuotationID.Value == DBNull.Value ? 0 : Convert.ToInt32(this.uneQuotationID.Value)))
            {
                PreferencesHelper.SetPreference("FilterLastQuotationIDValue", (this.uneQuotationID.Value == DBNull.Value ? 0 : Convert.ToInt32(this.uneQuotationID.Value)).ToString());
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastQuotationStatusTypeID")) != Convert.ToInt32(this.cmbQuotationStatusType.Value))
            {
                PreferencesHelper.SetPreference("FilterLastQuotationStatusTypeID", Convert.ToInt32(this.cmbQuotationStatusType.Value).ToString());
            }
            if (PreferencesHelper.GetPreference("FilterLastDateFromValue") != (this.dtDateFrom.Value == null ? "" : Convert.ToDateTime(this.dtDateFrom.Value).ToString("yyyyMMdd")))
            {
                PreferencesHelper.SetPreference("FilterLastDateFromValue", this.dtDateFrom.Value == null ? "" : Convert.ToDateTime(this.dtDateFrom.Value).ToString("yyyyMMdd"));
            }
            if (PreferencesHelper.GetPreference("FilterLastDateToValue") != (this.dtDateTo.Value == null ? "" : Convert.ToDateTime(this.dtDateTo.Value).ToString("yyyyMMdd")))
            {
                PreferencesHelper.SetPreference("FilterLastDateToValue", this.dtDateTo.Value == null ? "" : Convert.ToDateTime(this.dtDateTo.Value).ToString("yyyyMMdd"));
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastSectionTypeIDValue")) != Convert.ToInt32(this.cmbSectionType.Value))
            {
                PreferencesHelper.SetPreference("FilterLastSectionTypeIDValue", Convert.ToInt32(this.cmbSectionType.Value).ToString());
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastPipeDiameterTypeIDValue")) != Convert.ToInt32(this.cmbDiameterType.Value))
            {
                PreferencesHelper.SetPreference("FilterLastPipeDiameterTypeIDValue", Convert.ToInt32(this.cmbDiameterType.Value).ToString());
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastCustomerIDValue")) != Convert.ToInt32(this.cmbCustomer.Value))
            {
                PreferencesHelper.SetPreference("FilterLastCustomerIDValue", Convert.ToInt32(this.cmbCustomer.Value).ToString());
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastCustomerContactIDValue")) != Convert.ToInt32(this.cmbCustomerContact.Value))
            {
                PreferencesHelper.SetPreference("FilterLastCustomerContactIDValue", Convert.ToInt32(this.cmbCustomerContact.Value).ToString());
            }
            if (Convert.ToInt32(PreferencesHelper.GetPreference("FilterLastCompanyIDValue")) != Convert.ToInt32(this.cmbCompany.Value))
            {
                PreferencesHelper.SetPreference("FilterLastCompanyIDValue", Convert.ToInt32(this.cmbCompany.Value).ToString());
            }

            GetMyQuotations();

            this.Cursor = Cursors.Default;
        }

        private void cmbCustomer_ValueChanged(object sender, EventArgs e)
        {
            /*this.cmbCustomerContact.Value = null;
            if (this.cmbCustomer.Value != null)
            {
                if (this.cmbCustomer.Value.GetType().ToString() == "System.Int32")
                {
                    //If its an existing customer
                    this.SetFilteredDataset((int)this.cmbCustomer.Value);
                }
                else
                {
                    this.SetFilteredDataset(0);
                }
            }*/
        }

        private void SetFilteredDataset(int CustomerID)
        {
            this.cmbCustomerContact.DataSource = FilterContacts(CustomerID);
            this.cmbCustomerContact.DisplayMember = "ContactName";
            this.cmbCustomerContact.ValueMember = "CustomerContactID";
        }

        private DataSet FilterContacts(int CustomerID)
        {
            DataSet ds = new DataSet();
            DataTable dt = this.ReferenceData.Tables["Table3"].Clone();
            foreach (DataRow row in ReferenceData.Tables["Table3"].Select("CustomerID = " + CustomerID.ToString()))
            {
                dt.ImportRow(row);
            }
            ds.Tables.Add(dt);
            return ds;
        }

        private void ugMyQuotations_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.OpenQuotation(Convert.ToInt32(e.Row.Cells["QuotationID"].Value), (Cotizaciones.Enums.QuotationStatusType)e.Row.Cells["QuotationStatusTypeID"].Value);
        }

        private void OpenQuotation(int QuotationID, Cotizaciones.Enums.QuotationStatusType quotationTypeID)
        {
            CustomerInfoView custinfo = new CustomerInfoView(ReadOnlyMode);
            custinfo.QuotationID = QuotationID;
            custinfo.User = this.User;
            custinfo.QuotationStatusTypeID = quotationTypeID;

            MainController.Instance.ChangeStatusBar(StatusBarElements.QuotationID, "Cotizacion #: " + custinfo.QuotationID.ToString());
            if (quotationTypeID == Cotizaciones.Enums.QuotationStatusType.Finished
                || quotationTypeID == Cotizaciones.Enums.QuotationStatusType.Sold
                || quotationTypeID == Cotizaciones.Enums.QuotationStatusType.FinishedExternal
                || quotationTypeID == Cotizaciones.Enums.QuotationStatusType.FinishedAndSent)
            {
                MainController.Instance.ChangeStatusBar(StatusBarElements.StatusMessage, "Solo lectura");
            }
            else
            {
                MainController.Instance.ChangeStatusBar(StatusBarElements.StatusMessage, "Modificable");
            }
            MainController.Instance.Next(custinfo);
        }
        private void ugMyQuotations_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!ReadOnlyMode)
                {
                    Point mousePoint = new Point(e.X, e.Y);
                    UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);

                    UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                    if (cell != null)
                    {
                        int x, y;
                        /*
                        foreach (UltraGridRow row in this.ugMyQuotations.Rows)
                        {
                            row.Selected = false;
                        }*/
                        SelectedQuotationID = Convert.ToInt32(cell.Row.Cells["QuotationID"].Value);
                        SelectedQuotationStatusTypeID = Convert.ToInt32(cell.Row.Cells["QuotationStatusTypeID"].Value);

                        cell.Row.Selected = true;

                        x = this.Parent.Parent.Parent.Location.X + mousePoint.X + 10;
                        y = this.Parent.Parent.Parent.Location.Y + mousePoint.Y + 185;
                        Point contextMenuLocation = new Point(x, y);
                        contextMenuMyQuotations.Show(contextMenuLocation);
                    }
                }
            }
        }

        private void toolStripMenuItemEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta acción eliminará la cotización. ¿Desea continuar?", "Eliminar Cotización", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (SelectedQuotationID != 0)
                {
                    MyQuotationsManager.DeleteQuotation(SelectedQuotationID, this.User);
                    GetMyQuotations();
                }
            }
            else
            {
                //MessageBox.Show("NO Eliminar");
            }
        }

        private void toolStripMenuItemClone_Click(object sender, EventArgs e)
        {
            int NewQuotationID = MyQuotationsManager.CloneQuotation(SelectedQuotationID, this.User);
            this.OpenQuotation(NewQuotationID, Cotizaciones.Enums.QuotationStatusType.Incomplete);
        }

        private void marcarComoVendidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta acción marcará la cotización como vendida. ¿Desea continuar?", "Cotización Vendida", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //Marcar como vendida
                if (SelectedQuotationID != 0)
                {
                    //if we selected a quotationid
                    if (SelectedQuotationStatusTypeID != 0)
                    {
                        //if we have a valid quotation status
                        if ((Cotizaciones.Enums.QuotationStatusType)SelectedQuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.Finished)
                        {
                            MyQuotationsManager.SetQuotationSold(SelectedQuotationID, this.User);
                            GetMyQuotations();  //To refresh
                        }
                        else if ((Cotizaciones.Enums.QuotationStatusType)SelectedQuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.Sold)
                        {
                            MessageBox.Show("La cotización ya ha sido marcada como vendida.", "Cotización vendida");
                        }
                        else
                        {
                            MessageBox.Show("La cotización no ha sido finalizada. Primero finalice y despues marque como vendida.", "Cotización no finalizada");
                        }
                    }
                }
            }
        }

        private void linkOldQuotations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = Assembly.GetEntryAssembly().Location;
            p.StartInfo.Arguments = "Fersum2018";
            p.Start();
        }
    }
}
