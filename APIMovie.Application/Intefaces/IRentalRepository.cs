using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    public interface IRentalRepository
    {
        List<Rental> GetAllRentals();
        List<Rental> GetRentalById(int id);
        Rental CreateRental(Rental rental);
        Rental AddRentalMovie(MovieRentalDTO request);
    }
}
