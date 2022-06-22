using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    public interface IMemberRepository
    {
        List<Member> GetAllMembers();
        List<Member> GetMemberById(int id);
        Member CreateMember(Member member);
        Member UpdateMember(int id, Member member);
        Member DeleteMember(int id);
    }
}
