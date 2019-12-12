using System;
using System.IO;
using Rolê_Top.Models;

namespace Rolê_Top.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";

        public ClienteRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        public bool Inserir (Cliente cliente){
            var linha = new string[] {PreperarRegistroCSV(cliente)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public Cliente ObterPor(string email){
            var linhas = File.ReadAllLines(PATH);
            foreach(var item in linhas){
                if(ExtrairValorDoCampo("email", item).Equals(email)){
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo("nome", item);
                    c.Telefone = ExtrairValorDoCampo("telefone", item);
                    c.CPF = ExtrairValorDoCampo("cpf", item);
                    c.Email = ExtrairValorDoCampo("email", item);
                    c.Senha = ExtrairValorDoCampo("senha", item);
                    c.DataNascimento = DateTime.Parse(ExtrairValorDoCampo("data_nascimento", item));
                    return c;
                }
            }
            return null;
        }

        private string PreperarRegistroCSV(Cliente cliente){
            return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};telefone={cliente.Telefone};cpf={cliente.CPF};email={cliente.Email};senha={cliente.Senha};data_nascimento={cliente.DataNascimento}";
        }
    }
}