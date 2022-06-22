using APIMovie.Domain.Models;

namespace APIMovie.Application.Intefaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        List<Movie> GetMovieById(int id);
        Movie CreateMovie(Movie movie);
        Movie UpdateMovie(int id, Movie movie);
        Movie DeleteMovie(int id);  
    }
}
