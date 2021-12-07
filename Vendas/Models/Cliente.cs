using System;
using System.Collections.Generic;

namespace Vendas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
