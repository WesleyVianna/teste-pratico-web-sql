using System.Text.Json;
using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Services
{
    public interface IIbgeService
    {
        Task<List<EstadoDto>?> ObterEstadosAsync();
        Task<List<CidadeDto>?> ObterCidadesAsync(string estadoSigla);
    }

    public class IbgeService : IIbgeService
    {
        private readonly HttpClient _httpClient;

        public IbgeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EstadoDto>?> ObterEstadosAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome");
                return JsonSerializer.Deserialize<List<EstadoDto>>(response);
            }
            catch
            {
                return null; 
            }
        }

        public async Task<List<CidadeDto>?> ObterCidadesAsync(string estadoSigla)
        {
            if (string.IsNullOrWhiteSpace(estadoSigla))
                return new List<CidadeDto>();

            try
            {
                var response = await _httpClient.GetStringAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estadoSigla}/municipios");
                return JsonSerializer.Deserialize<List<CidadeDto>>(response);
            }
            catch
            {
                return null;
            }
        }
    }
}