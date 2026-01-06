using Microsoft.AspNetCore.Mvc;
using PontoTuristicoApp.Data;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using PontoTuristicoApp.Models;

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
        public async Task<IActionResult> Create()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(
                "https://servicodados.ibge.gov.br/api/v1/localidades/estados"
            );

            var estados = JsonSerializer.Deserialize<List<EstadoDto>>(response) ?? new List<EstadoDto>();

            ViewBag.Estados = estados.OrderBy(e => e.Nome).ToList();

            return View();
        }


        // POST: PontosTuristicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PontoTuristico ponto)
        {
            if (ModelState.IsValid)
            {
                _context.PontosTuristicos.Add(ponto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(ponto);
        }

        [HttpGet]
        public async Task<IActionResult> GetCidades(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                return BadRequest();

            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(
                $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estado}/municipios"
            );

            var cidades = JsonSerializer.Deserialize<List<CidadeDto>>(response)
                          ?? new List<CidadeDto>();

            return Json(
                cidades.OrderBy(c => c.Nome).ToList()
            );
        }

        public IActionResult Details(int id)
        {
            var ponto = _context.PontosTuristicos.FirstOrDefault(p => p.Id == id);

            if (ponto == null)
                return NotFound();

            return View(ponto);
        }

    }
}