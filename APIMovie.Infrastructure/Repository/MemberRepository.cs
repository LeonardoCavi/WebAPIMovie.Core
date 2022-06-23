using APIMovie.Application.Intefaces;
using APIMovie.Domain.Models;
using APIMovie.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace APIMovie.Infrastructure.Repository
{
    public class MemberRepository : IMemberRepository
    {
        //public static List<Member> members = new List<Member>()
        //{
        //    new Member { MemberFirstName = "Name1",
        //            MemberLastName = "LastName1",
        //            MemberEmail = "test1@email.com" }
        //};

        private readonly MovieDBContext _memberDBContext;

        public MemberRepository(MovieDBContext memberDBContext)
        {
            _memberDBContext = memberDBContext;
        }

        public List<Member> GetAllMembers()
        {
            var members = _memberDBContext.Members
                .Include(m => m.Rentals)
                .ToList();
            return members;
        }

        public List<Member> GetMemberById(int id)
        {
            var members = _memberDBContext.Members
                .Where(m => m.MemberId == id)
                .Include(m => m.Rentals)
                .ToList();

            return members;
        }

        public Member CreateMember(Member member)
        {
            _memberDBContext.Members.Add(member);
            _memberDBContext.SaveChanges();

            return member;
        }

        public Member UpdateMember(int id, Member member)
        {
            var members = _memberDBContext.Members.Find(id);

            if(members == null)
            {
                members = null;
                return members;
            }

            members.MemberFirstName = member.MemberFirstName;
            members.MemberLastName = member.MemberLastName;
            members.MemberEmail = member.MemberEmail;

            _memberDBContext.Members.Update(members);
            _memberDBContext.SaveChanges();

            return members;
        }

        public Member DeleteMember(int id)
        {
            var members = _memberDBContext.Members.Find(id);

            if (members == null)
            {
                members = null;
                return members;
            }

            _memberDBContext.Members.Remove(members);
            _memberDBContext.SaveChanges();

            return members;
        }
    }
}
