using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

/*
 Referência:
 https://docs.microsoft.com/pt-br/sql/connect/ado-net/microsoft-ado-net-sql-server?view=sql-server-ver15 
 Exemplos:
 https://docs.microsoft.com/pt-br/dotnet/framework/data/adonet/ado-net-code-examples#sqlclient


    DBCommand
    https://docs.microsoft.com/pt-br/dotnet/api/system.data.common.dbcommand?view=net-6.0
    SqlCommand
    https://docs.microsoft.com/pt-br/dotnet/api/system.data.sqlclient.sqlcommand?view=dotnet-plat-ext-6.0
    
 */

namespace AcessoDapper
{
    internal class DAOAluno
    {
        const string CONNECTION_STRING = "data source=localhost;initial catalog=TESTE;Persist Security Info=True;Connection Timeout=60;User ID=sa;Password=boi228369";

        public List<Aluno> RecuperarAlunos()
        {
            List<Aluno> listaAlunos;

            string sql = "SELECT * from Alunos"; //NUNCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    listaAlunos = conexao.Query<Aluno>(sql).AsList(); 

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                //throw;
                return null;
            }

            return listaAlunos;
        }



        public Aluno InserirAluno(Aluno alu)
        {
            alu.IdAluno = 0;
            try
            {
                string sqlAluno = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.idAluno 
                                                VALUES (@nome, @telefone)"; //NUCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

               
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var retornoAluno = conexao.ExecuteScalar(sqlAluno, alu);
                    alu.IdAluno = Convert.ToInt32(retornoAluno);                                           
                }
            }
            catch (DbException exDb)
            {
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                return alu;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
                return alu;
            }


            return alu;
        }

        public Aluno InserirAlunoTelefone(Aluno alu)
        {
            alu.IdAluno = 0;
            try
            {
                string sqlAluno = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.idAluno 
                                                VALUES (@nome, @telefone)";

                string sqlTelefone = @"INSERT INTO Telefone (numeroTelefone, idAluno)
                                       VALUES( @numeroTelefone, @idAluno)";



                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    conexao.Open();
                    using (var transaction = conexao.BeginTransaction())
                    {
                        var retornoAluno = conexao.ExecuteScalar(sqlAluno, alu, transaction);
                        alu.IdAluno = Convert.ToInt32(retornoAluno);

                        foreach (var tel in alu.listaTelefones)
                        {
                            tel.IdAluno = alu.IdAluno;
                        }

                        var retornoTelefone = conexao.Execute(sqlTelefone, alu.listaTelefones, transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (DbException exDb)
            {
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                return alu;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
                return alu;
            }


            return alu;
        }


        public Aluno AtualizarAluno(Aluno alu)
        {  
            try
            {
                string sqlAluno = $@"UPDATE Alunos
                                     SET [nome] = @nome
                                        ,[telefone] = @telefone
                                     WHERE idAluno = @idAluno";


                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var retornoAluno = conexao.Execute(sqlAluno, alu);
                    //alu.IdAluno = Convert.ToInt32(retornoAluno);
                }
            }
            catch (DbException exDb)
            {
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                return null;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
                return null;
            }


            return alu;
        }


        public int ExecutarProcedureRemoveAluno(Aluno alu)
        {
            int linhasAfetadas = 0;

            try
            {
                string procedure = "[removeAluno]";
                var pars = new { idAluno = alu.IdAluno };


                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var retornoAluno = conexao.Execute(procedure, pars, commandType: CommandType.StoredProcedure);
                    linhasAfetadas = Convert.ToInt32(retornoAluno);
                }
            }
            catch (DbException exDb)
            {
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                return 0;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
                return 0;
            }


            return linhasAfetadas;
        }

        public List<Telefone> ExecutarProcedureConsultaTelefones(Aluno alu)
        {
            List<Telefone> listaTelefones;

            try
            {
                string procedure = "[consultarTelefone]";
                var pars = new { idAluno = alu.IdAluno };


                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var telefones = conexao.Query<Telefone>(procedure, pars, commandType: CommandType.StoredProcedure);
                    listaTelefones = telefones.AsList();
                }
            }
            catch (DbException exDb)
            {
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                return null;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
                return null;
            }


            return listaTelefones;
        }

        //Implementar o metodo para atualizar um aluno (UPDATE)

        //Implementar o metodo para remover um aluno (DELETE)

    }
}

