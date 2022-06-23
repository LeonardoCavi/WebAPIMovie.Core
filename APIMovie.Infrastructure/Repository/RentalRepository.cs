using APIMovie.Application.Intefaces;
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
                .ToList();

            return rentals;
        }

        public List<Rental> GetRentalById(int id)
        {
            var rentals = _rentalDBContext.Rentals
                .Where(r => r.RentalId == id)
                .Include(r => r.Member)
                .ToList();

            return rentals;
        }

        public Rental CreateRental(Rental rental)
        {
            _rentalDBContext.Rentals.Add(rental);
            _rentalDBContext.SaveChanges();

            return rental;
        }
    }
}
