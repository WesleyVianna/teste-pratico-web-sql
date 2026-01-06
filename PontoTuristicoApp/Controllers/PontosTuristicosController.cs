using Microsoft.AspNetCore.Mvc;
using PontoTuristicoApp.Data;
using PontoTuristicoApp.Models;
using System.Text.Json;

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
            var pontos = _context.PontosTuristicos
                .OrderByDescending(p => p.DataInclusao)
                .ToList();

            return View(pontos);
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            await CarregarEstadosAsync();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PontoTuristico ponto)
        {
            if (!ModelState.IsValid)
            {
                await CarregarEstadosAsync();
                return View(ponto);
            }

            _context.PontosTuristicos.Add(ponto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            return Json(cidades.OrderBy(c => c.Nome));
        }

        public IActionResult Details(int id)
        {
            var ponto = _context.PontosTuristicos.FirstOrDefault(p => p.Id == id);

            if (ponto == null)
                return NotFound();

            return View(ponto);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ponto = await _context.PontosTuristicos.FindAsync(id);

            if (ponto == null)
                return NotFound();

            await CarregarEstadosAsync();
            return View(ponto);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PontoTuristico ponto)
        {
            if (id != ponto.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await CarregarEstadosAsync();
                return View(ponto);
            }

            _context.Update(ponto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task CarregarEstadosAsync()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(
                "https://servicodados.ibge.gov.br/api/v1/localidades/estados"
            );

            var estados = JsonSerializer.Deserialize<List<EstadoDto>>(response)
                          ?? new List<EstadoDto>();

            ViewBag.Estados = estados.OrderBy(e => e.Nome).ToList();
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var ponto = _context.PontosTuristicos.FirstOrDefault(p => p.Id == id);

            if (ponto == null)
                return NotFound();
            
            return View(ponto);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ponto = _context.PontosTuristicos.Find(id);

            if (ponto != null)
            {
                _context.PontosTuristicos.Remove(ponto);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}