using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repositories
{
    public class HeaderRepository
    {
        static NeinteenFlowerDatabaseEntities Database = new NeinteenFlowerDatabaseEntities();
        public static List<TrHeader> Get()
        {
            return Database.TrHeaders.ToList();
        }
        public static void Insert(TrHeader Header)
        {
            Database.TrHeaders.Add(Header);
            Database.SaveChanges();
        }
    }
}