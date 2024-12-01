using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoVendasAPI.Data.Mappings;

public class ProdutoImagensMap : IEntityTypeConfiguration<ProdutoImagens>
{
    public void Configure(EntityTypeBuilder<ProdutoImagens> builder)
    {
        builder.ToTable("ProdutoImagens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
        builder.Property(x=> x.ImagemUrl)
            .IsRequired()
            .HasColumnName("ImagemUrl")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(280);
            
        builder
            .HasOne(x => x.Produto)
            .WithMany(x => x.ProdutoImagens)
            .HasForeignKey(x => x.ProdutoId)
            .HasConstraintName("FK_ProdutoImagens_Produto")
            .OnDelete(DeleteBehavior.NoAction);
    }
}