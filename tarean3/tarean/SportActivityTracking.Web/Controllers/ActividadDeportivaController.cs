using Microsoft.AspNetCore.Mvc;
using SportActivityTracking.Web.Models.Entidad;
using SportActivityTracking.Web.Data;
using System.Linq;

namespace SportActivityTracking.Web.Controllers
{
    public class ActividadDeportivaController : Controller
    {
        private readonly ActividadDeportivaDbContext _context;

        public ActividadDeportivaController(ActividadDeportivaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var actividades = _context.ActividadesDeportivas.ToList();
            return View(actividades);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActividadDeportiva actividad)
        {
            if (ModelState.IsValid)
            {
                _context.ActividadesDeportivas.Add(actividad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(actividad);
        }

        public IActionResult Edit(int id)
        {
            var actividad = _context.ActividadesDeportivas.Find(id);
            if (actividad == null)
            {
                return NotFound();
            }
            return View(actividad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ActividadDeportiva actividad)
        {
            if (id != actividad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    _context.SaveChanges();
                }
                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actividad);
        }

        public IActionResult Delete(int id)
        {
            var actividad = _context.ActividadesDeportivas.Find(id);
            if (actividad == null)
            {
                return NotFound();
            }
            return View(actividad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actividad = _context.ActividadesDeportivas.Find(id);
            if (actividad != null)
            {
                _context.ActividadesDeportivas.Remove(actividad);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var actividad = _context.ActividadesDeportivas.FirstOrDefault(a => a.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }
    }
}