using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repositories
{
    public class DetailRepository
    {
        static NeinteenFlowerDatabaseEntities Database = new NeinteenFlowerDatabaseEntities();
        public static List<TrDetail> Get()
        {
            return Database.TrDetails.ToList();
        }
        public static void Insert(TrDetail Detail)
        {
            Database.TrDetails.Add(Detail);
            Database.SaveChanges();
        }
    }
}