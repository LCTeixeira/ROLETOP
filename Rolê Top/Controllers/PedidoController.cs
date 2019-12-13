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
        public IActionResult Registrar(IFormCollection form) {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido ();
            System.Console.WriteLine("=============================================");
            System.Console.WriteLine(ObterUsuarioSession());
            System.Console.WriteLine("=============================================");
            pedido.cliente = clienteRepository.ObterPor(ObterUsuarioSession());

            pedido.DataDoPedido = DateTime.Now;
            pedido.Nome_Evento = form["nome_Evento"];
            pedido.tipoEvento = uint.Parse(form["tipo-evento"]);
            pedido.DataDoPedido = DateTime.Parse(form["data"]);
            pedido.PreçoEvento = uint.Parse(form["p_evento"]);
            pedido.tipoPagamento = form["t_Pagamento"]; 

            if (pedidoRepository.Inserir(pedido)) {
                return View ("Sucesso", new RespostaViewModel () {
                    NomeView = "Pedido"
                });

            } else {

                return View ("Error", new RespostaViewModel () {
                    NomeView = "Pedido"
                });
            }

        }

    }
}