using System;
using System.ComponentModel.DataAnnotations;

namespace PontoTuristicoApp.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Localizacao { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
