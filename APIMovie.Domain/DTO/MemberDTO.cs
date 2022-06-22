using System.ComponentModel.DataAnnotations;

namespace APIMovie.Domain.DTO
{
    public class MemberDTO
    {
        [Required]
        public string MemberFirstName { get; set; } = string.Empty;
        [Required]
        public string MemberLastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid e-mail.")]
        public string MemberEmail { get; set; } = string.Empty;
    }
}
