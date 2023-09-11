using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repository de usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método de login que efetuara a autenticação do usuário
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>retorna um objeto do tipo usuario</returns>
        UsuarioDomain Login (string email, string senha);

    }
}
