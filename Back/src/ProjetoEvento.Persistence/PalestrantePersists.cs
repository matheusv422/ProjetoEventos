using ProjetoEvento.Domain;
using System.Threading.Tasks;

using ProjetoEventos.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoEventos.Persistence.Contexto;

namespace ProjetoEvento.Persistence.Contratos
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProjetoEventosContext _context;

        
        public PalestrantePersist(ProjetoEventosContext context)
        {
            _context = context;
        }
 



        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);
           
          
            if (includeEventos)
            {

                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

              query = query.AsNoTracking().OrderBy(p => p.Id);


            return await query.ToArrayAsync();
        }


        public async  Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
          IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);
           
          
            if (includeEventos)
            {

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

               query = query.AsNoTracking().OrderBy(p => p.Id).Where(p=>p.Nome.ToLower().Contains(nome.ToLower()));


            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);


            if (includeEventos)
            {

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == palestranteId);


            return await query.FirstOrDefaultAsync();
        }

    
    }
}