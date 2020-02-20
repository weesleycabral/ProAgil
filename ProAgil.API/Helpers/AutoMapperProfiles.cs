using ProAgil.API.DTOs;
using ProAgil.Domains;
using AutoMapper;
using System.Linq;
using ProAgil.Domains.Identity;

namespace ProAgil.API.Helpers
{
public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles()
       {
           CreateMap<Evento, EventoDTO>().ForMember(dest => dest.Palestrante, opt => {
               opt.MapFrom(src => src.PalestranteEvento.Select(x => x.Palestrante).ToList());
           }).ReverseMap();
           CreateMap<Palestrante, PalestranteDTO>().ForMember(dest => dest.Eventos, opt =>{
               opt.MapFrom(src => src.PalestranteEvento.Select(x => x.Evento).ToList());
           }).ReverseMap();
           CreateMap<Lote, LoteDTO>().ReverseMap();
           CreateMap<RedeSocial, RedeSocialDTO>().ReverseMap();
           CreateMap<User, UserDTO>().ReverseMap();
           CreateMap<User, UserLoginDTO>().ReverseMap();

       }
    }
}