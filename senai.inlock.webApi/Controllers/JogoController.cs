using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Properties.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        //utiliza do construtor do controller para atribuir a variável de referência _jogoRepository as propriedades e métodos da classe JogoRepository implementados pela interface.
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// EndPoint de listagem de jogos
        /// </summary>
        /// <returns>Retorna uma lista de todos os jogos cadastrados.</returns>
        [HttpGet]
        [Authorize(Roles = "Comum, Administrador")]
        public IActionResult ListarJogos()
        {
            try
            {
                //aciona o metodo de listagem de jogos
                List<JogoDomain> ListaJogos = _jogoRepository.ListarJogos();

                //retorna um status code ok e a lista de jogos
                return Ok(ListaJogos);

            }
            catch (Exception ex)
            {
                //retorna um badrequest e exibe a mensagem de erro
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// EndPoint de cadastro de jogos
        /// </summary>
        /// <param name="jogo">jogo a ser cadastrado</param>
        /// <returns>status code conforme resultado da requisição e jogo que foi cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(JogoDomain jogo)
        {
            try
            {
                //aciona o metodo para cadastrar o jogo
                _jogoRepository.Cadastrar(jogo);

                //retorna o status code de criado, e o objeto referente ao jogo criado
                return StatusCode(201, jogo);
            }
            catch (Exception erro)
            {
                //retorna um badrequest e exibe a mensagem de erro
                return BadRequest(erro.Message);
            }

        }
        /// <summary>
        /// EndPoint de exclusão de jogos
        /// </summary>
        /// <param name="id">Id do Jogo a ser deletado</param>
        /// <returns>Retorna um status code e sua respectiva mensagem</returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete (int id)
        {
            try
            {
                //Aciona o metodo de deletar o jogo
                _jogoRepository.DeletarJogo(id);

                //Retorna o status code e sua respectiva mensagem
                return StatusCode(204, "Jogo deletado com sucesso.");

            }
            catch (Exception ex)
            {
                //retorna um badrequest e exibe a mensagem de erro
                return BadRequest(ex.Message);
            }
        }


    }
}
