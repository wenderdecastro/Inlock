using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }


        /// <summary>
        /// EndPoint de listagem de estudios
        /// </summary>
        /// <returns>Retorna uma lista de todos os estudios cadastrados.</returns>
        [HttpGet]
        [Authorize(Roles = "Comum, Administrador")]
        public IActionResult ListarEstudios()
        {
            try
            {
                //aciona o metodo de listagem de estudios
                List<EstudioDomain> ListaEstudio = _estudioRepository.ListarEstudios();

                //retorna um status code ok e a lista de estudios
                return Ok(ListaEstudio);

            }
            catch (Exception ex)
            {
                //retorna um badrequest e exibe a mensagem de erro
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// EndPoint de cadastro de estudios
        /// </summary>
        /// <param name="estudio">estudio a ser cadastrado</param>
        /// <returns>status code conforme resultado da requisição e estudio que foi cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(EstudioDomain estudio)
        {
            try
            {
                //aciona o metodo para cadastrar o estudio
                _estudioRepository.Cadastrar(estudio);

                //retorna o status code de criado, e o objeto referente ao estudio criado
                return StatusCode(201, estudio);
            }
            catch (Exception erro)
            {
                //retorna um badrequest e exibe a mensagem de erro
                return BadRequest(erro.Message);
            }

        }
    }
}
