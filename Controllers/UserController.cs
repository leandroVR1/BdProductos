using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync
using Bdproductos.Data;
using Bdproductos.Models; // Agrega esta directiva para usar la clase User
 // Necesario para Task<ActionResult>
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

        public async Task<IActionResult> Delete(int id, User user)
        {
        
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
       public async Task<IActionResult> Edit(int? id)
        {
           var user = await _context.Users.FindAsync(id);
           return View(user);
            
        }
        [HttpPost]
        
 public async Task<IActionResult> Edit(int id, User user)
{
   
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("index"); // Redirecciona a la acción Index del controlador UserController
    
   
}

public ActionResult Search(string searchTerm)
{
    var users = _context.Users.ToList(); // Obtener todos los usuarios
    if (!string.IsNullOrEmpty(searchTerm))
    {
        users = users.Where(u => u.Names.Contains(searchTerm) || u.LastNames.Contains(searchTerm)).ToList(); // Filtrar por nombres o apellidos
    }
    return PartialView("_UserList", users); // Devolver vista parcial con lista de usuarios
}

/*       public ActionResult Search(string searchTerm)
{
    var users = _context.Users.ToList(); // Obtener todos los usuarios

    if (!string.IsNullOrEmpty(searchTerm))
    {
        // Convertir el término de búsqueda a minúsculas
        searchTerm = searchTerm.ToLower();

        // Intentar convertir el término de búsqueda en un número (ID)
        if (int.TryParse(searchTerm, out int id))
        {
            // Si es un número, buscar por ID
            users = users.Where(u => u.Id == id).ToList();
        }
        else
        {
            // Convertir nombres y apellidos de los usuarios a minúsculas y luego comparar
            users = users.Where(u => u.Names.ToLower().Contains(searchTerm) || u.LastNames.ToLower().Contains(searchTerm)).ToList();
        }
    }

    return PartialView("_UserList", users); // Devolver vista parcial con lista de usuarios
} */




    }
}
