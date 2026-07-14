using Microsoft.EntityFrameworkCore;
using PontoTuristicoApp.Data;
using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Repositories;

public class PontoTuristicoRepository : IPontoTuristicoRepository
{
    private readonly AppDbContext _context;

    public PontoTuristicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PontoTuristico>> ObterTodosAsync()
    {
        return await _context.PontosTuristicos.ToListAsync();
    }
}