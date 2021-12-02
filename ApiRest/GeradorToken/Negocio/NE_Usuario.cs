using GeradorToken.DAO;
using GeradorToken.Entidades;
using GeradorToken.Uteis;
using Microsoft.AspNetCore.Identity;

namespace GeradorToken.Negocio
{
    public class NE_Usuario
    {
        private DAO_Usuario daoUsuario;

        public NE_Usuario()
        {
            daoUsuario = new DAO_Usuario();
        }
       
        public Usuario VerificarUsuarioSenha(Usuario usu, out bool usuarioSenhaOK)
        {           

            var usuConsulta = daoUsuario.RecuperarUsuario(usu);
            if (usuConsulta.SenhaCriptografada == usu.SenhaCriptografada)
                usuarioSenhaOK = true;
            else
                usuarioSenhaOK = false;

            return usuConsulta;

        }

    }
}
