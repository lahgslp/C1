using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.DataModel;
using Cotizaciones.DataManagers;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace Cotizaciones.Views
{
    public partial class ProductSelectionView : BaseView
    {
        bool initProcess = true;
        int QuotationSectionDetailID = -1;

        Hashtable sections = new Hashtable();

        DataSet ds;
        DataTable dtPipeDiameter, dtPipeSpecification, dtAllSpecs, dtUnitType;
        DataTable OriginalProductInfo;
        UltraGridCell selectedCell = null;
        
        public ProductSelectionView()
        {
            sections.Add("TSCB", 1);
            sections.Add("TSCX52", 2);
            sections.Add("ERW", 3);
            sections.Add("LSAW", 4);
            sections.Add("SSAW", 5);
            sections.Add("EDITABLE", 6);

            InitializeComponent();
        }

        private void ProductSelectionView_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadReferenceData();
            InitializeControls();
            this.LoadQuotationData();
            EnableDisableControls();
            this.Cursor = Cursors.Default;
        }

        private void EnableDisableControls()
        {
            if (IsReadOnly == true)
            {
                //this.ugProducts.Enabled = false;
                foreach (UltraGridBand band in this.ugProducts.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn column in band.Columns)
                    {
                        column.CellClickAction = CellClickAction.RowSelect;
                        column.CellActivation = Activation.NoEdit;
                    }
                }
            }
            else
            {
            }
        }

        private void LoadQuotationData()
        {
            OriginalProductInfo = ProductSelectionManager.GetQuotationDetails(this.QuotationID);
            if (OriginalProductInfo.Rows.Count > 0)
            {
                InitializeQuotationData(OriginalProductInfo);
            }
            else
            {
                if (!IsReadOnly)
                {
                    this.CreateProductRow();
                }
            }
        }

        private void InitializeQuotationData(DataTable qdt)
        {
            foreach (DataRow row in qdt.Rows)
            {
                UltraDataRow newRow = this.ultraDataSourceProducts.Rows.Add();
                newRow["Diámetro Nominal"] = row["Diámetro Nominal"];
                newRow["Espesor"] = row["Espesor"];
                newRow["Cantidad Requerida"] = row["Cantidad Requerida"];
                newRow["Unidad"] = row["Unidad"];
                newRow["Peso"] = row["Peso"];
                foreach (string s in sections.Keys)
                {
                    newRow[s] = row[s];
                }
                newRow["QuotationSectionDetailID"] = row["QuotationSectionDetailID"];
            }
        }

        private void InitializeControls()
        {
            this.ucPipeDimeterType.DataSource = dtPipeDiameter;
            this.ucPipeDimeterType.DisplayMember = "ShortName";
            this.ucPipeDimeterType.ValueMember = "ShortName";
            this.ucPipeDimeterType.Visible = false;
            this.ucPipeDimeterType.LimitToList = false;
            this.ucPipeDimeterType.DisplayLayout.Bands[0].ColHeadersVisible = false;

            this.ucPipeSpecification.DataSource = dtPipeSpecification;
            this.ucPipeSpecification.DisplayMember = "Description";
            this.ucPipeSpecification.ValueMember = "Description";
            this.ucPipeSpecification.Visible = false;
            this.ucPipeSpecification.LimitToList = true;
            this.ucPipeSpecification.DisplayLayout.Bands[0].ColHeadersVisible = false;

            this.ucUnitType.DataSource = dtUnitType;
            this.ucUnitType.DisplayMember = "ShortName";
            this.ucUnitType.ValueMember = "UnitTypeID";
            this.ucUnitType.Visible = false;
            this.ucUnitType.LimitToList = true;
            this.ucUnitType.DisplayLayout.Bands[0].Columns["UnitTypeID"].Hidden = true;
            this.ucUnitType.DisplayLayout.Bands[0].Columns["Description"].Hidden = true;
            this.ucUnitType.DisplayLayout.Bands[0].Columns["Active"].Hidden = true;
            this.ucUnitType.DisplayLayout.Bands[0].ColHeadersVisible = false;
        }

        private void LoadReferenceData()
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetProductSpecs();

            ds = sp.ExecuteDataSet();

            dtPipeDiameter = ds.Tables["Table"];
            dtPipeDiameter.Columns.Remove("PipeDiameterTypeID");
            dtPipeSpecification = ds.Tables["Table1"];
            dtAllSpecs = ds.Tables["Table2"];
            dtUnitType = ds.Tables["Table3"];
        }

        private void CreateProductRow()
        {
            this.ultraDataSourceProducts.Rows.Add();
        }

        DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("PipeDiameterTypeID");
            DataColumn col2 = new DataColumn("PipeSpecificationID");
            DataColumn col3 = new DataColumn("Quantity");
            DataColumn col4 = new DataColumn("UnitTypeID");
            DataColumn col5 = new DataColumn("Weight");
            DataColumn col12 = new DataColumn("QuotationSectionDetailID");
            
            col1.DataType = System.Type.GetType("System.Int32");
            col2.DataType = System.Type.GetType("System.Int32");
            col3.DataType = System.Type.GetType("System.Double");
            col4.DataType = System.Type.GetType("System.Int32");
            col5.DataType = System.Type.GetType("System.Double");
            col12.DataType = System.Type.GetType("System.Int32");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col12);

            foreach (string s in sections.Keys)
            {
                DataColumn colSection = new DataColumn(s);
                colSection.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(colSection);
            }

            return dt;
        }

        private bool IsValidData()
        {
            bool isValidData = true;
            if (!IsReadOnly)
            {
                ArrayList nonUsedRows = new ArrayList();
                string errorValue;
                if (this.ultraDataSourceProducts.Rows.Count > 0)
                {
                    foreach (UltraDataRow row in this.ultraDataSourceProducts.Rows)
                    {
                        if (row["Diámetro Nominal"] != DBNull.Value && row["Espesor"] != DBNull.Value && row["Espesor"].ToString() != "")
                        {
                            errorValue = "Fila " + (row.Index + 1).ToString() + " ['" + row["Diámetro Nominal"].ToString() + "','" + row["Espesor"].ToString() + "']";
                            //Check for non used rows
                            if (!this.CheckUsedSections(row))
                            {
                                nonUsedRows.Add(errorValue);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se han llenado Diámetro Nominal o Espesor", "Datos incorrectos");
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha agregado ningun producto a la cotización", "Datos incorrectos");
                    return false;
                }
                string errorMessage = "";
                if (nonUsedRows.Count > 0)
                {
                    errorMessage += "Seleccione secciones para incluir: " + Environment.NewLine;
                    foreach (string element in nonUsedRows)
                    {
                        errorMessage += "\t" + element + Environment.NewLine;
                    }
                    errorMessage = errorMessage.Substring(0, errorMessage.Length - 1) + Environment.NewLine;
                    isValidData = false;
                }

                if (!isValidData)
                {
                    MessageBox.Show(errorMessage, "Datos incorrectos");
                }
            }
            return isValidData;
        }
        
        private bool CheckUsedSections(UltraDataRow row)
        {
            foreach (string s in sections.Keys)
            {
                if (Convert.ToBoolean(row[s]))
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateQuotation()
        {
            if (!IsReadOnly)
            {
                //Get the datatable to use to the QuotationProductsManager
                DataTable inputData = CreateDataTable();
                DataRow inputRow;
                int diameterTypeID, specificationID;

                foreach (UltraDataRow row in this.ultraDataSourceProducts.Rows)
                {
                    inputRow = inputData.NewRow();
                    diameterTypeID = FindDiameter(dtAllSpecs, row["Diámetro Nominal"].ToString());
                    specificationID = FindSpecification(dtAllSpecs, diameterTypeID, row["Espesor"].ToString());
                    inputRow["PipeDiameterTypeID"] = diameterTypeID;
                    inputRow["PipeSpecificationID"] = specificationID;
                    inputRow["Quantity"] = Convert.ToDouble(row["Cantidad Requerida"]);
                    inputRow["UnitTypeID"] = Convert.ToInt32(row["Unidad"]);
                    inputRow["Weight"] = Convert.ToDouble(row["Peso"]);
                    foreach (string s in sections.Keys)
                    {
                        inputRow[s] = Convert.ToBoolean(row[s]);
                    }
                    inputRow["QuotationSectionDetailID"] = Convert.ToInt32(row["QuotationSectionDetailID"]);
                    inputData.Rows.Add(inputRow);
                }
                ProductSelectionManager.UpdateQuotationDetails(this.QuotationID, this.User, inputData, OriginalProductInfo, sections);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                this.UpdateQuotation();

                MyQuotationsView myview = new MyQuotationsView();
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                this.UpdateQuotation();

                QuotationConditionsView myview = new QuotationConditionsView();
                myview.QuotationID = this.QuotationID;
                myview.User = this.User;
                myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        private DataTable FilterSpecification(string PipeDiameterShortName)
        {
            DataTable dt = dtPipeSpecification.Clone();
            foreach (DataRow row in dtPipeSpecification.Select("ShortName = '" + PipeDiameterShortName + "'"))
            {
                dt.ImportRow(row);
            }
            return dt;
        }

        private void ugProducts_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            switch (e.Cell.Column.Key)
            {
                case "Diámetro Nominal":
                    if (e.Cell.OriginalValue != e.Cell.Value)
                    {
                        e.Cell.Row.Cells["Espesor"].Value = null;
                    }
                    break;
                case "Espesor":
                    /*this.ucePipeSpecification.DataSource = dtPipeSpecification;
                    this.ucePipeSpecification.DisplayMember = "Description";
                    this.ucePipeSpecification.ValueMember = "PipeSpecificationID";*/
                    e.Cell.Row.Cells["Peso"].Value = GetWeight(dtAllSpecs, e.Cell.Row.Cells["Diámetro Nominal"].Text, e.Cell.Row.Cells["Espesor"].Text);
                    break;
                case "Cantidad Requerida":
                    break;
                case "Unidad":
                    break;
                case "Peso":
                    break;
                default:
                    if (sections.Contains(e.Cell.Column.Key))
                    {
                        if (Convert.ToBoolean(e.Cell.Value) == false)
                        {
                            foreach (string s in sections.Keys)
                            {
                                if (e.Cell.Column.Key != s)
                                {
                                    e.Cell.Row.Cells[s].Activation = Activation.AllowEdit;
                                }
                            }
                        }
                        else
                        {
                            foreach (string s in sections.Keys)
                            {
                                if (e.Cell.Column.Key != s)
                                {
                                    e.Cell.Row.Cells[s].Activation = Activation.Disabled;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void ugProducts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePoint = new Point(e.X, e.Y);
                UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);

                UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                if (cell != null)
                {
                    contextMenuStripProducts.Items[0].Visible = true;
                    selectedCell = cell;
                    foreach (UltraGridRow row in this.ugProducts.Rows)
                    {
                        row.Selected = false;
                    }
                    cell.Row.Selected = true;
                }
                else
                {
                    contextMenuStripProducts.Items[0].Visible = false;
                }
                int x, y;
                x = this.Parent.Parent.Parent.Location.X + mousePoint.X + 10;
                y = this.Parent.Parent.Parent.Location.Y + mousePoint.Y + 45;
                Point contextMenuLocation = new Point(x, y);
                contextMenuStripProducts.Show(contextMenuLocation);
            }
        }

        int FindDiameter(DataTable specValues, string diameter)
        {
            int d = 0;
            DataRow[] r = specValues.Select("ShortName = '" + diameter + "'");
            if (r.Length > 0)
            {
                d = Convert.ToInt32(r[0]["PipeDiameterTypeID"]);
            }
            else
            {
                throw new Exception("Invalid diameter selected");
            }
            return d;
        }

        int FindSpecification(DataTable specValues, int diameterTypeID, string wallThicknessDescription)
        {
            int s = 0;
            DataRow[] r = specValues.Select("PipeDiameterTypeID = " + diameterTypeID.ToString() + " AND Description = '" + wallThicknessDescription + "'");
            if (r.Length == 1)
            {
                s = Convert.ToInt32(r[0]["PipeSpecificationID"]);
            }
            else
            {
                throw new Exception("Invalid specification");
            }
            return s;
        }

        private double GetWeight(DataTable specValues, string diameterShortName, string wallThicknessDescription)
        {
            double weight = 0;
            if (diameterShortName != String.Empty && wallThicknessDescription != String.Empty)
            {
                int diameterTypeID = FindDiameter(specValues, diameterShortName);
                int specificationID = FindSpecification(specValues, diameterTypeID, wallThicknessDescription);
                DataRow[] r = specValues.Select("PipeDiameterTypeID = " + diameterTypeID.ToString() + " AND " + "PipeSpecificationID = " + specificationID.ToString());
                if (r.Length == 1)
                {
                    weight = Convert.ToDouble(r[0]["KilogramsPerMeter"]);
                }
                else
                {
                    throw new Exception("Can't find weight");
                }
            }
            return weight;
        }

        private void toolStripMenuItemRemoveProduct_Click(object sender, EventArgs e)
        {
            if (selectedCell != null)
            {
                selectedCell.Row.Delete();
            }
        }

        private void toolStripMenuItemAddProduct_Click(object sender, EventArgs e)
        {
            if (!IsReadOnly)
            {
                CreateProductRow();
            }
        }

        private void ultraDataSourceProducts_InitializeDataRow(object sender, Infragistics.Win.UltraWinDataSource.InitializeDataRowEventArgs e)
        {
            e.Row["Cantidad Requerida"] = 1;
            e.Row["Unidad"] = 1;
            foreach (string s in sections.Keys)
            {
                e.Row[s] = false;
            }
            e.Row["QuotationSectionDetailID"] = QuotationSectionDetailID--;
        }

        private void ugProducts_CellChange(object sender, CellEventArgs e)
        {
            bool isValidValue = true;
            DataRow[] rows;
            switch (e.Cell.Column.Key)
            {
                case "Diámetro Nominal":
                    rows = dtPipeDiameter.Select("ShortName = '" + e.Cell.Text + "'");
                    if (rows.Length <= 0)
                    {
                        isValidValue = false;
                    }
                    break;
                case "Espesor":
                    rows = dtPipeSpecification.Select("Description = '" + e.Cell.Text + "'");
                    if (rows.Length <= 0)
                    {
                        isValidValue = false;
                    }
                    break;
                case "Cantidad Requerida":
                    foreach(char c in e.Cell.Text)
                    {
                        if (!Char.IsDigit(c) && c != '.' && c != ',')
                        {
                            isValidValue = false;
                            break;
                        }
                    }
                    break;
            }
            if (isValidValue)
            {
                try
                {
                    initProcess = false;
                    e.Cell.Row.Update();
                    initProcess = true;
                }
                catch
                {
                    switch (e.Cell.Column.Key)
                    {
                        case "Diámetro Nominal":
                        case "Espesor":
                        case "Cantidad Requerida":
                            e.Cell.Value = e.Cell.OriginalValue;
                            break;
                    }
                }
            }
            else
            {
                switch (e.Cell.Column.Key)
                {
                    case "Diámetro Nominal":
                    case "Espesor":
                    case "Cantidad Requerida":
                        e.Cell.Value = e.Cell.OriginalValue;
                        break;
                }
                this.ugProducts.ActiveCell = e.Cell;
            }
        }

        private void ugProducts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["Diámetro Nominal"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            e.Layout.Bands[0].Columns["Diámetro Nominal"].CellDisplayStyle = CellDisplayStyle.FullEditorDisplay;
            if (IsReadOnly != true)
            {
                e.Layout.Bands[0].Columns["Diámetro Nominal"].ValueList = this.ucPipeDimeterType;
            }
            e.Layout.Bands[0].Columns["Diámetro Nominal"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnMouseEnter;

            e.Layout.Bands[0].Columns["Espesor"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            e.Layout.Bands[0].Columns["Espesor"].CellDisplayStyle = CellDisplayStyle.FullEditorDisplay;
            if (IsReadOnly != true)
            {
                e.Layout.Bands[0].Columns["Espesor"].ValueList = this.ucPipeDimeterType;
            }
            e.Layout.Bands[0].Columns["Espesor"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnMouseEnter;

            e.Layout.Bands[0].Columns["Unidad"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            e.Layout.Bands[0].Columns["Unidad"].CellDisplayStyle = CellDisplayStyle.FullEditorDisplay;
            if (IsReadOnly != true)
            {
                e.Layout.Bands[0].Columns["Unidad"].ValueList = this.ucUnitType;
            }
            e.Layout.Bands[0].Columns["Unidad"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnMouseEnter;

            e.Layout.Bands[0].Columns["Peso"].Format = "###,###,###.#0";
        }

        private void ugProducts_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if (this.ugProducts.ActiveCell.Column.Key == "Espesor")
            {
                this.ugProducts.ActiveCell.ValueList = null;
            }
        }

        private void ugProducts_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            switch (this.ugProducts.ActiveCell.Column.Key)
            {
                case "Espesor":
                    if (this.ugProducts.ActiveCell.Row.Cells["Diámetro Nominal"].Value != null)
                    {

                        this.ucPipeSpecification.DataSource = this.FilterSpecification(this.ugProducts.ActiveCell.Row.Cells["Diámetro Nominal"].Value.ToString());
                        this.ucPipeSpecification.DisplayMember = "Description";
                        this.ucPipeSpecification.ValueMember = "Description";
                        this.ucPipeSpecification.DisplayLayout.Bands[0].Columns["ShortName"].Hidden = true;
                        this.ucPipeSpecification.DisplayLayout.Bands[0].ColHeadersVisible = false;
                        //this.ucPipeSpecification.DropDownWidth = this.ugProducts.ActiveCell.Width;
                        this.ucPipeSpecification.DisplayLayout.Bands[0].Columns["Description"].Width = this.ugProducts.ActiveCell.Width;

                        this.ugProducts.ActiveCell.ValueList = this.ucPipeSpecification;
                    }
                    break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (IsValidData() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                this.UpdateQuotation();

                CustomerInfoView myview = new CustomerInfoView();
                myview.QuotationID = this.QuotationID;
                myview.User = this.User;
                myview.QuotationStatusTypeID = this.QuotationStatusTypeID;
                MainController.Instance.Next(myview);
                this.Cursor = Cursors.Default;
            }
        }

        private void ugProducts_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (initProcess)
            {
                foreach (string s in sections.Keys)
                {
                    if (Convert.ToInt32(e.Row.Cells["QuotationSectionDetailID"].Value) > 0)
                    {
                        if (Convert.ToBoolean(e.Row.Cells[s].Value))
                        {
                        }
                        else
                        {
                            e.Row.Cells[s].Activation = Activation.Disabled;
                        }
                    }
                    else
                    {
                        e.Row.Cells[s].Activation = Activation.AllowEdit;
                    }
                }
            }
        }
    }
}
