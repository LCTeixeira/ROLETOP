using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rolê_Top.Models;
using Rolê_Top.Repositories;
using Rolê_Top.ViewModel;

namespace Rolê_Top.Controllers
{
    public class PedidoController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        PedidoRepository pedidoRepository = new PedidoRepository();

        public IActionResult Index(){
            PedidoViewModel pvm = new PedidoViewModel();

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pvm.NomeCliente = nomeUsuarioLogado;
            }
            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null)
            {
                pvm.Cliente = clienteLogado;
            }
            pvm.NomeView = "Pedido";
            pvm.UsuarioEmail = usuarioLogado;
            pvm.UsuarioNome = nomeUsuarioLogado;
            
            return View(pvm);
        }
        public IActionResult Registrar (IFormCollection form) {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido ();

            Cliente cliente = new Cliente () {
                Nome = form["nome"],
                Telefone = form["telefone"],
                Email = form["email"]

            };

            pedido.cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;


            if (pedidoRepository.Inserir (pedido)) {
                return View ("Sucesso", new RespostaViewModel () {
                    NomeView = "Pedido"
                });

            } else {

                return View ("Erro", new RespostaViewModel () {
                    NomeView = "Pedido"
                });
            }

        }

    }
}