using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade TiposUsuario
    /// </summary>
    public class TiposUsuarioDomain
    {

        public int IdTipoUsuario { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string Titulo { get; set; }
    }
}
