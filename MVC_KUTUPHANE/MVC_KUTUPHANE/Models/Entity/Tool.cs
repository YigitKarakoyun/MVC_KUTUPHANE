using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_KUTUPHANE.Models.Entity
{
    public class Tool
    {
        
        static DBKUTUPHANEEntities db = null;
        public static DBKUTUPHANEEntities GetKUTUPHANEEntities()
        {
            if (db==null)
            {
                db = new DBKUTUPHANEEntities();
            }
            return db;
        }
    }
}