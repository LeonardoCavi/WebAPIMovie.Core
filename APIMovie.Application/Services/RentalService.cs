using APIMovie.Application.Intefaces;
using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;

namespace APIMovie.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public List<Rental> GetAllRentals()
        {
            var rentals = _rentalRepository.GetAllRentals();
            return rentals;
        }

        public List<Rental> GetRentalById(int id)
        {
            var rentals = _rentalRepository.GetRentalById(id);
            return rentals;
        }

        public Rental CreateRental(Rental rental)
        {
            var rentals = _rentalRepository.CreateRental(rental);
            return rentals;
        }

        public Rental AddRentalMovie(MovieRentalDTO request)
        {
            var rentals = _rentalRepository.AddRentalMovie(request);
            return rentals;
        }
    }
}
