using Movie_Catalog.Models;

namespace Movie_Catalog.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void update(Movie movie);
        void Delete(int id);
        void Update(Movie movie);
    }
}
