using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEvento.Application.Contratos;
using ProjetoEvento.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoEvento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }
        

        [HttpGet]

        public async Task<IActionResult> Get(){
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);

                if (eventos == null) return NoContent();

                    var eventoRetorno = new List<EventoDto>();

                    foreach (var evento in eventos)
                    {
                        
                    }
                
                return Ok(eventos);
            }

            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]

     public async Task<IActionResult> GetById(int id){
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);

                if (evento == null) return NoContent();

                return Ok(evento);
            }

            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }

            
        }

        [HttpGet("{tema}/tema")]

     public async Task<IActionResult> GetById(string tema){
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema,true);

                if (eventos == null) return NoContent();

                return Ok(eventos);
            }

            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }


        [HttpPost]

        public async Task<IActionResult> Post(EventoDto model){

             try
            {
               var eventos = await _eventoService.AddEventos(model);

              if (eventos == null) return BadRequest("Erro ao tentar adicionar eventos.");

              return Ok(eventos);
            }

            catch (Exception ex)
            
            {

                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }

        }

        [HttpPut ("{id}")]

        public async Task<IActionResult> Put(int id,EventoDto model){

             try
            {
               var eventos = await _eventoService.UpdateEventos(id,model);

              if (eventos == null) return BadRequest("Erro ao tentar atualizar eventos.");

              return Ok(eventos);
            }

            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
            }


        [HttpDelete ("{id}")]

        public async Task<IActionResult> Delete(int id){

             try
            {
               return await _eventoService.DeleteEventos(id) ? 
                         Ok("Deletado") :
                        BadRequest("Evento não deletado");
            }

            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }





     
        
    }
}
}