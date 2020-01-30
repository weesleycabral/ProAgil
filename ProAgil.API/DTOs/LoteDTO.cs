using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTOs
{
    public class LoteDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoID { get; set; }
        public EventoDTO Evento { get; set; }
    }
}