using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync
using Bdproductos.Data;
using System.Threading.Tasks; // Necesario para Task<ActionResult>

namespace Bdproductos.Controllers{
    public class ProductController : Controller{
        private readonly BaseContext _productcontext;
         public ProductController(BaseContext context)
        {
            _productcontext = context; // Inyecta el contexto de la base de datos en el controlador
        }

         public async Task<IActionResult> Index()
        {
            return View(await _productcontext.Products.ToListAsync());//select from * Users
        }
        public async Task<IActionResult> Details(int? id)
        {
            return View (await _productcontext.Products.FirstOrDefaultAsync(x => x.Id == id));
        }

    }

}