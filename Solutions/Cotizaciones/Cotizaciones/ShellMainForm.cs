using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.Common;
using Cotizaciones.Enums;
using Cotizaciones.Dialogs;
using System.Reflection;

namespace Cotizaciones
{
    public partial class ShellMainForm : Form
    {
        Control current = null;
        bool ReadOnlyMode;
        public ShellMainForm(bool readOnlyMode)
        {
            ReadOnlyMode = readOnlyMode;
            InitializeComponent();
        }

        private void ShellMainForm_Load(object sender, EventArgs e)
        {
            LoginDialog loginDlg = new LoginDialog();
            if (loginDlg.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
            MainController.Instance.Handler = new MainController.ViewHandler(this.SwitchView);
            MainController.Instance.BarHandler = new MainController.StatusBarHandler(this.ChangeStatusBarMessage);
            MainController.Instance.Handler();
            EnableDisableMenuOptions();
            string additionalMessage = "";
            if (ReadOnlyMode)
            {
                additionalMessage = " - SOLO LECTURA BASE DE DATOS " + ConfigurationHelper.ConnectionString;
            }
            this.Text = "Sistema de Cotizaciones (Versión " + GetSystemVersion() + ")" + additionalMessage;
        }
        
        void EnableDisableMenuOptions()
        {
            if (PreferencesHelper.GetPreference("DefaultUser") != Utilities.GetConfigurationKeyValue("AdminUser"))
            {
                this.administracionDeUsuariosToolStripMenuItem.Enabled = false;
                this.administracionDeDiametrosToolStripMenuItem.Enabled = false;
                this.adminitracionDeCatalogosToolStripMenuItem.Enabled = false;
            }
        }

        private void SwitchView()
        {
            RemoveCurrentView();
            AddView();
        }

        private void AddView()
        {
            current = MainController.Instance.GetNextControl();
            this.ultraTabPageControl1.Controls.Add(current);
        }

        private void RemoveCurrentView()
        {
            if (current != null)
            {
                this.ultraTabPageControl1.Controls.Remove(current);
            }
        }

        private void ChangeStatusBarMessage(StatusBarElements element, string message)
        {
            this.StatusBar.Panels[element.ToString()].Text = message;
        }

        private void ShellMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteExistingPDFFiles();
        }

        private void DeleteExistingPDFFiles()
        {
            try
            {
                string[] pdfList = Directory.GetFiles(Path.GetTempPath(), "C*.pdf");
                foreach (string f in pdfList)
                {
                    File.Delete(f);
                }
            }
            catch
            { }
        }

        private void reporteDeCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuotationReportDialog dialog = new QuotationReportDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void preferenciasDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPreferencesDialog dialog = new UserPreferencesDialog(PreferencesHelper.GetPreference("DefaultUser"), ReadOnlyMode);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void administracionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementDialog dialog = new UserManagementDialog(PreferencesHelper.GetPreference("DefaultUser"), ReadOnlyMode);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void administracionDeDiametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDiameterDialog dialog = new EditDiameterDialog(PreferencesHelper.GetPreference("DefaultUser"), ReadOnlyMode);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void administracionDeEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomersDialog dialog = new EditCustomersDialog(PreferencesHelper.GetPreference("DefaultUser"), ReadOnlyMode);
            if (dialog.ShowDialog() == DialogResult.OK)
            { }
        }

        string GetSystemVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Version.ToString();
        }

        private void adminitracionDeCatalogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogEditDialog dialog = new CatalogEditDialog(ReadOnlyMode);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}
