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

        Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventosAsyncByID(int EventoID, bool includePalestrantes);

         Task<Evento[]> GetAllPalestranteAsyncByName(bool includePalestrantes);
        Task<Evento> GetPalestranteAsyncByID(int PalestranteID, bool includePalestrantes);
    }
}