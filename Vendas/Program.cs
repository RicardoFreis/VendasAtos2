using Vendas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vendas
{
    internal class Program
    {
        static void TransacaoAlunoEndereco()
        {

            //var contexto = new VendasContext();
            //using var transaction = contexto.Database.BeginTransaction();

            //try
            //{
            //    //INSERIR PEDIDO
            //    Cliente cliente = new Cliente()
            //    {
            //        Nome = "José",
            //        Cpf = "3434-3434"
            //    };

            //    contexto.Clientes.Add(cliente);
            //    contexto.SaveChanges();
            //    var IdCliente = cliente.Id;


            //    transaction.Commit();
            //    Console.WriteLine("Ok registrado com sucesso !!! " + IdCliente);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}








            //var contexto = new VendasContext();
            //using var transaction = contexto.Database.BeginTransaction();

            //try
            //{
            //    //INSERIR PEDIDO
            //    Pedido pedido = new Pedido()
            //    {
            //        Id = 0,
            //        NomeCliente = "José",
            //        CpfCliente = "3434-3434",
            //        Data = "01/12/2020",
            //        Valor = 100
            //    };

            //    pedido.Cliente = new List<Cliente>();
            //    pedido.Cliente.Add(new Cliente() { Nome = "José", Cpf = "433.434.33-99" } );

            //    pedido.ProdutoItems = new List<ProdutoItem>()
            //    {
            //        new ProdutoItem () { DescricaoProduto = "Rua Oito",PrecoProduto = 100, Qtde = 2 },
            //        new ProdutoItem () { DescricaoProduto = "Rua Oito",PrecoProduto = 100, Qtde = 2 }
            //    };


            //    contexto.Pedidos.Add(pedido);
            //    contexto.SaveChanges();

            //    transaction.Commit();
            //    Console.WriteLine("Ok registrado com sucesso !!!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    transaction.Rollback();
            //}
        }

        static void IncluirCliente()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("+       * Incluir Cliente *      +");
            Console.WriteLine("+--------------------------------+");

            Console.WriteLine("");
            Console.Write("Nome...................: ");
            var Nome = Console.ReadLine();
            Console.Write("Cpf....................: ");
            var Cpf = Console.ReadLine();


            var contexto = new VendasContext();
            using var transaction = contexto.Database.BeginTransaction();
            try
            {
                Cliente cliente = new Cliente()
                {
                    Nome = Nome,
                    Cpf = Cpf
                };
                contexto.Add(cliente);
                contexto.SaveChanges();
                var IdGerado = cliente.Id;

                transaction.Commit();
                Console.WriteLine("Sucesso ao incluir o registro: " + IdGerado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            Console.WriteLine("<enter para voltar>");
            Console.ReadKey();
            Console.Clear();
        }

        static void IncluirProduto()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("+       * Incluir Produto *      +");
            Console.WriteLine("+--------------------------------+");

            Console.WriteLine("");
            Console.Write("Descrição...,,.........: ");
            var Descricao = Console.ReadLine();
            Console.Write("R$ Preço...............: ");
            var Preco = Console.ReadLine();

            var contexto = new VendasContext();
            using var transaction = contexto.Database.BeginTransaction();
            try
            {
                Produto produto = new Produto()
                {
                    Descricao = "Pen-Drive para Computadores",
                    //Preco = pARSEINT   Preco
                };

                contexto.Add(produto);
                contexto.SaveChanges();
                var IdGerado = produto.Id;

                transaction.Commit();
                Console.WriteLine("Produto incluído com sucesso com ID: " + IdGerado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            Console.WriteLine("<enter para voltar>");
            Console.ReadKey();
            Console.Clear();
        }



        static void Main(string[] args)
        {

            Console.WriteLine(" 1 - Incluir CLIENTE");
            Console.WriteLine(" 2 - Incluir PRODUTO");
            Console.WriteLine(" X - Encerrar");
            var Op = Console.ReadLine();

            while (Op.ToUpper() != "X")
            {
                if (Op == "1")
                {
                    IncluirCliente();
                }
                else if (Op == "2")
                {
                    IncluirProduto();
                }

                Console.WriteLine(" 1 - Incluir CLIENTE");
                Console.WriteLine(" 2 - Incluir PRODUTO");
                Console.WriteLine(" X - Encerrar");
                Op = Console.ReadLine();
            }
            Console.WriteLine("Sistema encerrado !");



            //var contexto = new VendasContext();
            //using var transaction = contexto.Database.BeginTransaction();

            //Certo
            //try
            //{
            //    //INSERIR Produto
            //    Produto produto = new Produto()
            //    {
            //        Descricao = "Pen-Drive para Computadores",
            //        Preco = (decimal?)99.99
            //    };
            //    contexto.Add(produto);
            //    contexto.SaveChanges();
            //    var IdGerado = produto.Id;

            //    transaction.Commit();
            //    Console.WriteLine("Ok Cliente com sucesso !!! " + IdGerado);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


            //Certo
            //try
            //{
            //    //INSERIR Pedido
            //    Pedido pedido = new Pedido()
            //    {
            //        NomeCliente = "Joaquim de Souza",
            //        CpfCliente = "113.433.554-04",
            //        Data = "10-10-2000",
            //        Valor = (decimal)(decimal?)50.00,
            //        IdCliente = 1
            //    };
            //    contexto.Add(pedido);
            //    contexto.SaveChanges();
            //    var IdGerado = pedido.Id;

            //    transaction.Commit();
            //    Console.WriteLine("Ok Pedido com sucesso !!! " + IdGerado);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


            //Certo
            //try
            //{
            //    //INSERIR ProdutoItem
            //    ProdutoItem produtoitem = new ProdutoItem()
            //    {
            //        DescricaoProduto = "Maurício de Souza",
            //        PrecoProduto = (decimal)(decimal?)150.00,
            //        Qtde = 3,
            //        IdProduto = 1,
            //        IdPedido = 5
            //    };

            //    contexto.Add(produtoitem);
            //    contexto.SaveChanges();
            //    var IdGerado = produtoitem.Id;

            //    transaction.Commit();
            //    Console.WriteLine("Ok Produtoitem com sucesso !!! " + IdGerado);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}



            try
            {
                //    //INSERIR PEDIDO
                //    Pedido pedido = new Pedido()
                //    {
                //        Id = 0,
                //        NomeCliente = "José",
                //        CpfCliente = "3434-3434",
                //        Data = "01/12/2020",
                //        Valor = 100
                //    };

                //    pedido.Cliente = new List<Cliente>();
                //    pedido.Cliente.Add(new Cliente() { Nome = "José", Cpf = "433.434.33-99" });

                //    pedido.ProdutoItems = new List<ProdutoItem>()
                //        {
                //            new ProdutoItem () { DescricaoProduto = "Rua Oito",PrecoProduto = 100, Qtde = 2 },
                //            new ProdutoItem () { DescricaoProduto = "Rua Oito",PrecoProduto = 100, Qtde = 2 }
                //        };


                //    contexto.Pedidos.Add(pedido);
                //    contexto.SaveChanges();

                //    transaction.Commit();
                //    Console.WriteLine("Ok registrado com sucesso !!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //transaction.Rollback();
            }


            //var context = new VendasContext();

            ////var listaAlunos = context.Alunos.ToList();


            //var listaAlunos = context.Alunos
            //            .Include(a => a.Telefones.Where(t => t.Id == 94))
            //            .Include(a => a.Enderecos)
            //            .ToList();


            //var listaTels = context.Telefones.Where(t => t.Id == 94)
            //                    .Include(t => t.IdAlunoNavigation)
            //                    .ToList();

            //var query1 = from alu in context.Alunos
            //             join tel in context.Telefones on alu.Id equals tel.IdAluno
            //             where tel.Id == 94
            //             select alu;

            //var lista2 = query1.ToList();






            //var aluno = new Aluno();
            //aluno.Nome = "Napoleao Bonaparte";
            //aluno.Enderecos = new List<Endereco>()
            //    {
            //        new Endereco() { Logradouro = "Rua Nove", Cep="32341-070", Numero="345"  }
            //    };
            //aluno.Telefones = new List<Telefone>()
            //    {
            //        new Telefone () {NumeroTelefone = "2222-22222"  },
            //        new Telefone () {NumeroTelefone = "3333-33333"  }
            //    };

            //context.Alunos.Add(aluno);
            //context.SaveChanges();



            //foreach (var item in listaAlunos)
            //{
            //    Console.WriteLine($"{item.Nome} {item.Id} {item.Telefone}");

            //    foreach (var endereco in item.Enderecos)
            //    {
            //        Console.WriteLine($"ENDERECO: {endereco.Logradouro} {endereco.Cep} {endereco.Numero}");
            //    }

            //    foreach (var telefone in item.Telefones)
            //    {
            //        Console.WriteLine($"Telefone: {telefone.NumeroTelefone}");
            //    }

            //}
        }
    }
}
