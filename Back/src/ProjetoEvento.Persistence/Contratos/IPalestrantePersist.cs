using ProjetoEvento.Domain;
using System.Threading.Tasks;

namespace ProjetoEvento.Persistence
{
    public interface IPalestrantePersist
    {

        
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);

        
    }
}