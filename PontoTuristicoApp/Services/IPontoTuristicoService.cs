using PontoTuristicoApp.Models;

public interface IPontoTuristicoService
{
    Task<IEnumerable<PontoTuristico>> ListarAsync();

    Task<PontoTuristico?> BuscarPorIdAsync(int id);

    Task CadastrarAsync(PontoTuristico ponto);

    Task AtualizarAsync(PontoTuristico ponto);

    Task ExcluirAsync(int id);
}