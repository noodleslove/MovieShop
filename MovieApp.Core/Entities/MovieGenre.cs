using Microsoft.EntityFrameworkCore;

namespace MovieApp.Core.Entities;

[PrimaryKey(nameof(MovieId), nameof(GenreId))]
public class MovieGenre
{
    public int MovieId { get; set; }
    public int GenreId { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}