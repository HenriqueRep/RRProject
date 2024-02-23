using AutoMapper;
using RRProject.API.Entities;
using RRProject.Models.DTOs;

namespace RRProject.API.Mappings
{
    public class AutoMappingProfilePersistency : Profile
    {
        public AutoMappingProfilePersistency()
        {
            CreateMap<UsuarioCadastroRequest, UsuarioCadastroRequestDto>().ReverseMap();
            CreateMap<UsuarioCadastroResponse, UsuarioCadastroResponseDto>().ReverseMap();
            CreateMap<UsuarioLoginRequest, UsuarioLoginRequestDto>().ReverseMap();
            CreateMap<UsuarioLoginResponse, UsuarioLoginResponseDto>().ReverseMap();
            CreateMap<UsuarioLogoutResponse, UsuarioLogoutResponseDto>().ReverseMap();
            CreateMap<Candidata, CandidataDto>().ReverseMap();
            CreateMap<AvaliacaoUsuario, AvaliacaoUsuarioDto>().ReverseMap();
        }
    }
}

