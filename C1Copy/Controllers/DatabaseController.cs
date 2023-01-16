using Microsoft.AspNetCore.Mvc;

namespace C1Copy.Controllers;

public class DatabaseController : Controller
{
    DatabaseController()
    {
        
    }
    
    public IActionResult Index()
    {
        return View();
    }
}