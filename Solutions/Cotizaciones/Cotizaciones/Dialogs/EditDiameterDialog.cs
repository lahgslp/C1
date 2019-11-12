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
using System.Text.RegularExpressions;

namespace Cotizaciones.Dialogs
{
   
    public partial class EditDiameterDialog : Form
    {
        bool ReadOnlyMode;
        bool changeGlobal = false;
        DataSet ds;
        UltraGridCell selectedCell = null;
        UltraGridRow auxRow = null;
        string user;
        int EditDiameterSectionID = -1;
        int EditPipeSectionID = -1;
        public EditDiameterDialog(string User, bool readOnlyMode)
        {
            ReadOnlyMode = readOnlyMode;
            InitializeComponent();
            this.user = User;
            btnSave.Enabled = false;
        }

        private void EditDiameterDialog_Load(object sender, EventArgs e)
        {
            EditDiameterInitialize();
            this.btnNew.Enabled = !ReadOnlyMode;
        }

        private void EditDiameterInitialize()
        {
            EditDiameterManager edm = new EditDiameterManager();
            ds = edm.getDiameter();
            ugEditDiameter.DataSource = ds;
            SetGridProperties();
            InitializeLayouts();
        }

        private void SetGridProperties()
        {
            //Section band
            foreach (UltraGridColumn col in this.ugEditDiameter.DisplayLayout.Bands[0].Columns)
            {
                switch (col.Key)
                {
                    case "PipeDiameterTypeID":
                        col.Hidden = true;
                        break;
                    case "ShortName":
                        col.Header.Caption = "Diámetro Nominal";
                        break;
                    case "ExternalDiameterInches":
                        col.Header.Caption = "Diámetro Exterior";
                        break;
                    case "Active":
                        col.Header.Caption = "Estados";
                        col.Hidden = true;              
                        break;
                    case "LastUpdated":
                        col.Header.Caption = "Actualizado en";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Activo":
                        col.Header.Caption = "Activo";
                        break;
                    case "Actualizado":
                        col.Header.Caption = "Actualizado";
                        col.Hidden = true;
                        break;
                }
            }
            foreach (UltraGridColumn col in this.ugEditDiameter.DisplayLayout.Bands[1].Columns)
            {
                switch (col.Key)
                {
                    case "PipeSpecificationID":
                        col.Hidden = true;
                        break;
                    case "PipeDiameterTypeID":
                        col.Hidden = true;
                        break;
                    case "ShortName":
                        col.Hidden = true;
                        break;
                    case "WallThicknessInches":
                        col.Header.Caption = "Espesores";                        
                        break;
                    case "PipeSchedule":
                        col.Header.Caption = "Cédulas";
                        break;
                    case "PipeClass":
                        col.Header.Caption = "Clase de Cédula";
                        break;
                    case "Active":
                        col.Header.Caption = "Estados";
                        col.Hidden = true;
                        break;
                    case "LastUpdated":
                        col.Header.Caption = "Actualizado en";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    case "Activo":
                        col.Header.Caption = "Activo";
                        break;
                    case "Actualizado":
                        col.Header.Caption = "Actualizado";
                        col.Hidden = true;
                        break;
                    }
            }
        }

        private void ugEditDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (ugEditDiameter.ActiveCell.Column.Key == "ShortName")
                {
                    if (char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        if (char.IsControl(e.KeyChar))
                            e.Handled = false;
                        else
                            if (char.IsPunctuation(e.KeyChar) && e.KeyChar == '/')
                            {
                                if (!ugEditDiameter.ActiveCell.Text.Contains('/'))
                                    e.Handled = false;
                                else
                                    e.Handled = true;
                            }
                            else
                                if (char.IsSeparator(e.KeyChar))
                                    e.Handled = false;
                                else
                                    e.Handled = true;
                }
                if (ugEditDiameter.ActiveCell.Column.Key == "ExternalDiameterInches")
                {
                    if (char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        if (char.IsControl(e.KeyChar))
                            e.Handled = false;
                        else
                            if (char.IsPunctuation(e.KeyChar) && e.KeyChar == '.')
                            {
                                if (!ugEditDiameter.ActiveCell.Text.Contains('.'))
                                    e.Handled = false;
                                else
                                    e.Handled = true;
                            }
                            else
                                e.Handled = true;
                }
                if (ugEditDiameter.ActiveCell.Column.Key == "WallThicknessInches")
                {
                    if (char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        if (char.IsControl(e.KeyChar))
                            e.Handled = false;
                        else
                            if (char.IsPunctuation(e.KeyChar) && e.KeyChar == '.')
                            {
                                if (!ugEditDiameter.ActiveCell.Text.Contains('.'))
                                    e.Handled = false;
                                else
                                    e.Handled = true;
                            }
                            else
                                e.Handled = true;
                }
                if (ugEditDiameter.ActiveCell.Column.Key == "PipeSchedule")
                {
                    if (char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        if (char.IsControl(e.KeyChar))
                            e.Handled = false;
                        else
                            e.Handled = true;
                }
            }
            catch { }
        }

        private bool IsValidDiameterShortName(string diameterShortName)
        {
            string ValidShortName = @"^[0-9]{1,5}(\/[0-9]{0,3})?$";
            string IsCero = @"^[0]{1,5}(\/[0-9]{0,3})?$";
            Regex re = new Regex(IsCero);
            if (re.IsMatch(diameterShortName))
            {
                return false;
            }
            else
            {
                Regex reg = new Regex(ValidShortName);
                if (reg.IsMatch(diameterShortName))
                {
                    return true;
                }
                else
                {
                    Regex reg1 = new Regex(@"^[1-9]{1,5}(\s[1-9]{1,5}(\/[0-9]{0,3}))?$");
                    if (reg1.IsMatch(diameterShortName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }                
        }

        private bool IsValidDataDiameters()
        {
            int DiameterId = 0;
            bool error = false, NewDiamterInactive = false;
            string errorMessage = "";
            
            foreach (DataRow row in ds.Tables["Table"].Rows)
            {
                if (error == false && NewDiamterInactive == false)
                {
                    if (Convert.ToInt32(row["PipeDiameterTypeID"]) > 0 || row["Active"].ToString() == "A")
                    {
                        if (row["ExternalDiameterInches"].ToString().Trim() == String.Empty || Convert.ToDecimal(row["ExternalDiameterInches"]) == 0)
                        {
                            errorMessage = "Falto ingresar datos en Diámetro Exterior" + Environment.NewLine;
                            DiameterId = Convert.ToInt32(row["PipeDiameterTypeID"].ToString());
                            error = true;
                        }

                        if (row["ShortName"].ToString().Trim() == String.Empty || IsValidDiameterShortName(row["ShortName"].ToString()) == false)
                        {
                            errorMessage = "Falto ingresar datos en Diámetro Nominal o el valor no es valido" + Environment.NewLine;
                            DiameterId = Convert.ToInt32(row["PipeDiameterTypeID"].ToString());
                            error = true;
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in ds.Tables[1].Select("PipeDiameterTypeID = " + Convert.ToInt32(row["PipeDiameterTypeID"])))
                        {
                            NewDiamterInactive = true;
                            DiameterId = Convert.ToInt32(row["PipeDiameterTypeID"].ToString());
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (NewDiamterInactive)
            {
                DialogResult mensaje = MessageBox.Show("Se crearon Diámetros que están inactivas, que no se guardaran.Ni los Espesores que se le crearon.¿Desea continuar?", "Save Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mensaje == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    FindAndSelectedDiameterError(DiameterId);
                    return false;
                }
            }
            else
            {
                if (error)
                {
                    MessageBox.Show(errorMessage, "Datos Incorrectos");
                    FindAndSelectedDiameterError(DiameterId);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private bool IsValidDataPipe()
        {
            int PipeId = 0;
            bool error = false;
            string errorMessage = "";

            foreach (DataRow row in ds.Tables["Table1"].Rows)
            {
                if (error == false)
                {
                    if (Convert.ToInt32(row["PipeSpecificationID"].ToString()) > 0 || row["Active"].ToString() == "A")                    
                    {
                        if (row["WallThicknessInches"].ToString().Trim() == String.Empty || Convert.ToDecimal(row["WallThicknessInches"].ToString()) == 0)
                        {
                            errorMessage = "Falto ingresar datos del Espesor" + Environment.NewLine;
                            PipeId = Convert.ToInt32(row["PipeSpecificationID"].ToString());
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
                FindAndSelectedPipeError(PipeId);
                return false;
            }

            return true;
                       
        }

        private void FindAndSelectedPipeError(int PipeID)
        {
            foreach (UltraGridRow row in ugEditDiameter.Rows)
            {
                row.Selected = false;
                UltraGridChildBand child = row.ChildBands[0];
                foreach (UltraGridRow childRow in child.Rows)
                {
                    childRow.Selected = false;
                    if (Convert.ToInt32(childRow.Cells["PipeSpecificationID"].Value) == PipeID)
                        auxRow = childRow;
                }                
            }
            auxRow.Selected = true;
        }

        private void FindAndSelectedDiameterError(int DiameterID)
        {
            foreach (UltraGridRow row in ugEditDiameter.Rows)
            {
                row.Selected = false;
                if (Convert.ToInt32(row.Cells["PipeDiameterTypeID"].Value) == DiameterID)
                    auxRow = row;
            }
            auxRow.Selected = true;
        }

        private void NewDiameter()
        {
            changeGlobal = true;
            DataRow dr = ds.Tables[0].Rows.Add();
            dr["PipeDiameterTypeID"] = EditDiameterSectionID;
            dr["ShortName"] = "";
            dr["ExternalDiameterInches"] = 0.0;
            dr["Active"] = "A";
            dr["LastUpdated"] = DateTime.Now.ToString("yyyy-MM-dd");
            dr["Activo"] = true;
            dr["Actualizado"] = true;            
            EditDiameterSectionID--;
        }

        private void NewPipe()
        {
            changeGlobal = true;
            DataRow dr = ds.Tables[1].Rows.Add();
            dr["PipeDiameterTypeID"] = Convert.ToInt32(selectedCell.Row.Cells["PipeDiameterTypeID"].Value);
            dr["ShortName"] = selectedCell.Row.Cells["ShortName"].Value;
            dr["PipeSpecificationID"] = EditPipeSectionID;           
            dr["Active"] = "A";
            dr["LastUpdated"] = DateTime.Now.ToString("yyyy-MM-dd");
            dr["Activo"] = true;
            dr["Actualizado"] = true;
            FindAndSelectedEspesor(EditPipeSectionID);
            EditPipeSectionID--;            
        }

        private void FindAndSelectedEspesor(int clave)
        {
            foreach (UltraGridRow row in ugEditDiameter.Rows)
            {
                row.Selected = false;
                UltraGridChildBand child = row.ChildBands[0];
                foreach (UltraGridRow childRow in child.Rows)
                {
                    childRow.Selected = false;
                    if (Convert.ToInt32(childRow.Cells["PipeSpecificationID"].Value) == clave)
                    {
                        auxRow = childRow;
                        row.Expanded = true;
                        row.Selected = false;
                    }
                }
            }
            auxRow.Selected = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewDiameter();
            ugEditDiameter.Rows[ugEditDiameter.Rows.Count - 1].Activate();
        }

        private void AddEspesor_Click(object sender, EventArgs e)
        {
            NewPipe();
        }

        private void ugEditDiameter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePoint = new Point(e.X, e.Y);
                UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);

                UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;

                if (cell != null)
                {
                    contextMenuEditDiameter.Items[0].Visible = true;
                    selectedCell = cell;
                    //MessageBox.Show(selectedCell.Row.Cells["ShortName"].Value.ToString());
                    foreach (UltraGridRow row in this.ugEditDiameter.Rows)
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
                    contextMenuEditDiameter.Items[0].Visible = false;
                }
                int x, y;
                x = ugEditDiameter.Parent.Parent.Location.X + mousePoint.X + 20;
                y = ugEditDiameter.Parent.Parent.Location.Y + mousePoint.Y + 45;
                Point contextMenuLocation = new Point(x, y);
                contextMenuEditDiameter.Show(contextMenuLocation);
            }   
        }

        private void AddDiameter_Click(object sender, EventArgs e)
        {
            NewDiameter();
            ugEditDiameter.Rows[ugEditDiameter.Rows.Count - 1].Activate();
        }

        private void ugEditDiameter_CellChange(object sender, CellEventArgs e)
        {
            Boolean IsValid = true;
            if (!ReadOnlyMode)
            {
                btnSave.Enabled = true;
            }
            changeGlobal = true;
            e.Cell.Row.Cells["actualizado"].Value = true;
            switch (e.Cell.Column.Key)
            {
                case "Activo":
                    if (Convert.ToBoolean(e.Cell.Text) == false)
                    {                        
                        e.Cell.Row.Cells["Active"].Value = "I";
                        try
                        {
                            UltraGridChildBand child = e.Cell.Row.ChildBands[0];
                            foreach (UltraGridRow childRow in child.Rows)
                            {
                                childRow.Activation = Activation.NoEdit;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        e.Cell.Row.Cells["Active"].Value = "A";
                        try
                        {
                            UltraGridChildBand child = e.Cell.Row.ChildBands[0];
                            foreach (UltraGridRow childRow in child.Rows)
                            {
                                childRow.Activation = Activation.AllowEdit;
                            }
                        }
                        catch { }
                    }
                    break;
                case "ShortName":
                    foreach (char c in e.Cell.Text)
                    {
                        if (!char.IsDigit(c) && c != '/' && !char.IsSeparator(c))
                        {
                            IsValid = false;
                        }
                    }
                    break;
                case "ExternalDiameterInches":
                case "WallThicknessInches":
                    foreach (char c in e.Cell.Text)
                    {
                        if (!char.IsDigit(c) && c != '.')
                        {
                            IsValid = false;
                        }
                    }
                    break;
            }
            if (IsValid)
            {
                try
                {
                    e.Cell.Row.Update();
                }
                catch
                {
                    switch (e.Cell.Column.Key)
                    {
                        case "ExternalDiameterInches":
                        case "WallThicknessInches":
                        case "ShortName":
                            e.Cell.Value = e.Cell.OriginalValue;
                            break;
                    }
                }
            }
            else
            {
                switch (e.Cell.Column.Key)
                {
                    case "ExternalDiameterInches":
                    case "WallThicknessInches":
                    case "ShortName":
                        e.Cell.Value = e.Cell.OriginalValue;
                        break;
                }
            }
        }

        private void ugEditDiameter_AfterCellUpdate(object sender, CellEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Save();
            btnSave.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private Boolean Save()
        {
            if (IsValidDataDiameters() && IsValidDataPipe())
            {
                this.Cursor = Cursors.WaitCursor;
                EditDiameterManager edm = new EditDiameterManager();
                edm.EditDiameterSave(user, ds);
                EditDiameterSectionID = -1;
                EditPipeSectionID = -1;
                changeGlobal = false;
                EditDiameterInitialize();
                InitializeLayouts();
                //ugEditDiameter.Rows[0].Selected = true;
                this.Cursor = Cursors.Default;
                return true;
            }
            else
                return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void EditDiameterDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changeGlobal)
            {
                if (!ReadOnlyMode)
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
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void InitializeLayouts()
        {
            foreach (UltraGridRow row in ugEditDiameter.Rows)
            {
                if (row.Cells["Active"].Text == "I")
                {
                    UltraGridChildBand child = row.ChildBands[0];
                    foreach (UltraGridRow childRow in child.Rows)
                    {
                        childRow.Activation = Activation.NoEdit;
                    }
                }
            }
        }       
    }

}
