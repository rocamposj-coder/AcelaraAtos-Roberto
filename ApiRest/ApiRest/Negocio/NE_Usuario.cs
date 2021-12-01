using ApiRest.DAO_DAPPER;
using ApiRest.Entidades;
using ApiRest.Uteis;
using Microsoft.AspNetCore.Identity;

namespace ApiRest.Negocio
{
    public class NE_Usuario
    {
        private DAO_Usuario daoUsuario;

        public NE_Usuario()
        {
            daoUsuario = new DAO_Usuario();
        }

        public Usuario CadastrarUsuario(Usuario usu)        
        {
            usu.SenhaCriptografada = Utilitarios.HashValue(usu.SenhaCriptografada); 

            usu = daoUsuario.CadastrarUsuario(usu);

            return usu;
        }

        public Usuario RecuperarUsuario(Usuario usu)
        {
            usu = daoUsuario.RecuperarUsuario(usu);
            return usu;
        }

        public Usuario VerificarUsuarioSenha(Usuario usu, out bool usuarioSenhaOK)
        {
            //Primeiro criptografo a senha que o usuário enviou
            usu.SenhaCriptografada = Utilitarios.HashValue(usu.SenhaCriptografada);

            var usuConsulta = daoUsuario.RecuperarUsuario(usu);
            if (usuConsulta.SenhaCriptografada == usu.SenhaCriptografada)
                usuarioSenhaOK = true;
            else
                usuarioSenhaOK = false;

            return usuConsulta;

        }

    }
}
