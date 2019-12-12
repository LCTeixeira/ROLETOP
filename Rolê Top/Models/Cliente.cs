using System;
namespace Rolê_Top.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public string CPF {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public DateTime DataNascimento {get;set;}
        public uint TipoUsuario {get;set;}

        public Cliente (){
            
        }

        public Cliente (string nome, string telefone, string cpf, string email, string senha, DateTime dataNascimento){
            this.Nome = nome;
            this.Telefone = telefone;
            this.CPF = cpf;
            this.Email = email;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;
        }
    }
}