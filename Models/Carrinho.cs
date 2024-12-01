namespace ProjetoVendasAPI.Models;

public class Carrinho
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
        
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int? VendaFinalId { get; set; }
    public VendaFinal? VendaFinal { get; set; }

    public IList<Produto> Produtos { get; set; }

    public Carrinho()
    {
        Produtos = new List<Produto>();
        ValorTotal = 0.00m;
    }
}