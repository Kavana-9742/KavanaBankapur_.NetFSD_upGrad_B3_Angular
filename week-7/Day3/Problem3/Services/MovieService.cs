using Movie_Catalog.Models;
using Movie_Catalog.Repositories;

namespace Movie_Catalog.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public List<Movie> GetAllMovies()
        {
            return _repository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddMovie(Movie movie)
        {
            _repository.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _repository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            _repository.Delete(id);
        }
    }

}
