using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="estudioDomain">Objeto a ser cadastrado.</param>
        void Cadastrar(EstudioDomain estudioDomain);

        /// <summary>
        /// Lista todos os estudios existentes
        /// </summary>
        /// <returns>Uma lista com todos os estudios.</returns>
        List<EstudioDomain> ListarEstudios();
    }
}
