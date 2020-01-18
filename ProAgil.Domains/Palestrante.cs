using System.Collections.Generic;

namespace ProAgil.Domains
{
    public class Palestrante
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemURL { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestranteEvento { get; set; }
    }
}