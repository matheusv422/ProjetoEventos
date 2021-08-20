using AutoMapper;
using ProjetoEvento.Application.Dtos;
using ProjetoEvento.Domain;

namespace ProjetoEvento.API.Helpers

{
    public class ProEventosProfile: Profile
    {
        public ProEventosProfile()
        {   
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            
        }
    }
}