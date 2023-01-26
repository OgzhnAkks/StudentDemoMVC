using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.DataAccess.Services.Contexts;
using Student.DataAccess.Services.Repositores.Abstract;
using Student.DataAccess.Services.Repositores.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
