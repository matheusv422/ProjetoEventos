using ProjetoEvento.Domain;
using System.Threading.Tasks;

using ProjetoEventos.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoEventos.Persistence.Contexto;

namespace ProjetoEvento.Persistence.Contratos
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProjetoEventosContext _context;

        public GeralPersist(ProjetoEventosContext context)
        {
            _context = context;
        }
 


        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);

        }


          public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }


         public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


    
    }
}