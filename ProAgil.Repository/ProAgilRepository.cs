using System.Threading.Tasks;
using ProAgil.Domains;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _Context;

        public ProAgilRepository(ProAgilContext Context)
        {
            _Context = Context;

        }
        public void Add<T>(T entity) where T : class
        {
            _Context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _Context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _Context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
          return  (await _Context.SaveChangesAsync()) > 0;
        }


        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllPalestranteAsyncByName(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetEventosAsyncByID(int EventoID, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetPalestranteAsyncByID(int PalestranteID, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }




    }
}