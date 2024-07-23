using MovieApp.Core.Models.Response;

namespace MovieApp.Core.Interfaces.Service;

public interface IGenreService
{
    Task<IEnumerable<GenreResponseModel>> GetAllGenres();
}