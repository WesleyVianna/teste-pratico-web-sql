using System;
using System.ComponentModel.DataAnnotations;

namespace PontoTuristicoApp.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = null!;
        [Required, StringLength(100)]
        public string Descricao { get; set; } = null!;
        [Required]
        public string Localizacao { get; set; } = null!;
        [Required]
        public string Cidade { get; set; } = null!;
        [Required]
        public string Estado { get; set; } = null!;
        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
