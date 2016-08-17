using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataManagers;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Cotizaciones.Views
{
    public partial class QuotationConditionsView : BaseView
    {
        DataSet ReferenceData;
        DataSet QuotationData;
        int SectionTypeIDValue;
        string DeliveryValue;
        string DeliveryTimeValue;
        string PaymentValue;
        //string ValidPeriodValue;

        public QuotationConditionsView()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                this.SaveQuotation(true);
                QuotationFinishView myview = new QuotationFinishView();
                myview.QuotationID = this.QuotationID;
                myview.User = this.User;
                myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        private bool IsValidData()
        {
            bool result = true;
            string errorMessage = "";
            foreach (DataRow row in QuotationData.Tables["Table1"].Rows)
            {
                if (Convert.ToDecimal(row["Price"]) <= 0)
                {
                    errorMessage += "Introduca precio en sección " + row.GetParentRow(QuotationData.Relations[0])["ShortName"].ToString() + ", Diámetro " + row["ShortName"].ToString() + ", Espesor " + row["Description"].ToString() + Environment.NewLine;
                    result = false;
                }
            }
            foreach (DataRow row in QuotationData.Tables["Table1"].Rows)
            {
                if (row["CurrencyDescription"].ToString().Trim() == String.Empty)
                {
                    errorMessage += "Moneda no especificada en " + row.GetParentRow(QuotationData.Relations[0])["ShortName"].ToString() + ", Diámetro " + row["ShortName"].ToString() + ", Espesor " + row["Description"].ToString() + Environment.NewLine;
                    result = false;
                }
            }
            if (!result)
            {
                MessageBox.Show(errorMessage, "Datos Incorrectos");
            }
            return result;
        }

        private void SaveQuotation(bool updateStatus)
        {
            if (!IsReadOnly)
            {
                QuotationConditionsManager.SaveQuotationConditions(this.QuotationID, this.User, QuotationData, updateStatus);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SaveQuotation(false);
            MyQuotationsView myview = new MyQuotationsView();
            MainController.Instance.Next(myview);
            this.Cursor = Cursors.Default;
        }

        private void QuotationConditionsView_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadReferenceData();
            LoadQuotationConditions();
            EnableDisableControls();
            this.Cursor = Cursors.Default;
        }

        private void EnableDisableControls()
        {
            if (IsReadOnly == true)
            {
                //this.ugQuotationConditions.Enabled = false;

                foreach (UltraGridBand band in this.ugQuotationConditions.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn column in band.Columns)
                    {
                        column.CellClickAction = CellClickAction.RowSelect;
                        column.CellActivation = Activation.NoEdit;
                    }
                }
            }
        }

        private void LoadReferenceData()
        {
            ReferenceData = QuotationConditionsManager.GetQuotationConditionsReferenceData();
            SetupControls();
        }

        private void SetupControls()
        {
            this.cmbDeliveryType.DataSource = ReferenceData;
            this.cmbDeliveryType.DataMember = "Table";
            this.cmbDeliveryType.DisplayLayout.Bands[0].ColHeadersVisible = false;

            this.cmbDeliveryTimeType.DataSource = ReferenceData;
            this.cmbDeliveryTimeType.DataMember = "Table1";
            this.cmbDeliveryTimeType.DisplayLayout.Bands[0].ColHeadersVisible = false;

            /*this.cmbPaymentType.DataSource = ReferenceData;
            this.cmbPaymentType.DataMember = "Table1";
            this.cmbPaymentType.DisplayLayout.Bands[0].ColHeadersVisible = false;*/

            this.cmbCurrencyType.DataSource = ReferenceData;
            this.cmbCurrencyType.DataMember = "Table2";
            this.cmbCurrencyType.DisplayLayout.Bands[0].ColHeadersVisible = false;

            /*this.cmbValidPeriodType.DataSource = ReferenceData;
            this.cmbValidPeriodType.DataMember = "Table3";
            this.cmbValidPeriodType.DisplayLayout.Bands[0].ColHeadersVisible = false;*/
        }

        private void LoadQuotationConditions()
        {
            QuotationData = QuotationConditionsManager.GetQuotationConditions(this.QuotationID);
            this.ugQuotationConditions.DataSource = QuotationData;
            SetGridProperties();
        }

        private void SetGridProperties()
        {
            //Section band
            foreach (UltraGridColumn col in this.ugQuotationConditions.DisplayLayout.Bands[0].Columns)
            {
                switch (col.Key)
                {
                    case "QuotationID":
                        col.Hidden = true;
                        break;
                    case "QuotationSectionID":
                        col.Hidden = true;
                        break;
                    case "SectionTypeID":
                        col.Hidden = true;
                        break;
                    case "ShortName":
                        col.Header.Caption = "Sección";
                        col.CellActivation = Activation.NoEdit;
                        col.Width = 25;
                        break;
                    case "Description":
                        col.Header.Caption = "Descripción";
                        //col.CellActivation = Activation.NoEdit;
                        break;
                }
            }

            //Details band
            foreach (UltraGridColumn col in this.ugQuotationConditions.DisplayLayout.Bands[1].Columns)
            {
                switch (col.Key)
                {
                    case "QuotationID":
                        col.Hidden = true;
                        break;
                    case "QuotationSectionID":
                        col.Hidden = true;
                        break;
                    case "SectionTypeID":
                        col.Hidden = true;
                        break;
                    case "QuotationSectionDetailID":
                        col.Hidden = true;
                        break;
                    case "PipeSpecificationID":
                        col.Hidden = true;
                        break;
                    case "ShortName":
                        col.Header.Caption = "Diámetro Nominal";
                        col.CellActivation = Activation.NoEdit;
                        col.Width = 25;
                        break;
                    case "Description":
                        col.Header.Caption = "Espesor";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Price":
                        col.Header.Caption = "Precio";
                        col.Format = "$ ###,###.#0";
                        break;
                    case "CurrencyDescription":
                        col.Header.Caption = "Moneda";
                        if (IsReadOnly != true)
                        {
                            col.ValueList = this.cmbCurrencyType;
                        }
                        break;
                    /*case "PaymentDescription":
                        col.Header.Caption = "Forma de pago";
                        if (IsReadOnly != true)
                        {
                            col.ValueList = this.cmbPaymentType;
                        }
                        break;*/
                    case "DeliveryDescription":
                        col.Header.Caption = "Condiciones de Entrega";
                        if (IsReadOnly != true)
                        {
                            col.ValueList = this.cmbDeliveryType;
                        }
                        break;
                    case "DeliveryTimeDescription":
                        col.Header.Caption = "Tiempo de Entrega";
                        if (IsReadOnly != true)
                        {
                            col.ValueList = this.cmbDeliveryTimeType;
                        }
                        break;
                    /*case "ValidPeriodDescription":
                        col.Header.Caption = "Validez";
                        if (IsReadOnly != true)
                        {
                            col.ValueList = this.cmbValidPeriodType;
                        }
                        break;*/
                }
            }
            this.ugQuotationConditions.Rows.ExpandAll(true);
        }

        private void ugQuotationConditions_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            switch (this.ugQuotationConditions.ActiveCell.Column.Key)
            {
                case "CurrencyDescription":
                    this.cmbCurrencyType.DisplayLayout.Bands[0].Columns["Description"].Width = this.ugQuotationConditions.ActiveCell.Width;
                    break;
                /*case "PaymentDescription":
                    this.cmbPaymentType.DisplayLayout.Bands[0].Columns["Description"].Width = this.ugQuotationConditions.ActiveCell.Width;
                    break;*/
                case "DeliveryDescription":
                    this.cmbDeliveryType.DisplayLayout.Bands[0].Columns["Description"].Width = this.ugQuotationConditions.ActiveCell.Width;
                    break;
                case "DeliveryTimeDescription":
                    this.cmbDeliveryTimeType.DisplayLayout.Bands[0].Columns["Description"].Width = this.ugQuotationConditions.ActiveCell.Width;
                    break;
                /*case "ValidPeriodDescription":
                    this.cmbValidPeriodType.DisplayLayout.Bands[0].Columns["Description"].Width = this.ugQuotationConditions.ActiveCell.Width;
                    break;*/
            }
        }

        //Delivery
        private void aplicarATodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyOptionToAll("DeliveryDescription", DeliveryValue, 0);
        }

        private void aplicarABanlcosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyOptionToAll("DeliveryDescription", DeliveryValue, 1);
        }

        private void ApplyOptionToAll(string columnName, string value, int option)
        {
            if (value != String.Empty)
            {
                foreach (DataRow row in QuotationData.Tables["Table1"].Rows)
                {
                    if (option == 2)
                    {
                        if (Convert.ToInt32(row["SectionTypeID"]) == SectionTypeIDValue)
                        {
                            row[columnName] = value;
                        }
                    }
                    else if (option == 1)
                    {
                        if (row[columnName].ToString() == String.Empty)
                        {
                            row[columnName] = value;
                        }
                    }
                    else
                    {
                        row[columnName] = value;
                    }
                }
                this.ugQuotationConditions.UpdateData();
                this.ugQuotationConditions.Refresh();
            }
        }

        //PaymentType
        private void aplicarATodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ApplyOptionToAll("PaymentDescription", PaymentValue, 0);
        }

        private void aplicarAVaciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ApplyOptionToAll("PaymentDescription", PaymentValue, 1);
        }

        private void ugQuotationConditions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePoint = new Point(e.X, e.Y);
                UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);

                UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                if (cell != null)
                {
                    int x, y;

                    x = this.Parent.Parent.Parent.Location.X + mousePoint.X + 11;
                    y = this.Parent.Parent.Parent.Location.Y + mousePoint.Y + 46;
                    Point contextMenuLocation = new Point(x, y);
                    switch (cell.Column.Key)
                    {
                        /*case "PaymentDescription":
                            PaymentValue = cell.Text;
                            contextMenuPayment.Show(contextMenuLocation);
                            break;*/
                        case "DeliveryDescription":
                            SectionTypeIDValue = Convert.ToInt32(cell.Row.Cells["SectionTypeID"].Value);
                            DeliveryValue = cell.Text;
                            contextMenuDelivery.Show(contextMenuLocation);
                            break;
                        case "DeliveryTimeDescription":
                            SectionTypeIDValue = Convert.ToInt32(cell.Row.Cells["SectionTypeID"].Value);
                            DeliveryTimeValue = cell.Text;
                            contextMenuDeliveryTime.Show(contextMenuLocation);
                            break;
                        /*case "ValidPeriodDescription":
                            ValidPeriodValue = cell.Text;
                            contextMenuValidPeriod.Show(contextMenuLocation);
                            break;*/
                    }
                }
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ApplyOptionToAll("ValidPeriodDescription", ValidPeriodValue, 0);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //ApplyOptionToAll("ValidPeriodDescription", ValidPeriodValue, 1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.SaveQuotation(false);
            ProductSelectionView myview = new ProductSelectionView();
            myview.QuotationID = this.QuotationID;
            myview.User = this.User;
            myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
            MainController.Instance.Next(myview);
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ApplyOptionToAll("DeliveryTimeDescription", DeliveryTimeValue, 0);
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            ApplyOptionToAll("DeliveryTimeDescription", DeliveryTimeValue, 1);
        }

        private void aplicarASecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Aplicar a sección DeliveryTimeDescription
            ApplyOptionToAll("DeliveryTimeDescription", DeliveryTimeValue, 2);
        }

        private void aplicarASecciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Aplicar a sección DeliveryDescription
            ApplyOptionToAll("DeliveryDescription", DeliveryValue, 2);
        }
    }
}
