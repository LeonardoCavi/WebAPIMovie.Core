using APIMovie.Application.Intefaces;
using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIMovieWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private string className = typeof(MembersController).Name;
        private readonly ILogger _logger;
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService, ILogger<MembersController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Member>> GetAllMembers()
        {
            try
            {
                var memberFromService = _memberService.GetAllMembers();
                if (memberFromService.Count == 0)
                {
                    return NotFound("No members found. Register first to consult!");
                }

                _logger.LogInformation($"{className} - GetAllMembers - Sucess.");
                return Ok(memberFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - GetAllMembers - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpGet("MemberID")]
        public ActionResult<List<Member>> GetMemberById(int id)
        {
            try
            {
                if(id < 0)
                {
                    return BadRequest("Invalid Member ID.");
                }
                var memberFromService = _memberService.GetMemberById(id);
                if (memberFromService.Count == 0)
                {
                    return NotFound("No members found by ID. Register first to consult!");
                }

                _logger.LogInformation($"{className} - GetMemberById(MemberId) - Sucess.");
                return Ok(memberFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - GetMemberById(MemberId) - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpPost]
        public ActionResult<Member> CreateMember(MemberDTO member)
        {
            try
            {
                if (member.MemberFirstName == String.Empty || member.MemberLastName == String.Empty || member.MemberEmail == String.Empty)
                {
                    return BadRequest("Invalid parameters!");
                }

                var newMember = new Member
                {
                    MemberFirstName = member.MemberFirstName,
                    MemberLastName = member.MemberLastName,
                    MemberEmail = member.MemberEmail
                };

                var memberFromService = _memberService.CreateMember(newMember);
                if (memberFromService == null)
                {
                    return BadRequest("Failed to create new member. Try again later!");
                }

                _logger.LogInformation($"{className} - CreateMember(member) - Sucess.");
                return StatusCode(201, memberFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - CreateMember(member) - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpPut]
        public ActionResult<Member> UpdateMember(int id, MemberDTO request)
        {
            try
            {
                if(id < 0)
                {
                    return BadRequest("Invalid Member ID.");
                }
                else if (request.MemberFirstName == String.Empty || request.MemberLastName == String.Empty || request.MemberEmail == String.Empty)
                {
                    return BadRequest("Invalid parameters!");
                }

                var updateMember = new Member
                {
                    MemberFirstName = request.MemberFirstName,
                    MemberLastName= request.MemberLastName,
                    MemberEmail = request.MemberEmail
                };

                var memberFromService = _memberService.UpdateMember(id, updateMember);
                if(memberFromService == null)
                {
                    return BadRequest("Failed to update member. Please check the ID is correct and try again later!");
                }

                _logger.LogInformation($"{className} - UpdateMember(MemberId, member) - Sucess.");
                return Ok(memberFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - UpdateMember(MemberId, member) - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpDelete]
        public ActionResult<Movie> DeleteMember(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid Member ID.");
                }

                var memberFromService = _memberService.DeleteMember(id);
                if (memberFromService == null)
                {
                    return BadRequest("Member deletion failed. Please check the ID is correct and try again later!");
                }

                _logger.LogInformation($"{className} - DeleteMember(MemberId) - Sucess.");
                return Ok(memberFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - DeleteMember(MemberId) - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }
    }
}
