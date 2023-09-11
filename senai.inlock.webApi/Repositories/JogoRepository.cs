using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Globalization;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=NOTE10-S15; Initial Catalog=inlock_games; User ID =sa; Pwd =Senai@134;TrustServerCertificate=true";

        /// <summary>
        /// Lista todos os jogos existentes
        /// </summary>
        /// <returns>Uma lista com todos os jogos.</returns>
        public List<JogoDomain> ListarJogos()
        {
            //Declara a String que será utilizada na função para listagem de todos os jogos por meio de uma query no SQL
            string querySelectAll = "SELECT IdJogo, IdEstudio, Nome, Descricao, DataLancamento, Valor FROM Jogo";

            //Estabelece conexão com o banco de dados por meio da stringconexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //abre conexão com o banco de dados
                con.Open();

                //Lista de jogos que sera retornada no final
                List<JogoDomain> ListaJogos = new List<JogoDomain>();

                //Declara o SqlCommand passando como parametro o comando que sera executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Declara o SqlDataReader e atribuindo a consulta por meio do método ExecuteReader() como valor
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //laço que cria objetos e atribui o valor do objeto em questão do banco de dados
                        while (rdr.Read())
                        {
                            JogoDomain jogo = new JogoDomain()
                            {
                                IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString(),

                                Descricao = rdr["Descricao"].ToString(),

                                DataLancamento = DateTime.Parse(rdr["DataLancamento"].ToString()),

                                Valor = float.Parse(rdr["Valor"].ToString()),

                            };

                            //adiciona o objeto na lista
                            ListaJogos.Add(jogo);
                        }

                    }

                }

                //retorna a lista
                return ListaJogos;

            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">Objeto a ser cadastrado.</param>
        public void Cadastrar(JogoDomain jogo)
        {
            //Declara a String que será utilizada para realizar cadastro de jogos no SQL
            string queryInsert = "INSERT INTO Jogo(IdEstudio, Nome, Descricao, DataLancamento) Values (@idestudio, @nome, @desc, @date)";

            //Estabelece conexão com o banco de dados por meio da stringconexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //abre conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando como parametro o comando que sera executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //adiciona os respectivos valores nas váriaveis do sql que serão utilizados como valor na inserção de dados na tabela
                    cmd.Parameters.AddWithValue("@idestudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@desc", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@date", jogo.DataLancamento);

                    //executa os comandos sem realizar uma consulta
                    cmd.ExecuteNonQuery();
                    
                }

            }

        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">id do Jogo a ser deletado</param>
        public void DeletarJogo(int id)
        {
            //string de modificação do banco de dados que realizará o processo de exclusão de um objeto
            string deleteRow = "DELETE FROM Jogo WHERE IdJogo = @id";

            //Estabelece conexão com o banco de dados por meio da stringconexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //abre conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando como parametro o comando que sera executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(deleteRow, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }

            }

        }

    }
}
