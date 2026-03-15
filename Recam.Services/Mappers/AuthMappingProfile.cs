using AutoMapper;
using Recam.Models.Entities;
using Recam.Services.DTOs;

namespace Recam.Services.Mappings;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email));
    }
}