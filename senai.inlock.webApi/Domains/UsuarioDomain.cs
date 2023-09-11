using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade usuário
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O Campo de Email é obrigatório.")]
        [NotNull]
        public string? Email { get; set; }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 á 24 caracteres")]
        public string? Senha { get; set; }

        /// <summary>
        /// Referência a classe tiposusuario que atribui o valor da mesma a usuario, por ser uma foreign key
        /// </summary>
        public TiposUsuarioDomain TipoUsuario { get; set; }
    }
}
