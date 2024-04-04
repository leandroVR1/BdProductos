using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync
using Bdproductos.Data;
using Bdproductos.Models; // Agrega esta directiva para usar la clase User
using System.Threading.Tasks; // Necesario para Task<ActionResult>
using Microsoft.AspNetCore.Mvc.Rendering;


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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(Product product)
{

    _productcontext.Products.Add(product);
    await _productcontext.SaveChangesAsync();

    return RedirectToAction("Index");
}
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productcontext.Products.FindAsync(id);
            _productcontext.Products.Remove(product);
            await _productcontext.SaveChangesAsync();
            return RedirectToAction("index");
        }

    }
    

}