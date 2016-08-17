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
using Cotizaciones.Enums;

namespace Cotizaciones.Views
{
    public partial class QuotationFinishView : BaseView
    {
        DataSet ReferenceData;
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
            MessageBox.Show("La cotización ha sido finalizada.", "Cotización Finalizada");
        }

        private void Save()
        {
            if (!IsReadOnly)
            {
                QuotationFinishManager.SaveQuotationFinishDetails(this.QuotationID, this.User, this.txtNotes.Text, this.txtFootNotes.Text, this.cmbValidPeriodType.Text, this.cmbPaymentType.Text, this.cmbInvoiceMethodType.Text);
            }
        }

        private void QuotationFinishView_Load(object sender, EventArgs e)
        {
            LoadReferenceData();
            LoadQuotationData();
        }

        private void LoadQuotationData()
        {
            Quotation q = QuotationFinishManager.GetQuotationEntity(this.QuotationID);
            this.QuotationStatusTypeID = (Cotizaciones.Enums.QuotationStatusType)q.QuotationStatusTypeID;
            this.txtNotes.Text = q.Notes;
            this.txtFootNotes.Text = q.FootNoteDescription;
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
                this.txtFootNotes.ReadOnly = true;
                this.cmbPaymentType.ReadOnly = true;
                this.cmbValidPeriodType.ReadOnly = true;
                this.cmbInvoiceMethodType.ReadOnly = true;
                this.btnFinalize.Enabled = false;
                this.btnFinalizeAndSend.Enabled = true;
                this.btnClose.Focus();
                if (this.QuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.FinishedExternal)
                {
                    this.btnPreliminaryView.Enabled = false;
                    this.btnFinalizeAndSend.Enabled = false;
                }
                if (this.QuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.Finished)
                {
                    this.btnCloseAndSend.Enabled = true;
                }
                else
                {
                    this.btnCloseAndSend.Enabled = false;
                }
            }
            else
            {
                this.btnFinalizeAndSend.Enabled = false;
                this.txtNotes.Focus();
                this.btnCloseAndSend.Enabled = false;
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

        private string SaveAndCreate()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Save();
            QuotationPDFWriter writer = new QuotationPDFWriter();
            string FileName = writer.CreatePDFQuotation(this.QuotationID);
            this.Cursor = Cursors.Default;
            return FileName;
        }

        private void SaveCreateFinalize()
        {
            string FileName = SaveAndCreate();
            if (Directory.Exists(Utilities.GetConfigurationKeyValue("NetworkFolder")) == true)
            {
                this.Cursor = Cursors.WaitCursor;
                //File.Copy(FileName, Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\" + FileName);
                QuotationAttachment qa = QuotationAttachmentManager.AddQuotationAttachment(this.QuotationID, Utilities.GetFileName(FileName), this.User, "Y");
                try
                {
                    File.Copy(FileName, Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + qa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(FileName));
                }
                catch (Exception exc)
                {
                    QuotationAttachmentManager.RemoveQuotationAttachment(qa.QuotationID, qa.QuotationAttachmentID);
                }
                QuotationFinishManager.FinalizeQuotation(QuotationID, User, Cotizaciones.Enums.QuotationStatusType.Finished);
                LoadQuotationData();
                MainController.Instance.ChangeStatusBar(StatusBarElements.StatusMessage, "Solo lectura");
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
            }
        }

        private void btnPreliminaryView_Click(object sender, EventArgs e)
        {
            string FileName = SaveAndCreate();
            Process.Start(FileName);
            if (!IsReadOnly)
            {
                if (MessageBox.Show("¿Son correctos los datos de la cotización?", "Validar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.btnFinalize.Enabled = true;
                }
            }
        }

        private void btnFinalizeAndSend_Click(object sender, EventArgs e)
        {
            //SaveCreateFinalize();
            //GetQuotatin data - TODO: Get only the relevant information in the future
            DataSet QuotationData = QuotationCreationManager.GetQuotationData(this.QuotationID);
            Utilities.CreateEmail(this.QuotationID, QuotationData, true, "");
            //AfterFinalize();
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta acción finalizará la cotización y los datos no podran ser modificados. ¿Desea continuar?", "Finalizar cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SaveCreateFinalize();
                AfterFinalize();
            }
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

        private void btnCloseAndSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta acción marcará la cotización como Finalizada y Enviada. ¿Desea continuar?", "Finalizar y Enviar Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                QuotationFinishManager.FinalizeQuotation(QuotationID, User, Cotizaciones.Enums.QuotationStatusType.FinishedAndSent);
                MyQuotationsView myview = new MyQuotationsView();
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }
    }
}
