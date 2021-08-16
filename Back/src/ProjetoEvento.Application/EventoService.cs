using ProjetoEvento.Application.Contratos;
using ProjetoEvento.Domain;
using ProjetoEvento.Persistence;
using System;
using System.Threading.Tasks;

namespace ProjetoEvento.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }




        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {

                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {

            try
            {

                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {

                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


      
        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(model.Id, false);

                if (evento == null) return null;

                model.Id = evento.Id;


                _geralPersist.Update<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("Evento para Delete não encontrado!");


                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();



            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
      
    }
}