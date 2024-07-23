using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Interfaces.Service;

namespace MovieApp.Presentation.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllMovies();
        return View(movies);
    }
    
    // GET
    [Route("Movies/Details/{id:int:min(1)}")]
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieService.GetMovieDetails(id);
        return View(movie);
    }
    
    // GET
    public async Task<IActionResult> Genre(int id, int pageSize = 30, int pageIndex = 1)
    {
        var movies = await _movieService.GetMoviesByGenre(id, pageSize, pageIndex);
        return View("PageIndex", movies);
    }
}