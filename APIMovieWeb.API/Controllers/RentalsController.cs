using APIMovie.Application.Intefaces;
using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIMovieWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetAllRentals()
        {
            try
            {
                var rentalsFromService = _rentalService.GetAllRentals();
                if (rentalsFromService.Count == 0)
                {
                    return NotFound("No rentals found. Register first to consult!");
                }

                return Ok(rentalsFromService);
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }

        }

        [HttpGet("RentalID")]
        public ActionResult<List<Movie>> GetRentalById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid Rental ID.");
                }
                var rentalsFromService = _rentalService.GetRentalById(id);
                if (rentalsFromService.Count == 0)
                {
                    return NotFound("No rental found by ID. Register first to consult!");
                }

                return Ok(rentalsFromService);
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }

        }

        [HttpPost]
        public ActionResult<Movie> CreateRental(MovieRentalDTO rental)
        {
            try
            {
                if (rental.RentalDate < DateTime.Now | rental.RentalExpiry < DateTime.Now | rental.TotalCost <= 0 | rental.MemberId < 0)
                {
                    return BadRequest("Invalid parameters!");
                }

                var newRental = new Rental
                {
                    RentalDate = rental.RentalDate,
                    RentalExpiry = rental.RentalExpiry,
                    TotalCost = rental.TotalCost,
                    MemberId = rental.MemberId
                };

                var rentalFromService = _rentalService.CreateRental(newRental);
                if (rentalFromService == null)
                {
                    return BadRequest("Failed to create new movie. Try again later!");
                }

                return StatusCode(201, rentalFromService);
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }
    }
}