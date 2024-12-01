using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Data.Mappings;

public class RelatorioVendasMap : IEntityTypeConfiguration<RelatorioVendas>
{
    public void Configure(EntityTypeBuilder<RelatorioVendas> builder)
    {
        builder.ToTable("RelatorioVendas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
        builder.Property(x=> x.ValorTotal)
            .IsRequired()
            .HasColumnName("ValorTotal")
            .HasColumnType("DECIMAL(18,2)");

        builder
            .HasOne(x => x.VendaFinal)
            .WithOne(x => x.RelatorioVendas)
            .HasForeignKey<RelatorioVendas>(x => x.VendaFinalId)
            .HasConstraintName("FK_RelatorioVendas_VendaFinal")
            .OnDelete(DeleteBehavior.NoAction);
    }
}