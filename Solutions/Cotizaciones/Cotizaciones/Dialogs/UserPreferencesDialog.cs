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
    public partial class UserPreferencesDialog : Form
    {
        private int UserID;
        private string User;
        private int tabCount = 0;
        bool ReadOnlyMode;

        public UserPreferencesDialog(string User, bool readOnlyMode)
        {
            ReadOnlyMode = readOnlyMode;
            this.User = User;
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordDialog dialog = new ChangePasswordDialog(this.User);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
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
            if (ValidateEmails())
            {
                SaveUser();
                SaveUserPreferences();
                SaveUserCompanyPreferences();
                this.Close();
            }
        }

        private void SaveUser()
        {
            User u = GetUser(User);
            u.FullName = this.txtName.Text;
            u.Modifier = User;
            u.Modified = DateTime.Now;
            u.Update();
        }

        private void SaveUserPreferences()
        {
            UserPreference up = GetUserPreferences(UserID);
            up.DefaultNotes = this.txtDefaultNotes.Text;
            up.DefaultFootNotes = this.txtDefaultFootNotes.Text;
            up.GreetingsMessage = this.txtGreetingsMessage.Text;
            up.DefaultCompanyID = Convert.ToInt32(this.uceDefaultCompany.Value);
            up.Modifier = User;
            up.Modified = DateTime.Now;
            up.Update();
        }

        private void SaveUserCompanyPreferences()
        {
            if (User != Utilities.GetConfigurationKeyValue("AdminUser"))
            {
                FersumDB db = new FersumDB();
                var result = from c in db.Companies
                             //where p.UserID == userID
                             select c;
                foreach (Company c in result)
                {
                    CompanyPreferencesUserControl ucpControl;

                    ucpControl = (CompanyPreferencesUserControl)this.tabControlUserPreferences.Controls["tabPage" + c.CompanyName].Controls["ucCompanyPreferences" + c.CompanyName];

                    StoredProcedure sp = db.Fersum_Upd_UserCompanyPreferences(UserID, c.CompanyID, ucpControl.CC, ucpControl.Signature, ucpControl.Email, User);
                    sp.Execute();
                }
            }
        }

        private bool ValidateEmails()
        {
            if (User != Utilities.GetConfigurationKeyValue("AdminUser"))
            {
                FersumDB db = new FersumDB();
                var result = from c in db.Companies
                             //where p.UserID == userID
                             select c;
                foreach (Company c in result)
                {
                    CompanyPreferencesUserControl ucpControl;

                    ucpControl = (CompanyPreferencesUserControl)this.tabControlUserPreferences.Controls["tabPage" + c.CompanyName].Controls["ucCompanyPreferences" + c.CompanyName];
                    if (ucpControl.Email != String.Empty && !Utilities.isEmail(ucpControl.Email))
                    {
                        MessageBox.Show("Correo electrónico incorrecto. Favor de intentar de nuevo");
                        return false;
                    }
                }
            }
            return true;
        }

        private void UserPreferencesDialog_Load(object sender, EventArgs e)
        {
            LoadCompanyInfo();
            LoadUserInfo();
            LoadUserPreferencesInfo();
            LoadUserCompanyPreferencesInfo();
            this.btnOK.Enabled = !ReadOnlyMode;
        }

        private void LoadUserInfo()
        {
            User u = GetUser(User);
            UserID = u.UserID;
            this.txtUser.Text = u.ShortName;
            this.txtName.Text = u.FullName;
        }

        private User GetUser(string user)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Users
                         where p.ShortName == user
                         select p;
            foreach (User u in result)
            {
                return u;
            }
            return null;
        }

        private UserPreference GetUserPreferences(int userID)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.UserPreferences
                         where p.UserID == userID
                         select p;
            foreach (UserPreference up in result)
            {
                return up;
            }
            return null;
        }

        private UserCompanyPreference GetUserCompanyPreferences(int userID, int companyID)
        {
            FersumDB db = new FersumDB();
            var result = from ucp in db.UserCompanyPreferences
                         where ucp.UserID == userID && ucp.CompanyID == companyID
                         select ucp;
            foreach (UserCompanyPreference ucp in result)
            {
                return ucp;
            }
            return null;
        }

        private void LoadUserPreferencesInfo()
        {
            UserPreference up = GetUserPreferences(UserID);
            if (up != null)
            {
                this.txtDefaultNotes.Text = up.DefaultNotes;
                this.txtGreetingsMessage.Text = up.GreetingsMessage;
                this.txtDefaultFootNotes.Text = up.DefaultFootNotes;
                this.uceDefaultCompany.Value = up.DefaultCompanyID;
            }
            else
            {
                this.txtName.Enabled = false;
                this.txtDefaultFootNotes.Enabled = false;
                this.txtDefaultNotes.Enabled = false;
                this.txtGreetingsMessage.Enabled = false;
                this.uceDefaultCompany.Enabled = false;
            }
        }

        private void AddCompanyTabs()
        {
            if (User != Utilities.GetConfigurationKeyValue("AdminUser"))
            {
                FersumDB db = new FersumDB();
                var result = from c in db.Companies
                             //where p.UserID == userID
                             select c;
                foreach (Company c in result)
                {
                    AddTab(c.CompanyID, c.CompanyName);
                }
            }
        }

        private void AddTab(int CompanyID, string CompanyName)
        {
            TabPage tabCompany = new System.Windows.Forms.TabPage();
            tabCompany.Name = "tabPage" + CompanyName;
            tabCompany.Padding = new System.Windows.Forms.Padding(3);
            tabCompany.Size = new System.Drawing.Size(276, 257);
            tabCompany.TabIndex = ++tabCount;
            tabCompany.Text = CompanyName;
            tabCompany.UseVisualStyleBackColor = true;

            CompanyPreferencesUserControl ucpControl = new CompanyPreferencesUserControl();
            ucpControl.Name = "ucCompanyPreferences" + CompanyName;
            ucpControl.Dock = DockStyle.Fill;

            UserCompanyPreference ucp = GetUserCompanyPreferences(UserID, CompanyID);

            ucpControl.CC = ucp.CC;
            ucpControl.Email = ucp.EmailAddress;
            ucpControl.Signature = ucp.Signature;

            tabCompany.Controls.Add(ucpControl);

            this.tabControlUserPreferences.Controls.Add(tabCompany);
        }

        private void LoadUserCompanyPreferencesInfo()
        {
            AddCompanyTabs();
        }

        private void LoadCompanyInfo()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetCompanyInfo();
            DataSet ds = sp.ExecuteDataSet();

            this.uceDefaultCompany.DataSource = ds;
            this.uceDefaultCompany.DataMember = "Table";
            this.uceDefaultCompany.DisplayMember = "CompanyName";
            this.uceDefaultCompany.ValueMember = "CompanyID";
        }

    }
}
