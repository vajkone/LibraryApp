using LibraryApp_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class MemberRepository
    {
        public static IList<Member> GetMembers()
        {

            using var database = new LibraryContext();
            var members = database.Members.ToList();
            return members;


        }

        public static Member GetMember(long id)
        {

            using var database = new LibraryContext();
            var member = database.Members.Where(b => b.MemberId == id).FirstOrDefault();
            return member;


        }

        public static void AddMember(Member member)
        {
            using var database = new LibraryContext();
            database.Members.Add(member);
            database.SaveChanges();

        }



        public static void UpdateMember(Member member)
        {
            using var database = new LibraryContext();

            database.Members.Update(member);
            database.SaveChanges();



        }

        public static bool DeleteMember(long id)
        {
            using var database = new LibraryContext();
            var dbMember = database.Members.Where(p => p.MemberId == id).FirstOrDefault();
            if (dbMember != null)
            {
                database.Members.Remove(dbMember);
                database.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
