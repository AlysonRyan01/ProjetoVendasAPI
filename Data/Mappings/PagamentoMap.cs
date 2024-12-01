using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Data.Mappings;

public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("Pagamento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x=> x.FormaPagamento)
            .IsRequired()
            .HasColumnName("FormaPagamento")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
            
        builder.Property(x=> x.NomeCliente)
            .IsRequired()
            .HasColumnName("NomeCliente")
            .HasColumnType("VARCHAR")
            .HasMaxLength(280);
            
        builder.Property(x=> x.NumeroCartao)
            .HasColumnName("NumeroCartao")
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);
            
        builder.Property(x=> x.CodigoCartao)
            .HasColumnName("CodigoCartao")
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);
            
        builder.Property(x=> x.CpfCliente)
            .IsRequired()
            .HasColumnName("CpfCliente")
            .HasColumnType("VARCHAR")
            .HasMaxLength(11);
            
        builder
            .HasOne(x=> x.VendaFinal)
            .WithOne(x=> x.Pagamento)
            .HasForeignKey<VendaFinal>(x => x.PagamentoId)
            .HasConstraintName("FK_VendaFinal_Pagamento")
            .OnDelete(DeleteBehavior.NoAction);
    }
}