using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;
using System.Data;
using System.Transactions;

namespace Cotizaciones.DataManagers
{
    class EditDiameterManager
    {
        private void AddColumns(DataTable dt)
        {
            dt.Columns.Add("Activo", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Actualizado", System.Type.GetType("System.Boolean"));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Active"].ToString() == "A")
                    dt.Rows[i]["Activo"] = true;
                else
                    dt.Rows[i]["Activo"] = false;
                dt.Rows[i]["Actualizado"] = false; ;
            }
        }

        public DataSet getDiameter()
        {
            DataSet ds;
            FersumDB fdb = new FersumDB();
            StoredProcedure sp = fdb.Fersum_Sel_GetProductDetails();
            ds = sp.ExecuteDataSet();
            AddColumns(ds.Tables[0]);
            AddColumns(ds.Tables[1]);
            DataRelation rel = new DataRelation("", ds.Tables[0].Columns["PipeDiameterTypeID"], ds.Tables[1].Columns["PipeDiameterTypeID"]);
            ds.Relations.Add(rel);
            return ds;
        }

        public void EditDiameterSave(string user, DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(row["PipeDiameterTypeID"].ToString()) < 0 && row["Active"].ToString() == "I")
                {
                    foreach (DataRow dt in ds.Tables[1].Select("PipeDiameterTypeID = " + Convert.ToInt32(row["PipeDiameterTypeID"].ToString())))
                    {
                        dt["Active"] = "I";
                    }
                }
                else if (Convert.ToInt32(row["PipeDiameterTypeID"].ToString()) > 0)
                {
                    if (Convert.ToBoolean(row["Actualizado"]))
                    {
                        PipeDiameterTypeUpdate(user, row, false);
                    }
                    foreach (DataRow dt in ds.Tables[1].Select("PipeDiameterTypeID = " + Convert.ToInt32(row["PipeDiameterTypeID"].ToString())))
                    {
                        if (Convert.ToBoolean(dt["Actualizado"]))
                        {
                            if (Convert.ToInt32(dt["PipeSpecificationID"].ToString()) > 0)
                            {
                                PipethicknessUpdate(user, dt);
                            }
                            else
                            {
                                if (Convert.ToInt32(dt["PipeSpecificationID"].ToString()) < 0 && dt["Active"].ToString() == "A")
                                {
                                    PipethicknessSave(user, dt);

                                }
                            }
                        }
                    }
                }
                else if (Convert.ToInt32(row["PipeDiameterTypeID"].ToString()) < 0 && row["Active"].ToString() == "A")
                {
                    int PipeDiamterIDOld = Convert.ToInt32(row["PipeDiameterTypeID"].ToString());
                    int PipeDiameterID = PipeDiameterTypeSave(user, row);
                    foreach (DataRow dt in ds.Tables[1].Select("PipeDiameterTypeID = " + PipeDiameterID))
                    {
                        if (dt["Active"].ToString() == "A")
                        {
                            dt["PipeDiameterTypeID"] = PipeDiameterID;
                            PipethicknessSave(user, dt);
                        }
                    }
                }
            }
        }

        private static void PipethicknessSave(string user, DataRow row)
        {
            PipeSpecification ps = new PipeSpecification();
            //ps.PipeSpecificationID = Convert.ToInt32(row["PipeSpecificationID"]);
            ps.WallThicknessInches = Convert.ToDecimal(row["WallThicknessInches"]);
            ps.PipeSchedule = row["PipeSchedule"].ToString();
            ps.PipeClass = row["PipeClass"].ToString();
            ps.PipeDiameterTypeID = Convert.ToInt32(row["PipeDiameterTypeID"]);
            ps.Active = row["Active"].ToString();
            ps.Creator = user;
            ps.Created = DateTime.Now;
            ps.Add();
        }

        private static void PipethicknessUpdate(string user,DataRow row)
        {
            PipeSpecification ps = new PipeSpecification();
            ps.SetIsLoaded(true);
            ps.PipeSpecificationID = Convert.ToInt32(row["PipeSpecificationID"]);
            ps.WallThicknessInches = Convert.ToDecimal(row["WallThicknessInches"]);
            ps.PipeSchedule = row["PipeSchedule"].ToString();
            ps.PipeClass = row["PipeClass"].ToString();
            ps.PipeDiameterTypeID = Convert.ToInt32(row["PipeDiameterTypeID"]);
            ps.Active = row["Active"].ToString();
            ps.Modifier = user;
            ps.Modified = DateTime.Now;
            ps.SetIsNew(false);
            ps.Save();
        }

        private static int PipeDiameterTypeSave(string user, DataRow row)
        {
            PipeDiameterType pdt = new PipeDiameterType();
            //pdt.PipeDiameterTypeID = Convert.ToInt32(row["PipeDiameterTypeID"]);
            pdt.ShortName = row["ShortName"].ToString();
            pdt.Description = "";
            pdt.ExternalDiameterInches = Convert.ToDecimal(row["ExternalDiameterInches"]);
            pdt.Active = row["Active"].ToString();
            pdt.Creator = user;
            pdt.Created = DateTime.Now;
            pdt.Add();
            row["PipeDiameterTypeID"] = pdt.PipeDiameterTypeID;
            return pdt.PipeDiameterTypeID;
        }

        private static void PipeDiameterTypeUpdate(string user, DataRow row, Boolean New)
        {
            PipeDiameterType pdt = new PipeDiameterType();
            pdt.SetIsLoaded(true);
            pdt.PipeDiameterTypeID = Convert.ToInt32(row["PipeDiameterTypeID"]);
            pdt.ShortName = row["ShortName"].ToString();
            pdt.ExternalDiameterInches = Convert.ToDecimal(row["ExternalDiameterInches"]);
            pdt.Active = row["Active"].ToString();
            pdt.Modifier = user;
            pdt.Modified = DateTime.Now;
            pdt.SetIsNew(New);
            pdt.Save();
        }
    }
}
