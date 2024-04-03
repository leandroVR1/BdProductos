using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync
using Bdproductos.Data;
using System.Threading.Tasks; // Necesario para Task<ActionResult>

namespace Bdproductos.Controllers{

    public class UserController : Controller{
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
            return View (await _context.Users.FirstOrDefaultAsync(x => x.Id == id));
        }

    }
}