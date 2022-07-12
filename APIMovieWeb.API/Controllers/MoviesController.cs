using APIMovie.Domain.DTO;
using APIMovie.Domain.Models;
using APIMovie.Application.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovieWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private string className = typeof(MembersController).Name;
        private readonly ILogger _logger;
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService, ILogger<MembersController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetAllMovies()
        {
            try
            {
                var moviesFromService = _movieService.GetAllMovies();
                if (moviesFromService.Count == 0)
                {
                    return NotFound("No movies found. Register first to consult!");
                }

                _logger.LogInformation($"{className} - GetAllMovies - Sucess.");
                return Ok(moviesFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - GetAllMovies - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
            
        }

        [HttpGet("MovieID")]
        public ActionResult<List<Movie>> GetMovieById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid Movie ID.");
                }
                var moviesFromService = _movieService.GetMovieById(id);
                if (moviesFromService.Count == 0)
                {
                    return NotFound("No movies found by ID. Register first to consult!");
                }

                _logger.LogInformation($"{className} - GetMovieById - Sucess.");
                return Ok(moviesFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - GetMovieById - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }

        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie(MovieDTO movie)
        {
            try
            {
                if (movie.MovieName == String.Empty || movie.MovieCost < 0 || movie.RentalDuration < 0)
                {
                    return BadRequest("Invalid parameters!");
                }

                var newMovie = new Movie
                {
                    MovieName = movie.MovieName,
                    MovieCost = movie.MovieCost,
                    RentalDuration = movie.RentalDuration,
                };

                var movieFromService = _movieService.CreateMovie(newMovie);
                if (movieFromService == null)
                {
                    return BadRequest("Failed to create new movie. Try again later!");
                }

                _logger.LogInformation($"{className} - CreateMovie - Sucess.");
                return StatusCode(201, movieFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - CreateMovie - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpPut]
        public ActionResult<Movie> UpdateMovie(int id, MovieDTO request)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid Movie ID.");
                }
                else if (request.MovieName == String.Empty || request.MovieCost < 0 || request.RentalDuration < 0)
                {
                    return BadRequest("Invalid parameters!");
                }

                var updateMovie = new Movie
                {
                    MovieName = request.MovieName,
                    MovieCost = request.MovieCost,
                    RentalDuration = request.RentalDuration
                };

                var movieFromService = _movieService.UpdateMovie(id, updateMovie);
                if (movieFromService == null)
                {
                    return BadRequest("Failed to update movie. Please check the ID is correct and try again later!");
                }

                _logger.LogInformation($"{className} - UpdateMovie - Sucess.");
                return Ok(movieFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - UpdateMovie - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }

        [HttpDelete]
        public ActionResult<Movie> DeleteMovie(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid Movie ID.");
                }

                var movieFromService = _movieService.DeleteMovie(id);
                if (movieFromService == null)
                {
                    return BadRequest("Movie deletion failed. Please check the ID is correct and try again later!");
                }

                _logger.LogInformation($"{className} - DeleteMovie - Sucess.");
                return Ok(movieFromService);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className} - DeleteMovie - Ex: {ex}.");
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }
    }
}
