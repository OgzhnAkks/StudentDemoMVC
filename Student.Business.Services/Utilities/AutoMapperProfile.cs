using AutoMapper;
using Student.Entity.Services.Models.Dto;
using ST = Student.Entity.Services.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
