using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    public interface IRentalService
    {
        List<Rental> GetAllRentals();
        List<Rental> GetRentalById(int id);
        Rental CreateRental(Rental rental);
        Rental AddRentalMovie(MovieRentalDTO request);
    }
}
