namespace ProjetoVendasAPI.Models;

public class ProdutoImagens
{
    public int Id { get; set; }
    public string ImagemUrl { get; set; }

    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
}