using System.Threading.Tasks;
using ProAgil.Domains;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {

        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //EVENTOS

        Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includeEventos);
        Task<Evento[]> GetAllEventosAsync(bool includeEventos);
        Task<Evento> GetEventosAsyncByID(int EventoID, bool includeEventos);

         Task<Palestrante[]> GetAllPalestranteAsyncByName(string nome, bool includeEventos);
        Task<Palestrante> GetPalestranteAsyncByID(int PalestranteID, bool includeEventos);
    }
}