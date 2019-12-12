using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rolê_Top.Enums;
using Rolê_Top.Repositories;
using Rolê_Top.ViewModel;

namespace Rolê_Top.Controllers {
    public class ClienteController : AbstractController {
        private ClienteRepository clienteRepository = new ClienteRepository ();
        private PedidoRepository pedidoRepository = new PedidoRepository();


        [HttpGet]

        public IActionResult Login () {
            return View (new BaseViewModel () {
                NomeView = "Login",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }

        [HttpPost]

        public IActionResult Login (IFormCollection form) {
            ViewData["Action"] = "Login";
            try {
                System.Console.WriteLine ("====================================");
                System.Console.WriteLine (form["email"]);
                System.Console.WriteLine (form["senha"]);
                System.Console.WriteLine ("====================================");

                var usuario = form["email"];
                var senha = form["senha"];

                var c = clienteRepository.ObterPor(usuario);

                if (c != null) {
                    if (c.Senha.Equals(senha)) {
                        switch (c.TipoUsuario) {
                            case (uint) TipoUsuario.CLIENTE:

                                HttpContext.Session.SetString (SESSION_EMAIL_CLIENTE, usuario);
                                HttpContext.Session.SetString (SESSION_NOME_CLIENTE, c.Nome);
                                HttpContext.Session.SetString (SESSION_TIPO_CLIENTE, c.TipoUsuario.ToString());
                                return RedirectToAction ("Index", "Home");

                            case (uint) TipoUsuario.ADMINISTRADOR:

                                HttpContext.Session.SetString (SESSION_EMAIL_CLIENTE, usuario);
                                HttpContext.Session.SetString (SESSION_NOME_CLIENTE, c.Nome);
                                HttpContext.Session.SetString (SESSION_TIPO_CLIENTE, c.TipoUsuario.ToString());
                                return RedirectToAction ("Index", "Home");

                            default:

                                return View ("Error", new RespostaViewModel ("Erro de TIPO no codigo"));
                        }
                    } else {
                        return View ("Error", new RespostaViewModel ("Senha incorreta"));
                    }

                } else {
                    return View ("Error", new RespostaViewModel ($"Usuário {usuario} não encontrado."));
                }

            } catch (Exception e) {
                System.Console.WriteLine (e.StackTrace);
                return View ("Error", new RespostaViewModel());
            }
        }

        public IActionResult Historico ()
        {
            var emailCliente = HttpContext.Session.GetString(SESSION_EMAIL_CLIENTE);
            var pedidosCliente = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel(){
                Pedidos = pedidosCliente,
                NomeView = "Historico",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 

            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_EMAIL_CLIENTE);
            HttpContext.Session.Remove(SESSION_NOME_CLIENTE);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}