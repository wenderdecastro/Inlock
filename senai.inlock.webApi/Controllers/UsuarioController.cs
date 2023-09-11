using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Endpoint de login do usuário
        /// </summary>
        /// <param name="usuario">objeto do tipo usuario que será utilizado para realizar a consulta, passando os dados pelo corpo da requisilçao por meio do JSON</param>
        /// <returns>retorna o token JWT para autenticação do usuário</returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            //utiliza do método de login e armazena o retorno em um objeto do tipo usuario
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            try
            {
                //se o usuario não for nulo, cria um token JWT
                if (usuarioBuscado != null)
                {

                    //criação do token JWT 

                    //1º, define as informações do token (payload), como parametro estão as propriedades do usuário que serão inseridas no token

                    var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                            new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                            new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Titulo),

                        };

                    //2º define chave de acesso ao token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-inlock.webapi.auth.dev-senai"));

                    //3º define as credenciais do token
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4º Gera o token JWT
                    var token = new JwtSecurityToken(
                        // emissor do token
                        issuer: "senai.inlock.webApi",
                        // destinatario do token
                        audience: "senai.inlock.webApi",
                        // informações do token
                        claims: claims,
                        // duração do token
                        expires: DateTime.Now.AddMinutes(30),
                        // credenciais que serão utilizadas
                        signingCredentials: creds
                        );

                    //retorna um ok e o token JWT
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                }

                //se o usuario é nulo, exibe uma mensagem de erro junto ao um notfound, porque o usuário não foi encontrado na tabela
                return NotFound("Email ou senha inválidos");

            }
            catch (Exception erro)
            {
                //retorna um badrequest e exibe a mensagem de erro
                return BadRequest(erro.Message);
            }

        }
    }
}
