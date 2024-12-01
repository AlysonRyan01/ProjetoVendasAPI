namespace ProjetoVendasAPI.Models;

public class Pagamento
{
    public int Id { get; set; }
    public string FormaPagamento { get; set; }
    public string NomeCliente { get; set; }
    public string? NumeroCartao { get; set; }
    public string? CodigoCartao { get; set; }
    public string CpfCliente { get; set; }

    public int VendaFinalId { get; set; }
    public VendaFinal VendaFinal { get; set; }
}