namespace ProjetoVendasAPI.Models;

public class RelatorioVendas
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }

    public int VendaFinalId { get; set; }
    public VendaFinal VendaFinal { get; set; }
}