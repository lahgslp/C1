using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cotizaciones.Dialogs
{
    public partial class CompanyPreferencesUserControl : UserControl
    {
        public string Email
        {
            get
            {
                return this.txtEmail.Text;
            }
            set
            {
                this.txtEmail.Text = value;
            }
        }
        public string CC
        {
            get
            {
                return this.txtCC.Text;
            }
            set
            {
                this.txtCC.Text = value;
            }
        }
        public string Signature
        {
            get
            {
                return this.txtSignature.Text;
            }
            set
            {
                this.txtSignature.Text = value;
            }
        }

        public CompanyPreferencesUserControl()
        {
            InitializeComponent();
        }
    }
}
