﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MvcVendas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241111190129_real4")]
    partial class real4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("MvcApiFarm.Models.AreaPlantio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FazendaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Hectares")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FazendaId");

                    b.ToTable("AreasPlantio");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaEntrega")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Fazenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Hectares")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fazendas");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Representante")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("FazendaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Funcao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Salario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FazendaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Preco")
                        .HasColumnType("real");

                    b.Property<DateTime>("PrevisaoEntrega")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecursoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("RecursoId");

                    b.ToTable("ItemsCompra");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemNFE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemVendaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NFEntradaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemVendaId");

                    b.HasIndex("NFEntradaId");

                    b.ToTable("ItemsNFE");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemNFS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemCompraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NFSaidaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemCompraId");

                    b.HasIndex("NFSaidaId");

                    b.ToTable("ItemsNFS");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemPlantio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlantioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecursoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlantioId");

                    b.HasIndex("RecursoId");

                    b.ToTable("ItemsPlantio");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Preco")
                        .HasColumnType("real");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecursoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecursoId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItemsVenda");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Manutencao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Custos")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("RecursoId");

                    b.ToTable("Manutencoes");
                });

            modelBuilder.Entity("MvcApiFarm.Models.NFEntrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Impostos")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroNota")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("data")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("NFEntradas");
                });

            modelBuilder.Entity("MvcApiFarm.Models.NFSaida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Impostos")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroNota")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("data")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("NFSaidas");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Plantio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AreaPlantioId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataPlantio")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AreaPlantioId");

                    b.ToTable("Plantios");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Recurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAquisicao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("real");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recursos");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaEntrega")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("MvcApiFarm.Models.AreaPlantio", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Fazenda", "Fazenda")
                        .WithMany()
                        .HasForeignKey("FazendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fazenda");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Compra", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Funcionario", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Fazenda", "Fazenda")
                        .WithMany()
                        .HasForeignKey("FazendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fazenda");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemCompra", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Compra", "Compra")
                        .WithMany("ItensCompra")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Recurso", "Recurso")
                        .WithMany()
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemNFE", b =>
                {
                    b.HasOne("MvcApiFarm.Models.ItemVenda", "ItemVenda")
                        .WithMany()
                        .HasForeignKey("ItemVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.NFEntrada", "NFEntrada")
                        .WithMany()
                        .HasForeignKey("NFEntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemVenda");

                    b.Navigation("NFEntrada");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemNFS", b =>
                {
                    b.HasOne("MvcApiFarm.Models.ItemCompra", "ItemCompra")
                        .WithMany()
                        .HasForeignKey("ItemCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.NFSaida", "NFSaida")
                        .WithMany()
                        .HasForeignKey("NFSaidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCompra");

                    b.Navigation("NFSaida");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemPlantio", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Plantio", "Plantio")
                        .WithMany("ItensPlantio")
                        .HasForeignKey("PlantioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Recurso", "Recurso")
                        .WithMany()
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plantio");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("MvcApiFarm.Models.ItemVenda", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Recurso", "Recurso")
                        .WithMany()
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Venda", "Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recurso");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Manutencao", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Recurso", "Recurso")
                        .WithMany()
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("MvcApiFarm.Models.NFEntrada", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("MvcApiFarm.Models.NFSaida", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApiFarm.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Plantio", b =>
                {
                    b.HasOne("MvcApiFarm.Models.AreaPlantio", "AreaPlantio")
                        .WithMany()
                        .HasForeignKey("AreaPlantioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaPlantio");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Venda", b =>
                {
                    b.HasOne("MvcApiFarm.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Compra", b =>
                {
                    b.Navigation("ItensCompra");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Plantio", b =>
                {
                    b.Navigation("ItensPlantio");
                });

            modelBuilder.Entity("MvcApiFarm.Models.Venda", b =>
                {
                    b.Navigation("ItensVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
