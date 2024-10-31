using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class ProfessorAplicadorRepository : IProfessorAplicadorRepository
    {
        private readonly string _conexaoMySQL;

        public ProfessorAplicadorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar(ProfessorAplicador professor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbprofessorAplicador(Nome, CPF, RG, Telefone, DataNasc) " +
                                                    " values (@Nome, @CPF, @RG, @Telefone, @DataNasc);", conexao);
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = professor.Nome;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = professor.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professor.RG;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = professor.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = professor.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public IEnumerable<ProfessorAplicador> ObterTodosProfessores()
        {
            List<ProfessorAplicador> ProfessorList = new List<ProfessorAplicador>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbprofessorAplicador;", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    ProfessorList.Add(
                        new ProfessorAplicador
                        {
                            IdProfessor = Convert.ToInt32(dr["IdProfessor"]),
                            Nome = (string)dr["Nome"],
                            CPF = Convert.ToInt64(dr["CPF"]),
                            RG = Convert.ToInt32(dr["RG"]),
                            Telefone = Convert.ToInt64(dr["Telefone"]),
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                }
                return ProfessorList;
            }
        }
    }
}
