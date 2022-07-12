using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIMovie.Domain.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string MemberFirstName { get; set; } = string.Empty;
        [Required]
        public string MemberLastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid e-mail.")]
        public string MemberEmail { get; set; } = string.Empty;

        [JsonIgnore]
        // Linking - Member - Rentals (1:N)
        public List<Rental> Rentals { get; set; }
    }
}
