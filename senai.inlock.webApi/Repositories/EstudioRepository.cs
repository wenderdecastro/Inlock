using Microsoft.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=NOTE10-S15; Initial Catalog=inlock_games; User ID =sa; Pwd =Senai@134;TrustServerCertificate=true";

        /// <summary>
        /// Lista todos os estudios existentes
        /// </summary>
        /// <returns>Uma lista com todos os estudios.</returns>
        public List<EstudioDomain> ListarEstudios()
        {
            //Declara a String que será utilizada na função para listagem de todos os estudios por meio de uma query no SQL
            string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

            //Estabelece conexão com o banco de dados por meio da stringconexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //abre conexão com o banco de dados
                con.Open();

                //Lista de estudios que sera retornada no final
                List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();

                //Declara o SqlCommand passando como parametro o comando que sera executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Declara o SqlDataReader e atribuindo a consulta por meio do método ExecuteReader() como valor
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //laço que cria objetos e atribui o valor do objeto em questão do banco de dados
                        while (rdr.Read())
                        {
                            EstudioDomain estudio = new EstudioDomain()
                            {

                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString(),

                            };

                            //adiciona o objeto na lista
                            ListaEstudios.Add(estudio);
                        }

                    }

                }

                //retorna a lista
                return ListaEstudios;

            }
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="estudio">Objeto a ser cadastrado.</param>
        public void Cadastrar(EstudioDomain estudio)
        {
            //Declara a String que será utilizada para realizar cadastro de jogos no SQL
            string queryInsert = "INSERT INTO Estudio (Estudio.Nome) Values (@nome)";

            //Estabelece conexão com o banco de dados por meio da stringconexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //abre conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando como parametro o comando que sera executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //adiciona os respectivos valores nas váriaveis do sql que serão utilizados como valor na inserção de dados na tabela
                    cmd.Parameters.AddWithValue("@nome", estudio.Nome);

                    //executa os comandos sem realizar uma consulta
                    cmd.ExecuteNonQuery();

                }

            }

        }




    }
}

