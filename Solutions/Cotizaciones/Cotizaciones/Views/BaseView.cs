using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cotizaciones.Views
{
    public partial class BaseView : UserControl
    {
        public int QuotationID { get; set; }
        public Cotizaciones.Enums.QuotationStatusType QuotationStatusTypeID { get; set; }
        public bool IsReadOnlyQuotation
        {
            get
            {
                return this.QuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.Finished
                    || this.QuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.Sold
                    || this.QuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.FinishedExternal
                    || this.QuotationStatusTypeID == Cotizaciones.Enums.QuotationStatusType.FinishedAndSent;
            }
        }
        public string User { get; set; }
        public BaseView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
    }
}
