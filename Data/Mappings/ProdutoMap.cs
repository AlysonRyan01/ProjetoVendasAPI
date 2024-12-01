using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Data.Mappings;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
        builder.Property(x=> x.Titulo)
            .IsRequired()
            .HasColumnName("Titulo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(280);

        builder.Property(x=> x.TipoProduto)
            .IsRequired()
            .HasColumnName("TipoProduto")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
            
        builder.Property(x=> x.Marca)
            .IsRequired()
            .HasColumnName("Marca")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
            
        builder.Property(x=> x.Modelo)
            .IsRequired()
            .HasColumnName("Modelo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);
            
        builder.Property(x=> x.Serie)
            .IsRequired()
            .HasColumnName("Serie")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(280);
            
        builder.Property(x=> x.Preco)
            .IsRequired()
            .HasColumnName("Preco")
            .HasColumnType("DECIMAL(18,2)");
            
        builder.Property(x=> x.Garantia)
            .IsRequired()
            .HasColumnName("Garantia")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);  

    }
}