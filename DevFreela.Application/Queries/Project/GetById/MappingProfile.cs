using AutoMapper;
using DevFreela.Application.Models;

namespace DevFreela.Application.Queries.Project.GetById;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Entities.Project, ProjectDetailsViewModel>()
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.FullName))
            .ForMember(dest => dest.FreelancerName, opt => opt.MapFrom(src => src.FreeLancer.FullName))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<Core.Entities.ProjectComment, ProjectDetailsViewModel.CommentsResponse>();
    }
}
