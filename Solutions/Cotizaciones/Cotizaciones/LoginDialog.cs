using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataManagers;
using Cotizaciones.Common;

namespace Cotizaciones
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (LoginManager.IsValidUser(this.txtUser.Text, this.txtPassword.Text) == true)
            {
                if (PreferencesHelper.GetPreference("DefaultUser") != this.txtUser.Text)
                {
                    PreferencesHelper.SetPreference("DefaultUser", this.txtUser.Text);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos, favor de intentar nuevamente", "Error en identificación de usuario");
                this.txtPassword.Text = "";
            }
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(null, null);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(null, null);
            }
        }

        private void LoginDialog_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DefaultUser == String.Empty)
            {
                this.txtUser.Focus();
            }
            else
            {
                this.txtUser.Text = Properties.Settings.Default.DefaultUser;
                this.txtPassword.Focus();
            }
        }
    }
}
