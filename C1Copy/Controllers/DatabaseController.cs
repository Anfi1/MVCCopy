using System.Diagnostics;
using C1Copy.Models;
using C1Copy.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        return View(await db.Clients.ToListAsync());
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
            client1.LegalEntitiesID = 1;
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

            Client user = new Client();
            if (id == null || (user = await db.Clients.FirstOrDefaultAsync(p=>p.ID==id)) == null)
                return NotFound();
            user.LegalEntitie = await db.LegalEntities.FirstOrDefaultAsync(p => p.LegalEntitiesID == user.LegalEntitiesID);
            user.Offices =  db.Offices.Where(p => p.ClientID == user.OfficesID).ToList();
            return View(user);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            Client user = new Client();
            if (id == null || (user = await db.Clients.FirstOrDefaultAsync(p=>p.ID==id)) == null)
                return NotFound();
            ClientModel client = new ClientModel();
            client.Client = user;
            client.LegalEntitiesList = await db.LegalEntities.ToListAsync();
            return View(client);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Client user = await db.Clients.FirstOrDefaultAsync(p => p.ID == id);
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
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string action, string Name, int ClientID, int? LegalID2)
        {
            if (action == "Back")
            {
                return RedirectToAction("Index", "Database");
            }
            Client user1 = new Client { ID = ClientID, Name = Name, LegalEntitiesID = LegalID2, OfficesID = 1};

            if (LegalID2 == null)
            {
                
            }
            
            db.Clients.Update(user1);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Database");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}