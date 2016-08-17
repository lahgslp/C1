using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DBNavigator
{
    public partial class DBManagerForm : Form
    {
        DataSet dsDBCatalog = new DataSet();
        string filePath = "DataBases.xml";

        public DBManagerForm()
        {
            InitializeComponent();
        }

        private void DBManagerForm_Load(object sender, EventArgs e)
        {
            LoadCatalog();
        }

        void LoadCatalog()
        {

            dsDBCatalog.Clear();
            this.ugDBCatalog.DataSource = null;

            if (System.IO.File.Exists(filePath) == false)
                return;

            System.IO.FileStream fsReadXml = new System.IO.FileStream
                (filePath, System.IO.FileMode.Open);
            try
            {
                dsDBCatalog.ReadXml(fsReadXml);
                this.ugDBCatalog.DataSource = dsDBCatalog;
                DisableNameColumn();
                DataColumn[] keys = new DataColumn[1];
                keys[0] = (DataColumn)dsDBCatalog.Tables[0].Columns["Name"];
                dsDBCatalog.Tables[0].PrimaryKey = keys;
                dsDBCatalog.Tables[0].TableNewRow +=new DataTableNewRowEventHandler(DBManagerForm_TableNewRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fsReadXml.Close();
            }
        }

        private void DBManagerForm_TableNewRow(object sender, EventArgs e)
        {
            //MessageBox.Show("Here");
            DisableNameColumn();
        }

        private void DisableNameColumn()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ugDBCatalog.DisplayLayout.Rows)
            {
                row.Cells["Name"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            dsDBCatalog.WriteXml(filePath);
            this.Close();
        }
    }
}