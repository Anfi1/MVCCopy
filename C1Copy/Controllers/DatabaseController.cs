using System.Diagnostics;
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
    public async Task<IActionResult> Create(string action, string Name)
    {
        if(action=="Back")
        {
            return RedirectToAction("Index");
        }

        try
        {
            Client client1 = new Client();
            client1.Name = Name;
            db.Clients.Add(client1);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch
        {
            return RedirectToAction("Index");
        }
    }
    
    public async Task<IActionResult> Details(int? id, string action)
        {
            if (id == null) return NotFound();
            
            if(action=="Back")
            {
                return RedirectToAction("Index");
            }
            ClientModel user = new ClientModel();
                user.Client = await db.Clients.FirstOrDefaultAsync(p => p.ID == id);
            if (user != null)
                return View(user);
            
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            Client user = new Client();
            if (id == null || (user = await db.Clients.FirstOrDefaultAsync(p=>p.ID==id)) == null)
                return NotFound();
            return View(user);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ClientModel user = new ClientModel();
                user.Client = await db.Clients.FirstOrDefaultAsync(p => p.ID == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id, string action)
        {
            if (id == null) return NotFound();
            if (action == "Back")
            {
                return RedirectToAction("Index", "Database");
            }
            Client user = await db.Clients.FirstOrDefaultAsync(p => p.ID == id);
            if (user != null)
            {
                db.Clients.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Database");
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Client user, string action)
        {
            if (action == "Back")
            {
                return RedirectToAction("Index", "Database");
            }
            db.Clients.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Database");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}