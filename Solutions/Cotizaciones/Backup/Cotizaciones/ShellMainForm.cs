using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.Enums;

namespace Cotizaciones
{
    public partial class ShellMainForm : Form
    {
        Control current = null;
        public ShellMainForm()
        {
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
                string[] pdfList = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pdf");
                foreach (string f in pdfList)
                {
                    File.Delete(f);
                }
            }
            catch
            { }
        }
    }
}
