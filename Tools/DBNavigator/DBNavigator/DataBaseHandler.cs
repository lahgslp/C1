using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
namespace DBNavigator
{
    class DataBaseHandler
    {
        XmlDocument xmldoc = new XmlDocument();
        public DataBaseHandler()
        {
        }

        public System.Collections.ArrayList GetDatabaseList()
        {
            ArrayList dbList = new ArrayList();
            xmldoc.Load("DataBases.xml");
            foreach (XmlNode node in xmldoc["DataBases"].ChildNodes)
            {
                DataBase db = new DataBase();
                db.Name = node.Attributes["Name"].Value.ToString();
                db.Conn = node.Attributes["ConnectionString"].Value.ToString();
                dbList.Add(db);
            }
            return dbList;
        }
    }
}
