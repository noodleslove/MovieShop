using MovieApp.Core.Entities;

namespace MovieApp.Core.Models.Response;

public class CastResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string TmdbUrl { get; set; }
    public string ProfilePath { get; set; }
    
    // Navigation properties
    public ICollection<MovieResponseModel> Movies { get; set; } = new List<MovieResponseModel>();
}