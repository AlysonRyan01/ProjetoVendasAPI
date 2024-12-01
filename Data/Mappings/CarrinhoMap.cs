using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Data.Mappings
{
    public class CarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("Carrinho");

            builder.HasKey(x=> x.Id);

            builder.Property(x=> x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x=> x.ValorTotal)
                .HasColumnName("ValorTotal")
                .HasColumnType("DECIMAL(18,2)")
                .HasDefaultValueSql("0.00");
            
            builder
                .HasOne(x => x.VendaFinal)
                .WithOne(x => x.Carrinho)
                .HasForeignKey<VendaFinal>(x => x.CarrinhoId)
                .HasConstraintName("FK_VendaFinal_Carrinho")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Cliente)
                .WithOne(x => x.Carrinho)
                .HasForeignKey<Cliente>(x => x.CarrinhoId)
                .HasConstraintName("FK_Cliente_Carrinho")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x=> x.Produtos)
                .WithOne(x=> x.Carrinho)
                .HasForeignKey(x => x.CarrinhoId)
                .HasConstraintName("FK_Produto_Carrinho")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}