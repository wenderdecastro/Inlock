using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repository de jogo
    /// </summary>
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogoDomain">Objeto a ser cadastrado.</param>
        void Cadastrar(JogoDomain jogoDomain);

        /// <summary>
        /// Lista todos os jogos existentes
        /// </summary>
        /// <returns>Uma lista com todos os jogos.</returns>
        List<JogoDomain> ListarJogos();

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">id do Jogo a ser deletado</param>
        void DeletarJogo(int id);

    }
}
