using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factories
{
    public class NeinteenFlowerFactory
    {
        public static MsEmployee InsertEmployee(String EmployeeName, DateTime EmployeeDOB, String EmployeeGender, String EmployeeAddress, String EmployeePhone, String EmployeeEmail, Int32 EmployeeSalary, String EmployeePassword)
        {
            MsEmployee Employee = new MsEmployee();
            Employee.EmployeeName = EmployeeName;
            Employee.EmployeeDOB = EmployeeDOB;
            Employee.EmployeeGender = EmployeeGender;
            Employee.EmployeeAddress = EmployeeAddress;
            Employee.EmployeePhone = EmployeePhone;
            Employee.EmployeeEmail = EmployeeEmail;
            Employee.EmployeeSalary = EmployeeSalary;
            Employee.EmployeePassword = EmployeePassword;
            return Employee;
        }
        public static MsMember InsertMember(String MemberName, DateTime MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            MsMember Member = new MsMember();
            Member.MemberName = MemberName;
            Member.MemberDOB = MemberDOB;
            Member.MemberGender = MemberGender;
            Member.MemberAddress = MemberAddress;
            Member.MemberPhone = MemberPhone;
            Member.MemberEmail = MemberEmail;
            Member.MemberPassword = MemberPassword;
            return Member;
        }
        public static MsFlower InsertFlower(String FlowerName, Int32 FlowerTypeId, String FlowerDescription, Int32 FlowerPrice, HttpPostedFile FlowerImage)
        {
            MsFlower Flower = new MsFlower();
            Flower.FlowerName = FlowerName;
            Flower.FlowerTypeId = FlowerTypeId;
            Flower.FlowerDescription = FlowerDescription;
            Flower.FlowerPrice = FlowerPrice;
            Flower.FlowerImage = "~/Flowers/" + FlowerImage.FileName;
            return Flower;
        }
        public static TrHeader InsertHeader(Int32 MemberId, Int32 EmployeeId, DateTime TransactionDate, Int32 DiscountPercentage)
        {
            TrHeader Header = new TrHeader();
            Header.MemberId = MemberId;
            Header.EmployeeId = EmployeeId;
            Header.TransactionDate = TransactionDate;
            Header.DiscountPercentage = DiscountPercentage;
            return Header;
        }
        public static TrDetail InsertDetail(Int32 TransactionId, Int32 FlowerId, Int32 Quantity)
        {
            TrDetail Detail = new TrDetail();
            Detail.TransactionId = TransactionId;
            Detail.FlowerId = FlowerId;
            Detail.Quantity = Quantity;
            return Detail;
        }
    }
}