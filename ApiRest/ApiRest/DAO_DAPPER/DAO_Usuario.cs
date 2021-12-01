using ApiRest.Entidades;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;

namespace ApiRest.DAO_DAPPER
{
    public class DAO_Usuario
    {
        public Usuario CadastrarUsuario(Usuario usu)
        {
            usu.Id = 0;
            try
            {
                string sqlUsuario = $@"INSERT INTO Usuario (nome,email,senhacriptografada)
                                                OUTPUT INSERTED.id 
                                                VALUES (@nome, @email, @senhacriptografada)"; //NUCA CONCATENAR STRING AQUI, PELA MOR DE DEUS ....

                string sqlRoles = $@"INSERT INTO Role(descricao,idUsuario)
                                     VALUES(@descricao, @idUsuario)";


                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    conexao.Open();

                    using (var transaction = conexao.BeginTransaction())
                    {

                        var retornoAluno = conexao.ExecuteScalar(sqlUsuario, usu, transaction);
                        usu.Id = Convert.ToInt32(retornoAluno);

                        foreach(var role in usu.ListaRoles)
                        {
                            role.IdUsuario = usu.Id;
                        }

                        var retornoRoles = conexao.Execute(sqlRoles, usu.ListaRoles, transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (DbException exDb)
            {/*
                Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                Console.WriteLine("DbException.Source: {0}", exDb.Source);
                Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                Console.WriteLine("DbException.Message: {0}", exDb.Message);
                */
                
                return null;
            }
            // Handle all other exceptions.
            catch (Exception ex)
            {
                //Console.WriteLine("Exception.Message: {0}", ex.Message);                
                return null;
            }


            return usu;
        }

        public Usuario RecuperarUsuario(Usuario usuario)
        {
            //O parametro usuário deve vir com o usuário preenchido

            string sql = @"SELECT Usuario.id,nome,email,senhacriptografada, Role.id, descricao, idUsuario from Usuario
                            INNER JOIN Role ON Role.idUsuario = Usuario.id                            
                            WHERE Usuario.nome = @nome";
            Usuario usuTemp = null;

            try
            {
                using (SqlConnection conexao = new SqlConnection(Configuracao.CONNECTION_STRING))
                {
                    

                    var items = conexao.Query<Usuario, Role, Usuario>(sql,
                        (usu, role) =>  //Este metodo anonimo é executado para cada linha de retorno da consulta
                        {
                            if (usuTemp == null) //se o aluno ainda não esta instanciado 
                            {                                
                                usuTemp = usu;
                                usuTemp.ListaRoles.Add(role);
                            }
                            else //se o aluno ja esta na coleção eu so adiciono o telefone
                            {
                                usuTemp.ListaRoles.Add(role);
                            }

                            return usuTemp;
                        },
                        usuario);  // splitOn: "id"


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);                
                return null;
            }

            return usuTemp;
        }

    }
}
