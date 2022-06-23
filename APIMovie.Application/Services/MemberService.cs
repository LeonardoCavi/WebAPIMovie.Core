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
            var members = _memberRepository.GetMemberById(id);
            return members;
        }

        public Member CreateMember(Member member)
        {
            var members = _memberRepository.CreateMember(member);
            return members;
        }
        public Member UpdateMember(int id, Member member)
        {
            var members = _memberRepository.UpdateMember(id, member);
            return members;
        }

        public Member DeleteMember(int id)
        {
            var members = _memberRepository.DeleteMember(id);
            return members;
        }      
    }
}
