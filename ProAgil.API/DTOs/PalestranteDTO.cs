using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTOs
{
    public class PalestranteDTO
    {
        public int ID { get; set; }

        // [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemURL { get; set; }

        // [Phone]
        public int Telefone { get; set; }

        // [EmailAddress]
        public string Email { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }
        public List<EventoDTO> Eventos { get; set; }
    }
}