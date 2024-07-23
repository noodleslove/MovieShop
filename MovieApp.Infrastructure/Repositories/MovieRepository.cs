using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Helpers;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Repositories;

public class MovieRepository : BaseAsyncRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }

    public override async Task<Movie?> GetByIdAsync(int id)
    {
        return await _movieDbContext.Movies
            .Include(m => m.MovieCasts)
            .ThenInclude(m => m.Cast)
            .Include(m => m.MovieGenres)
            .ThenInclude(m => m.Genre)
            .Include(m => m.Trailers)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
    {
        return await _movieDbContext.Movies
            .OrderByDescending(m => m.Revenue)
            .Take(24)
            .ToListAsync();
    }

    public async Task<PaginatedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex)
    {
        var count = _movieDbContext.MovieGenres.Count(mg => mg.GenreId == genreId);
        var movies = await _movieDbContext.MovieGenres
            .Where(mg => mg.GenreId == genreId)
            .Include(mg => mg.Movie)
            .Select(mg => new Movie
            {
                Id = mg.MovieId,
                TmdbUrl = mg.Movie.TmdbUrl,
                ImdbUrl = mg.Movie.ImdbUrl,
                Title = mg.Movie.Title,
                OverView = mg.Movie.OverView,
                Tagline = mg.Movie.Tagline,
                Runtime = mg.Movie.Runtime,
                Budget = mg.Movie.Budget,
                Revenue = mg.Movie.Revenue,
                BackdropUrl = mg.Movie.BackdropUrl,
                PosterUrl = mg.Movie.PosterUrl,
                OriginalLanguage = mg.Movie.OriginalLanguage,
                CreatedDate = mg.Movie.CreatedDate,
                CreatedBy = mg.Movie.CreatedBy,
                ReleaseDate = mg.Movie.ReleaseDate,
                UpdatedDate = mg.Movie.UpdatedDate,
                UpdatedBy = mg.Movie.UpdatedBy,
            })
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResultSet<Movie>(movies, pageIndex, pageSize, count);
    }
}