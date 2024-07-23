using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Core.Interfaces.Service;
using MovieApp.Core.Models.Response;

namespace MovieApp.Infrastructure.Services;

public class GenreService : IGenreService
{
    private readonly IAsyncRepository<Genre> _genreRepository;

    public GenreService(IAsyncRepository<Genre> genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
    {
        var genres = await _genreRepository.GetAllAsync();
        return genres.Select(g => new GenreResponseModel
        {
            Id = g.Id,
            Name = g.Name
        });
    }
}