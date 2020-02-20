using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTOs
{
    public class RedeSocialDTO
    {
        public int Id { get; set; }

        // [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }

        // [Required(ErrorMessage = "{0} é obrigatório.")]
        public string URL { get; set; }
    }
}