using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    //This is a use case;
    public interface IMemberService
    {
        List<Member> GetAllMembers();
        List<Member> GetMemberById(int id);
        Member CreateMember(Member member);
        Member UpdateMember(int id, Member member);
        Member DeleteMember(int id);
    }
}
