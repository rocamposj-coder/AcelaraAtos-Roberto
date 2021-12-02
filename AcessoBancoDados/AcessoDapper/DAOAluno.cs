using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

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

        public Aluno RecuperarAluno(Aluno alu)
        {
            
            string sql = "SELECT * from Alunos Where [id] = @id"; //NUNCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    alu = conexao.Query<Aluno>(sql, alu).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                //throw;
                return null;
            }

            return alu;
        }


        public Aluno RecuperarAlunoCompleto(Aluno alu)
        {
            
            string sql = @"SELECT * from Alunos
                            INNER JOIN Telefone ON Telefone.idAluno = Alunos.id
                            INNER JOIN Endereco ON Endereco.idAluno = Alunos.id
                            WHERE Alunos.id = @id";

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    Aluno aluTemp = null;

                    var items = conexao.Query<Aluno, Telefone, Endereco, Aluno>(sql,
                        (aluno, telefone, endereco) =>  //Este metodo anonimo é executado para cada linha de retorno da consulta
                        {                            
                            if (aluTemp == null) //se o aluno ainda não esta instanciado 
                            {
                                aluno.Endereco = endereco;
                                aluTemp = aluno;
                                aluTemp.listaTelefones.Add(telefone);                                
                            }
                            else //se o aluno ja esta na coleção eu so adiciono o telefone
                            {
                                aluTemp.listaTelefones.Add(telefone);
                            }

                            return aluTemp;
                        },
                        alu);  // splitOn: "id"


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                //throw;
                return null;
            }

            return alu;
        }


        public List<Aluno> RecuperarAlunosCompletos(List<Aluno> paramListaAlu)
        {
            List<Aluno> listaAlunos;


            string sql = @"SELECT * from Alunos
                            INNER JOIN Telefone ON Telefone.idAluno = Alunos.id
                            INNER JOIN Endereco ON Endereco.idAluno = Alunos.id
                            WHERE Alunos.id IN @id";


            var parametros = new { id = new string[paramListaAlu.Count] };

           

            for (int i=0; i<paramListaAlu.Count; i++)
            {
                parametros.id[i] =  paramListaAlu[i].Id.ToString() ;
            }

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    listaAlunos = new List<Aluno>();

                    
                    var items = conexao.Query<Aluno, Telefone, Endereco, Aluno>(sql,
                        (aluno, telefone, endereco) =>  //Este metodo anonimo é executado para cada linha de retorno da consulta
                        {
                            var alu = listaAlunos.Where(a => a.Id == aluno.Id).FirstOrDefault();
                            if (alu == null) //se o aluno ainda não esta na coleção eu adiciono tudo
                            {
                                aluno.Endereco = endereco;
                                alu = aluno;
                                alu.listaTelefones.Add(telefone);
                                listaAlunos.Add(alu);
                            }
                            else //se o aluno ja esta na coleção eu so adiciono o telefone
                            {
                                alu.listaTelefones.Add(telefone);
                            }

                            return aluno;
                        }, parametros);  // splitOn: "id"

                    //listaAlunos = items.AsList();

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


        public Aluno AtualizarAluno(Aluno alu)
        {
            try
            {
                string sqlAluno = $@"UPDATE Alunos
                                     SET [nome] = @nome
                                        ,[telefone] = @telefone
                                     WHERE id = @id";


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
                var pars = new { idAluno = alu.Id };


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
                var pars = new { idAluno = alu.Id };


                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var telefones = conexao.Query<Telefone>(procedure, pars, commandType: CommandType.StoredProcedure);
                    listaTelefones = telefones.AsList();
                    // listaTelefones = conexao.Query<Telefone>(procedure, pars, commandType: CommandType.StoredProcedure).AsList();
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

        public Aluno InserirAluno(Aluno alu)
        {
            alu.Id = 0;
            try
            {
                string sqlAluno = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.id 
                                                VALUES (@nome, @telefone)"; //NUCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

               
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var retornoAluno = conexao.ExecuteScalar(sqlAluno, alu);
                    alu.Id = Convert.ToInt32(retornoAluno);                                           
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
            alu.Id = 0;
            try
            {
                string sqlAluno = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.id 
                                                VALUES (@nome, @telefone)";

                string sqlTelefone = @"INSERT INTO Telefone (numeroTelefone, idAluno)
                                       VALUES( @numeroTelefone, @idAluno)";



                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    conexao.Open();
                    using (var transaction = conexao.BeginTransaction())
                    {
                        var retornoAluno = conexao.ExecuteScalar(sqlAluno, alu, transaction);
                        alu.Id = Convert.ToInt32(retornoAluno);

                        foreach (var tel in alu.listaTelefones)
                        {
                            tel.IdAluno = alu.Id;
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

        public Aluno InserirAlunoTelefoneEndereco(Aluno alu)
        {
            //O objeto aluno deve chegar aqui completo, com a lista de telefones e com o atributo endereço preenchido

            alu.Id = 0;
            try
            {
                string sqlAluno = $@"INSERT INTO Alunos (nome,telefone)
                                                OUTPUT INSERTED.id 
                                                VALUES (@nome, @telefone)";

                string sqlTelefone = @"INSERT INTO Telefone (numeroTelefone, idAluno)
                                       VALUES( @numeroTelefone, @idAluno)";

                string sqlEndereco = @"INSERT INTO Endereco (logradouro, cep, numero, idAluno)
                                       VALUES( @logradouro, @cep, @numero, @idAluno)";



                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    conexao.Open();
                    using (var transaction = conexao.BeginTransaction())
                    {
                        var retornoAluno = conexao.ExecuteScalar(sqlAluno, alu, transaction);
                        alu.Id = Convert.ToInt32(retornoAluno);

                        foreach (var tel in alu.listaTelefones)
                        {
                            tel.IdAluno = alu.Id;
                        }                       

                        var retornoTelefone = conexao.Execute(sqlTelefone, alu.listaTelefones, transaction);


                        alu.Endereco.IdAluno = alu.Id;
                        var retornoEndereco = conexao.Execute(sqlEndereco, alu.Endereco, transaction);

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


        public Aluno RecuperarAlunoEndereco(Aluno alu)
        {

            string sql = @"SELECT Alunos.id, nome,telefone, Endereco.id, logradouro, cep, numero
                            from Alunos 
                            INNER JOIN Endereco ON Endereco.idAluno = Alunos.id                         
                            Where Alunos.id = @id"; 

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {                    
                    var items = conexao.Query<Aluno, Endereco, Aluno>(sql,
                       (aluno, endereco) =>
                       {
                           aluno.Endereco = endereco;
                           return aluno;
                       },alu);

                    alu = items.FirstOrDefault();   // a consulta so traz um registro porque filtra pelo ID
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);               
                return null;
            }

            return alu;
        }

        public List<Aluno> RecuperarAlunosEndereco()
        {
            List<Aluno> listaAlunos;



            string sql = @"SELECT * from Alunos
                           INNER JOIN Endereco ON Endereco.idAluno = Alunos.id"; 

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    var items = conexao.Query<Aluno, Endereco, Aluno>(sql,
                        (aluno, endereco) => 
                        {
                            aluno.Endereco = endereco;
                            return aluno;
                        });

                    listaAlunos = items.AsList(); 

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

        public List<Aluno> RecuperarAlunosTelefones()
        {
            List<Aluno> listaAlunos;



            string sql = @"SELECT * from Alunos
                           INNER JOIN Telefone ON Telefone.idAluno = Alunos.id";

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    listaAlunos = new List<Aluno>();

                    var items = conexao.Query<Aluno, Telefone, Aluno>(sql,
                        (aluno, telefone) =>  //Este metodo anonimo é executado para cada linha de retorno da consulta
                        {
                            var alu = listaAlunos.Where(a => a.Id == aluno.Id).FirstOrDefault();
                            if (alu == null) //se o aluno ainda não esta na coleção eu adiciono tudo
                            {
                                alu = aluno;
                                alu.listaTelefones.Add(telefone);
                                listaAlunos.Add(alu);
                            }
                            else //se o aluno ja esta na coleção eu so adiciono o telefone
                            {
                                alu.listaTelefones.Add(telefone);
                            }
                            
                            return aluno;
                        }, splitOn: "Telefone");

                    //listaAlunos = items.AsList();

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

        public List<Aluno> RecuperarAlunosTelefonesEndereco()
        {
            List<Aluno> listaAlunos;



            string sql = @"SELECT * from Alunos
                            INNER JOIN Telefone ON Telefone.idAluno = Alunos.id
                            INNER JOIN Endereco ON Endereco.idAluno = Alunos.id";

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    listaAlunos = new List<Aluno>();

                    var items = conexao.Query<Aluno, Telefone, Endereco, Aluno>(sql,
                        (aluno, telefone, endereco) =>  //Este metodo anonimo é executado para cada linha de retorno da consulta
                        {
                            var alu = listaAlunos.Where(a => a.Id == aluno.Id).FirstOrDefault();
                            if (alu == null) //se o aluno ainda não esta na coleção eu adiciono tudo
                            {
                                aluno.Endereco = endereco;
                                alu = aluno;
                                alu.listaTelefones.Add(telefone);
                                listaAlunos.Add(alu);                                
                            }
                            else //se o aluno ja esta na coleção eu so adiciono o telefone
                            {
                                alu.listaTelefones.Add(telefone);
                            }

                            return aluno;
                        });  // splitOn: "id"

                    //listaAlunos = items.AsList();

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

       


        //Corriga este metodo
        public List<Aluno> RecuperarAlunosTelefonesEndereco(List<Aluno> listaAlunosParam)
        {
            List<Aluno> listaAlunos;


            string sql = @"SELECT * from Alunos
                            INNER JOIN Telefone ON Telefone.idAluno = Alunos.id
                            INNER JOIN Endereco ON Endereco.idAluno = Alunos.id
                            WHERE Alunos.id IN @id";

            try
            {
                using (SqlConnection conexao = new SqlConnection(CONNECTION_STRING))
                {
                    listaAlunos = new List<Aluno>();

                    var items = conexao.Query<Aluno, Telefone, Endereco, Aluno>(sql,
                        (aluno, telefone, endereco) =>  //Este metodo anonimo é executado para cada linha de retorno da consulta
                        {
                            var alu = listaAlunos.Where(a => a.Id == aluno.Id).FirstOrDefault();
                            if (alu == null) //se o aluno ainda não esta na coleção eu adiciono tudo
                            {
                                aluno.Endereco = endereco;
                                alu = aluno;
                                alu.listaTelefones.Add(telefone);
                                listaAlunos.Add(alu);
                            }
                            else //se o aluno ja esta na coleção eu so adiciono o telefone
                            {
                                alu.listaTelefones.Add(telefone);
                            }

                            return aluno;
                        },
                        listaAlunosParam);  // splitOn: "id"
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



    }
}

