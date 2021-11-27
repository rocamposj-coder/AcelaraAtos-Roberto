using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace AcessoBancoDados
{
    internal class DAOAluno
    {
        const string CONNECTION_STRING = "data source=localhost;initial catalog=TESTE;Persist Security Info=True;Connection Timeout=60;User ID=sa;Password=boi228369";
               
        public List<Aluno> RecuperarAlunos()
        {
            List<Aluno> listaAlunos = new List<Aluno>();

            try
            {

                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    conexao.Open();

                    using (DbCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = $@"SELECT * from Alunos";
                                                

                        using (IDataReader reader = comando.ExecuteReader())
                        {
                            Aluno alu;

                            while (reader.Read())
                            {
                                alu = new Aluno();

                                if (!reader.IsDBNull(0))
                                {
                                    alu.Id = Convert.ToInt32(reader[0]);
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    alu.Nome = Convert.ToString(reader[1]);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    alu.Telefone = Convert.ToString(reader[2]);
                                }

                                

                                listaAlunos.Add(alu);
                            }

                        }
                    }

                    conexao.Close(); //Da para abrir novamente
                    //conexao.Dispose(); //nao pode abrir novamente.
                    //Nao preciso fazer o Dispose aqui ! Porque ?
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

        public List<Aluno> RecuperarAlunosSQLCommand()
        {
            List<Aluno> listaAlunos = new List<Aluno>();

            try
            {

                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    conexao.Open();

                    using (SqlCommand comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = $@"SELECT * from Alunos";
                        

                        using (IDataReader reader = comando.ExecuteReader()) //ExecuteScalar
                        {
                            while (reader.Read())
                            {

                                Aluno alu = new Aluno();

                                if (!reader.IsDBNull(0))
                                {
                                    alu.Id = Convert.ToInt32(reader[0]);
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    alu.Nome = Convert.ToString(reader[1]);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    alu.Telefone = Convert.ToString(reader[2]);
                                }

                                listaAlunos.Add(alu);
                            }

                        }
                    }

                    conexao.Close(); //Da para abrir novamente
                    //conexao.Dispose(); //nao pode abrir novamente.
                    //Nao preciso fazer o Dispose aqui ! Porque ?
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
            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    conexao.Open();

                    using (DbCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = $@"INSERT INTO Alunos (nome,telefone)
                                                 VALUES ('{alu.Nome}' ,'{alu.Telefone}')"; //Eletrochoque para quem fizer
                        //Risco de injection

                        int rows = comando.ExecuteNonQuery();                        
                        Console.WriteLine("Registros inseridos {0}.", rows);
                        conexao.Close();
                    }
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

        public Aluno InserirAlunoParameter(Aluno alu)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {   
                    
                    string sql = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.id 
                                                VALUES (@nome, @telefone)";

                    using (SqlCommand comando = new SqlCommand(sql, conexao))
                    {
                        comando.CommandType=CommandType.Text; 

                        var param1 = new SqlParameter("@nome", SqlDbType.VarChar); 
                        param1.Value = alu.Nome;
                        var param2 = new SqlParameter("@telefone", SqlDbType.VarChar);
                        param2.Value = alu.Telefone;

                        //Para recuperar o id inserido
                        var param0 = comando.Parameters.AddWithValue("@id", 0).Direction = ParameterDirection.Output;
                        
                        comando.Parameters.Add(param1);                            
                        comando.Parameters.Add(param2);

                        //Abre a conexão
                        conexao.Open();

                        //SqlTransaction transaction = null;
                        //var transaction = conexao.BeginTransaction();
                        //comando.Transaction = transaction;  

                        //Executa a query                        
                        var retorno = comando.ExecuteScalar();
                                                                
                        conexao.Close();

                        Console.WriteLine($"Registros inserido com o id {retorno}");
                        alu.Id = Convert.ToInt32(retorno);


                        //transaction.Commit();
                    }
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

        //Implementar o metodo para atualizar um aluno (UPDATE)

        //Implementar o metodo para remover um aluno (DELETE)

    }
}

