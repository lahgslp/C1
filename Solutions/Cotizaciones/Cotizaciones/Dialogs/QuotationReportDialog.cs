using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataManagers;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Cotizaciones.Dialogs
{
    public partial class QuotationReportDialog : Form
    {
        public QuotationReportDialog()
        {
            InitializeComponent();
        }

        private void QuotationReportDialog_Load(object sender, EventArgs e)
        {
            this.dtDateFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            this.dtDateTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivo de Excel (*.xls)|*.xls";
            dlg.RestoreDirectory = true;
            dlg.FileName = "Reporte De Cotizaciones " + DateTime.Now.ToString("yyyyMMdd");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter.Export(this.ugQuotationData, dlg.FileName);
            }
        }

        private void btnFilterData_Click(object sender, EventArgs e)
        {
            this.ugQuotationData.DataSource = QuotationReportsManager.GetQuotationReport(Convert.ToDateTime(this.dtDateFrom.Value).ToString("yyyyMMdd"), Convert.ToDateTime(this.dtDateTo.Value).ToString("yyyyMMdd"));
            this.ugQuotationData.DataMember = "Table";
            RenameGridHeaders();
        }

        private void RenameGridHeaders()
        {
            foreach (UltraGridColumn col in this.ugQuotationData.DisplayLayout.Bands[0].Columns)
            {
                switch (col.Key)
                {
                    case "QuotationID":
                        col.Header.Caption = "Cotización #";
                        break;
                    case "Created":
                        col.Header.Caption = "Fecha";
                        break;
                    case "CompanyName":
                        col.Header.Caption = "Empresa Cotizadora";
                        break;
                    case "CustomerName":
                        col.Header.Caption = "Cliente";
                        break;
                    case "ContactName":
                        col.Header.Caption = "Contacto";
                        break;
                    case "Creator":
                        col.Header.Caption = "Creador";
                        break;
                    case "Status":
                        col.Header.Caption = "Estado";
                        break;
                    case "SectionType":
                        col.Header.Caption = "Sección";
                        break;
                    case "SectionDescription":
                        col.Header.Caption = "Comentarios de Sección";
                        break;
                    case "Diameter":
                        col.Header.Caption = "Diámetro";
                        break;
                    case "Width":
                        col.Header.Caption = "Espesor";
                        break;
                    case "Weight":
                        col.Header.Caption = "Peso";
                        break;
                    case "OpenField1":
                        col.Header.Caption = "Caract. especiales";
                        break;
                    case "Quantity":
                        col.Header.Caption = "Cantidad";
                        break;
                    case "UnitType":
                        col.Header.Caption = "Unidad";
                        break;
                    case "Price":
                        col.Header.Caption = "Precio";
                        break;
                    case "CurrencyDescription":
                        col.Header.Caption = "Moneda";
                        break;
                    case "DeliveryDescription":
                        col.Header.Caption = "LAB";
                        break;
                    case "PaymentDescription":
                        col.Header.Caption = "Condiciones de Pago";
                        break;
                    case "DeliveryTimeDescription":
                        col.Header.Caption = "Tiempo de Entrega";
                        break;
                    case "Notes":
                        col.Header.Caption = "Notas";
                        break;
                }
            }
        }
    }
}
