using System.ComponentModel.DataAnnotations;

namespace APIMovie.Domain.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        [Required]
        public DateTime RentalDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime RentalExpiry { get; set; } = DateTime.Now;
        public decimal TotalCost { get; set; } = 0;

        //One to Many Relationship
        public Member Member { get; set; }
        public int MemberId { get; set; }

        //Many to Many Relationship
        public List<Movie> Movies { get; set; }
    }
}
