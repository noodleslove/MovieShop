using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Repositories;

public class CastRepository : BaseAsyncRepository<Cast>, ICastRepository
{
    public CastRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }

    public override async Task<Cast?> GetByIdAsync(int id)
    {
        return await _movieDbContext.Casts
            .Include(c => c.MovieCasts)
            .ThenInclude(c => c.Movie)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}