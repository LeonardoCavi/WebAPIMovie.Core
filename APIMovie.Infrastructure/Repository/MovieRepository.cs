using APIMovie.Domain.Models;
using APIMovie.Infrastructure.Context;
using APIMovie.Application.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace APIMovie.Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        //public static List<Movie> movies = new List<Movie>()
        //{
        //    new Movie { MovieId = 1, MovieName = "Movie Test1", MovieCost = 10},
        //    new Movie { MovieId = 2, MovieName = "Movie Test2", MovieCost = 07}
        //};

        private readonly MovieDBContext _movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _movieDBContext.Movies
                .Include(m => m.Rentals)
                .ToList();

            return movies;
        }

        public List<Movie> GetMovieById(int id)
        {
            var movies = _movieDBContext.Movies
                .Where(m => m.MovieId == id)
                .Include(m => m.Rentals)
                .ToList();

            return movies;
        }

        public Movie CreateMovie(Movie movie)
        {
            _movieDBContext.Movies.Add(movie);
            _movieDBContext.SaveChanges();

            return movie;
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            var movies = _movieDBContext.Movies.Find(id);

            if(movies == null)
            {
                movies = null;
                return movies;
            }

            movies.MovieName = movie.MovieName;
            movies.MovieCost = movie.MovieCost;
            movies.RentalDuration = movie.RentalDuration;

            _movieDBContext.Movies.Update(movies);
            _movieDBContext.SaveChanges();

            return movies;
        }

        public Movie DeleteMovie(int id)
        {
            var movies = _movieDBContext.Movies.Find(id);

            if(movies == null)
            {
                movies = null;
                return movies;
            }

            _movieDBContext.Movies.Remove(movies);
            _movieDBContext.SaveChanges();

            return movies;
        }
    }
}
