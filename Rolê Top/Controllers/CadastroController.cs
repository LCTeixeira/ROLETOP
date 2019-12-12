using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rolê_Top.Enums;
using Rolê_Top.Models;
using Rolê_Top.Repositories;
using Rolê_Top.ViewModel;

namespace Rolê_Top.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult index(){
            return View(new BaseViewModel(){
                NomeView = "Cadastro",
                UsuarioNome = ObterUsuarioSession(),
                UsuarioEmail  = ObterUsuarioNomeSession()
            });
        }

        public IActionResult CadastrarCliente(IFormCollection form){
            ViewData["Action"] = "Cadastro";
            try{
                Cliente cliente = new Cliente(
                    form["nome"],
                    form["telefone"],
                    form["cpf"],
                    form["email"],
                    form["senha"],
                    DateTime.Parse(form["data-nascimento"])
                );
                cliente.TipoUsuario = (uint) TipoUsuario.CLIENTE;
                clienteRepository.Inserir(cliente);
                return View("Sucesso", new RespostaViewModel(){
                NomeView = "Cadastro",
                UsuarioNome = ObterUsuarioSession(),
                UsuarioEmail = ObterUsuarioNomeSession()
                });

            }catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Error", new RespostaViewModel(){
                        NomeView = "Cadastro"
                    });
            }
        }
    }
}