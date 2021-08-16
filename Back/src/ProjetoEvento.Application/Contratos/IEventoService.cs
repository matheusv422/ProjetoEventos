using ProjetoEvento.Domain;
using System.Threading.Tasks;

namespace ProjetoEvento.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento  model);
        Task<bool> DeleteEventos(int eventoId);

        
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes =false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

        
    }
}