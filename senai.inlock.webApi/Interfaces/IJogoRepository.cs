using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
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

        ///// <summary>
        ///// Busca um jogo pelo seu Id
        ///// </summary>
        ///// <param name="id">Id do jogo a ser buscado</param>
        ///// <returns>O Jogo buscado</returns>
        //JogoDomain BuscarPorId(int id);

        ///// <summary>
        ///// Edita um jogo pelo corpo da requisição
        ///// </summary>
        ///// <param name="jogoDomain">jogo a ser editado</param>
        //void EditarJogo(JogoDomain jogoDomain);

        ///// <summary>
        ///// Edita um jogo pelo seu id
        ///// </summary>
        ///// <param name="id">id do jogo a ser editado</param>
        ///// <param name="jogoDomainId">Corpo do jogo que será editado</param>
        //void EditarJogoId(int id, JogoDomain jogoDomainId);

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">id do Jogo a ser deletado</param>
        void DeletarJogo(int id);

    }
}
