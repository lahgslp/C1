using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataModel;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using Cotizaciones.DataManagers;
using iwantedue.Windows.Forms;
using System.IO;
using System.Collections;
using BlackFox.Win32;
using System.Diagnostics;

namespace Cotizaciones.Views
{
    public partial class CustomerInfoView : BaseView
    {
        DataSet dsCustomers, dsCompanies;
        ArrayList quotationAttachments;
        Boolean exist;

        public CustomerInfoView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;

                uceCustomer.Text = "";        
                this.Cursor = Cursors.WaitCursor;
                MyQuotationsView myview = new MyQuotationsView();
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>0 if no data selected</returns>
        private int GetCustomerID()
        {
            int customerID = 0;
            if (this.uceCustomer.Value != null)
            {
                if (this.uceCustomer.Value.GetType().ToString() == "System.Int32")
                {
                    //Customer exists
                    customerID = Convert.ToInt32(this.uceCustomer.Value);
                }
                else
                {
                    //Customer NOT exists
                    customerID = CustomerInfoManager.CreateCustomer(Convert.ToString(this.uceCustomer.Value), this.User);
                }
            }
            return customerID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>0 if no data selected</returns>
        private int GetContactID(int customerID)
        {
            int contactID = 0;
            if (customerID > 0 && this.uceContact.Value != null)
            {
                if (this.uceContact.Value.GetType().ToString() == "System.Int32")
                {
                    //CustomerContact exists
                    contactID = Convert.ToInt32(this.uceContact.Value);
                }
                else
                {
                    //CustomerContact NOT exists
                    contactID = CustomerInfoManager.CreateCustomerContact(Convert.ToString(this.uceContact.Value), this.txtEmail.Text, customerID, this.User);
                }
            }
            return contactID;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                if (uceCustomer.Text != "")
                {
                    if (btnAddCustomer.Enabled == true)
                    {
                        DialogResult dr = MessageBox.Show("¿Desea guardar el nombre de la empresa?", "Guardar empresa", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            Next();
                        }
                        else
                        {
                            uceCustomer.Focus();
                        }
                    }
                    else
                        Next();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado una empresa.","",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    uceCustomer.Focus();
                }
            }
        }

        private void Next()
        {
            this.Cursor = Cursors.WaitCursor;
            
            if(this.uceCustomer.Enabled == true)
                this.UpdateQuotation();           

            ProductSelectionView myview = new ProductSelectionView();
            myview.QuotationID = this.QuotationID;
            myview.User = this.User;
            myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
            MainController.Instance.Next(myview);
            this.Cursor = Cursors.Default;
        }

        private void UpdateQuotation()
        {
            if (!IsReadOnlyQuotation)
            {
                int companyID, customerID, contactID;
                customerID = GetCustomerID();
                contactID = GetContactID(customerID);
                companyID = Convert.ToInt32(this.uceCompany.Value);
                CustomerInfoManager.SaveCustomerInfo(this.QuotationID, companyID, customerID, contactID, this.txtEmail.Text, this.User);
            }
        }
        private void CustomerInfoView_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadCompanyInfo();
            LoadCustomerInfo();
            LoadQuotationInfo();
            LoadQuotationAttachments();
            this.uceCustomer.Focus();
            EnableDisableControls();
            this.Cursor = Cursors.Default;
        }

        private void EnableDisableControls()
        {
            if (IsReadOnlyQuotation == true)
            {
                this.uceCompany.ReadOnly = true;
                this.uceCustomer.ReadOnly = true;
                this.uceContact.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                //for the file features
                this.btnAddFile.Enabled = false;
                this.btnRemoveFile.Enabled = false;
                this.btnSendAndFinalize.Enabled = false;
                this.btnSaveFile.Enabled = false;
                this.lstFiles.AllowDrop = false;
            }
        }

        private void LoadQuotationInfo()
        {
            Quotation q = CustomerInfoManager.GetQuotationInfo(this.QuotationID);
            string nameCustomer = "";
            string nameContact = "";
            string email = "";
            if (q != null)
            {
                this.uceCompany.Value = q.CompanyID;
                if (q.CustomerID != null)
                {
                    foreach (DataRow row in dsCustomers.Tables["Table"].Select("CustomerID = " + q.CustomerID))
                    {
                        if (row["Active"].ToString() == "I")
                        {
                            this.uceCustomer.Enabled = false;
                            this.uceContact.Enabled = false;
                            this.txtEmail.Enabled = false;
                            nameCustomer = row["Description"].ToString();
                            if (q.CustomerContactID != null)
                            {
                                foreach (DataRow rowContact in dsCustomers.Tables["Table1"].Select("CustomerID = " + q.CustomerID + " AND CustomerContactID = " + q.CustomerContactID))
                                {
                                    nameContact = rowContact["ContactName"].ToString();
                                    email = rowContact["Email"].ToString();
                                }
                            }
                        }
                    }
                    if (this.uceCustomer.Enabled == true)
                    {
                        this.uceCustomer.Value = q.CustomerID;
                        if (q.CustomerContactID != null)
                        {
                            foreach (DataRow rowContact in dsCustomers.Tables["Table1"].Select("CustomerID = " + q.CustomerID + " AND CustomerContactID = " + q.CustomerContactID))
                            {
                                if (rowContact["Active"].ToString() == "A")
                                {
                                    this.uceContact.Value = q.CustomerContactID;
                                }
                                else
                                {
                                    q.CustomerContactID = null;
                                    this.uceContact.Value = q.CustomerContactID;
                                }
                            }
                        }
                        else
                        {
                            this.uceContact.Value = q.CustomerContactID;
                        }
                        this.txtEmail.Text = q.EmailTo;
                    }
                    else
                    {
                        this.uceCustomer.Text = nameCustomer;
                        this.uceContact.Text = nameContact;
                        this.txtEmail.Text = email;
                    }
                }
            }
        }

        private void LoadCompanyInfo()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetCompanyInfo();

            dsCompanies = sp.ExecuteDataSet();

            this.uceCompany.DataSource = dsCompanies;
            this.uceCompany.DataMember = "Table";
            this.uceCompany.DisplayMember = "CompanyName";
            this.uceCompany.ValueMember = "CompanyID";
        }

        private void LoadCustomerInfo()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetCustomerInfo();

            dsCustomers = sp.ExecuteDataSet();
            DataSet ds = new DataSet();
            
            DataTable dt = dsCustomers.Tables["Table"].Clone();
            foreach (DataRow row in dsCustomers.Tables["Table"].Select("Active = 'A'"))
            {
                dt.ImportRow(row);                
            }
            ds.Tables.Add(dt);

            this.uceCustomer.DataSource = ds;
            this.uceCustomer.DataMember = "Table";
            this.uceCustomer.DisplayMember = "Description";
            this.uceCustomer.ValueMember = "CustomerID";
        }

        private DataTable FilterContacts(int CustomerID)
        {
            DataTable dt = dsCustomers.Tables["Table1"].Clone();
            foreach (DataRow row in dsCustomers.Tables["Table1"].Select("CustomerID = " + CustomerID.ToString() + " AND Active = 'A'"))
            {
                dt.ImportRow(row);
            }
            return dt;
        }

        private void GetContactEmail(int CustomerContactID)
        {
            DataRow[] rows = dsCustomers.Tables["Table1"].Select("CustomerContactID = " + CustomerContactID.ToString());
            foreach (DataRow row in rows)
            {
                if (row["Email"] != null)
                {
                    this.txtEmail.Text = row["Email"].ToString();
                }
            }
        }

        private DataTable FilterCustomers(string Cadena)
        {
            DataTable dt = dsCustomers.Tables["Table"].Clone();
            foreach (DataRow row in dsCustomers.Tables["Table"].Select("Description LIKE '%" + Cadena.ToString() + "%' AND Active = 'A'"))
            {
                dt.ImportRow(row);
            }
            return dt;
        }

        private void uceCustomer_ValueChanged(object sender, EventArgs e)
        {      
            if(this.uceCustomer.Enabled == true)
            {
                exist = true;
                try
                {
                    if (uceCustomer.Value.GetType().ToString() == "System.Int32" && uceCustomer.Text != "")
                    {
                        GetFilteredContact();
                        btnAddCustomer.Enabled = false;
                        exist = false;
                    }
                }
                catch
                { }
                if (exist == true)
                {
                    GetFilteredCustomersDataset(uceCustomer.Text);
                    if (uceCustomer.Text == "")
                    {
                        btnAddCustomer.Enabled = false;
                    }
                    else
                    {
                        btnAddCustomer.Enabled = true;
                    }
                    GetFilteredContact();
                }
            }
        }

        private void GetFilteredCustomersDataset(string cadena)
        {            
            DataSet ds = new DataSet();
            ds.Tables.Add(FilterCustomers(cadena));
            this.uceCustomer.DataSource = ds;
            //this.uceCustomer.DataMember = "Table";
            this.uceCustomer.DisplayMember = "Description";
            this.uceCustomer.ValueMember = "CustomerID";
         }

        private void GetFilteredContact()
        {
            //Resetting contacts
            this.uceContact.Value = null;
            this.uceContact.Text = "";
            this.txtEmail.Text = "";

            if (uceCustomer.Value != null)
            {
                if (uceCustomer.Value.GetType().ToString() == "System.Int32")
                {
                    //If its an existing customer
                    //lnklblNewCustomer.Visible = false;
                    //this.uceContact.Enabled = true;
                    this.GetFilteredContactDataset((int)uceCustomer.Value);
                }
                else
                {
                    //If its an unexisting customer
                    //lnklblNewCustomer.Visible = true;
                    //this.uceContact.Enabled = false;
                    this.GetFilteredContactDataset(0);
                }
            }
        }

        private void GetFilteredContactDataset(int CustomerID)
        {
            this.uceContact.DataSource = FilterContacts(CustomerID);
            this.uceContact.DisplayMember = "ContactName";
            this.uceContact.ValueMember = "CustomerContactID";
        }

        private void uceContact_ValueChanged(object sender, EventArgs e)
        {
            if (this.uceCustomer.Enabled == true)
            {
                if (this.uceContact.Value != null)
                {
                    if (uceContact.Value.GetType().ToString() == "System.Int32")
                    {
                        //Its an existing contact
                        GetContactEmail((int)uceContact.Value);
                    }
                    else
                    {
                        this.txtEmail.Text = "";
                        //Its an unexisting contact
                    }
                }
            }
        }

        private bool IsValidData()
        {
            if(this.txtEmail.Text != String.Empty)
            {
                //if (Utilities.isEmail(this.txtEmail.Text) == false)
                List<string> incorrectEmails = Utilities.ValidateEmailList(this.txtEmail.Text);
                if (incorrectEmails.Count > 0)
                {
                    int counter = 0;
                    string listEmails = "";
                    foreach (var email in incorrectEmails)
                    {
                        counter ++;
                        listEmails += email + (counter < incorrectEmails.Count ? ", " : "");
                    }
                    MessageBox.Show("Formato de siguientes correos electrónicos no es válido: " + listEmails);
                    return false;
                }
                this.txtEmail.Text = this.txtEmail.Text.Replace(" ","").Replace(",",";");
            }
            return true;
        }

        private string[] CreateOutlookElements(DragEventArgs e)
        {
            //wrap standard IDataObject in OutlookDataObject
            OutlookDataObject dataObject = new OutlookDataObject(e.Data);

            //get the names and data streams of the files dropped
            string[] filenames = (string[])dataObject.GetData("FileGroupDescriptorW");
            MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");

            //this.label1.Text += "Files:\n";
            string[] FullFileNames = new string[filenames.Length];

            for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
            {
                //use the fileindex to get the name and data stream
                string filename = filenames[fileIndex];
                MemoryStream filestream = filestreams[fileIndex];
                //this.label1.Text += "    " + filename + "\n";

                //save the file stream using its name to the application path
                string FullFileName = Path.GetTempPath() + filename;
                FileStream outputStream = File.Create(FullFileName);
                filestream.WriteTo(outputStream);
                outputStream.Close();
                FullFileNames[fileIndex] = FullFileName;
            }

            return FullFileNames;
        }

        private void LoadQuotationAttachments()
        {
            quotationAttachments = QuotationAttachmentManager.GetQuotationAttachments(this.QuotationID);
            LoadFilesListView();
        }

        private void LoadFilesListView()
        {
            this.lstFiles.Items.Clear();
            this.lstFiles.SmallImageList = null;
            this.lstFiles.LargeImageList = null;

            int index = 0;
            ImageList imgl = new ImageList();
            foreach (QuotationAttachment qa in quotationAttachments)
            {
                //Icon ico = Icon.ExtractAssociatedIcon(Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + qa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(qa.ExternalFileName));
                Icon ico;
                try
                {
                    ico = IconExtractor.IconFromExtension(Utilities.GetFileExtension(qa.ExternalFileName), IconExtractor.SystemIconSize.Small);
                }
                catch
                {
                    ico = IconExtractor.IconFromExtension(".txt", IconExtractor.SystemIconSize.Small);
                }
                imgl.Images.Add(ico);

                this.lstFiles.SmallImageList = imgl;
                this.lstFiles.LargeImageList = imgl;
                this.lstFiles.Items.Add(new ListViewItem(qa.ExternalFileName, index++));
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstFiles.SelectedItems.Count == 0)
            {
                this.btnOpenFile.Enabled = false;
                this.btnRemoveFile.Enabled = false;
                this.btnSendAndFinalize.Enabled = false;
                this.btnSaveFile.Enabled = false;
            }
            else
            {
                this.btnOpenFile.Enabled = true;
                if (!IsReadOnlyQuotation)
                {
                    this.btnRemoveFile.Enabled = true;
                    this.btnSendAndFinalize.Enabled = true;
                }
                this.btnSaveFile.Enabled = true;
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            if (Directory.Exists(Utilities.GetConfigurationKeyValue("NetworkFolder")))
            {
                //code to open the selected file (s)?
                foreach (ListViewItem lvi in this.lstFiles.SelectedItems)
                {
                    QuotationAttachment qa = QuotationAttachmentManager.GetQuotationAttachmentByName(this.quotationAttachments, lvi.Text);
                    if (qa != null)
                    {
                        Process.Start(Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + qa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(lvi.Text));
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (!IsReadOnlyQuotation)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CopyCreateFile(dlg.FileName);
                }
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (!IsReadOnlyQuotation)
            {
                if (Directory.Exists(Utilities.GetConfigurationKeyValue("NetworkFolder")))
                {
                    foreach (ListViewItem lvi in this.lstFiles.SelectedItems)
                    {
                        if (MessageBox.Show("Esto eliminará el archivo de la cotización. ¿Desea continuar?", "Eliminar archivos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            QuotationAttachment qa = QuotationAttachmentManager.GetQuotationAttachmentByName(this.quotationAttachments, lvi.Text);
                            if (qa != null)
                            {
                                QuotationAttachmentManager.RemoveQuotationAttachment(qa.QuotationID, qa.QuotationAttachmentID);
                                File.Delete(Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + qa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(lvi.Text));
                                quotationAttachments.RemoveAt(QuotationAttachmentManager.GetQuotationAttachmentIndex(this.quotationAttachments, qa.ExternalFileName));
                                this.LoadFilesListView();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
                }
            }
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                int i;
                for (i = 0; i < s.Length; i++)
                {
                    //MessageBox.Show(s[i]);
                    CopyCreateFile(s[i]);
                }
            }
            else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                string[] s = CreateOutlookElements(e);
                int i;
                for (i = 0; i < s.Length; i++)
                {
                    //MessageBox.Show(s[i]);
                    CopyCreateFile(s[i]);
                }
            }
        }

        private void CopyCreateFile(string fileName)
        {
            if (Directory.Exists(Utilities.GetConfigurationKeyValue("NetworkFolder")))
            {
                if (File.Exists(fileName))
                {
                    QuotationAttachment eqa = QuotationAttachmentManager.GetQuotationAttachmentByName(this.quotationAttachments, fileName);
                    if (eqa == null)
                    {
                        QuotationAttachment qa = QuotationAttachmentManager.AddQuotationAttachment(this.QuotationID, Utilities.GetFileName(fileName), this.User);
                        quotationAttachments.Add(qa);
                        try
                        {
                            File.Copy(fileName, Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + qa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(fileName));
                        }
                        catch (Exception exc)
                        {
                            QuotationAttachmentManager.RemoveQuotationAttachment(qa.QuotationID, qa.QuotationAttachmentID);
                        }
                        LoadFilesListView();
                    }
                    else
                    {
                        if (MessageBox.Show("El archivo ya existe en la cotización. ¿Desea reemplazar?", "Reemplazar archivos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            File.Copy(fileName, Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + eqa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(fileName), true);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Utilities.GetConfigurationKeyValue("NetworkFolder")))
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.RestoreDirectory = true;
                dlg.Title = "¿Donde desea guardar el archivo?";
                foreach (ListViewItem lvi in this.lstFiles.SelectedItems)
                {
                    dlg.FileName = lvi.Text;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        QuotationAttachment eqa = QuotationAttachmentManager.GetQuotationAttachmentByName(this.quotationAttachments, lvi.Text);
                        if (eqa != null)
                        {
                            File.Copy(Utilities.GetConfigurationKeyValue("NetworkFolder") + "\\qa" + eqa.QuotationAttachmentID.ToString("000000") + "." + Utilities.GetFileExtension(lvi.Text), dlg.FileName, true);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
            }
        }

        private void SendAndFinalize()
        {
            if (Directory.Exists(Utilities.GetConfigurationKeyValue("NetworkFolder")))
            {
                foreach (ListViewItem lvi in this.lstFiles.SelectedItems)
                {
                    if (MessageBox.Show("Esto enviará el archivo al cliente y marcará la cotización como Finalizada Externa. ¿Desea continuar?", "Enviar y finalizar cotización", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        UpdateQuotation();
                        DataSet QuotationData = QuotationCreationManager.GetQuotationData(this.QuotationID);
                        Utilities.CreateEmail(this.QuotationID, QuotationData, false, lvi.Text);
                        if (MessageBox.Show("¿La cotización externa ha sido enviada?", "Confirmar envio de cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            QuotationFinishManager.FinalizeQuotation(QuotationID, User, Cotizaciones.Enums.QuotationStatusType.FinishedExternal);
                            this.btnCancel_Click(null, null);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado la carpeta de los archivos de cotizaciones", "Carpeta no encontrada");
            }
        }

        private void btnSendAndFinalize_Click(object sender, EventArgs e)
        {
            if (!IsReadOnlyQuotation)
            {
                if (uceCustomer.Text != "")
                {
                    if (btnAddCustomer.Enabled == true)
                    {
                        if (MessageBox.Show("Desea guardar el nombre de la empresa. Para continuar...", "Guardar empresa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            SendAndFinalize();
                        }
                        else
                            uceCustomer.Focus();
                    }
                    else
                        SendAndFinalize();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado una empresa.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    uceCustomer.Focus();
                }
            }
        }

        private void btnFinalizeExternal_Click(object sender, EventArgs e)
        {
            if (uceCustomer.Text != "")
            {
                if (btnAddCustomer.Enabled == true)
                {
                    if (MessageBox.Show("Desea guardar el nombre de la empresa. Para continuar...", "Guardar empresa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        FinalizeExternal();
                    }
                    else
                        uceCustomer.Focus();
                }
                else
                    FinalizeExternal();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una empresa.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                uceCustomer.Focus();
            }
        }

        private void FinalizeExternal()
        {
            if (MessageBox.Show("Esto marcará la cotización como Finalizada Externa. ¿Desea continuar?", "Finalizar cotización", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                UpdateQuotation();
                QuotationFinishManager.FinalizeQuotation(QuotationID, User, Cotizaciones.Enums.QuotationStatusType.FinishedExternal);
                this.btnCancel_Click(null, null);
            }
        }

        private void uceCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 38 || e.KeyChar == 40)
            {
                exist = false;                
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea guardar el nombre de la empresa?", "Guardar empresa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                UpdateQuotation();
                LoadCustomerInfo();
                LoadQuotationInfo();
                uceContact.Focus();
            }
            else
                uceCustomer.Focus();
        }
    }
}
