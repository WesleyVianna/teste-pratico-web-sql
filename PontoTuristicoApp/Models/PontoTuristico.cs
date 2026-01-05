using System;
using System.ComponentModel.DataAnnotations;

namespace PontoTuristicoApp.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public string Localizacao { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}