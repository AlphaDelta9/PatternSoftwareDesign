using NeinteenFlower.Factories;
using NeinteenFlower.Models;
using NeinteenFlower.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NeinteenFlower.Handlers
{
    public class MemberHandler
    {
        public static List<MsMember> Get()
        {
            return MemberRepository.Get();
        }
        public static MsMember Find(Int32 MemberId)
        {
            return MemberRepository.Find(MemberId);
        }
        public static Boolean Insert(String MemberName, String MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            if (EmailCheck(MemberEmail) && PasswordCheck(MemberPassword) && NameCheck(MemberName) && AgeCheck(MemberDOB.ToString()) && GenderCheck(MemberGender) && PhoneCheck(MemberPhone) && AddressCheck(MemberAddress))
            {
                /*MemberRepository.Insert(NeinteenFlowerFactory.InsertMember(MemberName, MemberDOB, MemberGender, MemberAddress, MemberPhone, MemberEmail, MemberPassword));*/
                MemberRepository.Insert(NeinteenFlowerFactory.InsertMember(MemberName, DateTime.Parse(MemberDOB), MemberGender, MemberAddress, MemberPhone, MemberEmail, Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(MemberPassword)))));
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Update(Int32 MemberId, String MemberName, String MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            if (EmailCheckUpdate(MemberEmail, MemberId) && PasswordCheck(MemberPassword) && NameCheck(MemberName) && AgeCheck(MemberDOB.ToString()) && GenderCheck(MemberGender) && PhoneCheck(MemberPhone) && AddressCheck(MemberAddress))
            {
                /*MemberRepository.Update(MemberId, MemberName, MemberDOB, MemberGender, MemberAddress, MemberPhone, MemberEmail, MemberPassword);*/
                MemberRepository.Update(MemberId, MemberName, DateTime.Parse(MemberDOB), MemberGender, MemberAddress, MemberPhone, MemberEmail, Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(MemberPassword))));
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Delete(Int32 MemberId)
        {
            MemberRepository.Delete(MemberId);
        }
        public static MsMember Where(String MemberEmail)
        {
            return MemberRepository.Where(MemberEmail);
        }
        public static Boolean WhereUpdate(String MemberEmail, Int32 MemberId)
        {
            if (Where(MemberEmail) == null || Where(MemberEmail).MemberId == MemberId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Verify(String MemberEmail, String MemberPassword)
        {
            MsMember Member = MemberRepository.Where(MemberEmail);
            if (Member != null && Member.MemberPassword.Equals(Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(MemberPassword)))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static Random random = new Random();
        public static String Captcha()
        {
            return CaptchaLetter() + CaptchaLetter() + CaptchaLetter() + CaptchaDigit() + CaptchaDigit() + CaptchaDigit();
        }
        public static String CaptchaLetter()
        {
            String Element = "qwertyuiopasdfghjklzxcvbnmMNBVCXZLKJHGFDSAPOIUYTREWQ";
            return Element[random.Next(Element.Length)].ToString();
        }
        public static String CaptchaDigit()
        {
            String Element = "1234567890";
            return Element[random.Next(Element.Length)].ToString();
        }
        public static Boolean UpdatePassword(String MemberEmail, String MemberPassword)
        {
            MsMember Member = MemberRepository.Where(MemberEmail);
            if(Member == null)
            {
                return false;
            }
            else
            {
                MemberRepository.Update(Member.MemberId, Member.MemberName, Member.MemberDOB, Member.MemberGender, Member.MemberAddress, Member.MemberPhone, MemberEmail, Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(MemberPassword))));
                return true;
            }
        }
        //
        public static Boolean EmailCheck(String Email)
        {
            if (Email.Length > 4 && new EmailAddressAttribute().IsValid(Email) && Where(Email) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean EmailCheckUpdate(String Email, Int32 MemberId)
        {
            if (Email.Length > 4 && new EmailAddressAttribute().IsValid(Email))
            {
                return WhereUpdate(Email, MemberId);
            }
            else
            {
                return false;
            }
        }
        public static Boolean PasswordCheck(String Password)
        {
            if (Password.Length < 3 || Password.Length > 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean NameCheck(String Name)
        {
            if (Name.Length < 3 || Name.Length > 20)
            {
                return false;
            }
            else
            {
                Int32 F = Name.Length - 1;
                while (F > -1)
                {
                    if (!Char.IsLetter(Name[F]))
                    {
                        return false;
                    }
                    F--;
                }
                return true;
            }
        }
        public static Boolean AgeCheck(String DOB)
        {
            DateTime N = DateTime.Now;
            if (DateTime.TryParse(DOB, out DateTime D) && ((N.Year - 17 == D.Year && N.Month >= D.Month && N.Day >= D.Day) || N.Year - 17 > D.Year))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean GenderCheck(String Gender)
        {
            if (String.IsNullOrWhiteSpace(Gender))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean PhoneCheck(String Phone)
        {
            if (Phone.Length > 0 && Int32.TryParse(Phone, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean AddressCheck(String Address)
        {
            if (Address.Length > 6 && Address.Contains("Street"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
    }
}