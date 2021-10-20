using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repositories
{
    public class FlowerRepository
    {
        static NeinteenFlowerDatabaseEntities Database = new NeinteenFlowerDatabaseEntities();
        public static List<MsFlower> Get()
        {
            return Database.MsFlowers.ToList();
        }
        public static MsFlower Find(Int32 FlowerId)
        {
            return Database.MsFlowers.Find(FlowerId);
        }
        public static void Insert(MsFlower Flower)
        {
            Database.MsFlowers.Add(Flower);
            Database.SaveChanges();
        }
        public static void Update(Int32 FlowerId, String FlowerName, Int32 FlowerTypeId, String FlowerDescription, Int32 FlowerPrice, HttpPostedFile FlowerImage)
        {
            MsFlower Flower = Find(FlowerId);
            Flower.FlowerName = FlowerName;
            Flower.FlowerTypeId = FlowerTypeId;
            Flower.FlowerDescription = FlowerDescription;
            Flower.FlowerPrice = FlowerPrice;
            Flower.FlowerImage = "~/Flowers/" + FlowerImage.FileName;
            Database.SaveChanges();
        }
        public static void Delete(Int32 FlowerId)
        {
            Database.MsFlowers.Remove(Find(FlowerId));
            Database.SaveChanges();
        }
        public static MsFlowerType FindType(Int32 FlowerTypeId)
        {
            return Database.MsFlowerTypes.Find(FlowerTypeId);
        }
        public static MsFlowerType Where(String FlowerTypeName)
        {
            return (from E in Database.MsFlowerTypes where E.FlowerTypeName.Equals(FlowerTypeName) select E).FirstOrDefault();
        }
    }
}