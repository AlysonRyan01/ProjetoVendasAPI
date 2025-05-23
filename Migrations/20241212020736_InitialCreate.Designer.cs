﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoVendasAPI.Data;

#nullable disable

namespace ProjetoVendasAPI.Migrations
{
    [DbContext(typeof(VendasDataContext))]
    [Migration("20241212020736_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClienteCargo", b =>
                {
                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("CargoId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClienteCargo");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.ToTable("Cargo", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("ValorTotal")
                        .HasDefaultValueSql("0.00");

                    b.Property<int?>("VendaFinalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carrinho", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Endereco");

                    b.Property<string>("Fone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Fone");

                    b.Property<string>("Imagem")
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoCartao")
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CodigoCartao");

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CpfCliente");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("FormaPagamento");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NomeCliente");

                    b.Property<string>("NumeroCartao")
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NumeroCartao");

                    b.Property<int>("VendaFinalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<string>("Garantia")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Garantia");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Modelo");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("Preco");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Serie");

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("TipoProduto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.ProdutoImagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ImagemUrl");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoImagens", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.RelatorioVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("ValorTotal");

                    b.Property<int>("VendaFinalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendaFinalId")
                        .IsUnique();

                    b.ToTable("RelatorioVendas", (string)null);
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.VendaFinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("RelatorioVendasId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId")
                        .IsUnique();

                    b.HasIndex("ClienteId");

                    b.HasIndex("PagamentoId")
                        .IsUnique();

                    b.ToTable("VendaFinal", (string)null);
                });

            modelBuilder.Entity("ClienteCargo", b =>
                {
                    b.HasOne("ProjetoVendasAPI.Models.Cargo", null)
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClienteCargo_CargoId");

                    b.HasOne("ProjetoVendasAPI.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClienteCargo_ClienteId");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Cliente", b =>
                {
                    b.HasOne("ProjetoVendasAPI.Models.Carrinho", "Carrinho")
                        .WithOne("Cliente")
                        .HasForeignKey("ProjetoVendasAPI.Models.Cliente", "CarrinhoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Carrinho");

                    b.Navigation("Carrinho");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Produto", b =>
                {
                    b.HasOne("ProjetoVendasAPI.Models.Carrinho", "Carrinho")
                        .WithMany("Produtos")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Produto_Carrinho");

                    b.Navigation("Carrinho");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.ProdutoImagens", b =>
                {
                    b.HasOne("ProjetoVendasAPI.Models.Produto", "Produto")
                        .WithMany("ProdutoImagens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ProdutoImagens_Produto");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.RelatorioVendas", b =>
                {
                    b.HasOne("ProjetoVendasAPI.Models.VendaFinal", "VendaFinal")
                        .WithOne("RelatorioVendas")
                        .HasForeignKey("ProjetoVendasAPI.Models.RelatorioVendas", "VendaFinalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_RelatorioVendas_VendaFinal");

                    b.Navigation("VendaFinal");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.VendaFinal", b =>
                {
                    b.HasOne("ProjetoVendasAPI.Models.Carrinho", "Carrinho")
                        .WithOne("VendaFinal")
                        .HasForeignKey("ProjetoVendasAPI.Models.VendaFinal", "CarrinhoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_VendaFinal_Carrinho");

                    b.HasOne("ProjetoVendasAPI.Models.Cliente", "Cliente")
                        .WithMany("ComprasConcluidas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_VendaFinal_Cliente");

                    b.HasOne("ProjetoVendasAPI.Models.Pagamento", "Pagamento")
                        .WithOne("VendaFinal")
                        .HasForeignKey("ProjetoVendasAPI.Models.VendaFinal", "PagamentoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_VendaFinal_Pagamento");

                    b.Navigation("Carrinho");

                    b.Navigation("Cliente");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Carrinho", b =>
                {
                    b.Navigation("Cliente")
                        .IsRequired();

                    b.Navigation("Produtos");

                    b.Navigation("VendaFinal");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Cliente", b =>
                {
                    b.Navigation("ComprasConcluidas");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Pagamento", b =>
                {
                    b.Navigation("VendaFinal")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.Produto", b =>
                {
                    b.Navigation("ProdutoImagens");
                });

            modelBuilder.Entity("ProjetoVendasAPI.Models.VendaFinal", b =>
                {
                    b.Navigation("RelatorioVendas")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
