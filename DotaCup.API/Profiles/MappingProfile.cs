using AutoMapper;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.ViewModels;

namespace DotaCup.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        CreateMap<Tournament, TournamentViewModel>().ReverseMap();
    }
}
