using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Core.Entities;

public class Cast
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string TmdbUrl { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string ProfilePath { get; set; }
    
    // Navigation properties
    public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
}