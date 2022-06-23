using System.ComponentModel.DataAnnotations;

namespace APIMovie.Domain.DTO
{
    public class MovieRentalDTO
    {
        [Required]
        public DateTime RentalDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime RentalExpiry { get; set; } = DateTime.Now;
        [Required]
        public decimal TotalCost { get; set; } = 0;
        public int MemberId { get; set; }
    }
}
