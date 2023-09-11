using Microsoft.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=NOTE10-S15; Initial Catalog=inlock_games; User ID =sa; Pwd =Senai@134;TrustServerCertificate=true";

        /// <summary>
        /// Método de login que efetuara a autenticação do usuário
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>retorna um objeto do tipo usuario que foi encontrado pelo método, em caso de não encontrado, retorna nulo</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            //string de consulta de usuario e tipo de usuario por meio do innerjoin no banco de dados, que tera como resultado o objeto cujo os parâmetros coincidem
            string loginQuery = "SELECT Usuario.IdUsuario, Usuario.Email, Usuario.IdTipoUsuario, TiposUsuario.IdTipoUsuario, TiposUsuario.Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Email = @email AND Senha = @senha";

            //Declara a conexão com o banco de dados utilizando como parâmetro a stringconexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //abre conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando como parametro o comando que sera executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(loginQuery, con))
                {
                    //adiciona os parâmetros as váriaveis do sql que serão utilizadas para consultar o usuário especifico no ato de login
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    //Declara o SqlDataReader e atribuindo a consulta por meio do método ExecuteReader() como valor
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //armazena o objeto encontrado no banco de dados em um objeto do tipo usuario
                        if (rdr.Read())
                        {
                            UsuarioDomain user = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                                Email = (string)rdr["Email"],

                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                                TipoUsuario = new TiposUsuarioDomain()
                                {
                                    IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                                    Titulo = (string)rdr["Titulo"]
                                }

                            };

                            //retorna o usuario
                            return user;
                        }
                        //retona nulo caso o usuario não seja encontrado na leitura
                        return null;

                    }

                }

            }


        }
    }
}
