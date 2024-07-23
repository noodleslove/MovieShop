using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Core.Entities;

public class Trailer
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string TrailerUrl { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string Name { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
}