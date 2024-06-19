using Kosy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Repositories
{
    public class DatabaseSingleton
    {
        private static KosyDatabaseEntities db = null;

        public static KosyDatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new KosyDatabaseEntities();
            }
            return db;
        }
    }
}