

using AutoMapper;
using RecruitmentPortalApp.Models;

namespace RecruitmentPortalApp.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, UserModel>()
             .ReverseMap();
            CreateMap<JobDto, JobsModel>()
            .ReverseMap();
            CreateMap<StageDto, StagesModel>()
           .ReverseMap();
            CreateMap<JobApplicantsDto, JobsModel>()
            .ReverseMap();
            CreateMap<ApplicationsDto, ApplicationsModel>()
           .ReverseMap();
        }
    }
}
