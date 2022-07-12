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
        private string className = typeof(MembersController).Name;
        private readonly ILogger _logger;
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService, ILogger<MembersController> logger)
        {
            _rentalService = rentalService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Rental>> GetAllRentals()
        {
            try
            {
                var rentalsFromService = _rentalService.GetAllRentals();
                if (rentalsFromService.Count == 0)
                {
                    return NotFound("No rentals found. Register first to consult!");
                }

                _logger.LogInformation($"{className} - GetAllRentals - Sucess.");
                return Ok(rentalsFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - GetAllRentals - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }

        }

        [HttpGet("RentalID")]
        public ActionResult<List<Rental>> GetRentalById(int id)
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

                _logger.LogInformation($"{className} - GetRentalById - Sucess.");
                return Ok(rentalsFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - GetRentalById - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }

        }

        [HttpPost]
        public ActionResult<Rental> CreateRental(RentalDTO rental)
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

                _logger.LogInformation($"{className} - CreateRental - Sucess.");
                return StatusCode(201, rentalFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - CreateRental - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpPost("MovieID + RentalId")]
        public ActionResult<Rental> AddRentalMovie(MovieRentalDTO request)
        {
            try
            {
                if(request.MovieId <= 0 || request.RentalId <= 0)
                {
                    return BadRequest("Invalid parameters!");
                }

                var movieRentalFromService = _rentalService.AddRentalMovie(request);
                if( movieRentalFromService == null)
                {
                    return BadRequest("Failed to add new Rental Movie. Please check the ID is correct and try again later!");
                }

                _logger.LogInformation($"{className} - AddRentalMovie - Sucess.");
                return StatusCode(201, movieRentalFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - AddRentalMovie - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }
    }
}



