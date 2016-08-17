namespace Cotizaciones.Views
{
    partial class CustomerInfoView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.lblEmail = new Infragistics.Win.Misc.UltraLabel();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uceContact = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceCustomer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblContact = new Infragistics.Win.Misc.UltraLabel();
            this.lblCompany = new Infragistics.Win.Misc.UltraLabel();
            this.btnBack = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnNext = new Infragistics.Win.Misc.UltraButton();
            this.MainPanel.SuspendLayout();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.CustomerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainSplitContainer);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1496, 563);
            this.MainPanel.TabIndex = 0;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitContainer.IsSplitterFixed = true;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.CustomerGroupBox);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.btnBack);
            this.MainSplitContainer.Panel2.Controls.Add(this.btnCancel);
            this.MainSplitContainer.Panel2.Controls.Add(this.btnNext);
            this.MainSplitContainer.Size = new System.Drawing.Size(1496, 563);
            this.MainSplitContainer.SplitterDistance = 530;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Controls.Add(this.lblEmail);
            this.CustomerGroupBox.Controls.Add(this.txtEmail);
            this.CustomerGroupBox.Controls.Add(this.uceContact);
            this.CustomerGroupBox.Controls.Add(this.uceCustomer);
            this.CustomerGroupBox.Controls.Add(this.lblContact);
            this.CustomerGroupBox.Controls.Add(this.lblCompany);
            this.CustomerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerGroupBox.Location = new System.Drawing.Point(0, 0);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(1496, 530);
            this.CustomerGroupBox.TabIndex = 0;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Cliente";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(6, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "e-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(112, 99);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(1378, 21);
            this.txtEmail.TabIndex = 2;
            // 
            // uceContact
            // 
            this.uceContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uceContact.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceContact.Location = new System.Drawing.Point(112, 59);
            this.uceContact.Name = "uceContact";
            this.uceContact.Size = new System.Drawing.Size(1378, 21);
            this.uceContact.TabIndex = 1;
            this.uceContact.ValueChanged += new System.EventHandler(this.uceContact_ValueChanged);
            // 
            // uceCustomer
            // 
            this.uceCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uceCustomer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceCustomer.Location = new System.Drawing.Point(112, 19);
            this.uceCustomer.Name = "uceCustomer";
            this.uceCustomer.Size = new System.Drawing.Size(1378, 21);
            this.uceCustomer.TabIndex = 0;
            this.uceCustomer.ValueChanged += new System.EventHandler(this.uceCustomer_ValueChanged);
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(6, 59);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(100, 23);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Contacto:";
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(6, 19);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(100, 23);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Empresa:";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Enabled = false;
            this.btnBack.Location = new System.Drawing.Point(1256, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "&Anterior";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1418, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cerrar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(1337, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Siguiente";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // CustomerInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Name = "CustomerInfoView";
            this.Size = new System.Drawing.Size(1496, 563);
            this.Load += new System.EventHandler(this.CustomerInfoView_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.ResumeLayout(false);
            this.CustomerGroupBox.ResumeLayout(false);
            this.CustomerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private Infragistics.Win.Misc.UltraButton btnNext;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceCustomer;
        private Infragistics.Win.Misc.UltraLabel lblContact;
        private Infragistics.Win.Misc.UltraLabel lblCompany;
        private Infragistics.Win.Misc.UltraLabel lblEmail;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceContact;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnBack;
    }
}
