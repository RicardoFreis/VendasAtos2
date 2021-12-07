using System;
using System.Collections.Generic;

namespace Vendas.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoItems = new HashSet<ProdutoItem>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal? Preco { get; set; }

        public virtual ICollection<ProdutoItem> ProdutoItems { get; set; }
    }
}
