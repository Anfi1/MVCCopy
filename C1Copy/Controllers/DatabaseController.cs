using C1Copy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C1Copy.Controllers;

public class DatabaseController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationContext db = new ApplicationContext();    
    public DatabaseController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public async Task<IActionResult> Index()
    {
        ClientModel model = new ClientModel();
        model.Clients = await db.Clients.ToListAsync();
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Client client, string action)
    {
        if(action=="Back")
        {
            return RedirectToAction("Index");
        }

        try
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch
        {
            return RedirectToAction("Index");
        }

            
    }
}