namespace ProjetoVendasAPI.Models;

public class Produto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string TipoProduto { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public decimal Preco { get; set; }
    public string Garantia { get; set; }

    public int? CarrinhoId { get; set; }
    public Carrinho? Carrinho { get; set; }

    public IList<ProdutoImagens> ProdutoImagens { get; set; }

    public Produto()
    {
        ProdutoImagens = new List<ProdutoImagens>();
    }
}