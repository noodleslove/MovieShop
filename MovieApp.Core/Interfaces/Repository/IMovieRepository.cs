using MovieApp.Core.Entities;
using MovieApp.Core.Helpers;

namespace MovieApp.Core.Interfaces.Repository;

public interface IMovieRepository : IAsyncRepository<Movie>
{
    Task<IEnumerable<Movie>> GetHighestGrossingMovies();
    Task<PaginatedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex);
}