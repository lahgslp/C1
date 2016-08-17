using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones;
using SubSonic.Schema;
using Cotizaciones.DataModel;

namespace Cotizaciones.Dialogs
{
    public partial class NewUserDialog : Form
    {
        public string NewUserShortName;
        public string NewUserFullName;
        public string NewUserPassword;

        public NewUserDialog()
        {
            InitializeComponent();
            this.NewUserShortName = "";
            this.NewUserPassword = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateUserName() && ValidateFullName() && ValidatePassword())
            {
                this.NewUserShortName = this.txtUser.Text;
                this.NewUserFullName = this.txtFullName.Text;
                this.NewUserPassword = this.txtConfirmPassword1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateFullName()
        {
            if (this.txtFullName.Text == String.Empty)
            {
                MessageBox.Show("Por favor incluya un nombre de completo de usuario", "Error");
                this.txtFullName.Focus();
                return false;
            }
            return true;
        }

        private bool ValidateUserName()
        {
            if (Utilities.isValidUserName(this.txtUser.Text))
            {
                if (GetUser(this.txtUser.Text) == null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Usuario ya existe. Intente otro nombre de usuario", "Error");
                    this.txtUser.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario incorrecto. No incluya espacios ni simbolos distintos a puntos y guiones", "Error");
                this.txtUser.Focus();
                return false;
            }
        }

        private bool ValidatePassword()
        {
            if (this.txtConfirmPassword1.Text != this.txtConfirmPassword2.Text)
            {
                MessageBox.Show("Claves no coinciden, por favor intente de nuevo","Error");
                BlankPasswords();
                return false;
            }
            else
            {
                if (Utilities.isValidPassword(this.txtConfirmPassword1.Text))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Clave incorrecta. No incluya espacios ni simbolos distintos a puntos y guiones", "Error");
                    BlankPasswords();
                    return false;
                }
            }
        }

        private void BlankPasswords()
        {
            this.txtConfirmPassword1.Text = "";
            this.txtConfirmPassword2.Text = "";
            this.txtConfirmPassword1.Focus();
        }

        private User GetUser(string userID)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Users
                         where p.ShortName == userID
                         select p;
            foreach (User u in result)
            {
                return u;
            }
            return null;
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }

        private void txtConfirmPassword1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }

        private void txtConfirmPassword2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}
