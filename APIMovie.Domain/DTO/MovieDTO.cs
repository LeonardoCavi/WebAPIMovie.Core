using System.ComponentModel.DataAnnotations;

namespace APIMovie.Domain.DTO
{
    public class MovieDTO
    {
        [Required]
        public string MovieName { get; set; } = string.Empty;
        [Required]
        public decimal MovieCost { get; set; } = 0;
        [Required]
        public int RentalDuration { get; set; } = 0;
    }
}
