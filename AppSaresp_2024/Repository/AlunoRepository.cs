using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _conexaoMySQL;

        public AlunoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbaluno(Nome, Email, Telefone, Serie, Turma, DataNasc) " +
                                                    " values (@Nome, @Email, @Telefone, @Serie, @Turma, @DataNasc)", conexao);
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = aluno.Nome;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = aluno.Telefone;
                cmd.Parameters.Add("@Serie", MySqlDbType.VarChar).Value = aluno.Serie;
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = aluno.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            List<Aluno> AlunoList = new List<Aluno>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbaluno", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    AlunoList.Add(
                        new Aluno
                        {
                            IdAluno = Convert.ToInt32(dr["IdAluno"]),
                            Nome = (string)dr["Nome"],
                            Email = (string)dr["Email"],
                            Telefone = Convert.ToInt32(dr["Telefone"]),
                            Serie = (string)dr["Serie"],
                            Turma = (string)dr["Turma"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                }
                return AlunoList;
            }
        }
    }
}
