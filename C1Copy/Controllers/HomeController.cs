using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using C1Copy.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using C1Copy.Models;

namespace C1Copy.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            UserModel model = new UserModel();
            model.Users = await db.Users.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user, string action)
        {
            if(action=="Back")
            {
                return RedirectToAction("Index");
            }

            try
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }

            
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult UpTime([FromServices] UpTimeServiceSeconds timeService)
        {
            return View(timeService);
        }
        public async Task<IActionResult> Details(int? id, string action)
        {
            if (id == null) return NotFound();
            
            if(action=="Back")
            {
                return RedirectToAction("Index");
            }
            User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
                return View(user);
            
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            User user;
            if (id == null || (user = await db.Users.FirstOrDefaultAsync(p=>p.Id==id)) == null)
                return NotFound();
            return View(user);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
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
                return RedirectToAction("Index");
            }
            User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user, string action)
        {
            if (action == "Back")
            {
                return RedirectToAction("Index");
            }
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
