using System;
using System.Collections.Generic;
using System.Text;

namespace DBNavigator
{
    class DataBase
    {
        string name;
        string conn;
        public DataBase() { }
        public string Name { get { return name; } set { name = value; } }
        public string Conn { get { return conn; } set { conn = value; } }
        public string File { get { return name + "_table.xml"; } }
        public string File_SP { get { return name + "_sp.xml"; } }
        public string File_Fn { get { return name + "_fn.xml"; } }
        public string File_View { get { return name + "_view.xml"; } }
        public string File_Synonym { get { return name + "_synonym.xml"; } }
        public string File_FavQueries { get { return name + "_favqueries.xml"; } }
    }
}
