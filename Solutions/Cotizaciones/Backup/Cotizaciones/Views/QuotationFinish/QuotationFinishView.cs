using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Mail;
using System.Diagnostics;
using Cotizaciones.DataManagers;
using Cotizaciones.DataModel;
using Cotizaciones.PDFWriter;
using System.IO;

namespace Cotizaciones.Views
{
    public partial class QuotationFinishView : BaseView
    {
        string FileName = "";
        DataSet ReferenceData;
        DataSet QuotationData;
        bool isFinalized = false;
        public QuotationFinishView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Save();
            MyQuotationsView myview = new MyQuotationsView();
            MainController.Instance.Next(myview);
            this.Cursor = Cursors.Default;
        }

        void AfterFinalize()
        {
            if (isFinalized == true)
            {
                MessageBox.Show("La cotización ha sido finalizada.", "Cotización Finalizada");
            }
            else
            {
                //MessageBox.Show("La cotización ha sido finalizada.", "Cotización Finalizada");
            }
            btnClose_Click(null, null);
        }

        private void Save()
        {
            if (!IsReadOnly)
            {
                QuotationFinishManager.SaveQuotationFinishDetails(this.QuotationID, this.User, this.txtNotes.Text, this.cmbValidPeriodType.Text, this.cmbPaymentType.Text, this.cmbInvoiceMethodType.Text);
            }
        }

        private void QuotationFinishView_Load(object sender, EventArgs e)
        {
            isFinalized = false;
            LoadReferenceData();
            Quotation q = QuotationFinishManager.GetQuotationEntity(this.QuotationID);
            this.txtNotes.Text = q.Notes;
            if (q.ValidPeriodDescription != String.Empty && IsReadOnly == false)
            {
                this.cmbValidPeriodType.Value = q.ValidPeriodDescription;
            }
            else
            {
                this.cmbValidPeriodType.Value = ReferenceData.Tables["Table"].Rows[0]["Description"].ToString();
            }

            if (q.PaymentDescription != String.Empty && IsReadOnly == false)
            {
                this.cmbPaymentType.Value = q.PaymentDescription;
            }
            else
            {
                this.cmbPaymentType.Value = ReferenceData.Tables["Table1"].Rows[0]["Description"].ToString();
            }

            if (q.InvoiceMethodDescription != String.Empty && IsReadOnly == false)
            {
                this.cmbInvoiceMethodType.Value = q.InvoiceMethodDescription;
            }
            else
            {
                this.cmbInvoiceMethodType.Value = ReferenceData.Tables["Table2"].Rows[0]["Description"].ToString();
            }
            EnableDisableControls();
        }

        private void LoadReferenceData()
        {
            ReferenceData = QuotationFinishManager.GetQuotationFinishReferenceData();
            SetupControls();
        }

        private void SetupControls()
        {
            this.cmbValidPeriodType.DataSource = ReferenceData;
            this.cmbValidPeriodType.DataMember = "Table";
            this.cmbValidPeriodType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbValidPeriodType.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbValidPeriodType.Width;

            this.cmbPaymentType.DataSource = ReferenceData;
            this.cmbPaymentType.DataMember = "Table1";
            this.cmbPaymentType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbPaymentType.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbPaymentType.Width;

            this.cmbInvoiceMethodType.DataSource = ReferenceData;
            this.cmbInvoiceMethodType.DataMember = "Table2";
            this.cmbInvoiceMethodType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            this.cmbInvoiceMethodType.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbInvoiceMethodType.Width;
        }

        private void EnableDisableControls()
        {
            if (IsReadOnly == true)
            {
                this.txtNotes.ReadOnly = true;
                this.cmbPaymentType.ReadOnly = true;
                this.cmbValidPeriodType.ReadOnly = true;
                this.cmbInvoiceMethodType.ReadOnly = true;
                this.btnFinalize.Enabled = false;
                this.btnFinalizeAndSaveFile.Enabled = false;
                this.btnFinalizeAndSend.Enabled = false;
                this.btnClose.Focus();
            }
            else
            {
                this.txtNotes.Focus();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Save();
            QuotationConditionsView myview = new QuotationConditionsView();
            myview.QuotationID = this.QuotationID;
            myview.User = this.User;
            myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
            MainController.Instance.Next(myview);
            this.Cursor = Cursors.Default;
        }

        private void SaveAndCreate()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Save();
            QuotationPDFWriter writer = new QuotationPDFWriter();
            FileName = writer.CreatePDFQuotation(this.QuotationID);
            this.Cursor = Cursors.Default;
        }

        private void SaveCreateFinalize()
        {
            SaveAndCreate();
            if (Directory.Exists(Properties.Settings.Default.NetworkFolder) == true)
            {
                isFinalized = true;
                this.Cursor = Cursors.WaitCursor;
                File.Copy(FileName, Properties.Settings.Default.NetworkFolder + "\\" + FileName);
                QuotationFinishManager.FinalizeQuotation(QuotationID, FileName, User);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
            }
        }

        private void btnPreliminaryView_Click(object sender, EventArgs e)
        {
            SaveAndCreate();
            Process.Start(FileName);
        }

        private void btnFinalizeAndSend_Click(object sender, EventArgs e)
        {
            SaveCreateFinalize();
            //GetQuotatin data - TODO: Get only the relevant information in the future
            this.QuotationData = QuotationCreationManager.GetQuotationData(this.QuotationID);
            CreateEmail();
            AfterFinalize();
        }

        private void CreateEmail()
        {
            //Create the email
            Microsoft.Office.Interop.Outlook.Application objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mail = (Microsoft.Office.Interop.Outlook.MailItem)(objOutlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));
            mail.To = this.QuotationData.Tables["Table"].Rows[0]["EmailTo"].ToString();
            if (this.QuotationData.Tables["Table"].Rows[0]["EmailTo"].ToString() != String.Empty)
            {
                mail.CC = this.QuotationData.Tables["Table"].Rows[0]["NotifyToEmail"].ToString();
            }
            //mail.Subject = "Cotización #" + this.QuotationID.ToString() + " para " + this.QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString();
            mail.Subject = "Cotización para " + this.QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString();
            mail.Body = GetEmailBody();
            string FullName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + FileName;
            mail.Attachments.Add(FullName, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, FileName);
            mail.Display(false);

        }

        private string GetEmailBody()
        {
            string body = "";
            if (this.QuotationData.Tables["Table"].Rows[0]["ContactName"] != null && this.QuotationData.Tables["Table"].Rows[0]["ContactName"].ToString().Trim() != String.Empty)
            {
                body += "Estimado(a) " + this.QuotationData.Tables["Table"].Rows[0]["ContactName"].ToString() + ",";
            }
            else
            {
                body += "A quien corresponda,";
            }
            body += Environment.NewLine;
            if (this.QuotationData.Tables["Table"].Rows[0]["CustomerName"] != null && this.QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString().Trim() != String.Empty)
            {
                body += this.QuotationData.Tables["Table"].Rows[0]["CustomerName"].ToString();
            }
            body += Environment.NewLine + Environment.NewLine;

            body += Properties.Settings.Default.GreetingsMessage;

            body += Environment.NewLine + Environment.NewLine;

            body += "Saludos," + Environment.NewLine;
            body += this.QuotationData.Tables["Table"].Rows[0]["Creator"].ToString() + Environment.NewLine;
            body += this.QuotationData.Tables["Table"].Rows[0]["CreatorEmail"].ToString() + Environment.NewLine;
            body += Properties.Settings.Default.CompanyFullName + Environment.NewLine;
            return body;
        }

        private void btnFinalizeAndSaveFile_Click(object sender, EventArgs e)
        {
            SaveCreateFinalize();
            AfterFinalize();
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            SaveCreateFinalize();
            AfterFinalize();
        }

        private void cmbValidPeriodType_BeforeDropDown(object sender, CancelEventArgs e)
        {
            this.cmbValidPeriodType.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbValidPeriodType.Width;
        }

        private void cmbPaymentType_BeforeDropDown(object sender, CancelEventArgs e)
        {
            this.cmbPaymentType.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbPaymentType.Width;
        }

        private void cmbInvoiceMethodType_BeforeDropDown(object sender, CancelEventArgs e)
        {
            this.cmbInvoiceMethodType.DisplayLayout.Bands[0].Columns["Description"].Width = this.cmbInvoiceMethodType.Width;
        }
    }
}
