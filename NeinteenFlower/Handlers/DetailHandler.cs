using NeinteenFlower.Factories;
using NeinteenFlower.Models;
using NeinteenFlower.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handlers
{
    public class DetailHandler
    {
        public static List<TrDetail> Get()
        {
            return DetailRepository.Get();
        }
        public static Boolean Insert(Int32 FlowerId, String Quantity, String MemberId)
        {
            if(Int32.TryParse(Quantity, out Int32 Q) && Q > 0 && Q < 101)
            {
                HeaderHandler.Insert(Int32.Parse(MemberId));
                DetailRepository.Insert(NeinteenFlowerFactory.InsertDetail(HeaderHandler.Get().LastOrDefault().TransactionId, FlowerId, Q));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}