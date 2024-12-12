using System.ComponentModel.DataAnnotations;

namespace ProjetoVendasAPI.ViewModels.Contas;

public class LoginClienteViewModel
{
    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [StringLength(60, MinimumLength = 8, ErrorMessage = "O Email deve ter entre 8 e 60 caracteres.")]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 15 caracteres.")]
    public string Senha { get; set; }
}