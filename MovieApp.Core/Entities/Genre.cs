using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Core.Entities;

public class Genre
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(24)")]
    public string Name { get; set; }
    
    // Navigation properties
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}