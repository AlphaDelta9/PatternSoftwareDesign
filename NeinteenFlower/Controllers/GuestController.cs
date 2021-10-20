using NeinteenFlower.Handlers;
using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controllers
{
    public class GuestController
    {
        public static MsMember Where(String MemberEmail)
        {
            return MemberHandler.Where(MemberEmail);
        }
        public static String MemberEmailCheck(String MemberEmail)
        {
            if (MemberEmail.Length > 4 && new EmailAddressAttribute().IsValid(MemberEmail))
            {
                if (Where(MemberEmail) == null)
                {
                    return "";
                }
                else
                {
                    return "Must be unique";
                }
            }
            else
            {
                return "Must using a correct email format";
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
        public static String NameCheck(String Name)
        {
            if (Name.Length < 3 || Name.Length > 20)
            {
                return "Minimal length is 3 characters and 20 characters is the maximal";
            }
            else
            {
                Int32 F = Name.Length - 1;
                while (F > -1)
                {
                    if (!Char.IsLetter(Name[F]))
                    {
                        return "Must be letter";
                    }
                    F--;
                }
                return "";
            }
        }
        public static String AgeCheck(String DOB)
        {
            DateTime N = DateTime.Now;
            if (DateTime.TryParse(DOB, out DateTime D) && ((N.Year - 17 == D.Year && N.Month >= D.Month && N.Day >= D.Day) || N.Year - 17 > D.Year))
            {
                return "";
            }
            else
            {
                return "Minimal age is 17 years old";
            }
        }
        public static String GenderCheck(String Gender)
        {
            if (String.IsNullOrWhiteSpace(Gender))
            {
                return "Must be chosen";
            }
            else
            {
                return "";
            }
        }
        public static String PhoneCheck(String Phone)
        {
            if (Phone.Length > 0 && Int32.TryParse(Phone, out _))
            {
                return "";
            }
            else
            {
                return "Must be numeric";
            }
        }
        public static String AddressCheck(String Address)
        {
            if (Address.Length > 6 && Address.Contains("Street"))
            {
                return "";
            }
            else
            {
                return "Must contain the word \"Street\"";
            }
        }
        public static Boolean InsertMember(String MemberName, String MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            return MemberHandler.Insert(MemberName, MemberDOB, MemberGender, MemberAddress, MemberPhone, MemberEmail, MemberPassword);
        }
        public static Boolean UpdateMember(Int32 MemberId, String MemberName, String MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            return MemberHandler.Update(MemberId, MemberName, MemberDOB, MemberGender, MemberAddress, MemberPhone, MemberEmail, MemberPassword);
        }
        public static String PasswordVerify(String Email, String Password)
        {
            if (MemberHandler.Verify(Email, Password))
            {
                return "";
            }
            else
            {
                return "Must be appropriate";
            }
        }
        public static String ResetEmailCheck(String MemberEmail)
        {
            if (MemberEmail.Length > 4 && new EmailAddressAttribute().IsValid(MemberEmail))
            {
                if (Where(MemberEmail) == null)
                {
                    return "Email must exist in database";
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
        public static String GetCaptcha()
        {
            return MemberHandler.Captcha();
        }
        public static String CaptchaCheck(String Password, String Captcha)
        {
            if (Password.Equals(Captcha))
            {
                return "";
            }
            else
            {
                return "Must be the same as captcha";
            }
        }
        public static Boolean UpdatePassword(String MemberEmail, String MemberPassword)
        {
            return MemberHandler.UpdatePassword(MemberEmail, MemberPassword);
        }
        public static HttpCookie Remember(String Email, String Password)
        {
            HttpCookie Cookies = new HttpCookie("Member");
            Cookies.Values.Add("Email",Email);
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