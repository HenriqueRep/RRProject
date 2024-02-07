using AutoMapper;
using RRProject.API.Entities;
using RRProject.Models.DTOs;

namespace RRProject.API.Mappings
{
    public class AutoMappingProfilePersistency : Profile
    {
        public AutoMappingProfilePersistency()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();  
            CreateMap<Candidata, CandidataDto>().ReverseMap();
        }

    }
}

