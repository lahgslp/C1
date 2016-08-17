namespace Cotizaciones.Dialogs
{
    partial class EditCustomersDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCustomersDialog));
            this.gbEditCustomers = new System.Windows.Forms.GroupBox();
            this.ugEditCustomers = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.uteFilterCustomers = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbFiltrado = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuEditCustomer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.NewContact = new System.Windows.Forms.ToolStripMenuItem();
            this.ubSave = new Infragistics.Win.Misc.UltraButton();
            this.ubClose = new Infragistics.Win.Misc.UltraButton();
            this.gbEditCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugEditCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteFilterCustomers)).BeginInit();
            this.gbFiltrado.SuspendLayout();
            this.contextMenuEditCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEditCustomers
            // 
            this.gbEditCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditCustomers.Controls.Add(this.ugEditCustomers);
            this.gbEditCustomers.Location = new System.Drawing.Point(12, 68);
            this.gbEditCustomers.Name = "gbEditCustomers";
            this.gbEditCustomers.Size = new System.Drawing.Size(612, 265);
            this.gbEditCustomers.TabIndex = 0;
            this.gbEditCustomers.TabStop = false;
            this.gbEditCustomers.Text = "Empresas y Contactos";
            // 
            // ugEditCustomers
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugEditCustomers.DisplayLayout.Appearance = appearance1;
            this.ugEditCustomers.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ugEditCustomers.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugEditCustomers.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugEditCustomers.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugEditCustomers.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ugEditCustomers.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugEditCustomers.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ugEditCustomers.DisplayLayout.MaxColScrollRegions = 1;
            this.ugEditCustomers.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugEditCustomers.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugEditCustomers.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.ugEditCustomers.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugEditCustomers.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ugEditCustomers.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugEditCustomers.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugEditCustomers.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugEditCustomers.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ugEditCustomers.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ugEditCustomers.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ugEditCustomers.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugEditCustomers.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.ugEditCustomers.DisplayLayout.Override.RowAppearance = appearance11;
            this.ugEditCustomers.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugEditCustomers.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.ugEditCustomers.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            this.ugEditCustomers.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugEditCustomers.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugEditCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugEditCustomers.Location = new System.Drawing.Point(3, 16);
            this.ugEditCustomers.Name = "ugEditCustomers";
            this.ugEditCustomers.Size = new System.Drawing.Size(606, 246);
            this.ugEditCustomers.TabIndex = 0;
            this.ugEditCustomers.Text = "ultraGrid1";
            this.ugEditCustomers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ugEditCustomers_MouseDown);
            this.ugEditCustomers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ugEditCustomers_KeyPress);
            this.ugEditCustomers.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugEditCustomers_CellChange);
            // 
            // uteFilterCustomers
            // 
            this.uteFilterCustomers.Location = new System.Drawing.Point(83, 19);
            this.uteFilterCustomers.MaxLength = 50;
            this.uteFilterCustomers.Name = "uteFilterCustomers";
            this.uteFilterCustomers.Size = new System.Drawing.Size(225, 21);
            this.uteFilterCustomers.TabIndex = 1;
            this.uteFilterCustomers.ValueChanged += new System.EventHandler(this.uteFilterCustomers_ValueChanged);
            // 
            // gbFiltrado
            // 
            this.gbFiltrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltrado.Controls.Add(this.label1);
            this.gbFiltrado.Controls.Add(this.uteFilterCustomers);
            this.gbFiltrado.Location = new System.Drawing.Point(12, 12);
            this.gbFiltrado.Name = "gbFiltrado";
            this.gbFiltrado.Size = new System.Drawing.Size(612, 50);
            this.gbFiltrado.TabIndex = 0;
            this.gbFiltrado.TabStop = false;
            this.gbFiltrado.Text = "Filtro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa:";
            // 
            // contextMenuEditCustomer
            // 
            this.contextMenuEditCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCustomer,
            this.NewContact});
            this.contextMenuEditCustomer.Name = "contextMenuEditDiameter";
            this.contextMenuEditCustomer.Size = new System.Drawing.Size(207, 48);
            // 
            // NewCustomer
            // 
            this.NewCustomer.Name = "NewCustomer";
            this.NewCustomer.Size = new System.Drawing.Size(206, 22);
            this.NewCustomer.Text = "Agregar Nueva Empresa";
            this.NewCustomer.Click += new System.EventHandler(this.NewCustomer_Click);
            // 
            // NewContact
            // 
            this.NewContact.Name = "NewContact";
            this.NewContact.Size = new System.Drawing.Size(206, 22);
            this.NewContact.Text = "Agregar Nuevo Contacto";
            this.NewContact.Click += new System.EventHandler(this.NewContact_Click);
            // 
            // ubSave
            // 
            this.ubSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubSave.Enabled = false;
            this.ubSave.Location = new System.Drawing.Point(399, 346);
            this.ubSave.Name = "ubSave";
            this.ubSave.Size = new System.Drawing.Size(108, 25);
            this.ubSave.TabIndex = 2;
            this.ubSave.Text = "Guardar";
            this.ubSave.Click += new System.EventHandler(this.ubSave_Click);
            // 
            // ubClose
            // 
            this.ubClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubClose.Location = new System.Drawing.Point(513, 346);
            this.ubClose.Name = "ubClose";
            this.ubClose.Size = new System.Drawing.Size(108, 25);
            this.ubClose.TabIndex = 3;
            this.ubClose.Text = "Cerrar";
            this.ubClose.Click += new System.EventHandler(this.ubClose_Click);
            // 
            // EditCustomersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 383);
            this.Controls.Add(this.ubClose);
            this.Controls.Add(this.gbFiltrado);
            this.Controls.Add(this.ubSave);
            this.Controls.Add(this.gbEditCustomers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditCustomersDialog";
            this.Text = "Administración de Empresas y Contactos";
            this.Load += new System.EventHandler(this.EditCustomersDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditCustomersDialog_FormClosing);
            this.gbEditCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugEditCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteFilterCustomers)).EndInit();
            this.gbFiltrado.ResumeLayout(false);
            this.gbFiltrado.PerformLayout();
            this.contextMenuEditCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEditCustomers;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugEditCustomers;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteFilterCustomers;
        private System.Windows.Forms.GroupBox gbFiltrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuEditCustomer;
        private System.Windows.Forms.ToolStripMenuItem NewCustomer;
        private Infragistics.Win.Misc.UltraButton ubSave;
        private Infragistics.Win.Misc.UltraButton ubClose;
        private System.Windows.Forms.ToolStripMenuItem NewContact;
    }
}