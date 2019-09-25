using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataManagers;

namespace Cotizaciones.Dialogs
{
    public partial class CatalogEditDialog : Form
    {
        public CatalogEditDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save()
        {
            EditCatalogsManager mgr = new EditCatalogsManager();
            mgr.UpdateDeliveryTypes(this.textBoxDeliveryConditions.Text);
            mgr.UpdateDeliveryTimeTypes(this.textBoxDeliveryTime.Text);
            this.Close();
        }

        private void CatalogEditDialog_Load(object sender, EventArgs e)
        {
            EditCatalogsManager mgr = new EditCatalogsManager();
            this.textBoxDeliveryConditions.Text = mgr.GetDeliveryTypes();
            this.textBoxDeliveryTime.Text = mgr.GetDeliveryTimeTypes();
        }
    }
}
