using AutoMapper;
using Student.Entity.Services.Models.Dto;
using ST = Student.Entity.Services.Models.Entity;

namespace Student.Business.Services.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ST::Student, StudentDto>().ReverseMap();
        }
    }
}
