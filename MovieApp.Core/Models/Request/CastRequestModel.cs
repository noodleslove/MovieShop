namespace MovieApp.Core.Models.Request;

public class CastRequestModel
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string TmdbUrl { get; set; }
    public string ProfilePath { get; set; }
}