using System;
using System.ComponentModel.DataAnnotations;

namespace PontoTuristicoApp.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; } = null!;
        [Required(ErrorMessage = "A localização é obrigatória")]
        public string Localizacao { get; set; } = null!;
        [Required(ErrorMessage = "Selecione a cidade")]
        public string Cidade { get; set; } = null!;
        [Required(ErrorMessage = "Selecione o estado")]
        public string Estado { get; set; } = null!;
        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
