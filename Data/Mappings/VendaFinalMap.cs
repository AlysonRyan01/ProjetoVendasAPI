using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Data.Mappings;

public class VendaFinalMap : IEntityTypeConfiguration<VendaFinal>
{
    public void Configure(EntityTypeBuilder<VendaFinal> builder)
    {
        builder.ToTable("VendaFinal");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
        builder.Property(x=> x.ValorTotal)
            .IsRequired()
            .HasColumnName("ValorTotal")
            .HasColumnType("DECIMAL(18,2)");

    }
}