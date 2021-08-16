using ProjetoEvento.Domain;
using System.Threading.Tasks;

namespace ProjetoEvento.Persistence
{
    public interface IEventoPersist 
    {


        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

        
        
    }
}