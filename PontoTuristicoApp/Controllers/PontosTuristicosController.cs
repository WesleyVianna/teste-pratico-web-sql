using Microsoft.AspNetCore.Mvc;
using PontoTuristicoApp.Data;
using System.Collections.Immutable;
using System.Linq;

namespace PontoTuristicoApp.Controllers
{
    public class PontosTuristicosContoller : Controller
    {
        private readonly AppDbContext _context;

        public PontosTuristicosContoller(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pontos = _context.PontosTuristicos.OrderByDescending(p => p.DataInclusao).ToImmutableList();

            return View(pontos);
        }
    }
}