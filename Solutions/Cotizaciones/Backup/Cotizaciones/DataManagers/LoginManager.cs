using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;

namespace Cotizaciones.DataManagers
{
    static class LoginManager
    {
        public static bool IsValidUser(string userName, string password)
        {
            bool result = false;
            User u = GetUser(userName);
            if (u != null)
            {
                if (u.Password == password)
                {
                    result = true;
                }
            }
            return result;
        }

        private static User GetUser(string userName)
        {
            FersumDB db = new FersumDB();
            var result = from p in db.Users
                         where p.ShortName == userName
                         select p;
            foreach (var item in result)
            {
                return item;
            }
            return null;
        }
    }
}
