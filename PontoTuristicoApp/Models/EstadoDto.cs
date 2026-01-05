using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace PontoTuristicoApp.Models
{
    public class EstadoDto
    {
        [JsonPropertyName("sigla")]
        public string Sigla { get; set; } = null!;

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = null!;
    }
}