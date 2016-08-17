using System;
using System.Collections.Generic;
using System.Text;

namespace DBNavigator
{
    public class QueryColumn
    {
        public QueryColumn()
        {
        }
        string name;
        string type;
        public string Name { get { return name; } set { name = value; } }
        public string Type { get { return type; } set { type = value; } }
    }
}
