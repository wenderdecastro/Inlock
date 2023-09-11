using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogo
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome de jogo é obrigatório")]
        public string? Nome { get; set; }

        [StringLength(256, MinimumLength = 24)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        public DateTime DataLancamento { get; set; }

        public float Valor { get; set; }


    }
}
