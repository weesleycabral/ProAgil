using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTOs
{
    public class EventoDTO
    {
        public int ID { get; set; }

        // [Required(ErrorMessage = "Local é obrigatório.")]
        // [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo 3, máximo 100 caracteres.")]
        public string Local { get; set; }
        public string DataEvento { get; set; }

        // [Required(ErrorMessage = "Tema é obrigatório.")]
        public string Tema { get; set; }

        // [Range(2, 120000, ErrorMessage = "Quantidade de pessoas entre 2 e 120.000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }

        // [Phone]
        public string Telefone { get; set; }

        public string Email { get; set; }
        public List<LoteDTO> Lotes { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }
        public List<PalestranteDTO> Palestrante { get; set; }

    }
}