using System.ComponentModel.DataAnnotations;

namespace ProjetoVendasAPI.ViewModels;

public class EditorClienteViewModel
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 40 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "O nome deve conter apenas letras e espaços.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [StringLength(13, MinimumLength = 8, ErrorMessage = "O Telefone deve ter entre 8 e 13 caracteres.")]
    [RegularExpression(@"^\d{8,13}$", ErrorMessage = "O telefone deve conter apenas números.")]
    public string Fone { get; set; }
    
    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [StringLength(60, MinimumLength = 8, ErrorMessage = "O Email deve ter entre 8 e 60 caracteres.")]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 15 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
        ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial.")]
    public string Senha { get; set; }
    
    [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "O Endereço deve ter entre 5 e 100 caracteres.")]
    public string Endereco { get; set; }
}