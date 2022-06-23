using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    public interface IRentalRepository
    {
        List<Rental> GetAllRentals();
        List<Rental> GetRentalById(int id);
        Rental CreateRental(Rental rental);
    }
}
