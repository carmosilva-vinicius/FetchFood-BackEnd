using System.ComponentModel.DataAnnotations;

namespace FetchFood.UseCases.DTOs
{
    public class CreateItemDto
    { 
        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Digite entre 2 e 50 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Digite entre 2 e 200 caracteres")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A imagem é obrigatória", AllowEmptyStrings = false)]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "O campo Preço é obrigatório", AllowEmptyStrings = false)]
        public float Price { get; set; }
    }
}
