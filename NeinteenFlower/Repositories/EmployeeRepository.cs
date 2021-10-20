using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repositories
{
    public class EmployeeRepository
    {
        static NeinteenFlowerDatabaseEntities Database = new NeinteenFlowerDatabaseEntities();
        public static List<MsEmployee> Get()
        {
            return Database.MsEmployees.ToList();
        }
        public static MsEmployee Find(Int32 EmployeeId)
        {
            return Database.MsEmployees.Find(EmployeeId);
        }
        public static void Insert(MsEmployee Employee)
        {
            Database.MsEmployees.Add(Employee);
            Database.SaveChanges();
        }
        public static void Update(Int32 EmployeeId, String EmployeeName, DateTime EmployeeDOB, String EmployeeGender, String EmployeeAddress, String EmployeePhone, String EmployeeEmail, Int32 EmployeeSalary, String EmployeePassword)
        {
            MsEmployee Employee = Find(EmployeeId);
            Employee.EmployeeName = EmployeeName;
            Employee.EmployeeDOB = EmployeeDOB;
            Employee.EmployeeGender = EmployeeGender;
            Employee.EmployeeAddress = EmployeeAddress;
            Employee.EmployeePhone = EmployeePhone;
            Employee.EmployeeEmail = EmployeeEmail;
            Employee.EmployeeSalary = EmployeeSalary;
            Employee.EmployeePassword = EmployeePassword;
            Database.SaveChanges();
        }
        public static void Delete(Int32 EmployeeId)
        {
            Database.MsEmployees.Remove(Find(EmployeeId));
            Database.SaveChanges();
        }
        public static MsEmployee Where(String EmployeeEmail)
        {
            return (from E in Database.MsEmployees where E.EmployeeEmail.Equals(EmployeeEmail) select E).FirstOrDefault();
        }
    }
}