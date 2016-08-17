#define USE_STAR

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace DBNavigator
{
    public enum QueryTypes
    {
        Select,
        Insert,
        Update,
        Delete,
        TablesWhoReference
    }
    public class QueryConstructor
    {
        public QueryConstructor()
        { }

        public string ConstructQuery(QueryTypes queryType, string Table, QueryColumn Column, ArrayList Columns)
        {
            string QueryResult = "";
            switch (queryType)
            {
                case QueryTypes.Select:
                    QueryResult += "SELECT ";
#if USE_STAR
                    QueryResult += "*";
#else
                    foreach (QueryColumn qc in Columns)
                    {
                        QueryResult += qc.Name + ", ";
                    }
                    QueryResult = QueryResult.Substring(0, QueryResult.Length - 2);
#endif
                    QueryResult += " FROM " + Table;
                    if (Column.Name != "")
                    {
                        QueryResult += " WHERE " + GetFieldFormat(Column) + " " + GetComparatorOperator(Column) + " " + GetComparator(Column);
                    }
                    QueryResult += ";";
                    break;
                case QueryTypes.Insert:
                    QueryResult += "INSERT INTO " + Table + "(";
                    foreach (QueryColumn qc in Columns)
                    {
                        QueryResult += qc.Name + ", ";
                    }
                    QueryResult = QueryResult.Substring(0, QueryResult.Length - 2);
                    QueryResult += ") VALUES (";
                    foreach (QueryColumn qc in Columns)
                    {
                        QueryResult += GetComparator(qc) + ", ";
                    }
                    QueryResult = QueryResult.Substring(0, QueryResult.Length - 2);
                    QueryResult += ");";
                    break;
                case QueryTypes.Update:
                    QueryResult += "UPDATE " + Table + " SET ";
                    foreach (QueryColumn qc in Columns)
                    {
                        QueryResult += qc.Name + " = " + GetComparator(qc) + ", ";
                    }
                    QueryResult = QueryResult.Substring(0, QueryResult.Length - 2);
                    if (Column.Name != "")
                    {
                        QueryResult += " WHERE " + GetFieldFormat(Column) + " " + GetComparatorOperator(Column) + " " + GetComparator(Column);
                    }
                    QueryResult += ";";
                    break;
                case QueryTypes.Delete:
                    QueryResult += "DELETE FROM " + Table;
                    if (Column.Name != "")
                    {
                        QueryResult += " WHERE " + GetFieldFormat(Column) + " " + GetComparatorOperator(Column) + " " + GetComparator(Column);
                    }
                    QueryResult += ";";
                    break;
                case QueryTypes.TablesWhoReference:
                    QueryResult += "select object_name(object_id) AS 'Foreign keys for " + Table + "', object_name(parent_object_id) AS 'Referencer'";
                    QueryResult += " from sys.foreign_keys where referenced_object_id = object_id('";
                    QueryResult += Table;
                    QueryResult += "') order by 1";
                    break;
            }
            //System.Windows.Forms.MessageBox.Show(QueryResult);
            return QueryResult;
        }

        string GetFieldFormat(QueryColumn qc)
        {
            string FmtField = "";
            switch (qc.Type)
            {
                case "int":
                case "numeric":
                case "char":
                case "varchar":
                case "decimal":
                    FmtField = qc.Name;
                    break;
                case "datetime":
                    FmtField = "CONVERT(VARCHAR(10), " + qc.Name + ", 110)";
                    break;
            }
            return FmtField;
        }

        string GetComparator(QueryColumn qc)
        {
            string comparator = "";
            switch (qc.Type)
            {
                case "int":
                case "numeric":
                case "decimal":
                    comparator = "?";
                    break;
                case "char":
                    comparator = "'?'";
                    break;
                case "varchar":
                    comparator = "'%?%'";
                    break;
                case "datetime":
                    comparator = "'MM-DD-YYYY'";
                    break;
            }
            return comparator;
        }

        string GetComparatorOperator(QueryColumn qc)
        {
            string comparator = "";
            switch (qc.Type)
            {
                case "int":
                case "numeric":
                case "char":
                case "datetime":
                case "decimal":
                    comparator = "=";
                    break;
                case "varchar":
                    comparator = "LIKE";
                    break;
            }
            return comparator;
        }
    }
}
