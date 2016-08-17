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
            this.QuotationGroupBox = new System.Windows.Forms.GroupBox();
            this.FilesGroupBox = new System.Windows.Forms.GroupBox();
            this.splitContainerFiles = new System.Windows.Forms.SplitContainer();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.btnFinalizeExternal = new System.Windows.Forms.Button();
            this.btnSendAndFinalize = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uceCompany = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblCompany = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.uceCustomer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblEmail = new Infragistics.Win.Misc.UltraLabel();
            this.lblCustomer = new Infragistics.Win.Misc.UltraLabel();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblContact = new Infragistics.Win.Misc.UltraLabel();
            this.uceContact = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnBack = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnNext = new Infragistics.Win.Misc.UltraButton();
            this.MainPanel.SuspendLayout();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.QuotationGroupBox.SuspendLayout();
            this.FilesGroupBox.SuspendLayout();
            this.splitContainerFiles.Panel1.SuspendLayout();
            this.splitContainerFiles.Panel2.SuspendLayout();
            this.splitContainerFiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceCompany)).BeginInit();
            this.CustomerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceContact)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainSplitContainer);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1606, 864);
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
            this.MainSplitContainer.Panel1.Controls.Add(this.QuotationGroupBox);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.btnBack);
            this.MainSplitContainer.Panel2.Controls.Add(this.btnCancel);
            this.MainSplitContainer.Panel2.Controls.Add(this.btnNext);
            this.MainSplitContainer.Size = new System.Drawing.Size(1606, 864);
            this.MainSplitContainer.SplitterDistance = 831;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // QuotationGroupBox
            // 
            this.QuotationGroupBox.Controls.Add(this.FilesGroupBox);
            this.QuotationGroupBox.Controls.Add(this.groupBox1);
            this.QuotationGroupBox.Controls.Add(this.CustomerGroupBox);
            this.QuotationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuotationGroupBox.Location = new System.Drawing.Point(0, 0);
            this.QuotationGroupBox.Name = "QuotationGroupBox";
            this.QuotationGroupBox.Size = new System.Drawing.Size(1606, 831);
            this.QuotationGroupBox.TabIndex = 0;
            this.QuotationGroupBox.TabStop = false;
            this.QuotationGroupBox.Text = "Datos de Cotización";
            // 
            // FilesGroupBox
            // 
            this.FilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesGroupBox.Controls.Add(this.splitContainerFiles);
            this.FilesGroupBox.Location = new System.Drawing.Point(6, 192);
            this.FilesGroupBox.Name = "FilesGroupBox";
            this.FilesGroupBox.Size = new System.Drawing.Size(1594, 633);
            this.FilesGroupBox.TabIndex = 8;
            this.FilesGroupBox.TabStop = false;
            this.FilesGroupBox.Text = "Archivos";
            // 
            // splitContainerFiles
            // 
            this.splitContainerFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerFiles.Location = new System.Drawing.Point(3, 16);
            this.splitContainerFiles.Name = "splitContainerFiles";
            // 
            // splitContainerFiles.Panel1
            // 
            this.splitContainerFiles.Panel1.Controls.Add(this.lstFiles);
            // 
            // splitContainerFiles.Panel2
            // 
            this.splitContainerFiles.Panel2.Controls.Add(this.btnFinalizeExternal);
            this.splitContainerFiles.Panel2.Controls.Add(this.btnSendAndFinalize);
            this.splitContainerFiles.Panel2.Controls.Add(this.btnSaveFile);
            this.splitContainerFiles.Panel2.Controls.Add(this.btnRemoveFile);
            this.splitContainerFiles.Panel2.Controls.Add(this.btnAddFile);
            this.splitContainerFiles.Panel2.Controls.Add(this.btnOpenFile);
            this.splitContainerFiles.Size = new System.Drawing.Size(1588, 614);
            this.splitContainerFiles.SplitterDistance = 1502;
            this.splitContainerFiles.TabIndex = 0;
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.Location = new System.Drawing.Point(0, 0);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(1502, 614);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.List;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            // 
            // btnFinalizeExternal
            // 
            this.btnFinalizeExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizeExternal.Location = new System.Drawing.Point(4, 148);
            this.btnFinalizeExternal.Name = "btnFinalizeExternal";
            this.btnFinalizeExternal.Size = new System.Drawing.Size(75, 46);
            this.btnFinalizeExternal.TabIndex = 5;
            this.btnFinalizeExternal.Text = "Finalizar E&xterna";
            this.btnFinalizeExternal.UseVisualStyleBackColor = true;
            this.btnFinalizeExternal.Click += new System.EventHandler(this.btnFinalizeExternal_Click);
            // 
            // btnSendAndFinalize
            // 
            this.btnSendAndFinalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendAndFinalize.Enabled = false;
            this.btnSendAndFinalize.Location = new System.Drawing.Point(4, 119);
            this.btnSendAndFinalize.Name = "btnSendAndFinalize";
            this.btnSendAndFinalize.Size = new System.Drawing.Size(75, 23);
            this.btnSendAndFinalize.TabIndex = 4;
            this.btnSendAndFinalize.Text = "En&viar";
            this.btnSendAndFinalize.UseVisualStyleBackColor = true;
            this.btnSendAndFinalize.Click += new System.EventHandler(this.btnSendAndFinalize_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Location = new System.Drawing.Point(4, 32);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 1;
            this.btnSaveFile.Text = "&Guardar";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFile.Enabled = false;
            this.btnRemoveFile.Location = new System.Drawing.Point(4, 90);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFile.TabIndex = 3;
            this.btnRemoveFile.Text = "&Eliminar";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFile.Location = new System.Drawing.Point(4, 61);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 2;
            this.btnAddFile.Text = "A&gregar";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.Location = new System.Drawing.Point(4, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "A&brir";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.uceCompany);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1594, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empresa que cotiza";
            // 
            // uceCompany
            // 
            this.uceCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uceCompany.LimitToList = true;
            this.uceCompany.Location = new System.Drawing.Point(112, 19);
            this.uceCompany.Name = "uceCompany";
            this.uceCompany.Size = new System.Drawing.Size(1476, 21);
            this.uceCompany.TabIndex = 0;
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(6, 19);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(100, 23);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Empresa:";
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerGroupBox.Controls.Add(this.btnAddCustomer);
            this.CustomerGroupBox.Controls.Add(this.uceCustomer);
            this.CustomerGroupBox.Controls.Add(this.lblEmail);
            this.CustomerGroupBox.Controls.Add(this.lblCustomer);
            this.CustomerGroupBox.Controls.Add(this.txtEmail);
            this.CustomerGroupBox.Controls.Add(this.lblContact);
            this.CustomerGroupBox.Controls.Add(this.uceContact);
            this.CustomerGroupBox.Location = new System.Drawing.Point(6, 81);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(1594, 105);
            this.CustomerGroupBox.TabIndex = 6;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Información de Cliente";
            //
            // btnAddCustomer
            // 
            this.btnAddCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCustomer.Enabled = false;
            this.btnAddCustomer.Location = new System.Drawing.Point(1483, 19);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(103, 23);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Agregar Empresa";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            //
            // uceCustomer
            //
            this.uceCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uceCustomer.Location = new System.Drawing.Point(112, 19);
            this.uceCustomer.Name = "uceCustomer";
            this.uceCustomer.Size = new System.Drawing.Size(1365, 21);
            this.uceCustomer.TabIndex = 0;
            this.uceCustomer.ValueChanged += new System.EventHandler(this.uceCustomer_ValueChanged);
            this.uceCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uceCustomer_KeyPress);
            //
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(6, 73);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "e-mail:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(6, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 23);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Empresa:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(112, 73);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(1476, 21);
            this.txtEmail.TabIndex = 3;
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(6, 46);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(100, 23);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Contacto:";
            // 
            // uceContact
            // 
            this.uceContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uceContact.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceContact.Location = new System.Drawing.Point(112, 46);
            this.uceContact.Name = "uceContact";
            this.uceContact.Size = new System.Drawing.Size(1476, 21);
            this.uceContact.TabIndex = 2;
            this.uceContact.ValueChanged += new System.EventHandler(this.uceContact_ValueChanged);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Enabled = false;
            this.btnBack.Location = new System.Drawing.Point(1366, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "&Anterior";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1528, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cerrar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(1447, 3);
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
            this.Size = new System.Drawing.Size(1606, 864);
            this.Load += new System.EventHandler(this.CustomerInfoView_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.ResumeLayout(false);
            this.QuotationGroupBox.ResumeLayout(false);
            this.FilesGroupBox.ResumeLayout(false);
            this.splitContainerFiles.Panel1.ResumeLayout(false);
            this.splitContainerFiles.Panel2.ResumeLayout(false);
            this.splitContainerFiles.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceCompany)).EndInit();
            this.CustomerGroupBox.ResumeLayout(false);
            this.CustomerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceContact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private Infragistics.Win.Misc.UltraButton btnNext;
        private System.Windows.Forms.GroupBox QuotationGroupBox;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceCustomer;
        private Infragistics.Win.Misc.UltraLabel lblContact;
        private Infragistics.Win.Misc.UltraLabel lblCustomer;
        private Infragistics.Win.Misc.UltraLabel lblEmail;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceContact;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnBack;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceCompany;
        private Infragistics.Win.Misc.UltraLabel lblCompany;
        private System.Windows.Forms.GroupBox FilesGroupBox;
        private System.Windows.Forms.SplitContainer splitContainerFiles;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnSendAndFinalize;
        private System.Windows.Forms.Button btnFinalizeExternal;
        private System.Windows.Forms.Button btnAddCustomer;
    }
}
