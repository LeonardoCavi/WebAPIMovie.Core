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
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
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

                return Ok(moviesFromService);
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
            
        }

        [HttpGet("ID")]
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

                return Ok(moviesFromService);
            }
            catch (Exception ex)
            {
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

                return StatusCode(201, movieFromService);
            }
            catch (Exception ex)
            {
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
                    return BadRequest("Failed to create new movie. Try again later!");
                }

                return Ok(movieFromService);
            }
            catch (Exception ex)
            {
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
                    return BadRequest("Movie deletion failed. Try again later!");
                }

                return Ok(movieFromService);
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"Internal Failure. Try again later. Error => {ex}");
            }
        }
    }
}
