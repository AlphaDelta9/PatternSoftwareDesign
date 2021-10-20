using NeinteenFlower.Handlers;
using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace NeinteenFlower.Controllers
{
    public class AdministratorController
    {
        public static List<MsEmployee> GetEmployee()
        {
            return EmployeeHandler.Get();
        }
        public static MsEmployee FindEmployee(Int32 EmployeeId)
        {
            return EmployeeHandler.Find(EmployeeId);
        }
        public static List<MsMember> GetMember()
        {
            return MemberHandler.Get();
        }
        public static MsMember FindMember(Int32 MemberId)
        {
            return MemberHandler.Find(MemberId);
        }
        public static String EmployeeEmailCheck(String EmployeeEmail)
        {
            if(EmployeeEmail.Length > 4 && new EmailAddressAttribute().IsValid(EmployeeEmail))
            {
                if (EmployeeHandler.Where(EmployeeEmail) == null)
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
        public static String EmployeeEmailCheckUpdate(String EmployeeEmail, Int32 EmployeeId)
        {
            if (EmployeeEmail.Length > 4 && new EmailAddressAttribute().IsValid(EmployeeEmail))
            {
                if (EmployeeHandler.WhereUpdate(EmployeeEmail, EmployeeId))
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
        public static String MemberEmailCheck(String MemberEmail)
        {
            if (MemberEmail.Length > 4 && new EmailAddressAttribute().IsValid(MemberEmail))
            {
                if (MemberHandler.Where(MemberEmail) == null)
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
        public static String MemberEmailCheckUpdate(String MemberEmail, Int32 MemberId)
        {
            if (MemberEmail.Length > 4 && new EmailAddressAttribute().IsValid(MemberEmail))
            {
                if (MemberHandler.WhereUpdate(MemberEmail, MemberId))
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
        public static String PasswordCheck(String Password)
        {
            if(Password.Length < 3 || Password.Length > 20)
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
        public static String SalaryCheck(String EmployeeSalary)
        {
            if(Int32.TryParse(EmployeeSalary, out Int32 S))
            {
                if (S < 100 || S > 1000)
                {
                    return "Must be between 100 to 1000 inclusively";
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
        public static Boolean InsertEmployee(String EmployeeName, String EmployeeDOB, String EmployeeGender, String EmployeeAddress, String EmployeePhone, String EmployeeEmail, String EmployeeSalary, String EmployeePassword)
        {
            return EmployeeHandler.Insert(EmployeeName, EmployeeDOB, EmployeeGender, EmployeeAddress, EmployeePhone, EmployeeEmail, EmployeeSalary, EmployeePassword);
        }
        public static Boolean UpdateEmployee(Int32 EmployeeId, String EmployeeName, String EmployeeDOB, String EmployeeGender, String EmployeeAddress, String EmployeePhone, String EmployeeEmail, String EmployeeSalary, String EmployeePassword)
        {
            return EmployeeHandler.Update(EmployeeId, EmployeeName, EmployeeDOB, EmployeeGender, EmployeeAddress, EmployeePhone, EmployeeEmail, EmployeeSalary, EmployeePassword);
        }
        public static void DeleteEmployee(Int32 EmployeeId)
        {
            EmployeeHandler.Delete(EmployeeId);
        }
        public static Boolean InsertMember(String MemberName, String MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            if (MemberHandler.Insert(MemberName, MemberDOB, MemberGender, MemberAddress, MemberPhone, MemberEmail, MemberPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean UpdateMember(Int32 MemberId, String MemberName, String MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            if (MemberHandler.Update(MemberId, MemberName, MemberDOB, MemberGender, MemberAddress, MemberPhone, MemberEmail, MemberPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DeleteMember(Int32 MemberId)
        {
            MemberHandler.Delete(MemberId);
        }
        public static List<String> GenderData()
        {
            List<String> Gender = new List<String>();
            Gender.Add(" ");
            Gender.Add("Male");
            Gender.Add("Female");
            return Gender;
        }
        public static Int32 Where(String AdministratorEmail)
        {
            return AdministratorHandler.Where(AdministratorEmail);
        }
        public static String Find(Int32 AdministratorId)
        {
            return AdministratorHandler.Find(AdministratorId);
        }
        public static String EmailVerify(String Email)
        {
            if (Email.Length > 4 && new EmailAddressAttribute().IsValid(Email))
            {
                if (Where(Email) == 0)
                {
                    return "";
                }
                else
                {
                    return "Must be appropriate";
                }
            }
            else
            {
                return "Must using a correct email format";
            }
        }
        public static String PasswordVerify(String Email, String Password)
        {
            if (AdministratorHandler.Verify(Email, Password))
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