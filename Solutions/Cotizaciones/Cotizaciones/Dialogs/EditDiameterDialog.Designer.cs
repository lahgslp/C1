namespace Cotizaciones.Dialogs
{
    partial class EditDiameterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDiameterDialog));
            this.gbEditDiameter = new System.Windows.Forms.GroupBox();
            this.ugEditDiameter = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnNew = new Infragistics.Win.Misc.UltraButton();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.contextMenuEditDiameter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddEspesor = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDiameter = new System.Windows.Forms.ToolStripMenuItem();
            this.gbEditDiameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugEditDiameter)).BeginInit();
            this.contextMenuEditDiameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEditDiameter
            // 
            this.gbEditDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditDiameter.Controls.Add(this.ugEditDiameter);
            this.gbEditDiameter.Location = new System.Drawing.Point(12, 12);
            this.gbEditDiameter.Name = "gbEditDiameter";
            this.gbEditDiameter.Size = new System.Drawing.Size(587, 296);
            this.gbEditDiameter.TabIndex = 0;
            this.gbEditDiameter.TabStop = false;
            this.gbEditDiameter.Text = "Diámetros y Espesores";
            // 
            // ugEditDiameter
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugEditDiameter.DisplayLayout.Appearance = appearance1;
            this.ugEditDiameter.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ugEditDiameter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugEditDiameter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugEditDiameter.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugEditDiameter.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ugEditDiameter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugEditDiameter.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ugEditDiameter.DisplayLayout.MaxColScrollRegions = 1;
            this.ugEditDiameter.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugEditDiameter.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugEditDiameter.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.ugEditDiameter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugEditDiameter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ugEditDiameter.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugEditDiameter.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugEditDiameter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugEditDiameter.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ugEditDiameter.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ugEditDiameter.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ugEditDiameter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugEditDiameter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.ugEditDiameter.DisplayLayout.Override.RowAppearance = appearance11;
            this.ugEditDiameter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugEditDiameter.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.ugEditDiameter.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            this.ugEditDiameter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugEditDiameter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugEditDiameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugEditDiameter.Location = new System.Drawing.Point(3, 16);
            this.ugEditDiameter.Name = "ugEditDiameter";
            this.ugEditDiameter.Size = new System.Drawing.Size(581, 277);
            this.ugEditDiameter.TabIndex = 0;
            this.ugEditDiameter.Text = "ultraGrid1";
            this.ugEditDiameter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ugEditDiameter_MouseDown);
            this.ugEditDiameter.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugEditDiameter_AfterCellUpdate);
            this.ugEditDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ugEditDiameter_KeyPress);
            this.ugEditDiameter.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugEditDiameter_CellChange);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(333, 314);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Nuevo Diámetro";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(440, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(524, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // contextMenuEditDiameter
            // 
            this.contextMenuEditDiameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEspesor,
            this.AddDiameter});
            this.contextMenuEditDiameter.Name = "contextMenuEditDiameter";
            this.contextMenuEditDiameter.Size = new System.Drawing.Size(205, 48);
            // 
            // AddEspesor
            // 
            this.AddEspesor.Name = "AddEspesor";
            this.AddEspesor.Size = new System.Drawing.Size(204, 22);
            this.AddEspesor.Text = "Insertar nuevo Espesor";
            this.AddEspesor.Click += new System.EventHandler(this.AddEspesor_Click);
            // 
            // AddDiameter
            // 
            this.AddDiameter.Name = "AddDiameter";
            this.AddDiameter.Size = new System.Drawing.Size(204, 22);
            this.AddDiameter.Text = "Ingresar nuevo Diámetro";
            this.AddDiameter.Click += new System.EventHandler(this.AddDiameter_Click);
            // 
            // EditDiameterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 349);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.gbEditDiameter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditDiameterDialog";
            this.Text = "Administración de Diámetros y Espesores";
            this.Load += new System.EventHandler(this.EditDiameterDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditDiameterDialog_FormClosing);
            this.gbEditDiameter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugEditDiameter)).EndInit();
            this.contextMenuEditDiameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEditDiameter;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugEditDiameter;
        private Infragistics.Win.Misc.UltraButton btnNew;
        private Infragistics.Win.Misc.UltraButton btnSave;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuEditDiameter;
        private System.Windows.Forms.ToolStripMenuItem AddEspesor;
        private System.Windows.Forms.ToolStripMenuItem AddDiameter;
    }
}