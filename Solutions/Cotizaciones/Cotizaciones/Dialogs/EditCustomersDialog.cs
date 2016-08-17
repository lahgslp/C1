using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataModel;
using Cotizaciones.DataManagers;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;

namespace Cotizaciones.Dialogs
{
    public partial class EditCustomersDialog : Form
    {
        Boolean GlobalChange = false;
        DataSet dsOriginal;
        string user;
        int NewCustomerID = -1, NewContactID = -1;
        UltraGridRow auxRow = null;
        UltraGridCell selectedCell = null;
        public EditCustomersDialog(string User)
        {
            InitializeComponent();
            this.user = User;
        }

        private void EditCustomersDialog_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeCustomers();
            this.Cursor = Cursors.Default;           
        }

        private void InitializeCustomers()
        {
            DataSet dsGrid = new DataSet();
            EditCustomersManager edm = new EditCustomersManager();
            dsOriginal = edm.getDiameter();
            dsGrid = dsOriginal;
            ugEditCustomers.DataSource = dsGrid;
            SetGridProperties();
            InicializeLayout();
        }

        private void SetGridProperties()
        {
            //Section band
            foreach (UltraGridColumn col in this.ugEditCustomers.DisplayLayout.Bands[0].Columns)
            {
                switch (col.Key)
                {
                    case "CustomerID":
                        col.Hidden = true;
                        break;
                    case "ShortName":
                        col.Hidden = true;
                        break;
                    case "Description":
                        col.Header.Caption = "Nombre de la Empresa";
                        break;
                    case "Creator":
                        col.Header.Caption = "Creado por";
                        col.CellActivation = Activation.NoEdit;        
                        break;
                    case "Created":
                        col.Header.Caption = "Creado en";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Modifier":
                        col.Header.Caption = "Modificado por";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Modified":
                        col.Header.Caption = "Modificado en";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Active":
                        col.Hidden = true;
                        break;
                    case "Actualizado":
                        col.Header.Caption = "Actualizado";
                        col.Hidden = true;
                        break;
                    case "Index":                        
                        col.Hidden = true;
                        break;
                    case "Table":
                        col.Hidden = true;
                        break;
                    case "Activo":
                        col.Header.Caption = "Activo";                        
                        break;
                }
            }
            foreach (UltraGridColumn col in this.ugEditCustomers.DisplayLayout.Bands[1].Columns)
            {
                switch (col.Key)
                {
                    case "CustomerContactID":
                        col.Hidden = true;
                        break;
                    case "CustomerID":
                        col.Hidden = true;
                        break;
                    case "ContactName":
                        col.Header.Caption = "Nombre Contacto";
                        break;
                    case "Email":
                        col.Header.Caption = "E-Mail";
                        break;
                    case "Creator":
                        col.Header.Caption = "Creado por";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Created":
                        col.Header.Caption = "Creado en";
                        col.CellActivation = Activation.NoEdit;;
                        break;
                    case "Modifier":
                        col.Header.Caption = "Modificado por";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Modified":
                        col.Header.Caption = "Modificado en";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Active":
                        col.Header.Caption = "Activo";
                        col.Hidden = true;
                        break;
                    case "Actualizado":
                        col.Header.Caption = "Actualizado";
                        col.Hidden = true;
                        break;
                    case "Index":
                        col.Hidden = true;
                        break;
                    case "Table":
                        col.Hidden = true;
                        break;
                    case "Activo":
                        col.Header.Caption = "Activo";
                        break;
                }
            }
        }

        private void uteFilterCustomers_ValueChanged(object sender, EventArgs e)
        {
            DataSet dsGrid = new DataSet();
            filter(dsGrid);
        }

        private void filter(DataSet dsGrid)
        {            
            if (uteFilterCustomers.Text != "")
            {
                dsGrid.Tables.Add(dsOriginal.Tables[0].Clone());
                dsGrid.Tables.Add(dsOriginal.Tables[1].Clone());
                foreach (DataRow row in dsOriginal.Tables[0].Select("Description LIKE '%" + uteFilterCustomers.Text + "%'"))
                {
                    dsGrid.Tables[0].ImportRow(row);
                    foreach (DataRow child in dsOriginal.Tables[1].Select("CustomerID = " + row["CustomerID"]))
                    {
                        dsGrid.Tables[1].ImportRow(child);
                    }
                }
                DataRelation rel = new DataRelation("", dsGrid.Tables[0].Columns["CustomerID"], dsGrid.Tables[1].Columns["CustomerID"]);
                dsGrid.Relations.Add(rel);
            }
            else
            {
                dsGrid = dsOriginal;
            }
            ugEditCustomers.DataSource = dsGrid;
            InicializeLayout();
        }

        private void InicializeLayout()
        {
            foreach (UltraGridRow row in ugEditCustomers.Rows)
            {
                if(row.Cells["Active"].Text == "I")
                {                
                    UltraGridChildBand child = row.ChildBands[0];
                    foreach (UltraGridRow childRow in child.Rows)
                    {
                        childRow.Activation = Activation.NoEdit;
                    }
                }
            }
        }

        private void ugEditCustomers_CellChange(object sender, CellEventArgs e)
        {            
            Boolean IsError = true;
            GlobalChange = true;
            ubSave.Enabled = true;
            e.Cell.Row.Cells["actualizado"].Value = true;
            if (Convert.ToInt32(e.Cell.Row.Cells["Table"].Value) == 0)
            {
                dsOriginal.Tables[0].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Actualizado"] = true;
            }
            else
            {
                dsOriginal.Tables[1].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Actualizado"] = true;
            }
            switch(e.Cell.Column.Key)
            {
                case "Description":                    
                    foreach (char c in e.Cell.Text)
                    {
                        if (!char.IsLetterOrDigit(c) && c != '.' && c != ',' && c != '/' && !char.IsControl(c) && !char.IsSeparator(c))
                        {
                            IsError = false;
                        }
                    }
                    break;
                case "Activo":
                    if (Convert.ToBoolean(e.Cell.Text) == false)
                    {
                        e.Cell.Row.Cells["Active"].Value = "I";
                        if (Convert.ToInt32(e.Cell.Row.Cells["Table"].Value) == 0)
                        {
                            dsOriginal.Tables[0].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Active"] = "I";
                            dsOriginal.Tables[0].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Actualizado"] = true;
                        }
                        else
                        {
                            dsOriginal.Tables[1].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Active"] = "I";
                            dsOriginal.Tables[1].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Actualizado"] = true;
                        }
                        if (Convert.ToInt32(e.Cell.Row.Cells["Table"].Value) == 0)
                        {
                            UltraGridChildBand child = e.Cell.Row.ChildBands[0];
                            foreach (UltraGridRow childRow in child.Rows)
                            {
                                childRow.Activation = Activation.NoEdit;
                            }
                        }                        
                    }
                    else
                    {
                        e.Cell.Row.Cells["Active"].Value = "A";
                        if (Convert.ToInt32(e.Cell.Row.Cells["Table"].Value) == 0)
                        {
                            dsOriginal.Tables[0].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Active"] = "A";
                            dsOriginal.Tables[0].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Actualizado"] = true;
                        }
                        else
                        {
                            dsOriginal.Tables[1].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Active"] = "A";
                            dsOriginal.Tables[1].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)]["Actualizado"] = true;
                        }
                        if (Convert.ToInt32(e.Cell.Row.Cells["Table"].Value) == 0)
                        {
                            UltraGridChildBand child = e.Cell.Row.ChildBands[0];
                            foreach (UltraGridRow childRow in child.Rows)
                            {
                                childRow.Activation = Activation.AllowEdit;
                            }
                        }
                    }           
                    break;
                case "ContactName":                    
                    foreach (char c in e.Cell.Text)
                    {
                        if (!char.IsLetterOrDigit(c) && c != '.' && c != ',' && !char.IsControl(c) && !char.IsSeparator(c))
                        {
                            IsError = false;
                        }
                    }
                    break;
                case "Email":                    
                    break;
            }
            if (IsError)
            {
                try
                {
                    e.Cell.Row.Update();
                    if (Convert.ToInt32(e.Cell.Row.Cells["Table"].Value) == 0)
                    {
                        dsOriginal.Tables[0].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)][e.Cell.Column.Key.ToString()] = e.Cell.Value;
                    }
                    else
                        dsOriginal.Tables[1].Rows[Convert.ToInt32(e.Cell.Row.Cells["Index"].Value)][e.Cell.Column.Key.ToString()] = e.Cell.Value;
                }
                catch
                {
                    switch (e.Cell.Column.Key)
                    {
                        case "Description":
                        case "ContactName":
                            e.Cell.Value = e.Cell.OriginalValue;
                            break;
                    }
                }
            }
            else
            {
                switch (e.Cell.Column.Key)
                {
                    case "Description":
                    case "ContactName":
                        e.Cell.Value = e.Cell.OriginalValue;
                        break;
                }
            }
        }

        private void ugEditCustomers_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                switch (ugEditCustomers.ActiveCell.Column.Key)
                {
                    case "Description":
                        if (char.IsDigit(e.KeyChar))
                            e.Handled = false;
                        else
                            if (char.IsControl(e.KeyChar))
                                e.Handled = false;
                            else
                                if (char.IsPunctuation(e.KeyChar) && e.KeyChar == '/' && e.KeyChar == '.' && e.KeyChar == ',')
                                    e.Handled = false;
                                else
                                    if (char.IsLetter(e.KeyChar))
                                        e.Handled = false;                                    
                                    else
                                        if (char.IsSeparator(e.KeyChar))
                                            e.Handled = false;
                                        else
                                            e.Handled = true;
                        break;
                    case "ContactName":
                        if (char.IsControl(e.KeyChar))
                            e.Handled = false;
                        else
                            if (char.IsPunctuation(e.KeyChar) && e.KeyChar == '.' && e.KeyChar == ',')
                                e.Handled = false;
                            else
                                if (char.IsLetter(e.KeyChar))
                                    e.Handled = false;
                                else
                                    if (char.IsSeparator(e.KeyChar))
                                        e.Handled = false;
                                    else
                                        e.Handled = true;
                        break;
                }
            }
            catch { }
        }

        private void ugEditCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePoint = new Point(e.X, e.Y);
                UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);

                UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;

                if (cell != null)
                {
                    contextMenuEditCustomer.Items[1].Visible = true;
                    selectedCell = cell;
                    foreach (UltraGridRow row in this.ugEditCustomers.Rows)
                    {
                        row.Selected = false;
                        UltraGridChildBand child = row.ChildBands[0];
                        foreach (UltraGridRow childRow in child.Rows)
                        {
                            childRow.Selected = false;
                        }
                    }
                    cell.Row.Selected = true;                    
                }
                else
                {
                    contextMenuEditCustomer.Items[1].Visible = false;
                }
                int x, y;
                x = ugEditCustomers.Parent.Parent.Location.X + mousePoint.X + 25;
                y = ugEditCustomers.Parent.Parent.Location.Y + mousePoint.Y + 100;
                Point contextMenuLocation = new Point(x, y);
                contextMenuEditCustomer.Show(contextMenuLocation);
            }
        }

        private void ubClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCustomersDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalChange)
            {
                DialogResult result = MessageBox.Show("Quiere salvar los cambios?", "Save Change", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (!Save())
                    {
                        e.Cancel = true;
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                    if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
            }
        }

        private Boolean Save()
        {
            if (IsValidDataCustomers() && IsValidDataContact())
            {
                this.Cursor = Cursors.WaitCursor;
                EditCustomersManager ecm = new EditCustomersManager();
                ecm.getCustomers(dsOriginal, user);
                GlobalChange = false;
                NewContactID = -1;
                NewCustomerID = -1;
                uteFilterCustomers.Text = "";
                InitializeCustomers();
                ubSave.Enabled = false;       
                this.Cursor = Cursors.Default;
                return true;
            }
            else
                return false;
        }

        private bool IsValidDataContact()
        {
            int ContactId = 0;
            bool error = false;
            string errorMessage = "";

            foreach (DataRow row in dsOriginal.Tables["Table1"].Rows)
            {
                if (error == false)
                {
                    if (Convert.ToInt32(row["CustomerContactID"].ToString()) > 0 || row["Active"].ToString() == "A")
                    {
                        if (row["Email"].ToString() != String.Empty)
                        {
                            if (Utilities.isEmail(row["Email"].ToString()) == false)
                            {
                                errorMessage = "El formato de correo electrónico no es válido" + Environment.NewLine;
                                ContactId = Convert.ToInt32(row["CustomerContactID"].ToString());
                                error = true;
                            }
                        }
                        if (row["ContactName"].ToString().Trim() == String.Empty)
                        {
                            errorMessage = "Falto ingresar datos en Nombre Contacto" + Environment.NewLine;
                            ContactId = Convert.ToInt32(row["CustomerContactID"].ToString());
                            error = true;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (error)
            {
                MessageBox.Show(errorMessage, "Datos Incorrectos");
                FindAndSelectedContactsError(ContactId);
                return false;
            }
            return true;
        }

        private void FindAndSelectedContactsError(int ContactId)
        {
            uteFilterCustomers.Text = "";
            FindAndSelectedContacts(ContactId);
        }

        private void FindAndSelectedContacts(int clave)
        {
            foreach (UltraGridRow row in ugEditCustomers.Rows)
            {
                row.Selected = false;
                UltraGridChildBand child = row.ChildBands[0];
                foreach (UltraGridRow childRow in child.Rows)
                {
                    childRow.Selected = false;
                    if (Convert.ToInt32(childRow.Cells["CustomerContactID"].Value) == clave)
                    {
                        auxRow = childRow;
                        row.Expanded = true;
                        row.Selected = false;
                    }
                }
            }
            auxRow.Selected = true;
        }

        private bool IsValidDataCustomers()
        {
            int CustomerIDValidData = 0, CustomerID = 0;
            bool errorData = false, error = false;
            string errorMessage = "";

            foreach (DataRow row in dsOriginal.Tables["Table"].Rows)
            {
                if (error == false && errorData == false)
                {
                    if (Convert.ToInt32(row["CustomerID"].ToString()) < 0 && row["Active"].ToString() == "I")
                    {
                        foreach (DataRow dr in dsOriginal.Tables[1].Select("CustomerID = " + Convert.ToInt32(row["CustomerID"])))
                        {
                            error = true;
                            CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
                        }
                    }
                    else
                    {
                        if (row["Description"].ToString().Trim() == String.Empty)
                        {
                            errorMessage = "Falto ingresar datos en Nombre de Empresa" + Environment.NewLine;
                            CustomerIDValidData = Convert.ToInt32(row["CustomerID"].ToString());
                            errorData = true;
                        }
                    }
                }
            }
            if (error)
            {
                DialogResult mensaje = MessageBox.Show("Se crearon Empresas que están inactivas, que no se guardaran.\nNi los Cantactos que se le crearon.\n¿Desea continuar?", "Save Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mensaje == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    FindAndSelectedCustomerError(CustomerID);
                    return false;
                }

            }
            else
            {
                if (errorData)
                {
                    MessageBox.Show(errorMessage, "Datos Incorrectos");
                    FindAndSelectedCustomerError(CustomerIDValidData);
                    return false;
                }
                else
                    return true;
            }
        }

        private void FindAndSelectedCustomerError(int CustomerId)
        {
            uteFilterCustomers.Text = "";
            foreach (UltraGridRow row in ugEditCustomers.Rows)
            {
                row.Selected = false;
                if (Convert.ToInt32(row.Cells["CustomerID"].Value) == CustomerId)
                {
                    auxRow = row;
                }
            }
            auxRow.Selected = true;        
        }

        private void ubSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Save();            
            this.Cursor = Cursors.Default;
        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomers();
            ugEditCustomers.Rows[ugEditCustomers.Rows.Count - 1].Activate();
        }

        private void NewContact_Click(object sender, EventArgs e)
        {
            int index = NewContacts();
            FindAndSelectedContacts(index);
        }

        private void NewCustomers()
        {
            GlobalChange = true;
            DataRow dr = dsOriginal.Tables[0].Rows.Add();
            dr["CustomerID"] = NewCustomerID;
            dr["Creator"] = user;
            dr["Created"] = DateTime.Now.ToString("yyyy-MM-dd");
            dr["Table"] = 0;
            dr["Index"] = dsOriginal.Tables[0].Rows.Count - 1;
            dr["Activo"] = true;
            dr["Active"] = "A";
            dr["Actualizado"] = true;            
            NewCustomerID--;
            uteFilterCustomers.Text = "";
        }

        private int NewContacts()
        {
            GlobalChange = true;
            DataRow dr = dsOriginal.Tables[1].Rows.Add();
            dr["CustomerContactID"] = NewContactID;
            dr["CustomerID"] = Convert.ToInt32(selectedCell.Row.Cells["CustomerID"].Value);
            dr["Creator"] = user;
            dr["Created"] = DateTime.Now.ToString("yyyy-MM-dd");
            dr["Table"] = 1;
            dr["Index"] = dsOriginal.Tables[1].Rows.Count - 1;
            dr["Activo"] = true;
            dr["Active"] = "A";
            dr["Actualizado"] = true;
            DataSet dsGrid = new DataSet();
            filter(dsGrid);
            NewContactID--;
            return (NewContactID + 1);
        }
    }
}
