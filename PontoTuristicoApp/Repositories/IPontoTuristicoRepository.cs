using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Repositories;

public interface IPontoTuristicoRepository
{
    public async Task<PaginatedList<PontoTuristico>> ObterPaginadoAsync(
        string? search,
        int page,
        int PageSize
    )
    {
        // GET: Index
        // Query base
        var query = _context.PontosTuristicos.AsQueryable();

        // Aplicar filtro se houver termo de busca
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim().ToLower();

            query = query.Where(p =>
                p.Nome.ToLower().Contains(search) ||
                p.Descricao.ToLower().Contains(search) ||
                p.Localizacao.ToLower().Contains(search));
        }

        // Ordenar por Data de Inclusão decrescente
        query = query.OrderByDescending(p => p.DataInclusao);

        // Obter total de itens (para paginação)
        var totalItems = await query.CountAsync();

        // Obter itens da página atual
        var pontos = await query
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        // Criar modelo de view com paginação
        return new PaginatedList<PontoTuristico>(pontos, totalItems, page, PageSize);

    }
}