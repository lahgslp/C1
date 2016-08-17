using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubSonic.Schema;
using Cotizaciones.DataModel;

namespace Cotizaciones.Dialogs
{
    public partial class ChangePasswordDialog : Form
    {
        string User;
        public ChangePasswordDialog(string user)
        {
            User = user;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (this.txtConfirmPassword1.Text == this.txtConfirmPassword2.Text)
            {
                if (Utilities.isValidPassword(this.txtConfirmPassword1.Text))
                {
                    User u = GetUser(User);
                    if (u != null)
                    {
                        u.Password = this.txtConfirmPassword1.Text;
                        u.Modifier = User;
                        u.Modified = DateTime.Now;
                        u.Save();
                        MessageBox.Show("Clave ha sido cambiada exitosamente", "Cambio de clave");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta. Por favor intente de nuevo", "Cambio de clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtCurrentPassword.Text = "";
                        this.txtCurrentPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Nueva clave incorrecta. No incluya espacios ni simbolos distintos a puntos y guiones", "Error");
                    this.txtConfirmPassword1.Text = "";
                    this.txtConfirmPassword2.Text = "";
                    this.txtConfirmPassword1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nuevas claves no coinciden. Por favor intente de nuevo", "Cambio de clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtConfirmPassword1.Text = "";
                this.txtConfirmPassword2.Text = "";
                this.txtConfirmPassword1.Focus();
            }
        }

        private User GetUser(string userID)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Users
                         where p.ShortName == userID && p.Password == this.txtCurrentPassword.Text
                         select p;
            foreach (User u in result)
            {
                return u;
            }
            return null;
        }

        private void txtCurrentPassword_KeyDown(object sender, KeyEventArgs e)
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
