using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rolê_Top.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_EMAIL_CLIENTE = "email_cliente";
        protected const string SESSION_NOME_CLIENTE = "nome_cliente";
        protected const string SESSION_TIPO_CLIENTE = "tipo_cliente";

        protected string ObterUsuarioSession(){
            var usuario = HttpContext.Session.GetString(SESSION_EMAIL_CLIENTE);
            if(!string.IsNullOrEmpty(usuario)){
                return usuario;
            }else{
                return "";
            }
        }

        protected string ObterUsuarioNomeSession(){
            var nomeUsuario = HttpContext.Session.GetString(SESSION_NOME_CLIENTE);
            if(!string.IsNullOrEmpty(nomeUsuario)){
                return nomeUsuario;
            }else{
                return "";
            }
        }

        protected string ObterUsuarioTipoSession(){
            var tipoUsuario = HttpContext.Session.GetString(SESSION_TIPO_CLIENTE);
            if(!string.IsNullOrEmpty(tipoUsuario)){
                return tipoUsuario;
            }else{
                return "";
            }
        }
    }
}