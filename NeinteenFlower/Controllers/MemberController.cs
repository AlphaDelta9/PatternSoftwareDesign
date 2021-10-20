using NeinteenFlower.DataSet;
using NeinteenFlower.Handlers;
using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controllers
{
    public class MemberController
    {
        public static List<MsFlower> GetFlower()
        {
            return FlowerHandler.Get();
        }
        public static MsMember FindMember(Int32 MemberId)
        {
            return MemberHandler.Find(MemberId);
        }

        public static String QuantityCheck(String Quantity)
        {
            if (Int32.TryParse(Quantity, out Int32 Q) && Q > 0 && Q < 101)
            {
                return "";
            }
            else
            {
                return "Must be between 1 to 100 inclusively";
            }
        }
        public static Boolean OrderFlower(Int32 FlowerId, String Quantity, String MemberId)
        {
            return DetailHandler.Insert(FlowerId, Quantity, MemberId);
        }
        public static NeinteenFlowerDataSet Where(Int32 MemberId)
        {
            NeinteenFlowerDataSet DataSet = new NeinteenFlowerDataSet();
            foreach(TrHeader H in HeaderHandler.Where(MemberId))
            {
                DataRow RowHeader = DataSet.TrHeader.NewRow();
                RowHeader["TransactionId"] = H.TransactionId;
                RowHeader["MemberId"] = H.MemberId;
                RowHeader["EmployeeId"] = H.EmployeeId;
                RowHeader["TransactionDate"] = H.TransactionDate.ToShortDateString();
                RowHeader["DiscountPercentage"] = H.DiscountPercentage;
                DataSet.TrHeader.Rows.Add(RowHeader);
                foreach(TrDetail D in H.TrDetails)
                {
                    DataRow RowDetail = DataSet.TrDetail.NewRow();
                    RowDetail["TransactionId"] = D.TransactionId;
                    RowDetail["FlowerId"] = D.FlowerId;
                    RowDetail["Quantity"] = D.Quantity;
                    DataSet.TrDetail.Rows.Add(RowDetail);
                    DataRow Flower = DataSet.MsFlower.NewRow();
                    Flower["FlowerId"] = FlowerHandler.Find(D.FlowerId).FlowerId;
                    Flower["FlowerPrice"] = FlowerHandler.Find(D.FlowerId).FlowerPrice;
                    DataSet.MsFlower.Rows.Add(Flower);
                }
            }
            return DataSet;
        }
    }
}