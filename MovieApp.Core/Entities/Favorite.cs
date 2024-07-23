using Microsoft.EntityFrameworkCore;

namespace MovieApp.Core.Entities;

[PrimaryKey(nameof(MovieId), nameof(UserId))]
public class Favorite
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public User User { get; set; } = null!;
}