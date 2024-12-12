using System.ComponentModel.DataAnnotations;

namespace ProjetoVendasAPI.ViewModels.Contas;

public class UploadImageViewModel
{
    [Required(ErrorMessage = "Imagem inválida")]
    public string Base64Image { get; set; }
}