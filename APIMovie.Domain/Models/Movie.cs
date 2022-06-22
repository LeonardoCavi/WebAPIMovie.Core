using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIMovie.Domain.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; } = string.Empty;
        [Required]
        public decimal MovieCost { get; set; } = 0;
        [Required]
        public int RentalDuration { get; set; } = 0;

        //Many to Many Relationship
        public List<Rental> Rentals { get; set; }
    }
}
