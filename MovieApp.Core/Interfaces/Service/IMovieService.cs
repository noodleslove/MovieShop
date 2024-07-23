using MovieApp.Core.Helpers;
using MovieApp.Core.Models.Request;
using MovieApp.Core.Models.Response;

namespace MovieApp.Core.Interfaces.Service;

public interface IMovieService
{
    Task<int> AddMovie(MovieRequestModel requestModel);
    Task<int> UpdateMovie(MovieRequestModel requestModel, int id);
    Task<int> DeleteMovie(int id);
    Task<IEnumerable<MovieResponseModel>> GetAllMovies();
    Task<MovieResponseModel?> GetMovieById(int id);
    Task<MovieResponseModel?> GetMovieDetails(int id);
    Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies();
    Task<PaginatedResultSet<MovieResponseModel>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex);
}