using Microsoft.AspNetCore.Mvc;
using PontoTuristicoApp.Data;
using PontoTuristicoApp.Models;
using PontoTuristicoApp.Services;
using Microsoft.EntityFrameworkCore;

namespace PontoTuristicoApp.Controllers
{
    public class PontosTuristicosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IIbgeService _ibgeService;
        private const int PageSize = 6;

        public PontosTuristicosController(AppDbContext context, IIbgeService ibgeService)
        {
            _context = context;
            _ibgeService = ibgeService;
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            await CarregarEstadosViewBagAsync();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PontoTuristico ponto)
        {
            if (!ModelState.IsValid)
            {
                await CarregarEstadosViewBagAsync();
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
                return BadRequest("Estado não fornecido.");

            var cidades = await _ibgeService.ObterCidadesAsync(estado)
             ?? new List<CidadeDto>();

            return Json(cidades.OrderBy(c => c.Nome));
        }

        public async Task<IActionResult> Details(int id)
        {
            var ponto = await _context.PontosTuristicos.FirstOrDefaultAsync(p => p.Id == id);

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

            await CarregarEstadosViewBagAsync();
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
                await CarregarEstadosViewBagAsync();
                return View(ponto);
            }

            _context.Update(ponto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var ponto = await _context.PontosTuristicos.FirstOrDefaultAsync(p => p.Id == id);

            if (ponto == null)
                return NotFound();

            return View(ponto);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ponto = await _context.PontosTuristicos.FindAsync(id);

            if (ponto != null)
            {
                _context.PontosTuristicos.Remove(ponto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Index
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            var query = _context.PontosTuristicos.AsNoTracking(); // AsNoTracking melhora performance em consultas de leitura

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                query = query.Where(p =>
                    p.Nome.ToLower().Contains(search) ||
                    p.Descricao.ToLower().Contains(search) ||
                    p.Localizacao.ToLower().Contains(search));
            }

            query = query.OrderByDescending(p => p.DataInclusao);

            var totalItems = await query.CountAsync();
            var pontos = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var model = new PaginatedList<PontoTuristico>(pontos, totalItems, page, PageSize);
            ViewBag.Search = search;

            return View(model);
        }

        private async Task CarregarEstadosViewBagAsync()
        {
            var estados = await _ibgeService.ObterEstadosAsync()
                          ?? new List<EstadoDto>();

            ViewBag.Estados = estados
                .OrderBy(e => e.Nome)
                .ToList();
        }
    }
}