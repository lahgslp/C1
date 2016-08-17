using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;
using System.IO;

namespace DBNavigator
{
    public partial class DBNavigator : Form
    {
        #region Data members
        DataSet dsDBTables = new DataSet();
        DataSet dsDBViews = new DataSet();
        DataSet dsDBSynonyms = new DataSet();
        DataSet dsDBFavQueries = new DataSet();

        DataBase dbSelected = new DataBase();

        DataBaseHandler dbHandler = new DataBaseHandler();

        XmlDocument xmldoc = new XmlDocument();

        ArrayList dbList;
        ArrayList spList = new ArrayList();
        ArrayList fnList = new ArrayList();

        #region For query creation
        string TableName;
        QueryColumn Column = new QueryColumn();
        ArrayList Columns = new ArrayList();
        #endregion
        #endregion Data members

        public DBNavigator()
        {
            InitializeComponent();
            LoadConfigFile();
        }

        void LoadConfigFile()
        {
            xmldoc.Load("Config.xml");
        }

        void SaveConfigFile()
        {
            xmldoc.Save("Config.xml");
        }

        private void DBNavigator_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.cmbDataBases.Items.Clear();
            dbList = dbHandler.GetDatabaseList();
            foreach (DataBase dbObj in dbList)
            {
                this.cmbDataBases.Items.Add(dbObj.Name);
                if (xmldoc["DBNavigator"]["LastUsedDB"].Attributes["name"].Value == dbObj.Name)
                {
                    dbSelected.Name = dbObj.Name;
                    dbSelected.Conn = dbObj.Conn;
                }
            }
            this.txtFastQuery.Text = xmldoc["DBNavigator"]["LastUsedQuery"].InnerText;
            this.cmbDataBases.SelectedItem = xmldoc["DBNavigator"]["LastUsedDB"].Attributes["name"].Value;
            this.txtFilter.Focus();
        }

        private void cmbDataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            xmldoc["DBNavigator"]["LastUsedDB"].Attributes["name"].Value = this.cmbDataBases.SelectedItem.ToString();
            foreach (DataBase dbObj in dbList)
            {
                if (xmldoc["DBNavigator"]["LastUsedDB"].Attributes["name"].Value == dbObj.Name)
                {
                    dbSelected.Name = dbObj.Name;
                    dbSelected.Conn = dbObj.Conn;
                }
            }
            SaveConfigFile();
            LoadUltraGridTables();
            LoadUltraGridViews();
            LoadSPCombo();
            LoadFnCombo();
            LoadUltraGridSynonyms();
            LoadUltraGridFavoriteQueries();
            this.ultraGridDBTables.DataSource = this.FilterDataSet(this.dsDBTables, this.txtFilter.Text, this.txtTblColFilter.Text);
            this.ultraGridViews.DataSource = this.FilterDataSet(this.dsDBViews, this.txtFilterViews.Text, this.txtViewColFilter.Text);
            this.txtFilter.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor tmpCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                LoadXmlTables();
                LoadXmlViews();
                LoadXmlSPs();
                LoadXmlFns();
                LoadXmlSynonyms();
                LoadXmlFavoriteQueries();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            this.Cursor = tmpCursor;
        }

        private void LoadXmlTables()
        {
            SqlConnection conn = new SqlConnection(dbSelected.Conn);

            conn.Open();

            string cmdRetrieveXmlColumn = "";
            cmdRetrieveXmlColumn += "SELECT UserTable.name AS TableName, UserTable.crdate AS Created, ";
            cmdRetrieveXmlColumn += "   UserTableColumn.name AS ColumnName, type_name(UserTableColumn.xusertype) AS Type, ";
            cmdRetrieveXmlColumn += "	UserTableColumn.length AS ColumnLength, CASE WHEN UserTableColumn.isnullable = 0 THEN 'No' ELSE 'Yes' END AS Nullable ";
            cmdRetrieveXmlColumn += "FROM sysobjects UserTable INNER JOIN syscolumns UserTableColumn ON UserTable.id = UserTableColumn.id ";
            cmdRetrieveXmlColumn += "WHERE UserTable.type='U' ";
            cmdRetrieveXmlColumn += "ORDER BY UserTable.name ";
            cmdRetrieveXmlColumn += "FOR XML AUTO ";

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = cmdRetrieveXmlColumn;
            command.CommandType = CommandType.Text;

            // execute the command that returns a SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            FileInfo t = new FileInfo(dbSelected.File);
            StreamWriter Tex = t.CreateText();
            //Tex.WriteLine("<DataBaseTables DataBaseName=\"" + dbSelected.Name + "\">");
            Tex.WriteLine("<DataBaseTables>");

            // display the results
            while (reader.Read())
            {
                Tex.Write(reader[0].ToString());
            }

            Tex.WriteLine("</DataBaseTables>");
            Tex.Close();

            // close the connection
            reader.Close();
            conn.Close();
            LoadUltraGridTables();
        }

        private void LoadXmlViews()
        {
            SqlConnection conn = new SqlConnection(dbSelected.Conn);

            conn.Open();

            string cmdRetrieveXmlColumn = "";
            cmdRetrieveXmlColumn += "SELECT UserTable.name AS TableName, UserTable.crdate AS Created, ";
            cmdRetrieveXmlColumn += "   UserTableColumn.name AS ColumnName, type_name(UserTableColumn.xusertype) AS Type, ";
            cmdRetrieveXmlColumn += "	UserTableColumn.length AS ColumnLength, CASE WHEN UserTableColumn.isnullable = 0 THEN 'No' ELSE 'Yes' END AS Nullable ";
            cmdRetrieveXmlColumn += "FROM sysobjects UserTable INNER JOIN syscolumns UserTableColumn ON UserTable.id = UserTableColumn.id ";
            cmdRetrieveXmlColumn += "WHERE UserTable.type='V' ";
            cmdRetrieveXmlColumn += "ORDER BY UserTable.name ";
            cmdRetrieveXmlColumn += "FOR XML AUTO ";

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = cmdRetrieveXmlColumn;
            command.CommandType = CommandType.Text;

            // execute the command that returns a SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            FileInfo t = new FileInfo(dbSelected.File_View);
            StreamWriter Tex = t.CreateText();
            //Tex.WriteLine("<DataBaseTables DataBaseName=\"" + dbSelected.Name + "\">");
            Tex.WriteLine("<DataBaseViews>");

            // display the results
            while (reader.Read())
            {
                Tex.Write(reader[0].ToString());
            }

            Tex.WriteLine("</DataBaseViews>");
            Tex.Close();

            // close the connection
            reader.Close();
            conn.Close();
            LoadUltraGridViews();
        }

        private void LoadXmlSPs()
        {
            SqlConnection conn = new SqlConnection(dbSelected.Conn);

            conn.Open();

            string cmdRetrieveXmlColumn = "SELECT name AS SP_Name FROM sysobjects SP WHERE xtype = 'P' ORDER BY name FOR XML AUTO ";

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = cmdRetrieveXmlColumn;
            command.CommandType = CommandType.Text;

            // execute the command that returns a SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            FileInfo t = new FileInfo(dbSelected.File_SP);
            StreamWriter Tex = t.CreateText();
            //Tex.WriteLine("<DataBaseTables DataBaseName=\"" + dbSelected.Name + "\">");
            Tex.WriteLine("<DataBaseSP>");

            // display the results
            while (reader.Read())
            {
                Tex.Write(reader[0].ToString());
            }

            Tex.WriteLine("</DataBaseSP>");
            Tex.Close();

            // close the connection
            reader.Close();
            conn.Close();
            LoadSPCombo();
        }

        private void LoadXmlFns()
        {
            SqlConnection conn = new SqlConnection(dbSelected.Conn);

            conn.Open();

            string cmdRetrieveXmlColumn = "SELECT name AS Fn_Name FROM sysobjects Fn WHERE xtype = 'FN' ORDER BY name FOR XML AUTO ";

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = cmdRetrieveXmlColumn;
            command.CommandType = CommandType.Text;

            // execute the command that returns a SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            FileInfo t = new FileInfo(dbSelected.File_Fn);
            StreamWriter Tex = t.CreateText();
            //Tex.WriteLine("<DataBaseTables DataBaseName=\"" + dbSelected.Name + "\">");
            Tex.WriteLine("<DataBaseFn>");

            // display the results
            while (reader.Read())
            {
                Tex.Write(reader[0].ToString());
            }

            Tex.WriteLine("</DataBaseFn>");
            Tex.Close();

            // close the connection
            reader.Close();
            conn.Close();
            LoadFnCombo();
        }

        private void LoadXmlSynonyms()
        {
            SqlConnection conn = new SqlConnection(dbSelected.Conn);

            conn.Open();

            string cmdRetrieveXmlColumn = "";
            cmdRetrieveXmlColumn += "SELECT name AS Name, base_object_name as Value FROM sys.synonyms Synonym";
            cmdRetrieveXmlColumn += " ORDER BY name FOR XML AUTO";

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = cmdRetrieveXmlColumn;
            command.CommandType = CommandType.Text;

            // execute the command that returns a SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            FileInfo t = new FileInfo(dbSelected.File_Synonym);
            StreamWriter Tex = t.CreateText();
            //Tex.WriteLine("<DataBaseTables DataBaseName=\"" + dbSelected.Name + "\">");
            Tex.WriteLine("<DataBaseSynonyms>");

            // display the results
            while (reader.Read())
            {
                Tex.Write(reader[0].ToString());
            }

            Tex.WriteLine("</DataBaseSynonyms>");
            Tex.Close();

            // close the connection
            reader.Close();
            conn.Close();
            LoadUltraGridSynonyms();
        }

        private void LoadXmlFavoriteQueries()
        {

            FileInfo t = new FileInfo(dbSelected.File_FavQueries);
            if (t.Exists == false)
            {
                StreamWriter Tex = t.CreateText();
                //Tex.WriteLine("<DataBaseTables DataBaseName=\"" + dbSelected.Name + "\">");
                Tex.WriteLine("<FavoriteQueries><FavoriteQuery><Name>Query1</Name><SQLText></SQLText></FavoriteQuery></FavoriteQueries>");
                Tex.Close();
            }
            LoadUltraGridFavoriteQueries();
        }

        private void LoadUltraGridTables()
        {
            this.ultraGridDBTables.DataSource = null;
            this.dsDBTables.Clear();

            if (System.IO.File.Exists(dbSelected.File) == false)
                return;

            System.IO.FileStream fsReadXml = new System.IO.FileStream
                (dbSelected.File, System.IO.FileMode.Open);
            try
            {
                dsDBTables.ReadXml(fsReadXml);
                this.ultraGridDBTables.DataSource = dsDBTables;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fsReadXml.Close();
            }
        }

        private void LoadUltraGridViews()
        {
            this.ultraGridViews.DataSource = null;
            this.dsDBViews.Clear();

            if (System.IO.File.Exists(dbSelected.File_View) == false)
                return;

            System.IO.FileStream fsReadXml = new System.IO.FileStream
                (dbSelected.File_View, System.IO.FileMode.Open);
            try
            {
                dsDBViews.ReadXml(fsReadXml);
                this.ultraGridViews.DataSource = dsDBViews;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fsReadXml.Close();
            }
        }

        private void LoadUltraGridSynonyms()
        {
            this.ultraGridSynonyms.DataSource = null;
            this.dsDBSynonyms.Clear();

            if (System.IO.File.Exists(dbSelected.File_Synonym) == false)
                return;

            System.IO.FileStream fsReadXml = new System.IO.FileStream
                (dbSelected.File_Synonym, System.IO.FileMode.Open);
            try
            {
                this.dsDBSynonyms.ReadXml(fsReadXml);
                this.ultraGridSynonyms.DataSource = this.dsDBSynonyms;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fsReadXml.Close();
            }
        }

        private void LoadUltraGridFavoriteQueries()
        {
            this.ultraGridDBFavoriteQueries.DataSource = null;
            this.dsDBFavQueries.Clear();

            if (System.IO.File.Exists(dbSelected.File_FavQueries) == false)
                return;

            System.IO.FileStream fsReadXml = new System.IO.FileStream
                (dbSelected.File_FavQueries, System.IO.FileMode.Open);
            try
            {
                this.dsDBFavQueries.ReadXml(fsReadXml);
                this.AddDefaultFavQueryRow();
                this.ultraGridDBFavoriteQueries.DataSource = this.dsDBFavQueries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fsReadXml.Close();
            }
        }

        void AddDefaultFavQueryRow()
        {
            //This is in case the user deletes all rows
            if (dsDBFavQueries.Tables.Count == 0 || (dsDBFavQueries.Tables.Count == 1 && dsDBFavQueries.Tables[0].Columns.Count == 1))
            {/*
                DataColumn dcName = new DataColumn("Name");
                DataColumn dcSQLText = new DataColumn("SQLText");
                DataTable dtFQ = new DataTable("FavoriteQuery");
                dtFQ.Columns.Add(dcName);
                dtFQ.Columns.Add(dcSQLText);
                dsDBFavQueries.Clear();
                dsDBFavQueries.Tables.Add(dtFQ);
                dsDBFavQueries.DataSetName = "FavoriteQueries";*/
            }
        }

        private void LoadSPCombo()
        {
            if (System.IO.File.Exists(dbSelected.File_SP) == false)
                return;

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(dbSelected.File_SP);

            this.lstSPNames.Items.Clear();
            this.spList.Clear();

            try
            {
                foreach (XmlNode node in xmldoc["DataBaseSP"].ChildNodes)
                {
                    this.lstSPNames.Items.Add(node.Attributes["SP_Name"].Value);
                    this.spList.Add(node.Attributes["SP_Name"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void LoadFnCombo()
        {
            if (System.IO.File.Exists(dbSelected.File_Fn) == false)
                return;

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(dbSelected.File_Fn);

            this.lstFnNames.Items.Clear();
            this.fnList.Clear();

            try
            {
                foreach (XmlNode node in xmldoc["DataBaseFn"].ChildNodes)
                {
                    this.lstFnNames.Items.Add(node.Attributes["Fn_Name"].Value);
                    this.fnList.Add(node.Attributes["Fn_Name"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilter.Text != "" || this.txtTblColFilter.Text != "")
            {
                this.ultraGridDBTables.DataSource = this.FilterDataSet(this.dsDBTables, this.txtFilter.Text, this.txtTblColFilter.Text);
            }
            else
            {
                this.ultraGridDBTables.DataSource = this.dsDBTables;
            }
        }

        private void txtTblColFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilter.Text != "" || this.txtTblColFilter.Text != "")
            {
                this.ultraGridDBTables.DataSource = this.FilterDataSet(this.dsDBTables, this.txtFilter.Text, this.txtTblColFilter.Text);
            }
            else
            {
                this.ultraGridDBTables.DataSource = this.dsDBTables;
            }
        }

        private void txtFilterViews_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilterViews.Text != "" || this.txtViewColFilter.Text != "")
            {
                this.ultraGridViews.DataSource = this.FilterDataSet(this.dsDBViews, this.txtFilterViews.Text, this.txtViewColFilter.Text);
            }
            else
            {
                this.ultraGridViews.DataSource = this.dsDBViews;
            }
        }

        private void txtViewColFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilterViews.Text != "" || this.txtViewColFilter.Text != "")
            {
                this.ultraGridViews.DataSource = this.FilterDataSet(this.dsDBViews, this.txtFilterViews.Text, this.txtViewColFilter.Text);
            }
            else
            {
                this.ultraGridViews.DataSource = this.dsDBViews;
            }
        }

        private bool CheckDatasetForColumns(DataSet dsDBParam, string txtUserTableId, string txtColumnFilter)
        {
            if (txtColumnFilter == "")
                return true;
            DataRow[] drUTC = dsDBParam.Tables["UserTableColumn"].Select("UserTable_Id = " + txtUserTableId + " AND ColumnName LIKE '%" + txtColumnFilter + "%'");
            foreach (DataRow dr in drUTC)
            {
                return true;
            }
            return false;
        }

        private DataSet FilterDataSet(DataSet dsDBParam, string txtFilter, string txtColumnFilter)
        {
            try
            {
                DataSet dsRes = new DataSet();
                DataTable dtTable = new DataTable();
                DataTable dtColumn = new DataTable();

                dtTable = dsDBParam.Tables["UserTable"].Clone();
                dtColumn = dsDBParam.Tables["UserTableColumn"].Clone();

                string strTableValues = "";
                DataRow[] drTableArray = dsDBParam.Tables["UserTable"].Select("TableName LIKE '%" + txtFilter + "%'");
                foreach (DataRow dr in drTableArray)
                {
                    DataRow drTableNew = dtTable.NewRow();
                    if (CheckDatasetForColumns(dsDBParam, dr["UserTable_Id"].ToString(), txtColumnFilter) == true)
                    {
                        strTableValues += dr["UserTable_Id"] + ",";
                        drTableNew["UserTable_Id"] = dr["UserTable_Id"];
                        drTableNew["TableName"] = dr["TableName"];
                        drTableNew["Created"] = dr["Created"];
                        dtTable.Rows.Add(drTableNew);
                    }
                }
                if (strTableValues != "")
                {
                    //Filtering columns
                    strTableValues = strTableValues.Substring(0, strTableValues.Length - 1);
                    strTableValues = "UserTable_Id IN(" + strTableValues + ") AND ColumnName LIKE '%" + txtColumnFilter + "%'";
                    DataRow[] drColumnArray = dsDBParam.Tables["UserTableColumn"].Select(strTableValues);
                    foreach (DataRow dr in drColumnArray)
                    {
                        //Me quede agregando los elementos a la tabla de archivos
                        DataRow drColumnNew = dtColumn.NewRow();
                        drColumnNew["UserTable_Id"] = dr["UserTable_Id"];
                        drColumnNew["ColumnName"] = dr["ColumnName"];
                        drColumnNew["Type"] = dr["Type"];
                        drColumnNew["ColumnLength"] = dr["ColumnLength"];
                        drColumnNew["Nullable"] = dr["Nullable"];
                        dtColumn.Rows.Add(drColumnNew);
                    }
                }
                dsRes.Tables.Add(dtTable);
                dsRes.Tables.Add(dtColumn);

                DataRelation drRelation = new DataRelation("UserTable_UserTableColumn", dsRes.Tables["UserTable"].Columns["UserTable_Id"], dsRes.Tables["UserTableColumn"].Columns["UserTable_id"]);
                dsRes.Relations.Add(drRelation);

                return dsRes;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        private void lstSPNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.lstSPNames.SelectedItem.ToString());
            if (this.lstSPNames.SelectedItem != null)
            {
                GetSPScript(this.lstSPNames.SelectedItem.ToString());
            }
            //this.txtSPCode.Text = "sp_helptext " + this.lstSPNames.SelectedItem.ToString() + ";";
        }

        private void GetSPScript(string spName)
        {
            Cursor tmpCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string tmpSPCode = "";
            try
            {
                SqlConnection conn = new SqlConnection(dbSelected.Conn);
                DataSet ds = new DataSet();
                conn.Open();

                string cmdRetrieveXmlColumn = "";
                cmdRetrieveXmlColumn += "sp_helptext " + spName;
                SqlCommand command = conn.CreateCommand();
                command.CommandText = cmdRetrieveXmlColumn;
                command.CommandType = CommandType.Text;

                // execute the command that returns a SqlDataReader
                SqlDataReader reader = command.ExecuteReader();

                //// display the results
                while (reader.Read())
                {
                    tmpSPCode += reader[0].ToString();
                }

                this.txtSPCode.Text = tmpSPCode;

                // close the connection
                reader.Close();
                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.Cursor = tmpCursor;
            }
        }

        private void txtFilterSP_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilterSP.Text != "")
            {
                this.lstSPNames.Items.Clear();
                foreach (string str in this.spList)
                {
                    if (str.ToLower().Contains(this.txtFilterSP.Text.ToLower()))
                    {
                        this.lstSPNames.Items.Add(str);
                    }
                }
            }
            else
            {
                this.lstSPNames.Items.Clear();
                foreach (string str in this.spList)
                {
                    this.lstSPNames.Items.Add(str);
                }
            }
        }

        private void chkSearchInSPs_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFilterSP.Text = "";
            this.txtFilterSP.Enabled = this.chkSearchInSPs.Checked ? false : true;

            this.txtSearchInSP.Text = "";
            this.txtSearchInSP.Enabled = this.chkSearchInSPs.Checked;

            this.btnSearchSPs.Enabled = this.chkSearchInSPs.Checked;

            if (this.chkSearchInSPs.Checked == false)
            {
                this.lstSPNames.Items.Clear();
                foreach (string str in this.spList)
                {
                    this.lstSPNames.Items.Add(str);
                }
            }
        }

        private void btnSearchSPs_Click(object sender, EventArgs e)
        {
            if (this.txtSearchInSP.Text != "")
            {
                Cursor tmpCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    SqlConnection conn = new SqlConnection(dbSelected.Conn);
                    DataSet ds = new DataSet();
                    
                    conn.Open();

                    string cmdRetrieveXmlColumn = "SELECT DISTINCT name FROM sysobjects so INNER JOIN syscomments sc ON so.id = sc.id WHERE so.xtype = 'P' AND text like '%" + txtSearchInSP.Text + "%' ORDER BY name";

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = cmdRetrieveXmlColumn;
                    command.CommandType = CommandType.Text;
                    
                    SqlDataReader reader = command.ExecuteReader();

                    //// display the results
                    this.lstSPNames.Items.Clear();
                    while (reader.Read())
                    {
                        this.lstSPNames.Items.Add(reader[0]);
                    }

                    // close the connection
                    reader.Close();
                    conn.Close();
                }

                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    this.Cursor = tmpCursor;
                }
                this.Cursor = tmpCursor;
            }
        }

        private void txtFastQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                string queryCode;
                if (txtFastQuery.SelectedText != "")
                {
                    queryCode = txtFastQuery.SelectedText;
                }
                else
                {
                    queryCode = txtFastQuery.Text;
                }
                Cursor tmpCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                ExecuteFastQuery(queryCode);
                this.Cursor = tmpCursor;
            }
        }

        private void ExecuteFastQuery(string query)
        {
            try
            {
                this.ultraGridFastQuery.DataSource = null;
                SqlConnection conn = new SqlConnection(dbSelected.Conn);
                conn.Open();
                string s = "SET ROWCOUNT 500\r\n" + query + "\r\nSET ROWCOUNT 0";
                SqlDataAdapter da = new SqlDataAdapter(s,conn);
               
                DataSet ds =new DataSet();

                da.Fill(ds,"Results");

                this.ultraGridFastQuery.DataMember = "Results";
                this.ultraGridFastQuery.DataSource = ds;

                conn.Close();
                SaveLastQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SaveLastQuery()
        {
            xmldoc["DBNavigator"]["LastUsedQuery"].InnerText = this.txtFastQuery.Text;
            SaveConfigFile();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBNavigatorAboutBox frm = new DBNavigatorAboutBox();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                frm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Ultragrid events
        private void ultraGridDBTables_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int deltaX = 26;
                int deltaY = 157;
                Point mousePoint = new Point(e.X, e.Y);
                Infragistics.Win.UIElement element = ((Infragistics.Win.UltraWinGrid.UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell)) as Infragistics.Win.UltraWinGrid.UltraGridCell;
                if (cell != null)
                {
                    //MessageBox.Show(cell.Band.Key.ToString());
                    switch (cell.Band.Key)
                    {
                        case "UserTable":
                            string tableName = cell.Row.Cells["TableName"].Value.ToString();
                            SetQueryData(this.dsDBTables, tableName, "", "");
                            contextMenuTables.Show(this.Left + e.X + deltaX, this.Top + e.Y + deltaY);
                            break;
                        case "UserTable_UserTableColumn":
                            tableName = cell.Row.ParentRow.Cells[1].Value.ToString();
                            string columnName = cell.Row.Cells["ColumnName"].Value.ToString();
                            string columnType = cell.Row.Cells["Type"].Value.ToString();
                            SetQueryData(this.dsDBTables, tableName, columnName, columnType);
                            contextMenuColumns.Show(this.Left + e.X + deltaX, this.Top + e.Y + deltaY);
                            break;
                    }
                }
            }
        }

        private void ultraGridViews_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int deltaX = 26;
                int deltaY = 157;
                Point mousePoint = new Point(e.X, e.Y);
                Infragistics.Win.UIElement element = ((Infragistics.Win.UltraWinGrid.UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell)) as Infragistics.Win.UltraWinGrid.UltraGridCell;
                if (cell != null)
                {
                    //MessageBox.Show(cell.Band.Key.ToString());
                    switch (cell.Band.Key)
                    {
                        case "UserTable":
                            string tableName = cell.Row.Cells["TableName"].Value.ToString();
                            SetQueryData(this.dsDBViews, tableName, "", "");
                            contextMenuTables.Show(this.Left + e.X + deltaX, this.Top + e.Y + deltaY);
                            break;
                        case "UserTable_UserTableColumn":
                            tableName = cell.Row.ParentRow.Cells[1].Value.ToString();
                            string columnName = cell.Row.Cells["ColumnName"].Value.ToString();
                            string columnType = cell.Row.Cells["Type"].Value.ToString();
                            SetQueryData(this.dsDBViews, tableName, columnName, columnType);
                            contextMenuColumns.Show(this.Left + e.X + deltaX, this.Top + e.Y + deltaY);
                            break;
                    }
                }
            }
        }
        #endregion Ultragrid events

        void SetQueryData(DataSet dsTables, string tableName, string columnName, string columnType)
        {
            this.TableName = tableName;
            this.Column.Name = columnName;
            this.Column.Type = columnType;
            GetTableColumns(dsTables, tableName);
        }

        void GetTableColumns(DataSet dsDBParam, string tableName)
        {
            Columns.Clear();

            int UserTableID = 0;
            DataRow[] drParentTableArray = dsDBParam.Tables["UserTable"].Select("TableName = '" + tableName + "'");
            foreach (DataRow dr2 in drParentTableArray)
            {
                UserTableID = Convert.ToInt32(dr2["UserTable_id"].ToString());
            }

            DataRow[] drTableArray = dsDBParam.Tables["UserTableColumn"].Select("UserTable_Id = " + UserTableID.ToString() + "");
            foreach (DataRow dr in drTableArray)
            {
                QueryColumn qc = new QueryColumn();
                qc.Name = dr["ColumnName"].ToString();
                qc.Type = dr["Type"].ToString();
                Columns.Add(qc);
            }
        }

        private void ExecuteQueryConstructor(QueryTypes queryType)
        {
            QueryConstructor queryConst = new QueryConstructor();
            switch(queryType)
            {
                case QueryTypes.Select:
                case QueryTypes.Insert:
                case QueryTypes.Delete:
                case QueryTypes.Update:
                    this.txtFastQuery.Text += "\r" + "\n" + queryConst.ConstructQuery(queryType, this.TableName, this.Column, Columns);
                    SaveLastQuery();
                    break;
                case QueryTypes.TablesWhoReference:
                    ExecuteFastQuery(queryConst.ConstructQuery(queryType, this.TableName, this.Column, Columns));
                    break;
        }
        }

        #region Context menu events
        //Functions for Tables
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Select);
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Insert);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Update);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Delete);
        }
        //Functions for Columns
        private void selectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Select);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Delete);
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.Update);
        }
        #endregion Context menu events

        private void txtFilterSyns_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilterSyns.Text != "")
            {
                this.ultraGridSynonyms.DataSource = this.FilterSynonymsDataSet(this.dsDBSynonyms, this.txtFilterSyns.Text);
            }
            else
            {
                this.ultraGridSynonyms.DataSource = this.dsDBSynonyms;
            }
        }

        private DataSet FilterSynonymsDataSet(DataSet dsDBParam, string txtFilter)
        {
            try
            {
                DataSet dsRes = new DataSet();
                DataTable dtTable = new DataTable();

                dtTable = dsDBParam.Tables["Synonym"].Clone();

                DataRow[] drTableArray = dsDBParam.Tables["Synonym"].Select("Name LIKE '%" + txtFilter + "%' OR Value LIKE '%" + txtFilter + "%'");
                foreach (DataRow dr in drTableArray)
                {
                    DataRow drTableNew = dtTable.NewRow();
                    drTableNew["Name"] = dr["Name"];
                    drTableNew["Value"] = dr["Value"];
                    dtTable.Rows.Add(drTableNew);
                }
                dsRes.Tables.Add(dtTable);
                return dsRes;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        private void txtFilterFn_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFilterFn.Text != "")
            {
                this.lstFnNames.Items.Clear();
                foreach (string str in this.fnList)
                {
                    if (str.ToLower().Contains(this.txtFilterFn.Text.ToLower()))
                    {
                        this.lstFnNames.Items.Add(str);
                    }
                }
            }
            else
            {
                this.lstFnNames.Items.Clear();
                foreach (string str in this.fnList)
                {
                    this.lstFnNames.Items.Add(str);
                }
            }
        }

        private void chkSearchInFns_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFilterFn.Text = "";
            this.txtFilterFn.Enabled = this.chkSearchInFns.Checked ? false : true;

            this.txtSearchInFn.Text = "";
            this.txtSearchInFn.Enabled = this.chkSearchInFns.Checked;

            this.btnSearchFns.Enabled = this.chkSearchInFns.Checked;

            if (this.chkSearchInFns.Checked == false)
            {
                this.lstFnNames.Items.Clear();
                foreach (string str in this.fnList)
                {
                    this.lstFnNames.Items.Add(str);
                }
            }
        }

        private void btnSearchFns_Click(object sender, EventArgs e)
        {
            if (this.txtSearchInFn.Text != "")
            {
                Cursor tmpCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    SqlConnection conn = new SqlConnection(dbSelected.Conn);
                    DataSet ds = new DataSet();

                    conn.Open();

                    string cmdRetrieveXmlColumn = "SELECT DISTINCT name FROM sysobjects so INNER JOIN syscomments sc ON so.id = sc.id WHERE so.xtype = 'FN' AND text like '%" + txtSearchInFn.Text + "%' ORDER BY name";
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = cmdRetrieveXmlColumn;
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();

                    //// display the results
                    this.lstFnNames.Items.Clear();
                    while (reader.Read())
                    {
                        this.lstFnNames.Items.Add(reader[0]);
                    }

                    // close the connection
                    reader.Close();
                    conn.Close();
                }

                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    this.Cursor = tmpCursor;
                }
                this.Cursor = tmpCursor;
            }
        }

        private void lstFnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.lstSPNames.SelectedItem.ToString());
            if (this.lstFnNames.SelectedItem != null)
            {
                GetFnScript(this.lstFnNames.SelectedItem.ToString());
            }
            //this.txtSPCode.Text = "sp_helptext " + this.lstSPNames.SelectedItem.ToString() + ";";
        }

        private void GetFnScript(string fnName)
        {
            Cursor tmpCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string tmpFNCode = "";
            try
            {
                SqlConnection conn = new SqlConnection(dbSelected.Conn);
                DataSet ds = new DataSet();
                conn.Open();

                string cmdRetrieveXmlColumn = "";
                cmdRetrieveXmlColumn += "sp_helptext " + fnName;
                SqlCommand command = conn.CreateCommand();
                command.CommandText = cmdRetrieveXmlColumn;
                command.CommandType = CommandType.Text;

                // execute the command that returns a SqlDataReader
                SqlDataReader reader = command.ExecuteReader();

                //// display the results
                while (reader.Read())
                {
                    tmpFNCode += reader[0].ToString();
                }

                this.txtFnCode.Text = tmpFNCode;

                // close the connection
                reader.Close();
                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.Cursor = tmpCursor;
            }
        }

        private void manageDBsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBManagerForm dlg = new DBManagerForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void tablesWhoreferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteQueryConstructor(QueryTypes.TablesWhoReference);
        }

        void SaveFavoriteQueries()
        {
            if (dsDBFavQueries.Tables[0].Columns.Count == 1)
            {
                dsDBFavQueries.Tables[0].Columns.Add();
            }
            this.dsDBFavQueries.WriteXml(dbSelected.File_FavQueries);
        }

        private void ultraGridDBFavoriteQueries_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveFavoriteQueries();
        }

        private void ultraGridDBFavoriteQueries_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            SaveFavoriteQueries();
        }

        private void ultraGridDBFavoriteQueries_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            SaveFavoriteQueries();
        }
    }
}