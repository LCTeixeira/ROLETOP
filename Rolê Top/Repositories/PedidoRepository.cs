using System;
using System.Collections.Generic;
using System.IO;
using Rolê_Top.Models;

namespace Rolê_Top.Repositories
{
    public class PedidoRepository : RepositoryBase
    {
        private const string PATH = "Database/Pedidos.csv";

        public PedidoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pedido pedido)
        {
            var quantidadePedidos = File.ReadAllLines(PATH).Length; 
            pedido.Id = (ulong) ++quantidadePedidos;
            var linha = new string[] {PrepararPedidoCSV(pedido)};
            File.AppendAllLines(PATH, linha);
            return true;

        }
        public List<Pedido> ObterTodosPorCliente(string emailCliente)
        {
            var pedidos = ObterTodos();
            List<Pedido> pedidosCliente = new List<Pedido>();

            foreach (var pedido in pedidos)
            {
                if(pedido.cliente.Email.Equals(emailCliente))
                {
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;
        }

        public List<Pedido> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Pedido> pedidos = new List<Pedido>();
            foreach (var l in linhas)
            {
                Pedido p = new Pedido();
                
                p.Id = ulong.Parse(ExtrairValorDoCampo("id", l));
                p.Status = uint.Parse(ExtrairValorDoCampo("status_pedido", l));
                p.PreçoEvento = uint.Parse(ExtrairValorDoCampo("preco_eventos", l));
                p.cliente.Nome = ExtrairValorDoCampo("cliente_nome", l);
                p.cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", l);
                p.cliente.Email = ExtrairValorDoCampo("cliente_email", l);
                p.PrecoTotal = double.Parse(ExtrairValorDoCampo("preco_total", l));
                p.DataDoPedido = DateTime.Parse(ExtrairValorDoCampo("data_pedido", l));

                pedidos.Add(p);
            }
            return pedidos;
        }

        public Pedido ObterPor(ulong id)
        {
            var pedidosTotais = ObterTodos();
            foreach (var p in pedidosTotais)
            {
                if(id.Equals(p.Id))
                {
                    return p;
                }
            }
            return null;
        }
        
        public Pedido ObterPreço()
        public bool Atualizar(Pedido p)
        {
            var pedidosTotais = File.ReadAllLines(PATH);
            var pedidoCSV = PrepararPedidoCSV(p);
            var linhaPedido = -1;
            var resultado = false;
            
            for (int i = 0; i < pedidosTotais.Length; i++)
            {
                var idConvertido =  ulong.Parse(ExtrairValorDoCampo("id", pedidosTotais[i]));
                if(p.Id.Equals(idConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado)
            {
                pedidosTotais[linhaPedido] = pedidoCSV;
                File.WriteAllLines(PATH, pedidosTotais);
            }

            return resultado;
        }
        private string PrepararPedidoCSV(Pedido p)
        {
            Cliente c = p.cliente;
            
            return $"id={p.Id};status_pedido={p.Status};cliente_nome={c.Nome};cliente_telefone={c.Telefone};cliente_email={c.Email};data_pedido={p.DataDoPedido};preco_total={p.PrecoTotal};preco_eventos={p.PreçoEvento};";
        }
    }
}

