using APIMovie.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMovie.Infrastructure.Context
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) 
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
