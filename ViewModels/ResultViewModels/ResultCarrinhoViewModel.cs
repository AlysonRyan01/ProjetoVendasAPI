namespace ProjetoVendasAPI.ViewModels.ResultViewModels;

public class ResultCarrinhoViewModel <T>
{
    public T Produtos { get; set; }

    public decimal ValorTotal { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public ResultCarrinhoViewModel(T produtos, decimal valorTotal ,List<string> errors)
    {
        
        Produtos = produtos;
        ValorTotal = valorTotal;
        Errors = errors;
    }

    public ResultCarrinhoViewModel(T produtos, decimal valorTotal)
    {
        
        Produtos = produtos;
        ValorTotal = valorTotal;
    }
    
}