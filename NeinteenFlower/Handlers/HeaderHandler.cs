using NeinteenFlower.Factories;
using NeinteenFlower.Models;
using NeinteenFlower.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handlers
{
    public class HeaderHandler
    {
        public static List<TrHeader> Get()
        {
            return HeaderRepository.Get();
        }
        static Random random = new Random();
        public static void Insert(Int32 MemberId)
        {
            HeaderRepository.Insert(NeinteenFlowerFactory.InsertHeader(MemberId, random.Next(EmployeeHandler.Get().FirstOrDefault().EmployeeId,EmployeeHandler.Get().LastOrDefault().EmployeeId), DateTime.Now, random.Next(100)));
        }
        public static List<TrHeader> Where(Int32 MemberId)
        {
            List<TrHeader> Header = new List<TrHeader>();
            foreach(TrHeader H in Get())
            {
                if(H.MemberId == MemberId)
                {
                    Header.Add(H);
                }
            }
            return Header;
        }
    }
}