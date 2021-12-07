using System;
using System.Collections.Generic;

namespace Vendas.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            ProdutoItems = new HashSet<ProdutoItem>();
        }

        public int Id { get; set; }
        public string NomeCliente { get; set; } = null!;
        public string CpfCliente { get; set; } = null!;
        public string Data { get; set; } = null!;
        public decimal Valor { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ProdutoItem> ProdutoItems { get; set; }
    }
}
