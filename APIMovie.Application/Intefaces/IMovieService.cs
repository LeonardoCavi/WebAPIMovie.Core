using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    //This is a use case;
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        List<Movie> GetMovieById(int id);
        Movie CreateMovie(Movie movie);
        Movie UpdateMovie(int id, Movie movie);
        Movie DeleteMovie(int id);
    }
}
