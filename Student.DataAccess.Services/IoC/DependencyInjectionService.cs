using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.DataAccess.Services.Contexts;
using Student.DataAccess.Services.Repositores.Abstract;
using Student.DataAccess.Services.Repositores.Implementation;

namespace Student.DataAccess.Services.IoC
{
    public static class DependencyInjectionService
    {
        public static void DataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(configuration.GetConnectionString("LocalDbConnection"));
            });

            services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}
