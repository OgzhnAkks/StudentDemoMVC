using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Student.Business.Services.Repositores.Implementation;
using Student.Business.Services.Services.Abstract;
using Student.Business.Services.Utilities;

namespace Student.Business.Services.IoC
{
    public static class DependencyInjectionService
    {
        public static void BusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
