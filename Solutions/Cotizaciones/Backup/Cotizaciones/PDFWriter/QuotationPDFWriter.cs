using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Diagnostics;
using Cotizaciones.DataManagers;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
using System.IO;

namespace Cotizaciones.PDFWriter
{
    class QuotationPDFWriter
    {
        public string CreatePDFQuotation(int QuotationID)
        {
            string fileName = "";

            QuotationForm quotation = new QuotationForm(QuotationID);
            Document document = quotation.CreateDocument();
            document.UseCmykColor = true;

            // Create a renderer for PDF that uses Unicode font encoding
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;

            // Create the PDF document
            pdfRenderer.RenderDocument();

            fileName = "C" + QuotationID.ToString("000000") + "-" + quotation.Created + "-" + quotation.CustomerName + "-" + DateTime.Now.Millisecond.ToString("0000") + ".pdf";

            pdfRenderer.Save(fileName);
            // ...and start a viewer.
            //Process.Start(fileName);

            return fileName;
        }
    }
}
