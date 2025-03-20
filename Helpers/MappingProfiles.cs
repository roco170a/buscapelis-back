using apiPeliculas.DTOs;
using apiPeliculas.Models;
using AutoMapper;

namespace apiPeliculas.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Mapeo de Película
            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(d => d.Generos, opt => opt.MapFrom(src => 
                    src.PeliculaGeneros.Select(pg => new PeliculaGeneroDTO 
                    { 
                        GeneroId = pg.GeneroId, 
                        NombreGenero = pg.Genero.Nombre 
                    })))
                .ForMember(d => d.Actores, opt => opt.MapFrom(src => 
                    src.PeliculaActores.Select(pa => new PeliculaActorDTO 
                    { 
                        ActorId = pa.ActorId, 
                        NombreActor = pa.Actor.Nombre,
                        Personaje = pa.Personaje
                    })));

            CreateMap<PeliculaDTO, Pelicula>();

            // Mapeo de Género
            CreateMap<Genero, GeneroDTO>().ReverseMap();

            // Mapeo de Actor
            CreateMap<Actor, ActorDTO>().ReverseMap();

            // Mapeo de Usuario
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}