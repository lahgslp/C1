using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections;
using Cotizaciones.DataModel;
using SubSonic.Schema;
using System.Transactions;

namespace Cotizaciones.DataManagers
{
    static class ProductSelectionManager
    {
        private static DataTable CreateViewDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("Diámetro Nominal");
            DataColumn col2 = new DataColumn("Espesor");
            DataColumn col3 = new DataColumn("Cantidad Requerida");
            DataColumn col4 = new DataColumn("Unidad");
            DataColumn col5 = new DataColumn("Peso");
            DataColumn col6 = new DataColumn("TSCB");
            DataColumn col7 = new DataColumn("TSCX52");
            DataColumn col8 = new DataColumn("ERW");
            DataColumn col9 = new DataColumn("LSAW");
            DataColumn col10 = new DataColumn("SSAW");
            DataColumn col11 = new DataColumn("EDITABLE");
            DataColumn col12 = new DataColumn("PipeSpecificationID");
            DataColumn col13 = new DataColumn("QuotationSectionDetailID");

            col1.DataType = System.Type.GetType("System.String");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.Double");
            col4.DataType = System.Type.GetType("System.Int32");
            col5.DataType = System.Type.GetType("System.Double");
            col6.DataType = System.Type.GetType("System.Boolean");
            col7.DataType = System.Type.GetType("System.Boolean");
            col8.DataType = System.Type.GetType("System.Boolean");
            col9.DataType = System.Type.GetType("System.Boolean");
            col10.DataType = System.Type.GetType("System.Boolean");
            col11.DataType = System.Type.GetType("System.Boolean");
            col12.DataType = System.Type.GetType("System.Int32");
            col13.DataType = System.Type.GetType("System.Int32");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col6);
            dt.Columns.Add(col7);
            dt.Columns.Add(col8);
            dt.Columns.Add(col9);
            dt.Columns.Add(col10);
            dt.Columns.Add(col11);
            dt.Columns.Add(col12);
            dt.Columns.Add(col13);

            return dt;
        }

        public static DataTable GetQuotationDetails(int quotationID)
        {
            Hashtable sections = new Hashtable();
            sections.Add(1, "TSCB");
            sections.Add(2, "TSCX52");
            sections.Add(3, "ERW");
            sections.Add(4, "LSAW");
            sections.Add(5, "SSAW");
            sections.Add(6, "EDITABLE");

            DataTable newDT = CreateViewDataTable();
            DataRow updRow;
            DataSet ds = GetQuotationDetailsData(quotationID);

            //This is to transform the DataSet to the one understandable for the view
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                //New row on the datatable
                updRow = newDT.NewRow();
                updRow["Diámetro Nominal"] = row["PDTDescription"].ToString();
                updRow["Espesor"] = row["PSDescription"].ToString();
                updRow["Cantidad Requerida"] = Convert.ToDouble(row["Quantity"]);
                updRow["Unidad"] = Convert.ToInt32(row["UnitTypeID"]);
                updRow["Peso"] = Convert.ToDouble(row["KilogramsPerMeter"]);
                updRow["PipeSpecificationID"] = Convert.ToInt32(row["PipeSpecificationID"]);
                updRow["QuotationSectionDetailID"] = Convert.ToInt32(row["QuotationSectionDetailID"]);
                foreach (string s in sections.Values)
                {
                    updRow[s] = false;
                }
                updRow[sections[Convert.ToInt32(row["SectionTypeID"])].ToString()] = true;
                newDT.Rows.Add(updRow);
            }
            return newDT;
        }

        private static DataSet GetQuotationDetailsData(int quotationID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationProductSelectionByQuotationID(quotationID);
            return sp.ExecuteDataSet();
        }

        public static void UpdateQuotationDetails(int quotationID, string user, DataTable quotationDetails, DataTable originalDetails, Hashtable sections)
        {
            Hashtable includedSections = new Hashtable();

            DataRow[] originalRows;
            DataRow originalRow;

            //To remove the unused pipespecs
            CheckQuotationDetails(quotationID, quotationDetails, originalDetails, sections, includedSections);

            //To create the sections
            foreach (DataRow row in quotationDetails.Rows)
            {
                if (originalDetails.Rows.Count > 0)
                {
                    originalRow = null;
                    originalRows = originalDetails.Select("QuotationSectionDetailID = " + row["QuotationSectionDetailID"].ToString());
                    if (originalRows.Length == 1)
                    {
                        originalRow = originalRows[0];
                    }
                    /*else
                    {
                        throw new Exception("Unable to find product on previous DataTable");
                    }*/
                }
                else
                {
                    originalRow = null;
                }
                foreach (string sectionName in sections.Keys)
                {
                    CreateQuotationSectionDetails(quotationID, user, sectionName, Convert.ToInt32(sections[sectionName]), includedSections, row, originalRow);
                }
            }
            RemoveFloatingQuotationSections(quotationID);
        }

        private static void CheckQuotationDetails(int quotationID, DataTable updatedDetails, DataTable originalDetails, Hashtable sections, Hashtable includedSections)
        {
            DataRow[] rows;
            if (originalDetails.Rows.Count == 0)
                return;
            foreach(DataRow row in originalDetails.Rows)
            {
                rows = updatedDetails.Select("QuotationSectionDetailID = " + row["QuotationSectionDetailID"].ToString());
                if (rows.Length == 0)
                {
                    //Remove the details from the DB
                    RemoveQuotationDetails(quotationID, Convert.ToInt32(row["QuotationSectionDetailID"]));
                }
                else
                {
                    AddExistingSections(quotationID, row, sections, includedSections);
                }
            }
        }

        private static void AddExistingSections(int quotationID, DataRow row, Hashtable sections, Hashtable includedSections)
        {
            int quotationSectionID;
            foreach (string sectionName in sections.Keys)
            {
                if (Convert.ToBoolean(row[sectionName]) == true)
                {
                    if (!includedSections.ContainsKey(sectionName))
                    {
                        quotationSectionID = GetQuotationSectionID(quotationID, Convert.ToInt32(sections[sectionName]));
                        if (quotationSectionID != 0)
                        {
                            includedSections.Add(sectionName, quotationSectionID);
                        }
                    }
                }
            }
        }

        private static void RemoveQuotationDetails(int quotationID, int QuotationSectionDetailID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Del_RemoveQuotationSectionDetailByQuotationID(quotationID, QuotationSectionDetailID);
            sp.Execute();
        }

        private static void RemoveQuotationDetailsByQuotationSectionDetailID(int quotationID, int QuotationSectionDetailID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID(quotationID, QuotationSectionDetailID);
            sp.Execute();
        }

        private static void RemoveFloatingQuotationSections(int quotationID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID(quotationID);
            sp.Execute();
        }

        private static int GetQuotationSectionID(int quotationID, int sectionTypeID)
        {
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetQuotationSectionID(quotationID, sectionTypeID);
            return sp.ExecuteScalar<Int32>();
        }

        private static void CreateQuotationSectionDetails(int quotationID, string user, string sectionName, int sectionTypeID, Hashtable sections, DataRow row, DataRow originalRow)
        {
            int quotationSectionID;
            if ((originalRow == null && Convert.ToBoolean(row[sectionName])) || (originalRow != null && Convert.ToBoolean(row[sectionName]) == true && Convert.ToBoolean(originalRow[sectionName]) == false))
            {
                //if it's new or if it was false and now is true
                if (!sections.ContainsKey(sectionName))
                {
                    quotationSectionID = InsertQuotationSection(quotationID, user, sectionTypeID, row);
                    sections.Add(sectionName, quotationSectionID);
                }
                InsertQuotationSectionDetail(Convert.ToInt32(sections[sectionName]), user, row);
            }
            else if (originalRow != null && Convert.ToBoolean(row[sectionName]) == true && Convert.ToBoolean(originalRow[sectionName]) == true)
            {
                //Update the details
                UpdateQuotationSectionDetail(user, row);
            }
            else if (originalRow != null && Convert.ToBoolean(row[sectionName]) == false && Convert.ToBoolean(originalRow[sectionName]) == true)
            {
                //if it was true and now it's false
                RemoveQuotationDetailsByQuotationSectionDetailID(quotationID, Convert.ToInt32(row["QuotationSectionDetailID"]));
            }
        }

        private static int InsertQuotationSection(int quotationID, string user, int sectionTypeID, DataRow row)
        {
            QuotationSection qs = new QuotationSection();
            qs.QuotationID = quotationID;
            qs.SectionTypeID = sectionTypeID;
            qs.SectionDescription = "";
            //qs.Quantity = Convert.ToDecimal(row["Quantity"]);
            //qs.UnitTypeID = Convert.ToInt32(row["UnitTypeID"]);
            qs.Active = "A";
            qs.Created = DateTime.Now;
            qs.Creator = user;
            qs.Add();
            return qs.QuotationSectionID;
        }

        private static int InsertQuotationSectionDetail(int quotationSectionID, string user, DataRow row)
        {
            QuotationSectionDetail qsd = new QuotationSectionDetail();
            qsd.QuotationSectionID = quotationSectionID;
            qsd.PipeSpecificationID = Convert.ToInt32(row["PipeSpecificationID"]);
            qsd.Quantity = Convert.ToDecimal(row["Quantity"]);
            qsd.UnitTypeID = Convert.ToInt32(row["UnitTypeID"]);

            qsd.Price = 0;
            qsd.DeliveryDescription = "";
            //qsd.PaymentDescription = "";
            qsd.DeliveryTimeDescription = "";
            qsd.CurrencyDescription = "";
            switch (qsd.UnitTypeID)
            {
                case 1:
                    //Metros
                    qsd.Weight = (Convert.ToDouble(row["Weight"]) * Convert.ToDouble(row["Quantity"])).ToString("#,###,##0.00");
                    break;
                case 2:
                    //Toneladas
                    qsd.Weight = (1000 * Convert.ToDouble(row["Quantity"])).ToString("#,###,##0.00");
                    break;
                default:
                    qsd.Weight = "Variable";
                    break;
            }

            qsd.Active = "A";
            qsd.Created = DateTime.Now;
            qsd.Creator = user;
            qsd.Add();
            return qsd.QuotationSectionDetailID;
        }

        private static void UpdateQuotationSectionDetail(string user, DataRow row)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.QuotationSectionDetails
                         where p.QuotationSectionDetailID == Convert.ToInt32(row["QuotationSectionDetailID"])
                         select p;
            foreach (QuotationSectionDetail qsd in result)
            {
                qsd.SetIsLoaded(true);
                //qsd.QuotationSectionID = quotationSectionID;
                qsd.PipeSpecificationID = Convert.ToInt32(row["PipeSpecificationID"]);
                qsd.Quantity = Convert.ToDecimal(row["Quantity"]);
                qsd.UnitTypeID = Convert.ToInt32(row["UnitTypeID"]);
                switch (qsd.UnitTypeID)
                {
                    case 1:
                        //Metros
                        qsd.Weight = (Convert.ToDouble(row["Weight"]) * Convert.ToDouble(row["Quantity"])).ToString("#,###,##0.00");
                        break;
                    case 2:
                        //Toneladas
                        qsd.Weight = (1000 * Convert.ToDouble(row["Quantity"])).ToString("#,###,##0.00");
                        break;
                    default:
                        qsd.Weight = "Variable";
                        break;
                }
                //qsd.Active = "A";
                qsd.Modified = DateTime.Now;
                qsd.Modifier = user;
                qsd.SetIsNew(false);
                qsd.Save();
            }
        }
    }
}
