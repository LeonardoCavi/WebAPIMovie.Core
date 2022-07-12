using APIMovie.Application.Intefaces;
using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;
using APIMovie.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace APIMovie.Infrastructure.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MovieDBContext _rentalDBContext;

        public RentalRepository(MovieDBContext rentalDBContext)
        {
            _rentalDBContext = rentalDBContext;
        }

        public List<Rental> GetAllRentals()
        {
            var rentals = _rentalDBContext.Rentals
                .Include(r => r.Member)
                .Include(r => r.Movies)
                .ToList();

            return rentals;
        }

        public List<Rental> GetRentalById(int id)
        {
            var rentals = _rentalDBContext.Rentals
                .Where(r => r.RentalId == id)
                .Include(r => r.Member)
                .Include(r => r.Movies)
                .ToList();

            return rentals;
        }

        public Rental CreateRental(Rental rental)
        {
            _rentalDBContext.Rentals.Add(rental);
            _rentalDBContext.SaveChanges();

            return rental;
        }

        public Rental AddRentalMovie(MovieRentalDTO request)
        {
            var rentals = _rentalDBContext.Rentals
                    .Where(r => r.RentalId == request.RentalId)
                    .Include(m => m.Movies)
                    .FirstOrDefault();

            if (rentals == null)
            {
                rentals = null;
                return rentals;
            }

            var movies = _rentalDBContext.Movies.Find(request.MovieId);
            if (movies == null)
            {
                rentals = null;
                return rentals;
            }

            rentals.Movies.Add(movies);
            _rentalDBContext.SaveChangesAsync();

            return rentals;
        }
    }
}
