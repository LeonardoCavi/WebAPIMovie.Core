using APIMovie.Application.Intefaces;
using APIMovie.Domain.Models;

namespace APIMovie.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public List<Member> GetAllMembers()
        {
            var members = _memberRepository.GetAllMembers();
            return members;
        }

        public List<Member> GetMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public Member CreateMember(Member member)
        {
            var members = _memberRepository.CreateMember(member);
            return members;
        }
        public Member UpdateMember(int id, Member member)
        {
            throw new NotImplementedException();
        }

        public Member DeleteMember(int id)
        {
            throw new NotImplementedException();
        }      
    }
}
