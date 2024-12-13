namespace ProjetoVendasAPI.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Imagem { get; set; }
    public string Cpf { get; set; }
    public string Fone { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Endereco { get; set; }

    public List<Cargo> Cargos { get; set; }
    
    public int CarrinhoId { get; set; }
    public Carrinho Carrinho { get; set; }

    public IList<VendaFinal> ComprasConcluidas { get; set; }

    public Cliente()
    {
        ComprasConcluidas = new List<VendaFinal>();
    }
}