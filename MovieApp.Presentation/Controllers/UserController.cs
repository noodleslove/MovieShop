using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Presentation.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}