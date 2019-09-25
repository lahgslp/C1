namespace Cotizaciones
{
    partial class ShellMainForm
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellMainForm));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ShellWorkSpace = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeCotizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenciasDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.administracionDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeDiametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeEmpresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminitracionDeCatalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ShellWorkSpace)).BeginInit();
            this.ShellWorkSpace.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(784, 515);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 539);
            this.StatusBar.Name = "StatusBar";
            ultraStatusPanel1.Key = "QuotationID";
            ultraStatusPanel1.Width = 120;
            ultraStatusPanel2.Key = "Description";
            ultraStatusPanel2.Width = 350;
            ultraStatusPanel3.Key = "StatusMessage";
            ultraStatusPanel3.Width = 150;
            ultraStatusPanel4.Key = "CurrentUser";
            ultraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4});
            this.StatusBar.Size = new System.Drawing.Size(784, 23);
            this.StatusBar.TabIndex = 0;
            // 
            // ShellWorkSpace
            // 
            this.ShellWorkSpace.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ShellWorkSpace.Controls.Add(this.ultraTabPageControl1);
            this.ShellWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShellWorkSpace.Location = new System.Drawing.Point(0, 24);
            this.ShellWorkSpace.Name = "ShellWorkSpace";
            this.ShellWorkSpace.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ShellWorkSpace.Size = new System.Drawing.Size(784, 515);
            this.ShellWorkSpace.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ShellWorkSpace.TabIndex = 1;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.ShellWorkSpace.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ShellWorkSpace.TabStop = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(784, 515);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeCotizacionesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "&Reportes";
            // 
            // reporteDeCotizacionesToolStripMenuItem
            // 
            this.reporteDeCotizacionesToolStripMenuItem.Name = "reporteDeCotizacionesToolStripMenuItem";
            this.reporteDeCotizacionesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.reporteDeCotizacionesToolStripMenuItem.Text = "Reporte de &Cotizaciones";
            this.reporteDeCotizacionesToolStripMenuItem.Click += new System.EventHandler(this.reporteDeCotizacionesToolStripMenuItem_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferenciasDeUsuarioToolStripMenuItem,
            this.toolStripMenuItem1,
            this.administracionDeUsuariosToolStripMenuItem,
            this.adminitracionDeCatalogosToolStripMenuItem,
            this.administracionDeDiametrosToolStripMenuItem,
            this.administracionDeEmpresasToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "&Opciones";
            // 
            // preferenciasDeUsuarioToolStripMenuItem
            // 
            this.preferenciasDeUsuarioToolStripMenuItem.Name = "preferenciasDeUsuarioToolStripMenuItem";
            this.preferenciasDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.preferenciasDeUsuarioToolStripMenuItem.Text = "&Preferencias";
            this.preferenciasDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.preferenciasDeUsuarioToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // administracionDeUsuariosToolStripMenuItem
            // 
            this.administracionDeUsuariosToolStripMenuItem.Name = "administracionDeUsuariosToolStripMenuItem";
            this.administracionDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.administracionDeUsuariosToolStripMenuItem.Text = "Administración de &Usuarios";
            this.administracionDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administracionDeUsuariosToolStripMenuItem_Click);
            // 
            // administracionDeDiametrosToolStripMenuItem
            // 
            this.administracionDeDiametrosToolStripMenuItem.Name = "administracionDeDiametrosToolStripMenuItem";
            this.administracionDeDiametrosToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.administracionDeDiametrosToolStripMenuItem.Text = "Administración de Diámetros";
            this.administracionDeDiametrosToolStripMenuItem.Click += new System.EventHandler(this.administracionDeDiametrosToolStripMenuItem_Click);
            // 
            // administracionDeEmpresasToolStripMenuItem
            // 
            this.administracionDeEmpresasToolStripMenuItem.Name = "administracionDeEmpresasToolStripMenuItem";
            this.administracionDeEmpresasToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.administracionDeEmpresasToolStripMenuItem.Text = "Administración de Empresas";
            this.administracionDeEmpresasToolStripMenuItem.Click += new System.EventHandler(this.administracionDeEmpresasToolStripMenuItem_Click);
            // 
            // adminitracionDeCatalogosToolStripMenuItem
            // 
            this.adminitracionDeCatalogosToolStripMenuItem.Name = "adminitracionDeCatalogosToolStripMenuItem";
            this.adminitracionDeCatalogosToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.adminitracionDeCatalogosToolStripMenuItem.Text = "Administración de Catalogos";
            this.adminitracionDeCatalogosToolStripMenuItem.Click += new System.EventHandler(this.adminitracionDeCatalogosToolStripMenuItem_Click);
            // 
            // ShellMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ShellWorkSpace);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShellMainForm";
            this.Text = "Sistema de Cotizaciones";
            this.Load += new System.EventHandler(this.ShellMainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShellMainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ShellWorkSpace)).EndInit();
            this.ShellWorkSpace.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ShellWorkSpace;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeCotizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferenciasDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administracionDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeDiametrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeEmpresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminitracionDeCatalogosToolStripMenuItem;
    }
}

