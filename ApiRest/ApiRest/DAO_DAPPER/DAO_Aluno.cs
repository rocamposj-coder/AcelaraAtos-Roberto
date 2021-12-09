using ApiRest.Entidades;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ApiRest.DAO_DAPPER
{
    public class DAO_Aluno : IDAO_Aluno
    {
        

        public Aluno CadastrarAluno(Aluno alu)
        {
            alu.Id = 0;
            try
            {
                string sqlAluno = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.id 
                                                VALUES (@nome, @telefone)"; //NUCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....


                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    var retornoAluno = conexao.ExecuteScalar(sqlAluno, alu);
                    alu.Id = Convert.ToInt32(retornoAluno);
                }
            }
            catch (DbException exDb)
            {/*
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                */
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao inserir o aluno!";
                return alu;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                //Console.WriteLine("Exception.Message: {0}", ex.Message);
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao inserir o aluno!";
                return alu;
            }


            return alu;
        }

        public Aluno RecuperarAluno(Aluno alu)
        {

            string sql = "SELECT * from Alunos Where [id] = @id"; //NUNCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

            try
            {
                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    alu = conexao.Query<Aluno>(sql, alu).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao Recuperar o aluno!";
                return alu;
            }

            return alu;
        }

        public IEnumerable<Aluno> RecuperarAlunos()
        {
            IEnumerable<Aluno> listaAlunos;

            string sql = "SELECT * from Alunos"; //NUNCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

            try
            {
                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    listaAlunos = conexao.Query<Aluno>(sql).AsList();
                }
            }
            catch (Exception ex)
            {
                //TODO Registrar o LOG do ERRO
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);

                return null;
            }

            return listaAlunos;
        }

        public Aluno AtualizarAluno(Aluno alu)
        {
            try
            {
                string sqlAluno = $@"UPDATE Alunos
                                     SET [nome] = @nome
                                        ,[telefone] = @telefone
                                     WHERE id = @id";


                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    var retornoAluno = conexao.Execute(sqlAluno, alu);
                    //alu.IdAluno = Convert.ToInt32(retornoAluno);
                }
            }
            catch (DbException exDb)
            {
                /*
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                */
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao atualizar o aluno!";
                return alu;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                //Console.WriteLine("Exception.Message: {0}", ex.Message);
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao atualizar o aluno!";
                return alu;
            }

            return alu;
        }

        public Aluno RemoverAluno(Aluno alu)
        {
            int linhasAfetadas = 0;

            try
            {
                string sql = "DELETE FROM ALUNOS WHERE id = @id";

                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    var retornoAluno = conexao.Execute(sql, alu);
                    linhasAfetadas = Convert.ToInt32(retornoAluno);
                }
            }
            catch (DbException exDb)
            {
                /*
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                */
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao remover o aluno!";

                return alu;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                alu.CodErro = -1;
                alu.MensagemErro = "Erro ao remover o aluno!";
                //Console.WriteLine("Exception.Message: {0}", ex.Message);
                return alu;
            }


            

            return alu;
        }
    }
}
