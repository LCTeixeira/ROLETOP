using System;
using Rolê_Top.Enums;

namespace Rolê_Top.Models
{
    public class Pedido
    {
        public ulong Id {get;set;}
        public Cliente cliente {get;set;}
        public uint tipoEvento {get;set;}
        public DateTime DataDoPedido {get;set;}
        public uint Status {get;set;}
        public uint PreçoEvento {get;set;}
        public string Nome_Evento {get;set;}

        public string tipoPagamento {get;set;}

        public Pedido()
        {
            
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE;
            this.PreçoEvento = (uint) PreçosEvento.BASICO;
            this.tipoEvento = (uint) tipoEvento;

        }
    }
}