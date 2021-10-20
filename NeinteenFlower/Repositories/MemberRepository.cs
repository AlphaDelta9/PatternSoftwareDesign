using NeinteenFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repositories
{
    public class MemberRepository
    {
        static NeinteenFlowerDatabaseEntities Database = new NeinteenFlowerDatabaseEntities();
        public static List<MsMember> Get()
        {
            return Database.MsMembers.ToList();
        }
        public static MsMember Find(Int32 MemberId)
        {
            return Database.MsMembers.Find(MemberId);
        }
        public static void Insert(MsMember Member)
        {
            Database.MsMembers.Add(Member);
            Database.SaveChanges();
        }
        public static void Update(Int32 MemberId, String MemberName, DateTime MemberDOB, String MemberGender, String MemberAddress, String MemberPhone, String MemberEmail, String MemberPassword)
        {
            MsMember Member = Find(MemberId);
            Member.MemberName = MemberName;
            Member.MemberDOB = MemberDOB;
            Member.MemberGender = MemberGender;
            Member.MemberAddress = MemberAddress;
            Member.MemberPhone = MemberPhone;
            Member.MemberEmail = MemberEmail;
            Member.MemberPassword = MemberPassword;
            Database.SaveChanges();
        }
        public static void Delete(Int32 MemberId)
        {
            Database.MsMembers.Remove(Find(MemberId));
            Database.SaveChanges();
        }
        public static MsMember Where(String MemberEmail)
        {
            return (from E in Database.MsMembers where E.MemberEmail.Equals(MemberEmail) select E).FirstOrDefault();
        }
    }
}