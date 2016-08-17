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
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ShellWorkSpace = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            ((System.ComponentModel.ISupportInitialize)(this.ShellWorkSpace)).BeginInit();
            this.ShellWorkSpace.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(784, 539);
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
            this.ShellWorkSpace.Location = new System.Drawing.Point(0, 0);
            this.ShellWorkSpace.Name = "ShellWorkSpace";
            this.ShellWorkSpace.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ShellWorkSpace.Size = new System.Drawing.Size(784, 539);
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
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(784, 539);
            // 
            // ShellMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ShellWorkSpace);
            this.Controls.Add(this.StatusBar);
            this.Name = "ShellMainForm";
            this.Text = "Fersum - Cotizaciones";
            this.Load += new System.EventHandler(this.ShellMainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShellMainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ShellWorkSpace)).EndInit();
            this.ShellWorkSpace.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ShellWorkSpace;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
    }
}

