namespace ProAgil.Domains
{
    public class RedeSocial
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoID { get; set; }
        public Evento Evento { get; set; }
        public int? PalestranteID { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}