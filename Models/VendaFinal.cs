namespace ProjetoVendasAPI.Models;

public class VendaFinal
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }

    public int CarrinhoId { get; set; }
    public Carrinho Carrinho { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int PagamentoId { get; set; }
    public Pagamento Pagamento { get; set; }

    public int RelatorioVendasId { get; set; }
    public RelatorioVendas RelatorioVendas { get; set; }
}