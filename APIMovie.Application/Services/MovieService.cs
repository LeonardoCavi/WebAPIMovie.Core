using APIMovie.Domain.Models;
using APIMovie.Application.Intefaces;

namespace APIMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        //Contructor Dependency Injection
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();
            return movies;
        }

        public List<Movie> GetMovieById(int id)
        {
            var movies = _movieRepository.GetMovieById(id);
            return movies;
        }

        public Movie CreateMovie(Movie movie)
        {
            var movies = _movieRepository.CreateMovie(movie);
            return movies;
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            var movies = _movieRepository.UpdateMovie(id, movie);
            return movies;
        }

        public Movie DeleteMovie(int id)
        {
            var movies = _movieRepository.DeleteMovie(id);
            return movies;
        }
    }
}
