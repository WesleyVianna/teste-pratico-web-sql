using System.Text.Json.Serialization;

namespace PontoTuristicoApp.Models
{
    public class CidadeDto
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; } = null!;
    }
}