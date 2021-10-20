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
    public class EmployeeHandler
    {
        public static List<MsEmployee> Get()
        {
            return EmployeeRepository.Get();
        }
        public static MsEmployee Find(Int32 EmployeeId)
        {
            return EmployeeRepository.Find(EmployeeId);
        }
        public static Boolean Insert(String EmployeeName, String EmployeeDOB, String EmployeeGender, String EmployeeAddress, String EmployeePhone, String EmployeeEmail, String EmployeeSalary, String EmployeePassword)
        {
            if (EmailCheck(EmployeeEmail) && PasswordCheck(EmployeePassword) && NameCheck(EmployeeName) && AgeCheck(EmployeeDOB.ToString()) && GenderCheck(EmployeeGender) && PhoneCheck(EmployeePhone) && AddressCheck(EmployeeAddress) && SalaryCheck(EmployeeSalary.ToString()))
            {
                /*EmployeeRepository.Insert(NeinteenFlowerFactory.InsertEmployee(EmployeeName, EmployeeDOB, EmployeeGender, EmployeeAddress, EmployeePhone, EmployeeEmail, EmployeeSalary, EmployeePassword));*/
                EmployeeRepository.Insert(NeinteenFlowerFactory.InsertEmployee(EmployeeName, DateTime.Parse(EmployeeDOB), EmployeeGender, EmployeeAddress, EmployeePhone, EmployeeEmail, Int32.Parse(EmployeeSalary), Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(EmployeePassword)))));
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Update(Int32 EmployeeId, String EmployeeName, String EmployeeDOB, String EmployeeGender, String EmployeeAddress, String EmployeePhone, String EmployeeEmail, String EmployeeSalary, String EmployeePassword)
        {
            if (EmailCheckUpdate(EmployeeEmail,EmployeeId) && PasswordCheck(EmployeePassword) && NameCheck(EmployeeName) && AgeCheck(EmployeeDOB.ToString()) && GenderCheck(EmployeeGender) && PhoneCheck(EmployeePhone) && AddressCheck(EmployeeAddress) && SalaryCheck(EmployeeSalary.ToString()))
            {
                /*EmployeeRepository.Update(EmployeeId, EmployeeName, EmployeeDOB, EmployeeGender, EmployeeAddress, EmployeePhone, EmployeeEmail, EmployeeSalary, EmployeePassword);*/
                EmployeeRepository.Update(EmployeeId,EmployeeName, DateTime.Parse(EmployeeDOB), EmployeeGender, EmployeeAddress, EmployeePhone, EmployeeEmail, Int32.Parse(EmployeeSalary), Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(EmployeePassword))));
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Delete(Int32 EmployeeId)
        {
            EmployeeRepository.Delete(EmployeeId);
        }
        public static MsEmployee Where(String EmployeeEmail)
        {
            return EmployeeRepository.Where(EmployeeEmail);
        }
        public static Boolean WhereUpdate(String EmployeeEmail, Int32 EmployeeId)
        {
            if (Where(EmployeeEmail) == null || Where(EmployeeEmail).EmployeeId == EmployeeId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Verify(String EmployeeEmail, String EmployeePassword)
        {
            MsEmployee Employee = EmployeeRepository.Where(EmployeeEmail);
            if (Employee != null && Employee.EmployeePassword.Equals(Encoding.Default.GetString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(EmployeePassword)))))
            {
                return true;
            }
            else
            {
                return false;
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
        public static Boolean EmailCheckUpdate(String Email, Int32 EmployeeId)
        {
            if (Email.Length > 4 && new EmailAddressAttribute().IsValid(Email))
            {
                return WhereUpdate(Email, EmployeeId);
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
        public static Boolean SalaryCheck(String EmployeeSalary)
        {
            if (Int32.TryParse(EmployeeSalary, out Int32 S))
            {
                if (S < 100 || S > 1000)
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
    }
}