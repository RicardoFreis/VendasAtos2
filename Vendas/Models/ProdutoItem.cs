using System;
using System.Collections.Generic;

namespace Vendas.Models
{
    public partial class ProdutoItem
    {
        public int Id { get; set; }
        public string? DescricaoProduto { get; set; }
        public decimal? PrecoProduto { get; set; }
        public int? Qtde { get; set; }
        public int? IdProduto { get; set; }
        public int? IdPedido { get; set; }

        public virtual Pedido? IdPedidoNavigation { get; set; }
        public virtual Produto? IdProdutoNavigation { get; set; }
    }
}
