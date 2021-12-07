using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vendas.Models
{
    public partial class VendasContext : DbContext
    {
        public VendasContext()
        {
        }

        public VendasContext(DbContextOptions<VendasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<ProdutoItem> ProdutoItems { get; set; } = null!;
        public virtual DbSet<Teste> Testes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Vendas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Cpf).HasMaxLength(20);

                entity.Property(e => e.Nome).HasMaxLength(60);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.CpfCliente).HasMaxLength(20);

                entity.Property(e => e.Data).HasMaxLength(30);

                entity.Property(e => e.NomeCliente).HasMaxLength(60);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Cliente");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(e => e.Descricao).HasMaxLength(80);

                entity.Property(e => e.Preco).HasColumnType("decimal(10, 0)");
            });

            modelBuilder.Entity<ProdutoItem>(entity =>
            {
                entity.ToTable("ProdutoItem");

                entity.Property(e => e.DescricaoProduto).HasMaxLength(80);

                entity.Property(e => e.PrecoProduto).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.ProdutoItems)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK_ProdutoItem_Pedido");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoItems)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK_ProdutoItem_Produto");
            });

            modelBuilder.Entity<Teste>(entity =>
            {
                entity.ToTable("Teste");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
