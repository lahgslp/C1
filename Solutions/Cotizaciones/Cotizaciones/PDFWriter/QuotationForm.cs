using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cotizaciones.DataManagers;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;

namespace Cotizaciones.PDFWriter
{
    class QuotationForm
    {
        int quotationID;

        Document document;

        DataSet quotationData;

        public string CustomerName
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["CustomerName"].ToString();
                }
                return "";
            }
        }

        public string ContactName
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["ContactName"].ToString();
                }
                return "";
            }
        }

        public string Creator
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["Creator"].ToString();
                }
                return "";
            }
        }

        public string Created
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return Convert.ToDateTime(quotationData.Tables[0].Rows[0]["Created"]).ToString("yyyy-MM-dd");
                }
                return "";
            }
        }

        public string Signature
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["Signature"].ToString();
                }
                return "";
            }
        }

        public string LogoFilePath
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["LogoFilePath"].ToString();
                }
                return "";
            }
        }

        public string LogoSize
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["LogoSize"].ToString();
                }
                return "";
            }
        }

        public string FontName
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["FontName"].ToString();
                }
                return "";
            }
        }

        public int CompanyID
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return Convert.ToInt32(quotationData.Tables[0].Rows[0]["CompanyID"]);
                }
                return 3;
            }
        }

        public string CompanyName
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["CompanyName"].ToString();
                }
                return "";
            }
        }

        public string FootNoteDescription
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["FootNoteDescription"].ToString();
                }
                return "";
            }
        }

        public string CompanyCity
        {
            get
            {
                if (quotationData != null && quotationData.Tables[0] != null && quotationData.Tables[0].Rows[0] != null)
                {
                    return quotationData.Tables[0].Rows[0]["CompanyCity"].ToString();
                }
                return "";
            }
        }

        public DataTable QuotationData
        {
            get
            {
                return quotationData.Tables["Table"];
            }
        }

        public DataTable Sections
        {
            get
            {
                return quotationData.Tables["Table1"];
            }
        }

        public DataTable SectionDetails
        {
            get
            {
                return quotationData.Tables["Table2"];
            }
        }

        public QuotationForm(int QuotationID)
        {
            this.quotationID = QuotationID;
            this.quotationData = QuotationCreationManager.GetQuotationData(QuotationID);
            CreateColumnDefinitions();
        }

        public Document CreateDocument()
        {
            this.document = new Document();

            //this.document.DefaultPageSetup.PageFormat = PageFormat.A1;
            //this.document.DefaultPageSetup.Orientation = Orientation.Landscape;
            this.document.DefaultPageSetup.PageWidth = "21.59cm";
            this.document.DefaultPageSetup.PageHeight = "27.94cm";
            this.document.DefaultPageSetup.LeftMargin = "1.5cm";
            this.document.DefaultPageSetup.RightMargin = "1.5cm";

            this.document.Info.Title = "Cotización #" + quotationID.ToString("000000") + " para " + this.CustomerName;
            this.document.Info.Subject = "Cotización " + this.CompanyName + " de materiales para " + this.CustomerName + " del día " + Created;
            this.document.Info.Author = Creator;

            DefineStyles();

            CreatePage();

            return this.document;
        }

        void AddFooter(Section s)
        {
            Paragraph p = s.Footers.Primary.AddParagraph();
            p.Format.Font.Size = 7;
            p.Format.Font.Bold = true;
            p.AddText(this.FootNoteDescription);
        }
        /// <summary>
        /// Defines the styles used to format the MigraDoc document.
        /// </summary>
        void DefineStyles()
        {
            Style style;

            // Get the predefined style Normal.
            style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = this.FontName;

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = this.FontName;
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }
        
        void CreatePage()
        {
            Section section = this.document.AddSection();

            CreateHeaderTable(section);
            AddSections(section);
            CreateBottom(section);
            AddFooter(section);
        }

        void CreateHeaderTable(Section section)
        {          
            //create table
            Table table = section.AddTable();
            
            table.Style = "Table";
            table.Borders.Visible = false;            
            table.Rows.VerticalAlignment = VerticalAlignment.Center;
            
            //Define teh columns
            Column col = table.AddColumn("8.5cm");
            col = table.AddColumn("10.35cm");            
            
            //Create rows
            Row row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            
            AddLogo(row);
            CreateHeader(row, table);
        }

        void AddLogo(Row row)
        {
            if (this.LogoFilePath != String.Empty)
            {
                if (System.IO.File.Exists(".\\Logos\\" + this.LogoFilePath))
                {
                    Image image = row.Cells[0].AddImage(".\\Logos\\" + this.LogoFilePath);
                    image.Height = this.LogoSize;
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Column;
                    image.Top = ShapePosition.Center;
                    image.Left = ShapePosition.Center;
                    row.Cells[0].MergeDown = 1;
                }
            }
        }


        void CreateHeader(Row row, Table table)
        {
            row.Format.Alignment = ParagraphAlignment.Right;
            row.VerticalAlignment = VerticalAlignment.Top;
            Paragraph paragraph = row.Cells[1].AddParagraph();

            paragraph.Format.Font.Size = 10;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            
            paragraph.AddText("Cotización #" + this.quotationID.ToString("000000"));
            //paragraph.AddLineBreak();
            
            row = table.AddRow();
            row.TopPadding = 3.5;
            row.Format.Alignment = ParagraphAlignment.Right;
            row.VerticalAlignment = VerticalAlignment.Center;
            paragraph = row.Cells[1].AddParagraph();
            paragraph.Format.Font.Size = 8;            
            paragraph.AddText(this.CompanyCity + Environment.NewLine + FormatDate(Convert.ToDateTime(this.Created)));
                      
        }       

        void AddSections(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();

            paragraph = section.AddParagraph();
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Font.Bold = true;

            if (ContactName != String.Empty)
            {
                paragraph.AddText("Attn, " + ContactName);
                paragraph.AddLineBreak();
            }

            if (CustomerName != String.Empty)
            {
                paragraph.AddText(CustomerName);
                paragraph.AddLineBreak();
            }

            if (Sections.Rows.Count > 0)
            {
                paragraph = section.AddParagraph();
                paragraph.AddLineBreak();
                paragraph.AddText("Por este medio cotizamos como sigue:");
                paragraph.AddLineBreak();
                paragraph.AddLineBreak();

                foreach (DataRow sectionRow in Sections.Rows)
                {
                    AddSection(sectionRow, section);
                }
            }
        }

        void AddSection(DataRow sectionRow, Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Size = 8;
            paragraph.Format.Font.Bold = true;
            paragraph.AddText(sectionRow["Description"].ToString());
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            
            //Add table here
            AddSectionTable(sectionRow, section);

            paragraph = section.AddParagraph();
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
        }

        static Dictionary<string, Color> colorMap = null;
        static Dictionary<string, Color> GetColorMap()
        {
            if(colorMap == null)
            {
                //Copany Fersum
                colorMap = new Dictionary<string, Color>();
                colorMap.Add("1_tableBorder", new Color(81, 125, 192));
                colorMap.Add("1_tableFill", new Color(235, 240, 249));
                colorMap.Add("1_notesFill", new Color(173, 216, 230));//colorMap.Add("1_notesFill", Colors.LightBlue);

                //Company Ayante
                colorMap.Add("2_tableBorder", Colors.Maroon);
                colorMap.Add("2_tableFill", Colors.Coral);
                colorMap.Add("2_notesFill", Colors.Coral);

                //Company undefined
                colorMap.Add("3_tableBorder", new Color(66, 66, 66));
                colorMap.Add("3_tableFill", new Color(189, 189, 189));
                colorMap.Add("3_notesFill", new Color(224, 224, 224));
            }
            return colorMap;
        }
        static Color GetColor(int companyId, string area)
        {
            Dictionary<string, Color> cm = GetColorMap();
            string key = companyId.ToString() + "_" + area;
            if(cm.Keys.Contains(key))
            {
                return cm[key];
            }
            return cm["3_" + area];
        }

        void AddSectionTable(DataRow sectionRow, Section section)
        {
            Table table = section.AddTable();
            table.Borders.Color = GetColor(this.CompanyID, "tableBorder");
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            CreateColumns(table);

            CreateHeader(sectionRow, table);

            CreateDetailRows(sectionRow, table);
            table.SetEdge(0, 0, 9, 3, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        void CreateDetailRows(DataRow sectionRow, Table table)
        {
            DataRow[] detailRows = sectionRow.GetChildRows(this.quotationData.Relations["QSQSD"]);
            Row tableRow;
            foreach (DataRow detailRow in detailRows)
            {                
                tableRow = table.AddRow();
                foreach (ColumnDefinition col in columns)
                {                    
                    if (col.MapsToColumn == "DeliveryDescription")
                    {
                        string deliveryTimeDetails = detailRow[col.MapsToColumn].ToString();
                        if (detailRow["DeliveryTimeDescription"].ToString().Trim() != string.Empty)
                        {
                            deliveryTimeDetails += ", " + detailRow["DeliveryTimeDescription"].ToString();
                        }
                        tableRow.Cells[col.Id].AddParagraph(deliveryTimeDetails);
                    }
                    else
                    {
                        if (col.Format == string.Empty)
                        {
                            tableRow.Cells[col.Id].AddParagraph(detailRow[col.MapsToColumn].ToString());
                        }
                        else
                        {
                            switch (col.MapsToColumn)
                            {
                                case "Quantity":
                                case "Weight":
                                case "LinearWeight":
                                case "TotalPerConcept":
                                    double value;
                                    if (Double.TryParse(detailRow[col.MapsToColumn].ToString(), out value))
                                    {
                                        tableRow.Cells[col.Id].AddParagraph(value.ToString(col.Format));
                                    }
                                    else
                                    {
                                        tableRow.Cells[col.Id].AddParagraph(detailRow[col.MapsToColumn].ToString());
                                    }
                                    break;
                            }
                        }
                    }
                    tableRow.Cells[col.Id].Format.Font.Size = 6;
                }
            }
        }

        void CreateColumns(Table table)
        {
            Column col;

            foreach (ColumnDefinition column in columns)
            {
                col = table.AddColumn(column.Size);
                col.Format.Alignment = ParagraphAlignment.Center;
            }
        }

        class ColumnDefinition
        {
            public ColumnDefinition()
            {
                Header = "";
                Comment = "";
                Size = "";
                MapsToColumn = "";
                Format = "";
            }
            public string Format { get; set; }
            public int Id { get; set; }
            public string Header { get; set; }
            public string Comment { get; set; }
            public string Size { get; set; }
            public string MapsToColumn { get; set; }
        }

        List<ColumnDefinition> columns = new List<ColumnDefinition>();

        void CreateColumnDefinitions()
        {
            int Count = 0;
            ColumnDefinition col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Diámetro";
            col.Comment = "Pulgadas";
            col.Size = "1.2cm";
            col.MapsToColumn = "ShortName";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "";
            col.Comment = "";
            col.Size = "1.2cm";
            col.MapsToColumn = "ExternalDiameterInches";
            columns.Add(col);


            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Espesor de Pared";
            col.Comment = "Pulgadas";
            col.Size = "2.9cm";
            col.MapsToColumn = "Description";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Cantidad Requerida";
            col.Comment = "";
            col.Size = "1.4cm";
            col.Format = "N";
            col.MapsToColumn = "Quantity";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Peso Total";
            col.Comment = "Kgs";
            col.Size = "1.3cm";
            col.Format = "N";
            col.MapsToColumn = "Weight";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Peso Lineal";
            col.Comment = "Kg/m";
            col.Size = "1.3cm";
            col.Format = "F2";
            col.MapsToColumn = "LinearWeight";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Precio";
            //col.Comment = "MN/Metro";
            col.Size = "2cm";
            col.MapsToColumn = "Price";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Total partida";
            col.Size = "2.1cm";
            col.Format = "C2";
            col.MapsToColumn = "TotalPerConcept";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Lugar y Tiempo de Entrega";
            col.Comment = "";
            col.Size = "5.15cm";            
            col.MapsToColumn = "DeliveryDescription";
            columns.Add(col);

            //col = new ColumnDefinition();
            //col.Id = Count++;
            //col.Header = "Tiempo de Entrega";
            //col.Comment = "";
            //col.Size = "2cm";
            //col.MapsToColumn = "DeliveryTimeDescription";
            //columns.Add(col);
        }

        void CreateHeader(DataRow sectionRow, Table table)
        {
            Row row;
            DataRow[] detailRows = sectionRow.GetChildRows(this.quotationData.Relations["QSQSD"]);

            row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Center;
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row.Format.Font.Size = 6;

            foreach (ColumnDefinition col in columns)
            {
                if (col.Id > 1)
                {
                    row.Cells[col.Id].AddParagraph(col.Header);
                    row.Cells[col.Id].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[col.Id].VerticalAlignment = VerticalAlignment.Center;
                    row.Cells[col.Id].MergeDown = 1;
                }
                else
                    if (col.Id == 0)
                    {
                        row.Cells[col.Id].AddParagraph(col.Header);
                        row.Cells[col.Id].Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[col.Id].VerticalAlignment = VerticalAlignment.Center;
                        row.Cells[col.Id].MergeRight = 1;
                    }
            }
            //definimos las celdas Nominal y Exterior
            row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Center;
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row.Format.Font.Size = 6;
            row.Cells[0].AddParagraph("Nominal");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].AddParagraph("Exterior");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

            row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Center;
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row.Format.Font.Size = 6;
            row.Shading.Color = GetColor(this.CompanyID, "tableFill");

            foreach (ColumnDefinition col in columns)
            {
                if (col.Header == "Cantidad Requerida")
                    col.Comment = detailRows[0]["QuantityUnit"].ToString();
                if (col.Header == "Precio")
                    col.Comment = detailRows[0]["CurrencyDescription"].ToString();
                row.Cells[col.Id].AddParagraph(col.Comment);
                row.Cells[col.Id].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[col.Id].VerticalAlignment = VerticalAlignment.Center;
                if (col.Header == "Diámetro")
                {
                    row.Cells[col.Id].MergeRight = 1;
                }
            }
        }

        string FormatDate(DateTime dt)
        {
            string fdt = "";

            #region Day
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    fdt += "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    fdt += "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    fdt += "Miércoles";
                    break;
                case DayOfWeek.Thursday:
                    fdt += "Jueves";
                    break;
                case DayOfWeek.Friday:
                    fdt += "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    fdt += "Sábado";
                    break;
                case DayOfWeek.Sunday:
                    fdt += "Domingo";
                    break;
            }
            #endregion

            fdt += " " + dt.Day.ToString() + " de ";

            #region Month
            switch (dt.Month)
            {
                case 1:
                    fdt += "Enero";
                    break;
                case 2:
                    fdt += "Febrero";
                    break;
                case 3:
                    fdt += "Marzo";
                    break;
                case 4:
                    fdt += "Abril";
                    break;
                case 5:
                    fdt += "Mayo";
                    break;
                case 6:
                    fdt += "Junio";
                    break;
                case 7:
                    fdt += "Julio";
                    break;
                case 8:
                    fdt += "Agosto";
                    break;
                case 9:
                    fdt += "Septiembre";
                    break;
                case 10:
                    fdt += "Octubre";
                    break;
                case 11:
                    fdt += "Noviembre";
                    break;
                case 12:
                    fdt += "Diciembre";
                    break;
            }
            #endregion

            fdt += " de " + dt.Year.ToString();

            return fdt;
        }

        void CreateBottom(Section section)
        {
            if (QuotationData.Rows[0]["Notes"] != null && QuotationData.Rows[0]["Notes"].ToString().Trim() != String.Empty)
            {
                Table table = section.AddTable();

                table.Style = "Table";
                table.Borders.Visible = false;
                table.Rows.VerticalAlignment = VerticalAlignment.Top;

                //Define teh columns
                Column col = table.AddColumn("18.7cm");

                string[] fullNotesText = ("Observaciones:" + Environment.NewLine + QuotationData.Rows[0]["Notes"].ToString()).Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string notesparagraph in fullNotesText)
                {
                    Row row = table.AddRow();
                    row.Format.Alignment = ParagraphAlignment.Left;
                    row.Shading.Color = GetColor(this.CompanyID, "notesFill");
                    var rowParagraph = row.Cells[0].AddParagraph();
                    row.Cells[0].Format.Font.Bold = true;
                    row.Cells[0].Format.Font.Italic = true;
                    row.Cells[0].Format.Font.Size = 8;

                    string[] separator = new string[]{"{t}"};
                    string[] fline = notesparagraph.Split(separator, StringSplitOptions.None);

                    int lineCount = 0;
                    foreach (var xline in fline)
                    {
                        lineCount++;
                        rowParagraph.AddText(xline);
                        if (fline.Count() > 1 && lineCount < fline.Count())
                        {
                            rowParagraph.AddTab();
                        }
                    }
                }
            }

            bool showPaymentCondition = QuotationData.Rows[0]["PaymentDescription"] != null && QuotationData.Rows[0]["PaymentDescription"].ToString().Trim() != String.Empty;
            bool showValidityCondition = QuotationData.Rows[0]["ValidPeriodDescription"] != null && QuotationData.Rows[0]["ValidPeriodDescription"].ToString().Trim() != String.Empty;
            bool showInvoicingCondition = QuotationData.Rows[0]["InvoiceMethodDescription"] != null && QuotationData.Rows[0]["InvoiceMethodDescription"].ToString().Trim() != String.Empty;

            if (showPaymentCondition || showValidityCondition || showInvoicingCondition)
            {
                Paragraph paragraphC = section.AddParagraph();
                paragraphC.Format.Font.Size = 8;
                paragraphC.Format.Font.Bold = true;
                paragraphC.AddLineBreak();
                if(showPaymentCondition)
                {
                    paragraphC.AddText("Forma de pago: ");
                    paragraphC.AddTab();
                    paragraphC.AddTab();
                    paragraphC.AddText(QuotationData.Rows[0]["PaymentDescription"].ToString());
                    paragraphC.AddLineBreak();
                }
                if(showValidityCondition)
                {
                    paragraphC.AddText("Validez de la oferta: ");
                    paragraphC.AddTab();
                    paragraphC.AddText(QuotationData.Rows[0]["ValidPeriodDescription"].ToString());
                    paragraphC.AddLineBreak();
                }
                if(showInvoicingCondition)
                {
                    paragraphC.AddText("Facturación: ");
                    paragraphC.AddTab();
                    paragraphC.AddTab();
                    paragraphC.AddText(QuotationData.Rows[0]["InvoiceMethodDescription"].ToString());
                    paragraphC.AddLineBreak();
                }
            }

            Paragraph paragraphSignature = section.AddParagraph();
            paragraphSignature.Format.Font.Size = 8;
            paragraphSignature.Format.Font.Bold = true;

            paragraphSignature.AddLineBreak();
            paragraphSignature.AddLineBreak();
            paragraphSignature.AddText(this.Signature);
            paragraphSignature.AddLineBreak();
        }

    }
}
