using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync
using Bdproductos.Data;
using Bdproductos.Models; // Agrega esta directiva para usar la clase User
using System.Threading.Tasks; // Necesario para Task<ActionResult>
                              // Necesario para Task<ActionResult>

namespace Bdproductos.Controllers
{

    public class UserController : Controller
    {
        private readonly BaseContext _context;

        public UserController(BaseContext context)
        {
            _context = context; // Inyecta el contexto de la base de datos en el controlador
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());//select from * Users
        }
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Users.FirstOrDefaultAsync(x => x.Id == id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
      /*   public async Task<IActionResult> Edit(int? id)
        {
            return View(await _context.Users.FirstOrDefaultAsync(x => x.Id ==));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserController user){
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        } */
        



    }
}