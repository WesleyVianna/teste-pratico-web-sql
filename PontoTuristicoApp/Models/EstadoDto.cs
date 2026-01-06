using System.Text.Json.Serialization;

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