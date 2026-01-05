using Microsoft.AspNetCore.Mvc;
using PontoTuristicoApp.Data;
using System.Collections.Immutable;
using System.Linq;

namespace PontoTuristicoApp.Controllers
{
    public class PontosTuristicosController : Controller
    {
        private readonly AppDbContext _context;

        public PontosTuristicosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pontos = _context.PontosTuristicos.OrderByDescending(p => p.DataInclusao).ToList();

            return View(pontos);
        }
    
        // GET: PontosTuristicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PontosTuristicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.PontoTuristico ponto)
        {
            if (ModelState.IsValid)
            {
                _context.PontosTuristicos.Add(ponto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(ponto);
        } 
    }
}