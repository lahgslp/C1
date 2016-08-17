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

            this.document.Info.Title = "Cotización #" + quotationID.ToString("000000") + " para " + this.CustomerName;
            this.document.Info.Subject = "Cotización " + Properties.Settings.Default.CompanyName + " de materiales para " + this.CustomerName + " del día " + Created;
            this.document.Info.Author = Creator;

            /*Section s = this.document.AddSection();
            
            Paragraph p = s.Footers.Primary.AddParagraph();
            p.AddNumPagesField();
            p.Format.Alignment = ParagraphAlignment.Right;*/

            DefineStyles();

            CreatePage();

            return this.document;
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
            style.Font.Name = Properties.Settings.Default.FontName;

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = Properties.Settings.Default.FontName;
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

            AddLogo(section);
            CreateHeader(section);
            AddSections(section);
            CreateBottom(section);
        }

        void AddLogo(Section section)
        {
            if (Properties.Settings.Default.LogoFile != String.Empty)
            {
                if (System.IO.File.Exists(Properties.Settings.Default.LogoFile))
                {
                    //Image image = section.Headers.Primary.AddImage(Properties.Settings.Default.LogoFile);
                    Image image = section.AddImage(Properties.Settings.Default.LogoFile);
                    image.Height = "2.5cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    //image.WrapFormat.Style = WrapStyle.Through;
                }
            }
        }


        void CreateHeader(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Size = 8;
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            paragraph.AddText(Properties.Settings.Default.CompanyCity + ", " + FormatDate(Convert.ToDateTime(this.Created)));
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
        }

        void AddSections(Section section)
        {
            if (Sections.Rows.Count > 0)
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.Format.Font.Size = 10;
                paragraph.Format.Font.Bold = true;
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph.AddLineBreak();
                paragraph.AddText("Cotización.");
                paragraph.AddLineBreak();

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

        readonly static Color tableBorder = new Color(81, 125, 192);
        readonly static Color tableBlue = new Color(235, 240, 249);

        void AddSectionTable(DataRow sectionRow, Section section)
        {
            Table table = section.AddTable();
            table.Borders.Color = tableBorder;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            CreateColumns(table);

            CreateHeader(table);

            CreateDetailRows(sectionRow, table);
            table.SetEdge(0, 0, 6, 2, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
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
                    tableRow.Cells[col.Id].AddParagraph(detailRow[col.MapsToColumn].ToString());
                    tableRow.Cells[col.Id].Format.Font.Size = 8;
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
            }
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
            col.Header = "Diámetro Nominal";
            col.Comment = "Pulgadas";
            col.Size = "2cm";
            col.MapsToColumn = "ShortName";
            columns.Add(col);

            
            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Espesor";
            col.Comment = "Pulgadas";
            col.Size = "3.5cm";
            col.MapsToColumn = "Description";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Cantidad Requerida";
            //col.Comment = "Metros";
            col.Size = "2cm";
            col.MapsToColumn = "Quantity";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Peso";
            col.Comment = "Kgs";
            col.Size = "2cm";
            col.MapsToColumn = "Weight";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Precio + IVA";
            //col.Comment = "MN/Metro";
            col.Size = "2cm";
            col.MapsToColumn = "Price";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Lugar de Entrega";
            col.Comment = "";
            col.Size = "3.5cm";
            col.MapsToColumn = "DeliveryDescription";
            columns.Add(col);

            col = new ColumnDefinition();
            col.Id = Count++;
            col.Header = "Tiempo de Entrega";
            col.Comment = "";
            col.Size = "2cm";
            col.MapsToColumn = "DeliveryTimeDescription";
            columns.Add(col);
        }

        void CreateHeader(Table table)
        {
            Row row;

            row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Left;
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row.Format.Font.Size = 8;
            //row.Shading.Color = tableBlue;

            foreach (ColumnDefinition col in columns)
            {
                row.Cells[col.Id].AddParagraph(col.Header);
                row.Cells[col.Id].Format.Alignment = ParagraphAlignment.Left;
            }

            row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Left;
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row.Format.Font.Size = 8;
            row.Shading.Color = tableBlue;

            foreach (ColumnDefinition col in columns)
            {
                row.Cells[col.Id].AddParagraph(col.Comment);
                row.Cells[col.Id].Format.Alignment = ParagraphAlignment.Left;
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
                Paragraph paragraphNotes = section.AddParagraph();
                paragraphNotes.Format.Font.Size = 8;
                //paragraphNotes.Format.Font.Bold = true;
                paragraphNotes.Format.Font.Italic = true;
                paragraphNotes.AddText(QuotationData.Rows[0]["Notes"].ToString());
                paragraphNotes.AddLineBreak();
                paragraphNotes.AddLineBreak();
                //paragraphNotes.Format.Font.Italic = false;
            }

            if (QuotationData.Rows[0]["PaymentDescription"] != null && QuotationData.Rows[0]["PaymentDescription"].ToString().Trim() != String.Empty)
            {
                Paragraph paragraphPD = section.AddParagraph();
                paragraphPD.Format.Font.Size = 8;
                paragraphPD.Format.Font.Bold = true;
                paragraphPD.AddLineBreak();
                paragraphPD.AddText("Forma de pago: ");
                paragraphPD.AddTab();
                paragraphPD.AddTab();
                paragraphPD.AddText(QuotationData.Rows[0]["PaymentDescription"].ToString());
                paragraphPD.AddLineBreak();
            }

            if (QuotationData.Rows[0]["ValidPeriodDescription"] != null && QuotationData.Rows[0]["ValidPeriodDescription"].ToString().Trim() != String.Empty)
            {
                Paragraph paragraphVPD = section.AddParagraph();
                paragraphVPD.Format.Font.Size = 8;
                paragraphVPD.Format.Font.Bold = true;
                paragraphVPD.AddLineBreak();
                paragraphVPD.AddText("Validez de la oferta: ");
                paragraphVPD.AddTab();
                paragraphVPD.AddText(QuotationData.Rows[0]["ValidPeriodDescription"].ToString());
                paragraphVPD.AddLineBreak();
            }

            if (QuotationData.Rows[0]["InvoiceMethodDescription"] != null && QuotationData.Rows[0]["InvoiceMethodDescription"].ToString().Trim() != String.Empty)
            {
                Paragraph paragraphIMD = section.AddParagraph();
                paragraphIMD.Format.Font.Size = 8;
                paragraphIMD.Format.Font.Bold = true;
                paragraphIMD.AddLineBreak();
                paragraphIMD.AddText("Facturación: ");
                paragraphIMD.AddTab();
                paragraphIMD.AddText(QuotationData.Rows[0]["InvoiceMethodDescription"].ToString());
                paragraphIMD.AddLineBreak();
            }

            Paragraph paragraphSignature = section.AddParagraph();
            paragraphSignature.Format.Font.Size = 8;
            paragraphSignature.Format.Font.Bold = true;

            paragraphSignature.AddLineBreak();
            paragraphSignature.AddLineBreak();
            paragraphSignature.AddText("Atentamente,");
            paragraphSignature.AddLineBreak();
            paragraphSignature.AddLineBreak();
            paragraphSignature.AddText(QuotationData.Rows[0]["Creator"].ToString());
            paragraphSignature.AddLineBreak();
            if (Properties.Settings.Default.AddCreatorEmailIndicator == true)
            {
                paragraphSignature.AddText(QuotationData.Rows[0]["CreatorEmail"].ToString());
                paragraphSignature.AddLineBreak();
            }
            if (Properties.Settings.Default.SignatureLine1 != String.Empty)
            {
                paragraphSignature.AddText(Properties.Settings.Default.SignatureLine1);
                paragraphSignature.AddLineBreak();
            }
            if (Properties.Settings.Default.SignatureLine2 != String.Empty)
            {
                paragraphSignature.AddText(Properties.Settings.Default.SignatureLine2);
                paragraphSignature.AddLineBreak();
            }
            if (Properties.Settings.Default.SignatureLine3 != String.Empty)
            {
                paragraphSignature.AddText(Properties.Settings.Default.SignatureLine3);
                paragraphSignature.AddLineBreak();
            }
            paragraphSignature.AddText(Properties.Settings.Default.CompanyFullName);
            paragraphSignature.AddLineBreak();
        }

    }
}
