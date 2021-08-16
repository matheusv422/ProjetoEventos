using ProjetoEvento.Domain;
using System.Threading.Tasks;

using ProjetoEventos.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoEventos.Persistence.Contexto;

namespace ProjetoEvento.Persistence.Contratos
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProjetoEventosContext _context;

        public EventoPersist(ProjetoEventosContext context)
        {
            _context = context;
        }
 



        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {

            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                .Include(e => e.RedesSociais);
            query = query.AsNoTracking().OrderBy(e => e.Id);

            if (includePalestrantes)
            {

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            return await query.ToArrayAsync();

        }


        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
              IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                .Include(e => e.RedesSociais);
            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            if (includePalestrantes)
            {

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }


        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.Include(p => p.Lotes)
                .Include(p => p.RedesSociais);
            query = query.AsNoTracking().OrderBy(p => p.Id)
            .Where(p => p.Id == eventoId);

            if (includePalestrantes)
            {

                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            return await query.FirstOrDefaultAsync();
        }


       

    
    }
}