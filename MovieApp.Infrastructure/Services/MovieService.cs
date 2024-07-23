using MovieApp.Core.Entities;
using MovieApp.Core.Helpers;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Core.Interfaces.Service;
using MovieApp.Core.Models.Request;
using MovieApp.Core.Models.Response;
using GenreResponseModel = MovieApp.Core.Models.Response.GenreResponseModel;

namespace MovieApp.Infrastructure.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<int> AddMovie(MovieRequestModel requestModel)
    {
        return await _movieRepository.InsertAsync(new Movie
        {
            TmdbUrl = requestModel.TmdbUrl,
            ImdbUrl = requestModel.ImdbUrl,
            Title = requestModel.Title,
            OverView = requestModel.OverView,
            Tagline = requestModel.Tagline,
            Runtime = requestModel.Runtime,
            Budget = requestModel.Budget,
            Revenue = requestModel.Revenue,
            BackdropUrl = requestModel.BackdropUrl,
            PosterUrl = requestModel.PosterUrl,
            OriginalLanguage = requestModel.OriginalLanguage,
            ReleaseDate = requestModel.ReleaseDate
        });
    }

    public async Task<int> UpdateMovie(MovieRequestModel requestModel, int id)
    {
        return await _movieRepository.UpdateAsync(new Movie
        {
            Id = id,
            TmdbUrl = requestModel.TmdbUrl,
            ImdbUrl = requestModel.ImdbUrl,
            Title = requestModel.Title,
            OverView = requestModel.OverView,
            Tagline = requestModel.Tagline,
            Runtime = requestModel.Runtime,
            Budget = requestModel.Budget,
            Revenue = requestModel.Revenue,
            BackdropUrl = requestModel.BackdropUrl,
            PosterUrl = requestModel.PosterUrl,
            OriginalLanguage = requestModel.OriginalLanguage,
            ReleaseDate = requestModel.ReleaseDate
        });
    }

    public async Task<int> DeleteMovie(int id)
    {
        return await _movieRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<MovieResponseModel>> GetAllMovies()
    {
        var movies = await _movieRepository.GetAllAsync();
        return movies.Select(movie => new MovieResponseModel
        {
            Id = movie.Id,
            TmdbUrl = movie.TmdbUrl,
            ImdbUrl = movie.ImdbUrl,
            Title = movie.Title,
            OverView = movie.OverView,
            Tagline = movie.Tagline,
            Runtime = movie.Runtime,
            Budget = movie.Budget,
            Revenue = movie.Revenue,
            BackdropUrl = movie.BackdropUrl,
            PosterUrl = movie.PosterUrl,
            OriginalLanguage = movie.OriginalLanguage,
            ReleaseDate = movie.ReleaseDate
        });
    }

    public async Task<MovieResponseModel?> GetMovieById(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null)
        {
            return null;
        }

        return new MovieResponseModel
        {
            Id = movie.Id,
            TmdbUrl = movie.TmdbUrl,
            ImdbUrl = movie.ImdbUrl,
            Title = movie.Title,
            OverView = movie.OverView,
            Tagline = movie.Tagline,
            Runtime = movie.Runtime,
            Budget = movie.Budget,
            Revenue = movie.Revenue,
            BackdropUrl = movie.BackdropUrl,
            PosterUrl = movie.PosterUrl,
            OriginalLanguage = movie.OriginalLanguage,
            ReleaseDate = movie.ReleaseDate
        };
    }

    public async Task<MovieResponseModel?> GetMovieDetails(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie != null)
        {
            return new MovieResponseModel
            {
                Id = movie.Id,
                TmdbUrl = movie.TmdbUrl,
                ImdbUrl = movie.ImdbUrl,
                Title = movie.Title,
                OverView = movie.OverView,
                Tagline = movie.Tagline,
                Runtime = movie.Runtime,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                BackdropUrl = movie.BackdropUrl,
                PosterUrl = movie.PosterUrl,
                OriginalLanguage = movie.OriginalLanguage,
                CreatedDate = movie.CreatedDate,
                CreatedBy = movie.CreatedBy,
                ReleaseDate = movie.ReleaseDate,
                UpdatedDate = movie.UpdatedDate,
                UpdatedBy = movie.UpdatedBy,

                // Navigation properties
                Casts = movie.MovieCasts.Select(mc => new MovieCastResponseModel
                {
                    MovieId = movie.Id,
                    CastId = mc.Cast.Id,
                    Name = mc.Cast.Name,
                    Gender = mc.Cast.Gender,
                    TmdbUrl = mc.Cast.TmdbUrl,
                    ProfilePath = mc.Cast.ProfilePath,
                    Character = mc.Character
                }).ToList(),
                Genres = movie.MovieGenres.Select(mg => new GenreResponseModel
                {
                    Id = mg.Genre.Id,
                    Name = mg.Genre.Name
                }).ToList(),
                Trailers = movie.Trailers.Select(t => new TrailerResponseModel
                {
                    Id = t.Id,
                    MovieId = movie.Id,
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                }).ToList()
            };
        }

        return null;
    }

    public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
    {
        var movies = await _movieRepository.GetHighestGrossingMovies();
        return movies.Select(m => new MovieResponseModel
        {
            Id = m.Id,
            TmdbUrl = m.TmdbUrl,
            ImdbUrl = m.ImdbUrl,
            Title = m.Title,
            OverView = m.OverView,
            Tagline = m.Tagline,
            Runtime = m.Runtime,
            Budget = m.Budget,
            Revenue = m.Revenue,
            BackdropUrl = m.BackdropUrl,
            PosterUrl = m.PosterUrl,
            OriginalLanguage = m.OriginalLanguage,
            ReleaseDate = m.ReleaseDate
        });
    }

    public async Task<PaginatedResultSet<MovieResponseModel>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex)
    {
        var movies = await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageIndex);
        var movieResponseModels = movies.Data.Select(m => new MovieResponseModel
        {
            Id = m.Id,
            TmdbUrl = m.TmdbUrl,
            ImdbUrl = m.ImdbUrl,
            Title = m.Title,
            OverView = m.OverView,
            Tagline = m.Tagline,
            Runtime = m.Runtime,
            Budget = m.Budget,
            Revenue = m.Revenue,
            BackdropUrl = m.BackdropUrl,
            PosterUrl = m.PosterUrl,
            OriginalLanguage = m.OriginalLanguage,
            ReleaseDate = m.ReleaseDate
        });

        return new PaginatedResultSet<MovieResponseModel>(movieResponseModels, pageIndex, pageSize, movies.Count);
    }
}