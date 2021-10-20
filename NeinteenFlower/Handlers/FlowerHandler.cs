using NeinteenFlower.Factories;
using NeinteenFlower.Models;
using NeinteenFlower.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Handlers
{
    public class FlowerHandler
    {
        public static List<MsFlower> Get()
        {
            return FlowerRepository.Get();
        }
        public static MsFlower Find(Int32 FlowerId)
        {
            return FlowerRepository.Find(FlowerId);
        }
        public static Boolean Insert(String FlowerName, String FlowerType, String FlowerDescription, String FlowerPrice, FileUpload FlowerImage)
        {
            if(NameCheck(FlowerName) && ImageCheck(FlowerImage) && DescriptionCheck(FlowerDescription) && TypeCheck(FlowerType) && PriceCheck(FlowerPrice))
            {
                FlowerImage.SaveAs(HttpContext.Current.Server.MapPath("~/Flowers/" + FlowerImage.PostedFile.FileName));
                FlowerRepository.Insert(NeinteenFlowerFactory.InsertFlower(FlowerName, Where(FlowerType), FlowerDescription, Int32.Parse(FlowerPrice), FlowerImage.PostedFile));
                return true;
            }
            else
            {
                return false;
            }

        }
        public static Boolean Update(Int32 FlowerId, String FlowerName, String FlowerType, String FlowerDescription, String FlowerPrice, FileUpload FlowerImage)
        {
            if (NameCheck(FlowerName) && ImageCheck(FlowerImage) && DescriptionCheck(FlowerDescription) && TypeCheck(FlowerType) && PriceCheck(FlowerPrice))
            {
                FlowerImage.SaveAs(HttpContext.Current.Server.MapPath("~/Flowers/" + FlowerImage.PostedFile.FileName));
                FlowerRepository.Update(FlowerId, FlowerName, Where(FlowerType), FlowerDescription, Int32.Parse(FlowerPrice), FlowerImage.PostedFile);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Delete(Int32 FlowerId)
        {
            FlowerRepository.Delete(FlowerId);
        }

        //
        public static Boolean NameCheck(String FlowerName)
        {
            if (FlowerName.Length < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean ImageCheck(FileUpload FlowerImage)
        {
            if (FlowerImage.HasFile && Path.GetExtension(FlowerImage.PostedFile.FileName).Equals(".jpg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean DescriptionCheck(String FlowerDescription)
        {
            if (FlowerDescription.Length < 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean TypeCheck(String FlowerType)
        {
            if (FlowerType.Equals("Daisies") || FlowerType.Equals("Lilies") || FlowerType.Equals("Roses"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean PriceCheck(String FlowerPrice)
        {
            if (Int32.TryParse(FlowerPrice, out Int32 P))
            {
                if (P < 20 || P > 100)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        //
        public static MsFlowerType FindType(Int32 FlowerTypeId)
        {
            return FlowerRepository.FindType(FlowerTypeId);
        }
        public static Int32 Where(String FlowerTypeName)
        {
            return FlowerRepository.Where(FlowerTypeName).FlowerTypeId;
        }
    }
}