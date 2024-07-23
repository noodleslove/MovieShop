using MovieApp.Core.Interfaces.Repository;
using MovieApp.Core.Interfaces.Service;
using MovieApp.Core.Models.Response;

namespace MovieApp.Infrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        _castRepository = castRepository;
    }

    public async Task<CastResponseModel?> GetCastDetails(int id)
    {
        var castDetails = await _castRepository.GetByIdAsync(id);
        if (castDetails == null)
        {
            return null;
        }

        return new CastResponseModel
        {
            Id = castDetails.Id,
            Name = castDetails.Name,
            Movies = castDetails.MovieCasts.Select(mc => new MovieResponseModel
            {
                Id = mc.Movie.Id,
                Title = mc.Movie.Title,
                PosterUrl = mc.Movie.PosterUrl,
                ReleaseDate = mc.Movie.ReleaseDate
            }).ToList()
        };
    }
}