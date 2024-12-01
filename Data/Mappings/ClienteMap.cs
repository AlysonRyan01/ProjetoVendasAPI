using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Data.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(x=> x.Id);

        builder.Property(x=> x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
        builder.Property(x=> x.Cpf)
            .IsRequired()
            .HasColumnName("Cpf")
            .HasColumnType("VARCHAR")
            .HasMaxLength(11);

        builder.Property(x=> x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder.Property(x=> x.Fone)
            .IsRequired()
            .HasColumnName("Fone")
            .HasColumnType("VARCHAR")
            .HasMaxLength(12);
            
        builder.Property(x=> x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);

        builder.Property(x=> x.Senha)
            .IsRequired()
            .HasColumnName("Senha")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(x=> x.Endereco)
            .IsRequired()
            .HasColumnName("Endereco")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(280);

        builder
            .HasMany(x => x.ComprasConcluidas)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.ClienteId)
            .HasConstraintName("FK_VendaFinal_Cliente")
            .OnDelete(DeleteBehavior.NoAction);
    }
}