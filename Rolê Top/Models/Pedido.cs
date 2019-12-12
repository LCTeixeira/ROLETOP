using System;
using Rolê_Top.Enums;

namespace Rolê_Top.Models
{
    public class Pedido
    {
        public ulong Id {get;set;}
        public Cliente cliente {get;set;}
        public TipoEvento tipoEvento {get;set;}
        public DateTime DataDoPedido {get;set;}
        public double PrecoTotal {get;set;}
        public uint Status {get;set;}
        public uint PreçoEvento {get;set;}

        public Pedido()
        {
            this.cliente = new Cliente();
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE;
            this.PreçoEvento = (uint) PreçosEvento.BASICO;

        }
    }
}