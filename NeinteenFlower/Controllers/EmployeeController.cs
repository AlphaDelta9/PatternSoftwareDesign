using NeinteenFlower.Handlers;
using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NeinteenFlower.Controllers
{
    public class EmployeeController
    {
        public static MsEmployee Find(Int32 EmployeeId)
        {
            return EmployeeHandler.Find(EmployeeId);
        }
        public static MsEmployee Where(String EmployeeEmail)
        {
            return EmployeeHandler.Where(EmployeeEmail);
        }
        public static List<MsFlower> GetFlower()
        {
            return FlowerHandler.Get();
        }
        public static MsFlower FindFlower(Int32 FlowerId)
        {
            return FlowerHandler.Find(FlowerId);
        }
        public static String NameCheck(String FlowerName)
        {
            if (FlowerName.Length < 1)
            {
                return "Must be filled";
            }
            else if (FlowerName.Length < 5)
            {
                return "minimal length is 5 characters";
            }
            else
            {
                return "";
            }
        }
        public static String ImageCheck(FileUpload FlowerImage)
        {
            if (FlowerImage.HasFile && Path.GetExtension(FlowerImage.PostedFile.FileName).Equals(".jpg"))
            {
                return "";
            }
            else
            {
                return "Extension must ends with “.jpg”";
            }
        }
        public static String DescriptionCheck(String FlowerDescription)
        {
            if (FlowerDescription.Length < 50)
            {
                return "Must be longer than 50 characters";
            }
            else
            {
                return "";
            }
        }
        public static String TypeCheck(String FlowerType)
        {
            if(FlowerType.Equals("Daisies") || FlowerType.Equals("Lilies") || FlowerType.Equals("Roses"))
            {
                return "";
            }
            else
            {
                return "Must be either \"Daisies\", \"Lilies\" or \"Roses\"";
            }
        }
        public static String PriceCheck(String FlowerPrice)
        {
            if(Int32.TryParse(FlowerPrice,out Int32 P))
            {
                if (P < 20 || P > 100)
                {
                    return "Must be between 20 and 100 inclusively";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "Must be numeric";
            }
        }
        public static Boolean InsertFlower(String FlowerName, String FlowerType, String FlowerDescription, String FlowerPrice, FileUpload FlowerImage)
        {
            return FlowerHandler.Insert(FlowerName, FlowerType, FlowerDescription, FlowerPrice, FlowerImage);
        }
        public static Boolean UpdateFlower(Int32 FlowerId, String FlowerName, String FlowerTypeId, String FlowerDescription, String FlowerPrice, FileUpload FlowerImage)
        {
            return FlowerHandler.Update(FlowerId, FlowerName, FlowerTypeId, FlowerDescription, FlowerPrice, FlowerImage);
        }
        public static void DeleteFlower(Int32 FlowerId)
        {
            FlowerHandler.Delete(FlowerId);
        }
        public static MsFlowerType FindType(Int32 FlowerTypeId)
        {
            return FlowerHandler.FindType(FlowerTypeId);
        }
        public static String PasswordCheck(String Password)
        {
            if (Password.Length < 3 || Password.Length > 20)
            {
                return "Minimal length is 3 characters and 20 characters is the maximal";
            }
            else
            {
                return "";
            }
        }
        public static String EmailVerify(String Email)
        {
            if (Email.Length > 4 && new EmailAddressAttribute().IsValid(Email))
            {
                if (Where(Email) == null)
                {
                    return "Must be appropriate";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "Must using a correct email format";
            }
        }
        public static String PasswordVerify(String Email, String Password)
        {
            if (EmployeeHandler.Verify(Email, Password))
            {
                return "";
            }
            else
            {
                return "Must be appropriate";
            }
        }
        public static HttpCookie Remember(String Email, String Password)
        {
            HttpCookie Cookies = new HttpCookie("Member");
            Cookies.Values.Add("Email", Email);
            Cookies.Values.Add("Password", Password);
            Cookies.Expires = DateTime.Now.AddDays(1);
            return Cookies;
        }
        public static HttpCookie Clear()
        {
            HttpCookie Cookies = new HttpCookie("Member");
            Cookies.Expires = DateTime.Now.AddDays(-1);
            return Cookies;
        }
    }
}