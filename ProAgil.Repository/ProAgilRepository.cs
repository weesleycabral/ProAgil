using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return (await _Context.SaveChangesAsync()) > 0;
        }


        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query

                .Include(pe => pe.PalestranteEvento)
                .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
             IQueryable<Evento> query = _Context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query

                .Include(pe => pe.PalestranteEvento)
                .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento)
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async  Task<Palestrante[]> GetAllPalestranteAsyncByName(string nome, bool includeEventos)
        {
               IQueryable<Palestrante> query = _Context.Palestrantes
            .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query

                .Include(pe => pe.PalestranteEvento)
                .ThenInclude(e => e.Evento);
            }

            query = query.Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventosAsyncByID(int EventoID, bool includePalestrantes)
        {
            IQueryable<Evento> query = _Context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query

                .Include(pe => pe.PalestranteEvento)
                .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento)
                .Where(c => c.ID == EventoID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante> GetPalestranteAsyncByID(int PalestranteID, bool includeEventos = false)
        {
             IQueryable<Palestrante> query = _Context.Palestrantes
            .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query

                .Include(pe => pe.PalestranteEvento)
                .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(c => c.Nome).Where(p => p.ID == PalestranteID);

            return await query.FirstOrDefaultAsync();
        }




    }
}