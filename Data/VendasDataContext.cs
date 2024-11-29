using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data.Mappings;

namespace ProjetoVendasAPI.Data;

public class VendasDataContext : DbContext
{
    public DbSet<CarrinhoMap> Carrinhos { get; set; }
    public DbSet<ClienteMap> Clientes { get; set; }
    public DbSet<PagamentoMap> Pagamentos { get; set; }
    public DbSet<ProdutoImagensMap> ProdutoImagens { get; set; }
    public DbSet<ProdutoMap> Produtos { get; set; }
    public DbSet<RelatorioVendasMap> RelatoriosVendas { get; set; }
    public DbSet<VendaFinalMap> VendasFinais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarrinhoMap());
        
    }
}