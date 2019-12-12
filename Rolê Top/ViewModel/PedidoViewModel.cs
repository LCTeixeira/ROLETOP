using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rolê_Top.Models;

namespace Rolê_Top.ViewModel {
    public class PedidoViewModel : BaseViewModel {
        public Cliente Cliente { get; set; }
        public string NomeCliente { get; set; }
        public Pedido pedido { get; set; }

        public PedidoViewModel () {
            this.Cliente = new Cliente ();
            this.NomeCliente = "Jovem";
            this.pedido = new Pedido ();
        }

        
    }
}