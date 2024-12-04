using System.ComponentModel.DataAnnotations;

namespace ProjetoVendasAPI.ViewModels;

public class RegisterClienteViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O E-mail é invalido")]
    public string Email { get; set; }
}