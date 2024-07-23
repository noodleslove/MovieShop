using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Presentation.Controllers;

public class CastController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}