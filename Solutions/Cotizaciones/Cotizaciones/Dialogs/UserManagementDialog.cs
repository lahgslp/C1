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
    public partial class UserManagementDialog : Form
    {
        string CurrentUser;
        string UserID;
        public UserManagementDialog(string currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NewUserDialog dialog = new NewUserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CreateUser(dialog.NewUserShortName, dialog.NewUserFullName, dialog.NewUserPassword);
                MessageBox.Show("Se ha creado exitosamente el usuario.\n\nPreferencias por default han sido cargadas y pueden ser modificadas por el usuario","Nuevo usuario");
                GetUsers();
                this.btnActivateUser.Enabled = false;
                this.btnDeactivateUser.Enabled = false;
            }
        }

        private void CreateUser(string shortname, string fullname, string password)
        {
            //User
            User u = new User();
            u.ShortName = shortname;
            u.FullName = fullname;
            u.Password = password;
            u.Active = "A";
            u.Creator = CurrentUser;
            u.Created = DateTime.Now;
            u.Save();
            //UserPreferences
            UserPreference up = new UserPreference();
            up.UserID = u.UserID;
            up.GreetingsMessage = Utilities.GetConfigurationKeyValue("DefaultGreetingsMessage");
            up.DefaultNotes = "";
            up.DefaultFootNotes = "";
            up.DefaultCompanyID = Convert.ToInt32(Utilities.GetConfigurationKeyValue("DefaultCompanyID"));
            up.Active = "A";
            up.Creator = CurrentUser;
            up.Created = DateTime.Now;
            up.Save();
            //UserCompanyPreferences
            FersumDB db = new FersumDB();
            var result = from p in db.Companies
                         select p;
            foreach (Company c in result)
            {
                UserCompanyPreference ucp = new UserCompanyPreference();
                ucp.UserID = u.UserID;
                ucp.CompanyID = c.CompanyID;
                ucp.CC = "";
                ucp.Signature = u.FullName + Environment.NewLine + c.CompanyFullName + Environment.NewLine;
                ucp.EmailAddress = "";
                ucp.Active = "A";
                ucp.Creator = CurrentUser;
                ucp.Created = DateTime.Now;
                ucp.Save();
            }
        }

        private void btnActivateUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta acción activará al usuario. ¿Desea continuar?", "Administración de Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                UpdateUser(UserID, "A");
                this.btnActivateUser.Enabled = false;
                this.btnDeactivateUser.Enabled = false;
            }
        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta acción desactivará al usuario. ¿Desea continuar?", "Administración de Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                UpdateUser(UserID, "I");
                this.btnActivateUser.Enabled = false;
                this.btnDeactivateUser.Enabled = false;
            }
        }

        private void UserManagementDialog_Load(object sender, EventArgs e)
        {
            this.btnDeactivateUser.Enabled = false;
            this.btnActivateUser.Enabled = false;
            GetUsers();
        }

        private void GetUsers()
        {
            this.lstUsers.Items.Clear();
            FersumDB db = new FersumDB();
            var result = from p in db.Users
                         select p;
            foreach (User u in result)
            {
                this.lstUsers.Items.Add(u.ShortName);
            }
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

        private void UpdateUser(string userID, string active)
        {
            User u = GetUser(userID);
            u.Active = active;
            u.Modifier = CurrentUser;
            u.Modified = DateTime.Now;
            u.Update();
            GetUsers();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstUsers.SelectedItem != null)
            {
                UserID = this.lstUsers.SelectedItem.ToString();
                if (UserID == Utilities.GetConfigurationKeyValue("AdminUser"))
                {
                    this.btnDeactivateUser.Enabled = false;
                    this.btnActivateUser.Enabled = false;
                }
                else
                {
                    User u = GetUser(UserID);
                    if (u.Active == "A")
                    {
                        this.btnActivateUser.Enabled = false;
                        this.btnDeactivateUser.Enabled = true;
                    }
                    else
                    {
                        this.btnActivateUser.Enabled = true;
                        this.btnDeactivateUser.Enabled = false;
                    }
                }
            }
        }
    }
}
