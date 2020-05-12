

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
        }
    }
}
